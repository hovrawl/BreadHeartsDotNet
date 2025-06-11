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
        
        switch (flag.ValueType)
        {
            case FlagValueType.Int:
            {
                flag.Value = engine.ReadInt(flag.Address);
                break;
            }
            case FlagValueType.Long:
            {
                flag.Value = engine.ReadLong(flag.Address);
                break;
            }
            case FlagValueType.Float:
            {
                flag.Value = engine.ReadFloat(flag.Address);
                break;
            }
            case FlagValueType.Double:
            {
                flag.Value = engine.ReadDouble(flag.Address);
                break;
            }
            case FlagValueType.Bool:
            {
                flag.Value = engine.ReadInt(flag.Address) != 0;
                break;
            }
            case FlagValueType.String:
            {
                flag.Value = engine.ReadString(flag.Address);
                break;
            }
            case FlagValueType.Byte:
            {
                flag.Value = engine.ReadByte(flag.Address);
                break;
            }
            case FlagValueType.Bytes:
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
        
        switch (flag.ValueType)
        {
            case FlagValueType.Int when newValue is int result:
            {
                engine.WriteInt(flag.Address, result);
                break;
            }
            case FlagValueType.Long when newValue is long result:
            {
                engine.WriteLong(flag.Address, result);
                break;
            }
            case FlagValueType.Float when newValue is float result:
            {
                engine.WriteFloat(flag.Address, result);
                break;
            }
            case FlagValueType.Double when newValue is double result:
            {
                engine.WriteDouble(flag.Address, result);
                break;
            }
            case FlagValueType.Bool when newValue is bool result:
            {
                // true == 1
                // false == 0
                engine.WriteInt(flag.Address, result ? 1 : 0);
                break;
            }
            case FlagValueType.String when newValue is string result:
            {
                engine.WriteString(flag.Address, result);
                break;
            }
            case FlagValueType.Byte when newValue is byte result:
            {
                engine.WriteByte(flag.Address, result);
                break;
            }
            case FlagValueType.Bytes when newValue is List<int> result:
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