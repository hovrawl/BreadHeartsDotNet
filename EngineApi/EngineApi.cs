using System.Diagnostics;
using BreadFramework.Flags;

namespace EngineApi;

public interface EngineApi
{
    public ProcessModule MainModule { get; }

    public GameFlagsRepo GameFlagsRepo { get; }

    public WorldInfo CurrentWorld { get; set; }

    #region Util
    public string ReadFileText(string path);

    public void WriteTextToFile(string path, string text);
    #endregion
    
    #region Memory

    public void WriteInt(long address, int value);

    public void WriteShort(long address, int value);

    public void WriteFloat(long address, float value);

    public void WriteString(long address, string value);

    public void WriteByte(long address, byte value);
    
    public void Write2Bytes(long address, byte value);
    
    public void WriteBytes(long address, List<int> value);

    public void WriteBytesAbsolute(long address, List<int> value);

    public void WriteDouble(long address, double value);

    public void WriteLong(long address, long value);

    public void WriteLong(long address, ulong value);

    public int ReadInt(long address);

    public uint ReadUInt(long address);

    public int ReadIntRev(long address);

    public uint ReadUIntAbsolute(long address);

    public float ReadFloat(long address);

    public string ReadString(long address);

    public string ReadString(long address, int length);

    public short ReadShort(long address);

    public short ReadShortAbsolute(long address);

    public byte ReadByte(long address);

    public byte[] ReadBytes(long address, int length);

    public byte Read2Byte(long address);

    public long ReadLong(long address);

    public long ReadLongAbsolute(long address);

    public double ReadDouble(long address);

    #endregion
}