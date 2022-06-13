using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Text;

namespace KHEngine.Engine;

public class ManualReader
{
    const int PROCESS_WM_READ = 0x0010;
         
     [DllImport("kernel32.dll")]
     public static extern IntPtr OpenProcess(int dwDesiredAccess, bool bInheritHandle, int dwProcessId);

     [DllImport("kernel32.dll")]
     public static extern bool ReadProcessMemory(int hProcess, Int64 lpBaseAddress, byte[] lpBuffer, int dwSize, ref int lpNumberOfBytesRead);

     public static Process Process;
     public static IntPtr ProcessHandle;
     public bool Hooked;

     public ManualReader()
     {
         try
         {
             Process = Process.GetProcessesByName("KINGDOM HEARTS FINAL MIX")[0];
             ProcessHandle = OpenProcess(PROCESS_WM_READ, false, Process.Id);
         }
         catch (IndexOutOfRangeException)
         {
             Hooked = false;
             return;
         }
         Hooked = true;

     }

     public byte[] ReadMemory(int address, int bytesToRead, bool absolute = false)
     {
         if (Process.HasExited)
         {
             throw new Exception();
         }

         ProcessModule processModule = Process.MainModule;
         var readAddress = processModule.BaseAddress.ToInt64() + address;

         var _addressWithOffset = (0x3A0606 + readAddress);

         if (absolute)
         {
             _addressWithOffset = (address);
         }

         int bytesRead = 0;
         byte[] buffer = new byte[bytesToRead];


         //ReadProcessMemory((int)ProcessHandle, (int)_address, buffer, buffer.Length, ref bytesRead);
         ReadProcessMemory((int)ProcessHandle, _addressWithOffset, buffer, buffer.Length, ref bytesRead);


         return buffer;
     }

     public byte[] ReadArray(int address, int length, bool absolute = false)
     {
         if (Process.HasExited)
         {
             throw new Exception();
         }

         ProcessModule processModule = Process.MainModule;
         var readAddress = processModule.BaseAddress.ToInt64() + address;

         var _addressWithOffset = (0x3A0606 + readAddress);

         if (absolute)
         {
             _addressWithOffset = (address);
         }

         var _outArray = new byte[length];
         int _outRead = 0;

         ReadProcessMemory((int)ProcessHandle, _addressWithOffset, _outArray, length, ref _outRead);

         return _outArray;
     }

     //public unsafe static T Read<T>(int Address, bool Absolute = false) where T : unmanaged
     //{
     //    IntPtr _address = (IntPtr)(GameAddress + Address);

     //    if (Absolute)
     //        _address = (IntPtr)(Address);

     //    var _outSize = sizeof(T);

     //    var _outArray = new byte[_outSize];
     //    int _outRead = 0;

     //    ReadProcessMemory(GameHandle, _address, _outArray, _outSize, ref _outRead);

     //    var _gcHandle = GCHandle.Alloc(_outArray, GCHandleType.Pinned);
     //    var _retData = (T)Marshal.PtrToStructure(_gcHandle.AddrOfPinnedObject(), typeof(T));

     //    _gcHandle.Free();

     //    return _retData;
     //}

     /// <summary>
     /// Returns the string from specified address within max length, then returns the offset when string was terminated
     /// </summary>
     /// <param name="address"></param>
     /// <param name="maxlength"></param>
     /// <returns></returns>
     public Tuple<string, int> ReadNullTerminatedWString(int address, int maxlength)
     {
        
         if (Process.HasExited)
         {
             throw new Exception();
         }

         ProcessModule processModule = Process.MainModule;

         var byteArray = new byte[maxlength * 2];

         var bytesRead = 0;

         ReadProcessMemory((int)ProcessHandle, processModule.BaseAddress.ToInt64() + address, byteArray, maxlength, ref bytesRead);


         int nullterm = 0;
         while (nullterm < bytesRead && byteArray[nullterm] != 0)
         {
             nullterm = nullterm + 2;
         }

         var s = Encoding.UTF8.GetString(byteArray, 0, nullterm);
         var str = System.Text.Encoding.Default.GetString(byteArray);

         var returnTuple = new Tuple<string, int>(str, nullterm + 2);
         return returnTuple;
     }
}