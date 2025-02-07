using System.Diagnostics;
using System.Runtime.InteropServices;

namespace BreadRuntime.Engine;

public class BreadHeartsMemoryManager
{
    private Process _process;
    private IntPtr _processHandle;
    private ProcessModule _mainModule;

    #region Native Methods
    [DllImport("kernel32.dll")]
    private static extern IntPtr OpenProcess(int dwDesiredAccess, bool bInheritHandle, int dwProcessId);

    [DllImport("kernel32.dll")]
    private static extern bool ReadProcessMemory(IntPtr hProcess, IntPtr lpBaseAddress, [Out] byte[] lpBuffer, int dwSize, out IntPtr lpNumberOfBytesRead);

    [DllImport("kernel32.dll")]
    private static extern bool WriteProcessMemory(IntPtr hProcess, IntPtr lpBaseAddress, byte[] lpBuffer, int dwSize, out IntPtr lpNumberOfBytesWritten);
    #endregion

    public ProcessModule MainModule => _mainModule;

    public bool OpenProcess(int processId)
    {
        try
        {
            _process = Process.GetProcessById(processId);
            _processHandle = OpenProcess(0x1F0FFF, false, processId);
            _mainModule = _process.MainModule;
            return _processHandle != IntPtr.Zero;
        }
        catch
        {
            return false;
        }
    }

    public int GetProcIdFromName(string processName)
    {
        var process = Process.GetProcessesByName(processName).FirstOrDefault();
        return process?.Id ?? -1;
    }

    #region Read Methods
    public int ReadInt(string address)
    {
        var addr = ResolveAddress(address);
        var buffer = new byte[4];
        ReadProcessMemory(_processHandle, addr, buffer, buffer.Length, out _);
        return BitConverter.ToInt32(buffer, 0);
    }

    public uint ReadUInt(string address)
    {
        var addr = ResolveAddress(address);
        var buffer = new byte[4];
        ReadProcessMemory(_processHandle, addr, buffer, buffer.Length, out _);
        return BitConverter.ToUInt32(buffer, 0);
    }

    public float ReadFloat(string address)
    {
        var addr = ResolveAddress(address);
        var buffer = new byte[4];
        ReadProcessMemory(_processHandle, addr, buffer, buffer.Length, out _);
        return BitConverter.ToSingle(buffer, 0);
    }

    public string ReadString(string address, int length = 32)
    {
        var addr = ResolveAddress(address);
        var buffer = new byte[length];
        ReadProcessMemory(_processHandle, addr, buffer, length, out _);
        
        var result = System.Text.Encoding.UTF8.GetString(buffer);
        var nullTerminator = result.IndexOf('\0');
        return nullTerminator != -1 ? result.Substring(0, nullTerminator) : result;
    }

    public byte ReadByte(string address)
    {
        var addr = ResolveAddress(address);
        var buffer = new byte[1];
        ReadProcessMemory(_processHandle, addr, buffer, 1, out _);
        return buffer[0];
    }

    public byte[] ReadBytes(string address, int length)
    {
        var addr = ResolveAddress(address);
        var buffer = new byte[length];
        ReadProcessMemory(_processHandle, addr, buffer, length, out _);
        return buffer;
    }

    public long ReadLong(string address)
    {
        var addr = ResolveAddress(address);
        var buffer = new byte[8];
        ReadProcessMemory(_processHandle, addr, buffer, buffer.Length, out _);
        return BitConverter.ToInt64(buffer, 0);
    }

    public double ReadDouble(string address)
    {
        var addr = ResolveAddress(address);
        var buffer = new byte[8];
        ReadProcessMemory(_processHandle, addr, buffer, buffer.Length, out _);
        return BitConverter.ToDouble(buffer, 0);
    }
    #endregion

    #region Write Methods
    public bool WriteMemory<T>(string address, T value)
    {
        var addr = ResolveAddress(address);
        byte[] buffer;

        switch (value)
        {
            case int intValue:
                buffer = BitConverter.GetBytes(intValue);
                break;
            case float floatValue:
                buffer = BitConverter.GetBytes(floatValue);
                break;
            case string stringValue:
                buffer = System.Text.Encoding.UTF8.GetBytes(stringValue + '\0');
                break;
            case byte byteValue:
                buffer = new[] { byteValue };
                break;
            case long longValue:
                buffer = BitConverter.GetBytes(longValue);
                break;
            case double doubleValue:
                buffer = BitConverter.GetBytes(doubleValue);
                break;
            default:
                throw new ArgumentException("Unsupported type");
        }

        return WriteProcessMemory(_processHandle, addr, buffer, buffer.Length, out _);
    }

    public bool WriteBytes(string address, byte[] bytes)
    {
        var addr = ResolveAddress(address);
        return WriteProcessMemory(_processHandle, addr, bytes, bytes.Length, out _);
    }
    #endregion

    #region Helper Methods
    private IntPtr ResolveAddress(string address)
    {
        // Handle both absolute and relative addresses
        if (address.Contains('+'))
        {
            var parts = address.Split('+');
            var baseAddr = _mainModule.BaseAddress;
            var offset = Convert.ToInt64(parts[1], 16);
            return new IntPtr(baseAddr.ToInt64() + offset);
        }
        
        return new IntPtr(Convert.ToInt64(address, 16));
    }
    #endregion
}