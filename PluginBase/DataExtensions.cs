using BreadFramework.Flags;
using BreadRuntime.Enums;

namespace PluginBase;

public static class DataExtensions
{
    public static void ReadMemory(this GameFlag flag, EngineApi.EngineApi engine, ModulePriority priority)
    {
        var priorityTimeMs = (int) priority;
        // Do not re-read memory if enough time has not passed
        if (flag.TimeSinceLastRead + priorityTimeMs <= DateTime.Now.Millisecond) return;
        
        switch (flag.Type)
        {
            case FlagType.Int:
            {
                flag.Value = engine.ReadInt(flag.Address);
                break;
            }
            case FlagType.Long:
            {
                flag.Value = engine.ReadLong(flag.Address);
                break;
            }
            case FlagType.Float:
            {
                flag.Value = engine.ReadFloat(flag.Address);
                break;
            }
            case FlagType.Double:
            {
                flag.Value = engine.ReadDouble(flag.Address);
                break;
            }
            case FlagType.Bool:
            {
                flag.Value = engine.ReadInt(flag.Address) != 0;
                break;
            }
            case FlagType.String:
            {
                flag.Value = engine.ReadString(flag.Address);
                break;
            }
            case FlagType.Byte:
            {
                flag.Value = engine.ReadByte(flag.Address);
                break;
            }
            case FlagType.Bytes:
            {
                flag.Value = engine.ReadBytes(flag.Address, flag.Length);
                break;
            }
            default:
            {
                throw new ArgumentOutOfRangeException();
            }
        }

        flag.UpdateLastRead();
    }
    
    public static void WriteMemory(this GameFlag flag, EngineApi.EngineApi engine, ModulePriority priority, object newValue)
    {
        var priorityTimeMs = (int) priority;
        // Do not re-write memory if enough time has not passed
        if (flag.TimeSinceLastWrite + priorityTimeMs <= DateTime.Now.Millisecond) return;
        
        switch (flag.Type)
        {
            case FlagType.Int when newValue is int result:
            {
                engine.WriteInt(flag.Address, result);
                break;
            }
            case FlagType.Long when newValue is long result:
            {
                engine.WriteLong(flag.Address, result);
                break;
            }
            case FlagType.Float when newValue is float result:
            {
                engine.WriteFloat(flag.Address, result);
                break;
            }
            case FlagType.Double when newValue is double result:
            {
                engine.WriteDouble(flag.Address, result);
                break;
            }
            case FlagType.Bool when newValue is bool result:
            {
                // true == 1
                // false == 0
                engine.WriteInt(flag.Address, result ? 1 : 0);
                break;
            }
            case FlagType.String when newValue is string result:
            {
                engine.WriteString(flag.Address, result);
                break;
            }
            case FlagType.Byte when newValue is byte result:
            {
                engine.WriteByte(flag.Address, result);
                break;
            }
            case FlagType.Bytes when newValue is List<int> result:
            {
                engine.WriteBytes(flag.Address, result);
                break;
            }
            default:
            {
                throw new ArgumentOutOfRangeException();
            }
        }

        flag.UpdateLastWrite();
        
        flag.ReadMemory(engine, priority);
    }
}