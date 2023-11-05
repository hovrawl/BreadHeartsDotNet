using System.Reflection;
using System.Text;
using BreadFramework.Common;
using BreadFramework.Enums;
using BreadFramework.Flags;
using BreadFramework.Game;
using BreadFramework.Worlds;
using BreadRuntime.Enums;
using BreadRuntime.Modules;
using BreadRuntime.Settings;
using Memory;

namespace BreadRuntime.Engine;

public sealed class KHEngine
{
    #region InstanceLocking
    private static volatile KHEngine _instance = new KHEngine();
    private static readonly object ThreadLock = new object();

    private static readonly object SyncRoot = new object();
    
    public static KHEngine Instance => _instance;

    #endregion

    #region Fields

    private KHGame _selectedGame = KHGame.KHFM;
    
    public KHGame SelectedGame => _selectedGame;
    

    private static List<BaseModule> Modules = new ();
    public Mem Memory;

    public WorldInfo CurrentWorld;
    private List<WorldInfo> Worlds = new ();

    private Timer LowPriorityTimer;
    private Timer MediumPriorityTimer;
    private Timer HighPriorityTimer;

    private List<BaseModule> LowPriorityModules = new ();
    private List<BaseModule> MediumPriorityModules = new ();
    private List<BaseModule> HighPriorityModules = new ();

    public GameFlagsRepo GameFlagsRepo = new();
    
    private static ReaderWriterLockSlim _readWriteLock = new ();

    private static bool _attached = false;

    private bool _running = false;
    public bool IsRunning => _running;
    
    public static bool Attached => _attached;

    #endregion

    #region Engine

    public void Initialise()
    {
        Memory = new Mem();
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

        if (openedProc) _attached = true;
    }

    #endregion

    #region Timers

    private void SetupTimers()
    {
        var initialisedModules = Modules.Where(i => i.Initialised);
        
        // Low Priority
        LowPriorityTimer?.Dispose();
        LowPriorityModules.Clear();
        LowPriorityModules.AddRange(initialisedModules.Where(i => i.Priority == ModulePriority.Low && i.Game == SelectedGame));
        LowPriorityTimer = new Timer(LowTimerFrame, LowPriorityModules,1000, (int)ModulePriority.Low);
        
        // Medium Priority
        MediumPriorityTimer?.Dispose();
        MediumPriorityModules.Clear();
        MediumPriorityModules.AddRange(initialisedModules.Where(i => i.Priority == ModulePriority.Medium && i.Game == SelectedGame));
        MediumPriorityTimer = new Timer(MediumTimerFrame, MediumPriorityModules,1000, (int)ModulePriority.Medium);
        
        // High Priority
        HighPriorityTimer?.Dispose();
        HighPriorityModules.Clear();
        HighPriorityModules.AddRange(initialisedModules.Where(i => i.Priority == ModulePriority.High && i.Game == SelectedGame));
        HighPriorityTimer = new Timer(HighTimerFrame, HighPriorityModules,1000, (int)ModulePriority.High);
    }

    
    private void LowTimerFrame(Object stateInfo)
    {
        // Update Current World
        CurrentWorld = GetCurrentWorld();
        
        if (stateInfo is not List<BaseModule> modules) return;
        
        foreach (var module in modules)
        {
            if(!module.Initialised) continue;
            module.OnFrame();
        }
    }
    
    private void MediumTimerFrame(Object stateInfo)
    {
        // Update Current World
        CurrentWorld = GetCurrentWorld();

        if (stateInfo is not List<BaseModule> modules) return;
        
        foreach (var module in modules)
        {
            if(!module.Initialised) continue;
            module.OnFrame();
        }
    }
    
    private void HighTimerFrame(Object stateInfo)
    {
        // Update Current World
        CurrentWorld = GetCurrentWorld();
        
        if (stateInfo is not List<BaseModule> modules) return;
        
        foreach (var module in modules)
        {
            if(!module.Initialised) continue;
            module.OnFrame();
        }
    }

    #endregion
    
    #region Modules
    private void InitialiseModules()
    {
        // Iterate over modules, attempt to activate if enabled
        foreach (var module in Modules)
        {
            if (!module.Enabled) continue;
            var executed = module.Initialise(this);
            if (!executed)
            {
                // Log the individual module that didnt start
            }
        }
    }

    public List<BaseModule> GetModules()
    {
        return Modules;
    }
    
    public BaseModule GetModuleById(Guid moduleId)
    {
        return Modules.FirstOrDefault(i => i.Id.Equals(moduleId));
    }

    public BaseModule GetModuleByName(string moduleName)
    {
        return Modules.FirstOrDefault(i => i.Name.Equals(moduleName, StringComparison.CurrentCultureIgnoreCase));
    }

    public List<ModuleSetting> GetModuleSettings(string moduleName)
    {
        var module = Modules.FirstOrDefault(i => i.Name.Equals(moduleName, StringComparison.CurrentCultureIgnoreCase));
        
        if (module == null) return new List<ModuleSetting>();

        return module.GetSettings();
    }

    public void AddModule(BaseModule module)
    {
        RemoveModule(module);
        Modules.Add(module);
    }

    public void RemoveModule(BaseModule module)
    {
        RemoveModule(module.Id);
    }

    public void RemoveModule(Guid moduleId)
    {
        Modules.RemoveAll(i => i.Id.Equals(moduleId));
    }
    
    #endregion

    #region Worlds

    private void SetupWorldList()
    {
        Worlds = BreadFramework.Worlds.Worlds.GetWorldList();
    }
    
    // TODO - this should be game specific 
    private int WorldIdAddress = GameFlags.WorldId.GetAddress();
    
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

    #region Memory Read/Write functions

    public void WriteInt(long address, int value)
    {
        var processName = SelectedGame.ProcessName;
        Memory.WriteMemory($"{processName}+{address:X8}", "int", $"{value}");
    }

    public void WriteShort(long address, int value)
    {
        var processName = SelectedGame.ProcessName;
        ushort writeVal = 0;
        try
        {
            writeVal = (ushort)value;
        }catch{/**/}
        Memory.WriteMemory($"{processName}+{address:X8}", "int", $"{writeVal}");
    }
    
    public void WriteFloat(long address, float value)
    {
        var processName = SelectedGame.ProcessName;
        Memory.WriteMemory($"{processName}+{address:X8}", "float", $"{value}");
    }

    public void WriteString(long address, string value)
    {
        var processName = SelectedGame.ProcessName;
        Memory.WriteMemory($"{processName}+{address:X8}", "string", $"{value}");
    }

    public void WriteByte(long address, byte value)
    {
        var processName = SelectedGame.ProcessName;
        Memory.WriteMemory($"{processName}+{address:X8}", "byte", $"0x{value:X2}");
    }
    public void Write2Bytes(long address, byte value)
    {
        var processName = SelectedGame.ProcessName;
        Memory.WriteMemory($"{processName}+{address:X8}", "2bytes", $"0x{value:X2}");
    }
    public void WriteBytes(long address, List<int> value)
    {
        var processName = SelectedGame.ProcessName;
        var hexValues = new List<string>();
        foreach (var byteVal in value)
        {
            hexValues.Add($"{byteVal:X2}");
        }
        var byteString = string.Join(",", hexValues);

        Memory.WriteMemory($"{processName}+{address:X8}", "bytes", $"{byteString}");
    }
    
    public void WriteBytesAbsolute(long address, List<int> value)
    {
        var hexValues = new List<string>();
        foreach (var byteVal in value)
        {
            hexValues.Add($"{byteVal:X2}");
        }
        var byteString = string.Join(",", hexValues);

        Memory.WriteMemory($"{address:X8}", "bytes", $"{byteString}");
    }
    
    public void WriteDouble(long address, double value)
    {
        var processName = SelectedGame.ProcessName;
        Memory.WriteMemory($"{processName}+{address:X8}", "double", $"{value}");
    }
    
    public void WriteLong(long address, long value)
    {
        var processName = SelectedGame.ProcessName;
        Memory.WriteMemory($"{processName}+{address:X8}", "long", $"{value}");
    }
    public void WriteLong(long address, ulong value)
    {
        var processName = SelectedGame.ProcessName;
        Memory.WriteMemory($"{processName}+{address:X8}", "long", $"{value}");
    }
    
    public int ReadInt(long address)
    {
        var processName = SelectedGame.ProcessName;
        int result = Memory.ReadInt($"{processName}+{address:X8}");
        return result;
    }
    public uint ReadUInt(long address)
    {
        var processName = SelectedGame.ProcessName;
        uint result = Memory.ReadUInt($"{processName}+{address:X8}");
        return result;
    }

    public int ReadIntRev(long address)
    {
        var processName = SelectedGame.ProcessName;
        int result = Memory.ReadInt($"{processName}+-{address:X8}");
        return result;
    }
    
    public uint ReadUIntAbsolute(long address)
    {
        uint result = Memory.ReadUInt($"{address:X8}");
        return result;
    }
    
    public float ReadFloat(long address)
    {
        var processName = SelectedGame.ProcessName;
        float result = Memory.ReadFloat($"{processName}+{address:X8}");
        return result;
    }

    public string ReadString(long address)
    {
        var processName = SelectedGame.ProcessName;
        string result = Memory.ReadString($"{processName}+{address:X8}");
        return result;
    }
    
    public string ReadString(long address, int length)
    {
        var processName = SelectedGame.ProcessName;
        string result = Memory.ReadString($"{processName}+{address:X8}", length:length);
        return result;
    }
    
    public short ReadShort(long address)
    {
        var processName = SelectedGame.ProcessName;
        var result = Memory.ReadInt($"{processName}+{address:X8}");
        short shortVal = 0;
        try
        {
            shortVal = (short)(result);
        }catch{/**/}
        return shortVal;
    }
    
    public short ReadShortAbsolute(long address)
    {
        var result = Memory.ReadInt($"{address:X8}");
        short shortVal = 0;
        try
        {
            shortVal = (short)(result);
        }catch{/**/}
        return shortVal;
    }
    
    public byte ReadByte(long address)
    {
        var processName = SelectedGame.ProcessName;
        byte result = (byte)Memory.ReadByte($"{processName}+{address:X8}");
        return result;
    }

    public byte[] ReadBytes(long address, int length)
    {
        var processName = SelectedGame.ProcessName;
        byte[] result = Memory.ReadBytes($"{processName}+{address:X8}", length);
        return result;
    }
    
    public byte Read2Byte(long address)
    {
        var processName = SelectedGame.ProcessName;
        byte result = (byte)Memory.Read2Byte($"{processName}+{address:X8}");
        return result;
    }
    
    public long ReadLong(long address)
    {
        var processName = SelectedGame.ProcessName;
        long result = Memory.ReadLong($"{processName}+{address:X8}");
        return result;
    }
    
    public long ReadLongAbsolute(long address)
    {
        long result = Memory.ReadLong($"{address:X8}");
        return result;
    }
    
    public double ReadDouble(long address)
    {
        var processName = SelectedGame.ProcessName;
        double result = Memory.ReadDouble($"{processName}+{address:X8}");
        return result;
    }
    
    #endregion

    #region Abilities

    private GameFlags AbilityFlags = new ();
    
    

    #endregion
}