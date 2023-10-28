using BreadFramework.Enums;
using BreadFramework.Flags;
using Memory;

namespace BreadRuntime.Modules;

public class OpenInCombatModule: BaseModule
{
    private GameFlag OpenMenuInCombat;
    private GameFlag TalkRequirement;
    private GameFlag ChestOpenRequirement;
    private GameFlag TrinityRequirement;
    private GameFlag ExamineRequirement;

    public bool OpenMenu;
    public bool Talk;
    public bool OpenChest;
    public bool ActivateTrinity;
    public bool Examine;
    
    public override string Author => "KSX";
    public override string Name => "Open in Combat";

    public override string Description =>
        "Allows certain actions to be performed in combat.";

    public override bool Initialise(Engine.KHEngine khEngine)
    {
        var success = true;

        KhEngine = khEngine;
        
        OpenMenuInCombat = KhEngine.GameFlagsRepo.GetFlag(GameFlags.OpenMenuInCombat);
        TalkRequirement = KhEngine.GameFlagsRepo.GetFlag(GameFlags.TalkRequirement);
        ChestOpenRequirement = KhEngine.GameFlagsRepo.GetFlag(GameFlags.ChestOpenRequirement);
        TrinityRequirement = KhEngine.GameFlagsRepo.GetFlag(GameFlags.TrinityRequirement);
        ExamineRequirement = KhEngine.GameFlagsRepo.GetFlag(GameFlags.ExamineRequirement);
        
        OpenChest = true;
        OpenMenu = true;
        Examine = true;
        Talk = true;
        ActivateTrinity = true;
        
        Initialised = success;
        return success;
    }

    public override void OnFrame()
    {
        if (OpenMenu)
        {
            KhEngine.WriteByte(OpenMenuInCombat.Address, 0);
        }
        if (OpenChest)
        {
            KhEngine.WriteByte(ChestOpenRequirement.Address, 0x73);
        }
        if (Examine)
        {
            KhEngine.WriteByte(ExamineRequirement.Address, 0x70);
        }
        if (Talk)
        {
            KhEngine.WriteByte(TalkRequirement.Address, 0x70);
        }
        if (ActivateTrinity)
        {
            KhEngine.WriteByte(TrinityRequirement.Address, 0x71);
        }
    }
}