using Memory;

namespace KHRandoEngine.Engine;

public class Engine
{
    private string processName = "KINGDOM HEARTS FINAL MIX.exe";
    private string processId = "KINGDOM HEARTS FINAL MIX";
    private Mem memory;
    
    public void Start()
    {
        memory = new Mem();
        GetPID();
    }

    private void GetPID()
    {
        int pid = memory.GetProcIdFromName(processId);
        bool openProc = false;

        if (pid > 0) openProc = memory.OpenProcess(pid);
    }
    
    #region Read/Write functions

    public void WriteInt(int address, int value)
    {
        GetPID();
        memory.WriteMemory($"{processName}+{address:X8}", "int", $"{value}");
    }

    public void WriteFloat(int address, float value)
    {
        GetPID();
        memory.WriteMemory($"{processName}+{address:X8}", "float", $"{value}");
    }

    public void WriteString(int address, string value)
    {
        GetPID();
        memory.WriteMemory($"{processName}+{address:X8}", "string", $"{value}");
    }

    public void WriteByte(int address, byte value)
    {
        GetPID();
        memory.WriteMemory($"{processName}+{address:X8}", "byte", $"0x{value:X2}");
    }

    public void Write2Bytes(int address, byte value1, byte value2)
    {
        GetPID();
        memory.WriteMemory($"{processName}+{address:X8}", "bytes", $"0x{value1:X2} 0x{value2:X2}");
    }

    public int ReadInt(int address)
    {
        GetPID();
        int result = memory.ReadInt($"{processName}+{address:X8}");
        return result;
    }

    public float ReadFloat(int address)
    {
        GetPID();
        float result = memory.ReadFloat($"{processName}+{address:X8}");
        return result;
    }

    public string ReadString(int address)
    {
        GetPID();
        string result = memory.ReadString($"{processName}+{address:X8}");
        return result;
    }

    public byte ReadByte(int address)
    {
        GetPID();
        byte result = (byte)memory.ReadByte($"{processName}+{address:X8}");
        return result;
    }

    #endregion
}