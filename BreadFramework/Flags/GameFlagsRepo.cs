using BreadFramework.Enums;

namespace BreadFramework.Flags;

public class GameFlagsRepo
{
    #region GameFlagsRepo
    private static volatile GameFlagsRepo _instance = new();
    private static readonly object ThreadLock = new object();

    private static readonly object SyncRoot = new object();
    public static GameFlagsRepo Instance => _instance;

    #endregion

    private readonly Dictionary<GameFlags, GameFlag> Flags = new();

    /// <summary>
    /// 
    /// </summary>
    /// <param name="flagEnum"></param>
    /// <returns></returns>
    public GameFlag GetFlag(GameFlags flagEnum)
    {
        var existing = Flags.ContainsKey(flagEnum);
        
        // ReSharper disable once InvertIf
        if (!existing)
        {
            var flag = new GameFlag
            {
                Name = flagEnum.Description,
                Address = flagEnum.Address,
                Type = flagEnum.Type,
                ValueType = flagEnum.ValueType,
                Flag = flagEnum,
            };
            Flags.Add(flagEnum, flag);
        }

        return Flags[flagEnum];
    }
}