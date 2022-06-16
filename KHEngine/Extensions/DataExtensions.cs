using KHData.Flags;

namespace KHEngine.Extensions;

public static class DataExtensions
{
    public static void ReadMemory(this GameFlag flag, Engine.KHEngine engine)
    {
        switch (flag.Type)
        {
            case FlagType.Int:
            {
                flag.Value = engine.ReadInt(flag.Address).ToString();
                break;
            }
            case FlagType.Long:
            {
                break;
            }
            case FlagType.Float:
            {
                break;
            }
            case FlagType.Double:
            {
                break;
            }
            case FlagType.Bool:
            {
                break;
            }
            case FlagType.String:
            {
                break;
            }
            case FlagType.Byte:
            {
                break;
            }
            case FlagType.Bytes:
            {
                break;
            }
            default:
            {
                throw new ArgumentOutOfRangeException();
            }
        }
    }
    
    public static void WriteMemory(this GameFlag flag, Engine.KHEngine engine, object newValue)
    {
        switch (flag.Type)
        {
            case FlagType.Int when newValue is int intVal:
            {
                engine.WriteInt(flag.Address, intVal);
                break;
            }
            case FlagType.Long:
            {
                break;
            }
            case FlagType.Float:
            {
                break;
            }
            case FlagType.Double:
            {
                break;
            }
            case FlagType.Bool:
            {
                break;
            }
            case FlagType.String:
            {
                break;
            }
            case FlagType.Byte:
            {
                break;
            }
            case FlagType.Bytes:
            {
                break;
            }
            default:
            {
                throw new ArgumentOutOfRangeException();
            }
        }
        
        flag.ReadMemory(engine);

    }
}