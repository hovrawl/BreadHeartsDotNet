using System.Text.RegularExpressions;
using BreadFramework.Flags;
using BreadFramework.Game;
using BreadFramework.Items;
using PluginBase;
using PluginBase.Settings;

namespace BreadRuntime.Modules;

public class KhRandomizerPlugin : BasePlugin
{
    #region Memory Offsets
    private const int BASE_OFFSET = 0x3A0606;
    private const int BATTLE_TABLE = 0x2D1F3C0 - BASE_OFFSET;
    private const int ITEM_TABLE = BATTLE_TABLE + 0x1A58;
    private const int WEAPON_TABLE = BATTLE_TABLE + 0x94F8;
    private const int SORA_STAT_TABLE = BATTLE_TABLE + 0x3AC0;
    private const int DONALD_STAT_TABLE = SORA_STAT_TABLE + 0x3F8;
    private const int GOOFY_STAT_TABLE = DONALD_STAT_TABLE + 0x198;
    private const int SORA_ABILITY_TABLE = BATTLE_TABLE + 0x3BF8;
    private const int SORA_ABILITY_TABLE2 = SORA_ABILITY_TABLE - 0xD0;
    private const int SORA_ABILITY_TABLE3 = SORA_ABILITY_TABLE - 0x68;
    private const int REWARD_TABLE = BATTLE_TABLE + 0xC6A8;
    private const int CHEST_TABLE = 0x5259E0 - BASE_OFFSET;
    #endregion

    private readonly Random _random = new Random();
    private int _weaponStatRandoMode = 3;
    private int _stackAbilitiesMode = 2;
    private readonly List<byte> _earlyAbilities = new List<byte>();
    private bool _initialized;
    private Dictionary<int, WeaponStats> _originalWeaponStats;

    public override string Name => "Randomizer";
    public override string Author => "Your Name";
    public override string Description => "Randomizes various aspects of Kingdom Hearts";
    public override KHGame Game => KHGame.KHFM;

    private class WeaponStats
    {
        public byte Strength { get; set; }
        public byte Magic { get; set; }
        public byte Ability { get; set; }
    }

    public override bool Initialise(EngineApi.EngineApi khEngine)
    {
        _originalWeaponStats = new Dictionary<int, WeaponStats>();
        BackupOriginalWeaponStats();
        RandomizeInitialSetup();
        _initialized = true;
        return true;
    }

    private void BackupOriginalWeaponStats()
    {
        for (int i = 0; i < 15; i++)
        {
            long address = WEAPON_TABLE + (i * 0x48);
            _originalWeaponStats[i] = new WeaponStats
            {
                Strength = KhEngine.ReadByte(address + 0x12),
                Magic = KhEngine.ReadByte(address + 0x13),
                Ability = KhEngine.ReadByte(address + 0x14)
            };
        }
    }

    private void RandomizeInitialSetup()
    {
        RandomizeWeaponStats();
        RandomizeChests();
        RandomizeTrinityRewards();
        SetupEarlyAbilities();
    }

    private void RandomizeWeaponStats()
    {
        if (_weaponStatRandoMode == 0) return;

        var weapons = new List<WeaponStats>();
        
        // Collect all weapon stats
        for (int i = 0; i < 15; i++)
        {
            weapons.Add(_originalWeaponStats[i]);
        }

        if (_weaponStatRandoMode >= 2)
        {
            // Shuffle stats between weapons
            var strengthValues = weapons.Select(w => w.Strength).ToList();
            var magicValues = weapons.Select(w => w.Magic).ToList();
            
            strengthValues.Shuffle(_random);
            magicValues.Shuffle(_random);

            for (int i = 0; i < weapons.Count; i++)
            {
                long address = WEAPON_TABLE + (i * 0x48);
                KhEngine.WriteByte(address + 0x12, strengthValues[i]);
                KhEngine.WriteByte(address + 0x13, magicValues[i]);
            }
        }

        if (_weaponStatRandoMode == 1 || _weaponStatRandoMode == 3)
        {
            // Buff weak weapons
            for (int i = 0; i < weapons.Count; i++)
            {
                long address = WEAPON_TABLE + (i * 0x48);
                byte strength = KhEngine.ReadByte(address + 0x12);
                byte magic = KhEngine.ReadByte(address + 0x13);

                if (strength < 3) strength = (byte)(3 + _random.Next(2));
                if (magic < 3) magic = (byte)(3 + _random.Next(2));

                KhEngine.WriteByte(address + 0x12, strength);
                KhEngine.WriteByte(address + 0x13, magic);
            }
        }
    }

    private void RandomizeChests()
    {
        var chestItems = new List<byte>();
        
        // Collect all chest contents
        for (int i = 0; i < 100; i++) // Adjust number based on actual chest count
        {
            long address = CHEST_TABLE + (i * 0x08);
            chestItems.Add(KhEngine.ReadByte(address + 0x04));
        }

        // Shuffle chest contents
        chestItems.Shuffle(_random);

        // Write back shuffled contents
        for (int i = 0; i < chestItems.Count; i++)
        {
            long address = CHEST_TABLE + (i * 0x08);
            KhEngine.WriteByte(address + 0x04, chestItems[i]);
        }
    }

    private void RandomizeTrinityRewards()
    {
        var trinityRewards = new List<byte>();
        
        // Collect trinity rewards
        for (int i = 0; i < 50; i++) // Adjust number based on actual trinity count
        {
            long address = REWARD_TABLE + (i * 0x08);
            trinityRewards.Add(KhEngine.ReadByte(address + 0x04));
        }

        // Shuffle rewards
        trinityRewards.Shuffle(_random);

        // Write back shuffled rewards
        for (int i = 0; i < trinityRewards.Count; i++)
        {
            long address = REWARD_TABLE + (i * 0x08);
            KhEngine.WriteByte(address + 0x04, trinityRewards[i]);
        }
    }

    private void SetupEarlyAbilities()
    {
        if (_earlyAbilities.Count == 0) return;

        // Add early abilities to first level ups
        for (int i = 0; i < Math.Min(_earlyAbilities.Count, 4); i++)
        {
            long address = SORA_ABILITY_TABLE + i;
            KhEngine.WriteByte(address, _earlyAbilities[i]);
        }
    }

    public override void OnFrame(PluginState state)
    {
        if (!state.Enabled || !_initialized) return;

        HandleAbilityStacking();
    }

    private void HandleAbilityStacking()
    {
        if (_stackAbilitiesMode == 0) return;

        // Handle High Jump stacking
        if (_stackAbilitiesMode >= 1)
        {
            int highJumpCount = CountEquippedAbilities(0x8A); // High Jump ability ID
            if (highJumpCount > 1)
            {
                int jumpHeight = Math.Max(290, 190 + (highJumpCount * 100));
                KhEngine.WriteShort(GameFlags.JumpHeight, 390);
                KhEngine.WriteShort(GameFlags.JumpHeight + 2, Math.Max(390, jumpHeight));
            }
        }

        // Handle movement ability stacking
        if (_stackAbilitiesMode >= 2)
        {
            int glideCount = CountEquippedAbilities(0x8B); // Glide ability ID
            int dodgeRollCount = CountEquippedAbilities(0x96); // Dodge Roll ability ID

            if (glideCount > 1)
            {
                float glideSpeed = 1.0f + (glideCount * 0.15f);
                KhEngine.WriteFloat(GameFlags.GlideSpeed, glideSpeed);
            }

            if (dodgeRollCount > 1)
            {
                float rollSpeed = 1.0f + (dodgeRollCount * 0.1f);
                var dodgeDataAddress = GetDodgeDataAddress();
                //GameFlags.DodgeRollSpeed
                KhEngine.WriteFloat(dodgeDataAddress, rollSpeed);
            }
        }
    }

    private int CountEquippedAbilities(byte abilityId)
    {
        int count = 0;
        for (int i = 0; i < 32; i++)
        {
            if (KhEngine.ReadByte(SORA_ABILITY_TABLE + i) == abilityId)
                count++;
        }
        return count;
    }

    public override PluginSettings GetSettings()
    {
        return
        [
            new PluginDropDownSetting<int>([
                new("Off", 0),
                new("Buff Weak", 1),
                new("Shuffle", 2),
                new("Shuffle + Buff", 3)
            ])
            {
                Name = "Weapon Stat Randomization",
                Description = "Off, Buff weak, Shuffle, Shuffle+Buff",
                Value = _weaponStatRandoMode
            },

            new PluginDropDownSetting<int>([
                new("Off", 0),
                new("High Jump", 1),
                new("Movement abilities", 2)
            ])
            {
                Name = "Stack Abilities",
                Description = "Off, High Jump, Movement abilities",
                Value = _stackAbilitiesMode
            }
        ];
    }
    
    private bool IsDodgeDataValid(long address)
    {
        return KhEngine.ReadShort(address + 0x18) == 0xEF && 
               KhEngine.ReadShort(address + 0x34) == 0x94;
    }

    private long GetDodgeDataAddress()
    {
        var halfPointers = 0x2EE03B0;
        var animHalfPointers = KhEngine.ReadLong(0x2866498) + 0xC0;
    
        var index = 0;
        while (true)
        {
            var animValue = KhEngine.ReadInt(animHalfPointers + index);
            if (animValue <= 0)
                break;

            var dodgePointer = KhEngine.ReadLong(halfPointers + 8) + (animValue % 0x1000000);
        
            if (IsDodgeDataValid(dodgePointer))
            {
                var dodgeFrames = KhEngine.ReadByte(dodgePointer + 4);
                KhEngine.LogDebug(Name, $"Found dodge data at {index:X}, dodge frames: {dodgeFrames}");
                return dodgePointer;
            }

            index += 4;
        }

        return 0;
    }

}



public static class ListExtensions
{
    public static void Shuffle<T>(this IList<T> list, Random rng)
    {
        int n = list.Count;
        while (n > 1)
        {
            n--;
            int k = rng.Next(n + 1);
            T value = list[k];
            list[k] = list[n];
            list[n] = value;
        }
    }
}