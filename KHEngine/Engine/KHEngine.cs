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
    
    public void Initialise(Mem mem)
    {
        Memory = mem;

        //Memory = new Mem();
        GetPID();
        Worlds = KHData.Worlds.Worlds.GetWorldList();
    }
    
    public bool InitialiseModules()
    {
        var success = false;

        foreach (var module in Modules)
        {
            var executed = module.Initialise(this);
            if (!executed)
            {
                success = false;
                break;
            }
        }

        return success;
    }

    public void OnFrame()
    {
        // Update Current World
        CurrentWorld = GetCurrentWorld();

        foreach (var module in Modules)
        {
            module.OnFrame();
        }
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
    
    
    #region Read/Write functions

    public void WriteInt(int address, int value)
    {
        Memory.WriteMemory($"{processName}+{address:X8}", "int", $"{value}");
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

    public void Write2Bytes(int address, byte value1, byte value2)
    {
        Memory.WriteMemory($"{processName}+{address:X8}", "bytes", $"0x{value1:X2} 0x{value2:X2}");
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

    public byte ReadByte(int address)
    {
        byte result = (byte)Memory.ReadByte($"{processName}+{address:X8}");
        return result;
    }

    #endregion
}