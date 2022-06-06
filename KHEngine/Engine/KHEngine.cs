using System.Text;
using KHData.Common;
using KHData.Enums;
using KHData.Flags;
using KHEngine.Modules;
using Memory;

namespace KHEngine.Engine;

public sealed class KHEngine
{
    
    #region InstanceLocking
    private static volatile KHEngine _instance;
    private static readonly object ThreadLock = new object();

    private static readonly object SyncRoot = new object();
    public static KHEngine Instance
    {
        get
        {
            if (_instance != null) return _instance;
            lock (SyncRoot)
            {
                if (_instance != null) return _instance;
                _instance = new KHEngine();
            }

            return _instance;
        }
    }
    #endregion
    
    private string processName = "KINGDOM HEARTS FINAL MIX.exe";
    private string processId = "KINGDOM HEARTS FINAL MIX";
    
    private static List<BaseModule> Modules = new List<BaseModule>();
    public Mem Memory;

    public WorldFlag CurrentWorld;
    private List<CheckBase> Worlds = new List<CheckBase>();
    public Timer aTimer;
    
    private static ReaderWriterLockSlim _readWriteLock = new ReaderWriterLockSlim();

    public void Initialise(Mem mem)
    {
        Memory = mem;

        //Memory = new Mem();
        GetPID();
        Worlds = KHData.Worlds.Worlds.GetWorldList();
    }

    public void Start()
    {
        InitialiseModules();
        SetTimer();
    }
    
    public void Stop()
    {
        aTimer?.Dispose();
    }

    
    
    private void OnFrame(Object stateInfo)
    {
        // Update Current World
        CurrentWorld = GetCurrentWorld();

        foreach (var module in Modules.Where(i => i.Initialised)) 
        {
            module.OnFrame();
        }
    }

    
    private bool InitialiseModules()
    {
        var success = false;

        foreach (var module in Modules)
        {
            var executed = module.Initialise(this);
            if (!executed)
            {
                // Log the individual module that didnt start
                success = false;
            }
        }

        return success;
    }


    private void SetTimer()
    {
        aTimer = new Timer(OnFrame, null,1000, 250 );
    }

    private void GetPID()
    {
        int pid = Memory.GetProcIdFromName(processId);
        bool openProc = false;

        if (pid > 0) openProc = Memory.OpenProcess(pid);
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
    
    private WorldFlag GetCurrentWorld()
    {
        var worldFlag = GameFlags.WorldId;

        var worldId = ReadInt(worldFlag.GetAddress());
        var worldCheck = Worlds.FirstOrDefault(i => i.OriginalAddress == worldId);
        var world = worldCheck != null ? 
            new WorldFlag
            {
                Address = worldCheck.OriginalAddress,
                FlagName = worldCheck.Name
            } : null;
        return world;
    }

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
    public void WriteInt(int address, int value)
    {
        Memory.WriteMemory($"{processName}+{address:X8}", "int", $"{value}");
    }
    
    public void WriteShort(int address, short value)
    {
        Memory.WriteMemory($"{processName}+{address:X8}", "int", $"{value}");
    }
    
    public void WriteShort(int address, int value)
    {
        ushort writeVal = 0;
        try
        {
            writeVal = (ushort)value;
        }catch{/**/}
        Memory.WriteMemory($"{processName}+{address:X8}", "int", $"{writeVal}");
    }
    
    public void WriteFloat(int address, float value)
    {
        Memory.WriteMemory($"{processName}+{address:X8}", "float", $"{value}");
    }

    public void WriteString(int address, string value)
    {
        Memory.WriteMemory($"{processName}+{address:X8}", "string", $"{value}");
    }

    public void WriteByte(int address, byte value)
    {
        Memory.WriteMemory($"{processName}+{address:X8}", "byte", $"0x{value:X2}");
    }
    public void Write2Bytes(int address, byte value)
    {
        Memory.WriteMemory($"{processName}+{address:X8}", "2bytes", $"0x{value:X2}");
    }
    public void WriteBytes(int address, List<int> value)
    {
        var hexValues = new List<string>();
        foreach (var byteVal in value)
        {
            hexValues.Add($"{byteVal:X2}");
        }
        var byteString = string.Join(",", hexValues);

        Memory.WriteMemory($"{processName}+{address:X8}", "bytes", $"{byteString}");
    }
    public void WriteDouble(int address, byte value)
    {
        Memory.WriteMemory($"{processName}+{address:X8}", "double", $"{value}");
    }
    public void WriteLong(int address, long value)
    {
        Memory.WriteMemory($"{processName}+{address:X8}", "long", $"{value}");
    }
    public void WriteLong(int address, ulong value)
    {
        Memory.WriteMemory($"{processName}+{address:X8}", "long", $"{value}");
    }
    
    public int ReadInt(int address)
    {
        int result = Memory.ReadInt($"{processName}+{address:X8}");
        return result;
    }

    public float ReadFloat(int address)
    {
        float result = Memory.ReadFloat($"{processName}+{address:X8}");
        return result;
    }

    public string ReadString(int address)
    {
        string result = Memory.ReadString($"{processName}+{address:X8}");
        return result;
    }
    
    public string ReadString(int address, int length)
    {
        string result = Memory.ReadString($"{processName}+{address:X8}", length:length);
        return result;
    }
    
    public short ReadShort(int address)
    {
        var result = Memory.ReadInt($"{processName}+{address:X8}");
        short shortVal = 0;
        try
        {
            shortVal = (short)(result);
        }catch{/**/}
        return shortVal;
    }
    
    public byte ReadByte(int address)
    {
        byte result = (byte)Memory.ReadByte($"{processName}+{address:X8}");
        return result;
    }

    public byte[] ReadBytes(int address, int length)
    {
        byte[] result = Memory.ReadBytes($"{processName}+{address:X8}", length);
        return result;
    }
    
    public byte Read2Byte(int address)
    {
        byte result = (byte)Memory.Read2Byte($"{processName}+{address:X8}");
        return result;
    }
    
    public long ReadLong(int address)
    {
        long result = Memory.ReadLong($"{processName}+{address:X8}");
        return result;
    }
    
    public double ReadDouble(int address)
    {
        double result = Memory.ReadDouble($"{processName}+{address:X8}");
        return result;
    }
    
    #endregion
}