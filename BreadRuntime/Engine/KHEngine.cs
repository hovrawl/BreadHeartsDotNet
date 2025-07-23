using System.Diagnostics;
using BreadFramework.Common;
using BreadFramework.Enums;
using BreadFramework.Flags;
using BreadFramework.Game;
using BreadFramework.Worlds;
using BreadRuntime.Enums;
using BreadRuntime.Tools;
using PluginBase;
using System.Collections.ObjectModel;
using System.ComponentModel.Composition;
using System.ComponentModel.Composition.Hosting;
using BreadFramework.Patches;
using BreadRuntime.Tools.Logging;
using PluginBase.Settings;

namespace BreadRuntime.Engine;

public sealed class KHEngine: EngineApi.EngineApi
{
    #region InstanceLocking
    
    private readonly object ThreadLock = new object();

    private readonly object SyncRoot = new object();
    
    private readonly EngineLogger _log;
    public event EventHandler<LogEventArgs> OnLogMessage;

    public KHEngine()
    {
        _log = new EngineLogger();
        _log.OnNewLog += (sender, args) => OnLogMessage?.Invoke(this, args);
    }

    #endregion

    #region Fields

    private KHGame _selectedGame = KHGame.KHFM;
    
    public KHGame SelectedGame => _selectedGame;

    private DirectoryInfo _modsDirectoryInfo;
    private DirectoryInfo _patchesDirectoryInfo;
    
    private GameDirectoryInfo _gameDirectoryInfo;

    public GameDirectoryInfo GameDirectoryInfo
    {
        get => _gameDirectoryInfo;
        private set => _gameDirectoryInfo = value;
    }
    
    public DirectoryInfo ModsDirectoryInfo
    {
        get => _modsDirectoryInfo;
        private set => _modsDirectoryInfo = value;
    }
    
    public DirectoryInfo PatchesDirectoryInfo
    {
        get => _patchesDirectoryInfo;
        private set => _patchesDirectoryInfo = value;
    }
    
    private FileSystemWatcher _modsFileWatcher;
    
    
    public string GameDataFolder
    {
        get
        {
            if (GameDirectoryInfo.Platform == GamePlatform.Steam)
            {
                return Path.Combine(GameDirectoryInfo.Path, "Image\\dt\\");
            }
            
            return Path.Combine(GameDirectoryInfo.Path, "Image\\en\\");
        }
    }
    
    [ImportMany(typeof(BasePlugin))]
    private ObservableCollection<BasePlugin> _modules = new ();
    
    public ObservableCollection<BasePlugin> Plugins => _modules;
    
    
    public ObservableCollection<PluginState> PluginStates = new();

    
    private ObservableCollection<OpenKhPatch> _patches = new ();
    
    public ObservableCollection<OpenKhPatch> Patches => _patches;
    
    public List<BasePlugin> LoadedPlugins
    {
        get
        {
            var enabledPlugins = new List<BasePlugin>();
            foreach (var pluginState in PluginStates.Where(i => i.Enabled))
            {
                var plugin = Plugins.FirstOrDefault(i => i.Id == pluginState.Id);
                if (plugin == null) continue;
                enabledPlugins.Add(plugin);
            }

            return enabledPlugins;
        }
    }

    private BreadHeartsMemoryManager Memory;
    
    public ProcessModule MainModule => Memory.MainModule;


    public WorldInfo CurrentWorld { get; set; }
    
    private List<WorldInfo> Worlds = new ();

    private Timer LowPriorityTimer;
    private Timer MediumPriorityTimer;
    private Timer HighPriorityTimer;

    private List<BasePlugin> LowPriorityModules = new ();
    private List<BasePlugin> MediumPriorityModules = new ();
    private List<BasePlugin> HighPriorityModules = new ();

    public GameFlagsRepo GameFlagsRepo { get; } = new();

    private static ReaderWriterLockSlim _readWriteLock = new ();

    private static bool _attached = false;

    private bool _running = false;
    public bool IsRunning => _running;
    
    public static bool Attached => _attached;


    public List<string> Errors = new List<string>();
    #endregion

    #region Engine

    public void Initialise()
    {
        Memory = new BreadHeartsMemoryManager();
    }

    public void Start()
    {
        // Attempt to attach
        AttachToProcess();
        
        // Failed to attach, dont start mods
        if (!Attached) return;
        
        // Setup World List
        SetupWorldList();
        
        // Initialise Modules
        InitialiseModules();
        
        // Setup timers
        SetupTimers();

        _running = true;
    }
    
    public void Stop()
    {
        // Stop timers and clear modules
        LowPriorityTimer?.Dispose();
        LowPriorityModules.Clear();
        MediumPriorityTimer?.Dispose();
        MediumPriorityModules.Clear();
        HighPriorityTimer?.Dispose();
        HighPriorityModules.Clear();

        _running = false;
    }

    /// <summary>
    ///  Change the game to run mods on, will stop any running mods when changing
    /// </summary>
    /// <param name="newGame"></param>
    public void ChangeGame(KHGame newGame)
    {
        // Stop engine if already running
        if (IsRunning) Stop();
        
        // Dont set game if incoming val is null
        if (newGame == null) return;

        // update the selected game
        _selectedGame = newGame;
    }

    #endregion

    #region Process

    public void Attach()
    {
        AttachToProcess();
    }

    private void AttachToProcess()
    {
        // Reset memory
        _attached = false;

        var openedProc = false;

        var processId = SelectedGame.ProcessId;
        var pid = Memory.GetProcIdFromName(processId);

        if (pid > 0) openedProc = Memory.OpenProcess(pid);

        if (openedProc)
        {
            _attached = true;
        }
    }

    #endregion

    #region Timers

    private void SetupTimers()
    {
        var initialisedModules = _modules.Where(i => i.Initialised);
        
        // Low Priority
        LowPriorityTimer?.Dispose();
        LowPriorityModules.Clear();
        LowPriorityModules.AddRange(initialisedModules.Where(i => i.Priority == ModulePriority.Low && i.Game == SelectedGame));
        LowPriorityTimer = new Timer(LowTimerFrame, LowPriorityModules,1000, (int)ModulePriority.Low);
        
        // Medium Priority
        MediumPriorityTimer?.Dispose();
        MediumPriorityModules.Clear();
        MediumPriorityModules.AddRange(initialisedModules.Where(i => i.Priority == ModulePriority.Medium && i.Game == SelectedGame));
        MediumPriorityTimer = new Timer(MediumTimerFrame, MediumPriorityModules,500, (int)ModulePriority.Medium);
        
        // High Priority
        HighPriorityTimer?.Dispose();
        HighPriorityModules.Clear();
        HighPriorityModules.AddRange(initialisedModules.Where(i => i.Priority == ModulePriority.High && i.Game == SelectedGame));
        HighPriorityTimer = new Timer(HighTimerFrame, HighPriorityModules,250, (int)ModulePriority.High);
    }

    
    private void LowTimerFrame(Object stateInfo)
    {
        // Update Current World
        CurrentWorld = GetCurrentWorld();
        
        if (stateInfo is not List<BasePlugin> modules) return;
        
        foreach (var module in modules)
        {
            if(!module.Initialised) continue;
            var moduleState = PluginStates.FirstOrDefault(i => i.Id == module.Id);
            if (moduleState == null) continue;
            if (!moduleState.Enabled) continue;
            
            module.OnFrame(moduleState);
        }
    }
    
    private void MediumTimerFrame(Object stateInfo)
    {
        // Update Current World
        CurrentWorld = GetCurrentWorld();

        if (stateInfo is not List<BasePlugin> modules) return;
        
        foreach (var module in modules)
        {
            if(!module.Initialised) continue;
            var moduleState = PluginStates.FirstOrDefault(i => i.Id == module.Id);
            if (moduleState == null) continue;
            if (!moduleState.Enabled) continue;
            
            module.OnFrame(moduleState);
        }
    }
    
    private void HighTimerFrame(Object stateInfo)
    {
        // Update Current World
        CurrentWorld = GetCurrentWorld();
        
        if (stateInfo is not List<BasePlugin> modules) return;
        
        foreach (var module in modules)
        {
            if(!module.Initialised) continue;
            var moduleState = PluginStates.FirstOrDefault(i => i.Id == module.Id);
            if (moduleState == null) continue;
            if (!moduleState.Enabled) continue;
            
            module.OnFrame(moduleState);
        }
    }

    #endregion
    
    #region Modules
    private void InitialiseModules()
    {
        // Iterate over modules, attempt to activate if enabled
        foreach (var module in LoadedPlugins)
        {
            var executed = module.Initialise(this);
            if (!executed)
            {
                // Log the individual module that didnt start
            }
        }
    }

    public ObservableCollection<BasePlugin> GetModules()
    {
        return _modules;
    }
    
    public BasePlugin GetModuleById(Guid moduleId)
    {
        return _modules.FirstOrDefault(i => i.Id.Equals(moduleId));
    }

    public BasePlugin GetModuleByName(string moduleName)
    {
        return _modules.FirstOrDefault(i => i.Name.Equals(moduleName, StringComparison.CurrentCultureIgnoreCase));
    }

    public PluginSettings GetModuleDefaultSettings(string moduleName)
    {
        var module = _modules.FirstOrDefault(i => i.Name.Equals(moduleName, StringComparison.CurrentCultureIgnoreCase));
        
        if (module == null) return new PluginSettings();

        return module.GetSettings();
    }

    public void AddModule(BasePlugin module)
    {
        RemoveModule(module);
        _modules.Add(module);
    }
    
    public void AddPatch(OpenKhPatch patch)
    {
        RemovePatch(patch);
        Patches.Add(patch);
    }

    public void RemoveModule(BasePlugin module)
    {
        RemoveModule(module.Id);
    }
    
    public void RemovePatch(OpenKhPatch patch)
    {
        var matchingModules = _patches.Where(i => i.Name.Equals(patch.Name)).ToList();
        foreach (var module in matchingModules)
        {
            _patches.Remove(module);
        }    
    }

    public void RemoveModule(Guid moduleId)
    {
        var matchingModules = _modules.Where(i => i.Id.Equals(moduleId)).ToList();
        foreach (var module in matchingModules)
        {
            _modules.Remove(module);
        }
    }

    public void ClearPatches()
    {
        _patches.Clear();
    }
    
    #endregion

    #region Worlds

    private void SetupWorldList()
    {
        Worlds = BreadFramework.Worlds.Worlds.GetWorldList();
    }
    
    // TODO - this should be game specific 
    private int WorldIdAddress = GameFlags.WorldId;
    
    private WorldInfo GetCurrentWorld()
    {
        // when reading, we check cached value so we dont read too often
        var worldId = ReadInt(WorldIdAddress);
        var world = Worlds.FirstOrDefault(i => i.WorldId == worldId);
        if (world == null)
        {
            world = new WorldInfo
            {
                World = WorldList.DiveToHeart,
                Name = "Invalid",
                WorldId = -1,
            };
        }
        return world;
    }

    #endregion

    #region FileSystem

    public FileStream OpenLocalFile(string fileName, FileMode openMode)
    {
        if (!File.Exists(fileName))
        {
            return null;
        }
        var file = File.Open(fileName, openMode);

        return file;
    }
    
    public string ReadFileText(string path)
    {
        var text = "";
        if (!File.Exists(path))
        {
            return text;
        }
        
        _readWriteLock.EnterReadLock();
        try
        {
            text = File.ReadAllText(path);
        }
        finally
        {
            _readWriteLock.ExitWriteLock();
        }

        return text;
    }

    public void WriteTextToFile(string path, string text)
    {
        _readWriteLock.EnterWriteLock();
        try
        {
            using var sw = File.AppendText(path);
            sw.WriteLine(text);
            sw.Close();
        }
        finally
        {
            _readWriteLock.ExitWriteLock();
        }
    }

    #endregion

    #region Write Methods

    public void WriteInt(long address, int value)
    {
        var processName = SelectedGame.ProcessName;
        Memory.WriteMemory($"{processName}+{address:X8}", value);
    }

    public void WriteShort(long address, int value)
    {
        var processName = SelectedGame.ProcessName;
        ushort writeVal = 0;
        try
        {
            writeVal = (ushort)value;
        }
        catch
        {
            /* */
        }

        Memory.WriteMemory($"{processName}+{address:X8}", writeVal);
    }

    public void WriteFloat(long address, float value)
    {
        var processName = SelectedGame.ProcessName;
        Memory.WriteMemory($"{processName}+{address:X8}", value);
    }

    public void WriteString(long address, string value)
    {
        var processName = SelectedGame.ProcessName;
        Memory.WriteMemory($"{processName}+{address:X8}", value);
    }

    public void WriteByte(long address, byte value)
    {
        var processName = SelectedGame.ProcessName;
        Memory.WriteMemory($"{processName}+{address:X8}", value);
    }

    public void Write2Bytes(long address, byte value)
    {
        var processName = SelectedGame.ProcessName;
        Memory.WriteBytes($"{processName}+{address:X8}", new byte[] { value, 0 });
    }

    public void WriteBytes(long address, List<int> value)
    {
        var processName = SelectedGame.ProcessName;
        var bytes = value.Select(v => (byte)v).ToArray();
        Memory.WriteBytes($"{processName}+{address:X8}", bytes);
    }

    public void WriteBytesAbsolute(long address, List<int> value)
    {
        var bytes = value.Select(v => (byte)v).ToArray();
        Memory.WriteBytes($"{address:X8}", bytes);
    }

    public void WriteDouble(long address, double value)
    {
        var processName = SelectedGame.ProcessName;
        Memory.WriteMemory($"{processName}+{address:X8}", value);
    }

    public void WriteLong(long address, long value)
    {
        var processName = SelectedGame.ProcessName;
        Memory.WriteMemory($"{processName}+{address:X8}", value);
    }

    public void WriteLong(long address, ulong value)
    {
        var processName = SelectedGame.ProcessName;
        Memory.WriteMemory($"{processName}+{address:X8}", (long)value);
    }

    #endregion

    #region Read Methods

    public int ReadInt(long address)
    {
        var processName = SelectedGame.ProcessName;
        return Memory.ReadInt($"{processName}+{address:X8}");
    }

    public uint ReadUInt(long address)
    {
        var processName = SelectedGame.ProcessName;
        return Memory.ReadUInt($"{processName}+{address:X8}");
    }

    public int ReadIntRev(long address)
    {
        var processName = SelectedGame.ProcessName;
        return Memory.ReadInt($"{processName}+-{address:X8}");
    }

    public uint ReadUIntAbsolute(long address)
    {
        return Memory.ReadUInt($"{address:X8}");
    }

    public float ReadFloat(long address)
    {
        var processName = SelectedGame.ProcessName;
        return Memory.ReadFloat($"{processName}+{address:X8}");
    }

    public string ReadString(long address)
    {
        var processName = SelectedGame.ProcessName;
        return Memory.ReadString($"{processName}+{address:X8}");
    }

    public string ReadString(long address, int length)
    {
        var processName = SelectedGame.ProcessName;
        return Memory.ReadString($"{processName}+{address:X8}", length);
    }

    public short ReadShort(long address)
    {
        var processName = SelectedGame.ProcessName;
        var result = Memory.ReadInt($"{processName}+{address:X8}");
        try
        {
            return (short)result;
        }
        catch
        {
            return 0;
        }
    }

    public short ReadShortAbsolute(long address)
    {
        var result = Memory.ReadInt($"{address:X8}");
        try
        {
            return (short)result;
        }
        catch
        {
            return 0;
        }
    }

    public byte ReadByte(long address)
    {
        var processName = SelectedGame.ProcessName;
        return Memory.ReadByte($"{processName}+{address:X8}");
    }

    public byte[] ReadBytes(long address, int length)
    {
        var processName = SelectedGame.ProcessName;
        return Memory.ReadBytes($"{processName}+{address:X8}", length);
    }

    public byte Read2Byte(long address)
    {
        var processName = SelectedGame.ProcessName;
        var bytes = Memory.ReadBytes($"{processName}+{address:X8}", 2);
        return bytes[0];
    }

    public long ReadLong(long address)
    {
        var processName = SelectedGame.ProcessName;
        return Memory.ReadLong($"{processName}+{address:X8}");
    }

    public long ReadLongAbsolute(long address)
    {
        return Memory.ReadLong($"{address:X8}");
    }

    public double ReadDouble(long address)
    {
        var processName = SelectedGame.ProcessName;
        return Memory.ReadDouble($"{processName}+{address:X8}");
    }

    #endregion

    #region Abilities

    //private GameFlags AbilityFlags = new();

    #endregion

    #region File Patching


    public void PatchFiles(List<string> patchFile, KHGame patchType, PatchBackgroundWorker bgWorker, bool backupPKG = true,
        bool extractPatch = false)
    {
        try
        {
            FilePatcher.ApplyPatch(patchFile, patchType, GameDataFolder,  bgWorker, backupPKG, extractPatch);
        }
        catch (Exception ex)
        {
            var errMsg = ex.Message;
            Errors.Add(errMsg);
        }
    }

    #endregion

    #region UI Utilities
    public void SetGameDirectory(GameDirectoryInfo gameDirectoryInfo)
    {
        _gameDirectoryInfo = gameDirectoryInfo;
    }
    
    public void SetModsDirectory(DirectoryInfo directoryInfo, Action<Action> uiDispatchAction)
    {
        if (directoryInfo == null) return;
        
        ModsDirectoryInfo = directoryInfo;
        if (!ModsDirectoryInfo.Exists) return;
        
        _modsFileWatcher?.Dispose();
        _modsFileWatcher = new FileSystemWatcher(ModsDirectoryInfo.FullName);
        
        _modsFileWatcher.EnableRaisingEvents = true;
        
        _modsFileWatcher.Created += (sender, e) =>
        {
            modsFileWatcherOnCreated(sender, e, uiDispatchAction);
        };
        _modsFileWatcher.Deleted += (sender, e) =>
        {
            modsFileWatcherOnDelete(sender, e, uiDispatchAction);
        };
        //_modsFileWatcher.Created += (sender, args) => uiCallback?.Invoke();
        
        // Clear loaded mods
        //ModsCompositionContainer.ReleaseExports();
        
        ModsDirectoryCatalog?.Dispose();
        ModsAggregateCatalog?.Dispose();
        ModsCompositionContainer?.Dispose();
        
        ModsDirectoryCatalog = new DirectoryCatalog(ModsDirectoryInfo.FullName);
        ModsAggregateCatalog = new AggregateCatalog(ModsDirectoryCatalog);
        
        ModsCompositionContainer = new CompositionContainer(ModsAggregateCatalog);
        ModsCompositionContainer.SatisfyImportsOnce(this);

        // // Initial process of mods
        // ProcessModsInDirectory(ModsDirectoryInfo);
        uiDispatchAction.Invoke(RefreshMods);
    }
    
    public void SetPatchesDirectory(DirectoryInfo directoryInfo)
    {
        if (directoryInfo == null) return;

        PatchesDirectoryInfo = directoryInfo;
    }
    
    private static DirectoryCatalog ModsDirectoryCatalog;
    private static AggregateCatalog ModsAggregateCatalog;
    private static CompositionContainer ModsCompositionContainer;
    
    private void modsFileWatcherOnCreated(object sender, FileSystemEventArgs e, Action<Action> uiDispatchAction)
    {
        // Interrogate the file that changed, if it matches a mod file we will load it
        if (string.IsNullOrEmpty(e.Name)) return;

        uiDispatchAction.Invoke(RefreshMods);
    }
    
    private void modsFileWatcherOnDelete(object sender, FileSystemEventArgs e, Action<Action> uiDispatchAction)
    {
        // Interrogate the file that changed, if it matches a mod file we will load it
        if (string.IsNullOrEmpty(e.Name)) return;

        uiDispatchAction.Invoke(RefreshMods);
    }

    private void RefreshMods()
    {
        ModsDirectoryCatalog?.Refresh();
        ModsCompositionContainer?.SatisfyImportsOnce(this);

        var loadedPlugins = Plugins.ToList();
        // Remove states for plugins that are no longer loaded
        var existingStates = PluginStates.ToList();
        foreach (var pluginState in existingStates)
        {
            var loadedPlugin = loadedPlugins.FirstOrDefault(p => p.Id == pluginState.Id);
            if (loadedPlugin == null) continue;
            
            PluginStates.Remove(pluginState);
        }
        
        existingStates = PluginStates.ToList();
        foreach (var loadedPlugin in loadedPlugins)
        {
            var existingState = existingStates.FirstOrDefault(p => p.Id == loadedPlugin.Id);
            if (existingState != null) continue;
            
            var pluginState = new PluginState(loadedPlugin);
            ApplySettingsToPluginState(pluginState);
            PluginStates.Add(pluginState);
        }
        
    }

    private void ApplySettingsToPluginState(PluginState pluginState)
    {
        foreach (var setting in pluginState.PluginSettings)
        {
            var loadedValue = "";
            pluginState.ApplySettingValue(setting.Name, loadedValue);
        }
    }

    #endregion

    #region Logging

    public void LogDebug(string pluginName, string message) => _log.Log(pluginName, LogLevel.Debug, message);
    public void LogInfo(string pluginName, string message) => _log.Log(pluginName, LogLevel.Info, message);
    public void LogWarning(string pluginName, string message) => _log.Log(pluginName, LogLevel.Warning, message);
    public void LogError(string pluginName, string message) => _log.Log(pluginName, LogLevel.Error, message);

    public IReadOnlyList<LogEntry> GetPluginLogs(string pluginName) => _log.GetPluginLogs(pluginName);
    public IReadOnlyList<LogEntry> GetAllLogs() => _log.GetAllLogs();


    #endregion
}