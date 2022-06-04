using KHData.Enums;
using KHData.Flags;
using Memory;

namespace KHEngine.Modules;

public class FastCameraModule : BaseModule
{
    // For some reason can't write to these addresses
    private GameFlag Accel;
    private GameFlag Deaccel;
    private GameFlag CurSpeedV;
    private GameFlag CurSpeedH;
    private GameFlag CameraInputH;
    private GameFlag CameraInputV;
    private GameFlag CameraCenter;
    //
    private GameFlag Snap;
    private GameFlag AccelHack;
    private GameFlag DeaccelHack;
    private GameFlag Speed;
    private GameFlag MenuOpen;
    
    private double CenterSpeed = 2;
    private double OverallSpeed = 1.2;
    private double OverallSpeedV = 1.2;
    private double AccelerationSpeed = 0.001;
    private double AccelerationSpeedV = 0.0014;
    private double DeaccelerationSpeedV = -0.001;
    private double DeaccelerationSpeed = -0.0016;

    private double LastSpeedH = 0;
    private double LastSpeedV = 0;
    
    public override string Name => "Fast Camera";

    public override string Description => "Allows for faster camera control.";
    
    public override bool Initialise(Engine.KHEngine khEngine)
    {
        var success = false;

        KhEngine = khEngine;
        
        Accel = new GameFlag
        {
            FlagName = "Camera Snap Flag",
            Address = GameFlags.CameraAcceleration.GetAddress()
        };
        Deaccel = new GameFlag
        {
            FlagName = "Camera Snap Flag",
            Address = GameFlags.CameraDeceleration.GetAddress()
        };
        CurSpeedV = new GameFlag
        {
            FlagName = "Camera Snap Flag",
            Address = GameFlags.CameraCurrentSpeedV.GetAddress()
        };
        CurSpeedH = new GameFlag
        {
            FlagName = "Camera Snap Flag",
            Address = GameFlags.CameraCurrentSpeedH.GetAddress()
        };
        CameraInputH = new GameFlag
        {
            FlagName = "Camera Snap Flag",
            Address = GameFlags.CameraInputH.GetAddress()
        };
        CameraInputV = new GameFlag
        {
            FlagName = "Camera Snap Flag",
            Address = GameFlags.CameraInputV.GetAddress()
        };
        CameraCenter = new GameFlag
        {
            FlagName = "Camera Snap Flag",
            Address = GameFlags.CameraCenter.GetAddress()
        };
        Snap = new GameFlag
        {
            FlagName = "Camera Snap Flag",
            Address = GameFlags.CameraSnap.GetAddress()
        };
        AccelHack = new GameFlag
        {
            FlagName = "Camera Acceleration",
            Address = GameFlags.CameraAccellerationHack.GetAddress()
        };
        DeaccelHack = new GameFlag
        {
            FlagName = "Camera Deceleration",
            Address = GameFlags.CameraDecellertaionHack.GetAddress()
        };
        Speed = new GameFlag
        {
            FlagName = "Camera Speed",
            Address = GameFlags.CameraSpeed.GetAddress()
        };
        MenuOpen = new GameFlag
        {
            FlagName = "Menu Open",
            Address = GameFlags.MenuOpen.GetAddress()
        };
        
        success = true;
        Initialised = true;
        return success;
    }

    public override void OnFrame()
    {
        var menuOpen = KhEngine.ReadByte(MenuOpen.Address);
        var currentSpeedH = KhEngine.ReadFloat(CurSpeedH.Address);
        var currentSpeedV = KhEngine.ReadFloat(CurSpeedV.Address);
        var difH = currentSpeedH - LastSpeedH;
        var difV = currentSpeedV - LastSpeedV;

        var cameraCenter = KhEngine.ReadFloat(CameraCenter.Address);
        var cameraSpeed = KhEngine.ReadFloat(Speed.Address);

        var cameraInputH = KhEngine.ReadFloat(CameraInputH.Address);
        var cameraInputV = KhEngine.ReadFloat(CameraInputV.Address);
        
        if (menuOpen == 0)
        {
            if (cameraCenter > 1)
            {
                KhEngine.WriteFloat(CameraCenter.Address, (float)(cameraCenter - CenterSpeed));
            }
            if (Math.Abs(cameraSpeed) == 1.0)  // This way it works for inverted camera
            {
                var speedMinusFour = KhEngine.ReadFloat(Speed.Address - 4);
                KhEngine.WriteFloat(Speed.Address, (float)(cameraSpeed * OverallSpeed));
                KhEngine.WriteFloat(Speed.Address - 4, (float)(speedMinusFour * OverallSpeedV));
            }
           
		
            if (currentSpeedH != 0)
            {
                if(Math.Abs(cameraInputH) > 0.05)
                {
                    KhEngine.WriteFloat(CurSpeedH.Address,
                        (float)(Math.Min(Math.Max(currentSpeedH + cameraInputH * AccelerationSpeed, -0.44), 0.44)));
                }
                else
                {
                    KhEngine.WriteFloat(CurSpeedH.Address, (float)(currentSpeedH * (1.0 - DeaccelerationSpeed * 10)));
                }
            }
            if (currentSpeedV != 0)
            {
                if (Math.Abs(cameraInputV) > 0.05) 
                {
                    KhEngine.WriteFloat(CurSpeedV.Address,
                        (float)(Math.Min(Math.Max(currentSpeedV - cameraInputV * AccelerationSpeedV, -0.44), 0.44)));
                }
                else
                {
                    KhEngine.WriteFloat(CurSpeedV.Address, (float)(currentSpeedV * (1.0 - DeaccelerationSpeedV * 10)));
                }
                
            }

            LastSpeedH = currentSpeedH;
            LastSpeedV = currentSpeedV;
        }
    }
}