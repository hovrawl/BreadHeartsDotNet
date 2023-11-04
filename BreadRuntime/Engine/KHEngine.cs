using System.Reflection;
using System.Text;
using BreadFramework.Common;
using BreadFramework.Enums;
using BreadFramework.Flags;
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
    
    private string processName = "KINGDOM HEARTS FINAL MIX.exe";
    private string processId = "KINGDOM HEARTS FINAL MIX";
    
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
    
    public static bool Attached => _attached;

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
    }
    
    public void Stop()
    {
        MediumPriorityTimer?.Dispose();
    }

    public void Attach()
    {
        AttachToProcess();
    }

    private void AttachToProcess()
    {
        // Reset memory
        _attached = false;
        if (Memory.mProc?.Process?.HasExited == false) return;
        Memory.CloseProcess();
        
        var openedProc = false;

        
        var pid = Memory.GetProcIdFromName(processId);

        if (pid > 0) openedProc = Memory.OpenProcess(pid);

        if (openedProc) _attached = true;
    }
    
    #region Timers

    private void SetupTimers()
    {
        var initialisedModules = Modules.Where(i => i.Initialised);
        
        // Low Priority
        LowPriorityModules.Clear();
        LowPriorityModules.AddRange(initialisedModules.Where(i => i.Priority == ModulePriority.Low));
        LowPriorityTimer?.Dispose();
        LowPriorityTimer = new Timer(LowTimerFrame, null,1000, (int)ModulePriority.Low);
        
        // Medium Priority
        MediumPriorityModules.Clear();
        MediumPriorityModules.AddRange(initialisedModules.Where(i => i.Priority == ModulePriority.Medium));
        MediumPriorityTimer?.Dispose();
        MediumPriorityTimer = new Timer(MediumTimerFrame, null,1000, (int)ModulePriority.Medium);
        
        // High Priority
        HighPriorityModules.Clear();
        HighPriorityModules.AddRange(initialisedModules.Where(i => i.Priority == ModulePriority.High));
        HighPriorityTimer?.Dispose();
        HighPriorityTimer = new Timer(HighTimerFrame, null,1000, (int)ModulePriority.High);
    }

    
    private void LowTimerFrame(Object stateInfo)
    {
        // Update Current World
        CurrentWorld = GetCurrentWorld();
        
        foreach (var module in LowPriorityModules) 
        {
            if(!module.Initialised) continue;
            module.OnFrame();
        }
    }
    
    private void MediumTimerFrame(Object stateInfo)
    {
        // Update Current World
        CurrentWorld = GetCurrentWorld();
        
        foreach (var module in MediumPriorityModules) 
        {
            if(!module.Initialised) continue;
            module.OnFrame();
        }
    }
    
    private void HighTimerFrame(Object stateInfo)
    {
        // Update Current World
        CurrentWorld = GetCurrentWorld();
        
        foreach (var module in HighPriorityModules) 
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
    
    
    #region Read/Write functions

    public void WriteInt(long address, int value)
    {
        Memory.WriteMemory($"{processName}+{address:X8}", "int", $"{value}");
    }

    public void WriteShort(long address, int value)
    {
        ushort writeVal = 0;
        try
        {
            writeVal = (ushort)value;
        }catch{/**/}
        Memory.WriteMemory($"{processName}+{address:X8}", "int", $"{writeVal}");
    }
    
    public void WriteFloat(long address, float value)
    {
        Memory.WriteMemory($"{processName}+{address:X8}", "float", $"{value}");
    }

    public void WriteString(long address, string value)
    {
        Memory.WriteMemory($"{processName}+{address:X8}", "string", $"{value}");
    }

    public void WriteByte(long address, byte value)
    {
        Memory.WriteMemory($"{processName}+{address:X8}", "byte", $"0x{value:X2}");
    }
    public void Write2Bytes(long address, byte value)
    {
        Memory.WriteMemory($"{processName}+{address:X8}", "2bytes", $"0x{value:X2}");
    }
    public void WriteBytes(long address, List<int> value)
    {
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
        Memory.WriteMemory($"{processName}+{address:X8}", "double", $"{value}");
    }
    
    public void WriteLong(long address, long value)
    {
        Memory.WriteMemory($"{processName}+{address:X8}", "long", $"{value}");
    }
    public void WriteLong(long address, ulong value)
    {
        Memory.WriteMemory($"{processName}+{address:X8}", "long", $"{value}");
    }
    
    public int ReadInt(long address)
    {
        int result = Memory.ReadInt($"{processName}+{address:X8}");
        return result;
    }
    public uint ReadUInt(long address)
    {
        uint result = Memory.ReadUInt($"{processName}+{address:X8}");
        return result;
    }

    public int ReadIntRev(long address)
    {
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
        float result = Memory.ReadFloat($"{processName}+{address:X8}");
        return result;
    }

    public string ReadString(long address)
    {
        string result = Memory.ReadString($"{processName}+{address:X8}");
        return result;
    }
    
    public string ReadString(long address, int length)
    {
        string result = Memory.ReadString($"{processName}+{address:X8}", length:length);
        return result;
    }
    
    public short ReadShort(long address)
    {
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
        byte result = (byte)Memory.ReadByte($"{processName}+{address:X8}");
        return result;
    }

    public byte[] ReadBytes(long address, int length)
    {
        byte[] result = Memory.ReadBytes($"{processName}+{address:X8}", length);
        return result;
    }
    
    public byte Read2Byte(long address)
    {
        byte result = (byte)Memory.Read2Byte($"{processName}+{address:X8}");
        return result;
    }
    
    public long ReadLong(long address)
    {
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
        double result = Memory.ReadDouble($"{processName}+{address:X8}");
        return result;
    }
    
    #endregion
}