using KHData.Enums;
using KHData.Flags;
using KHEngine.Extensions;
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
    
    public override string Author => "Denhonator";
    
    public override string Name => "Fast Camera";

    public override string Description => "Allows for faster camera control.";
    
    public override bool Initialise(Engine.KHEngine khEngine)
    {
        var success = true;

        KhEngine = khEngine;
        
        Accel = KhEngine.GameFlagsRepo.GetFlag(GameFlags.CameraAcceleration);
        Deaccel = KhEngine.GameFlagsRepo.GetFlag(GameFlags.CameraDeceleration);
        CurSpeedV = KhEngine.GameFlagsRepo.GetFlag(GameFlags.CameraCurrentSpeedV);
        CurSpeedH = KhEngine.GameFlagsRepo.GetFlag(GameFlags.CameraCurrentSpeedH);
        CameraInputH = KhEngine.GameFlagsRepo.GetFlag(GameFlags.CameraInputH);
        CameraInputV = KhEngine.GameFlagsRepo.GetFlag(GameFlags.CameraInputV);
        CameraCenter = KhEngine.GameFlagsRepo.GetFlag(GameFlags.CameraCenter);
        Snap = KhEngine.GameFlagsRepo.GetFlag(GameFlags.CameraSnap);
        AccelHack = KhEngine.GameFlagsRepo.GetFlag(GameFlags.CameraAccelerationHack);
        DeaccelHack = KhEngine.GameFlagsRepo.GetFlag(GameFlags.CameraDecelerationHack);
        Speed = KhEngine.GameFlagsRepo.GetFlag(GameFlags.CameraSpeed);
        MenuOpen = KhEngine.GameFlagsRepo.GetFlag(GameFlags.MenuOpen);
        
        Initialised = success;
        return success;
    }

    public override void OnFrame()
    {
        //var menuOpen = KhEngine.ReadByte(MenuOpen.Address);
        // var currentSpeedH = KhEngine.ReadFloat(CurSpeedH.Address);
        // var currentSpeedV = KhEngine.ReadFloat(CurSpeedV.Address);
        // var difH = currentSpeedH - LastSpeedH;
        // var difV = currentSpeedV - LastSpeedV;
        //
        // var cameraCenter = KhEngine.ReadFloat(CameraCenter.Address);
        // var cameraSpeed = KhEngine.ReadFloat(Speed.Address);
        //
        // var cameraInputH = KhEngine.ReadFloat(CameraInputH.Address);
        // var cameraInputV = KhEngine.ReadFloat(CameraInputV.Address);
        
        MenuOpen.ReadMemory(KhEngine);

        if (MenuOpen.ValueAsBool) return;
        
        CurSpeedH.ReadMemory(KhEngine);
        CurSpeedV.ReadMemory(KhEngine);
        CameraCenter.ReadMemory(KhEngine);
        Speed.ReadMemory(KhEngine);
        CameraInputH.ReadMemory(KhEngine);
        CameraInputV.ReadMemory(KhEngine);
       
        
        var currentSpeedH = CurSpeedH.ValueAsFloat;
        var currentSpeedV = CurSpeedV.ValueAsFloat;
        var difH = currentSpeedH - LastSpeedH;
        var difV = currentSpeedV - LastSpeedV;

        var cameraCenter = CameraCenter.ValueAsFloat;
        var cameraSpeed = Speed.ValueAsFloat;

        var cameraInputH = CameraInputH.ValueAsFloat;
        var cameraInputV = CameraInputV.ValueAsFloat;
            
        if (cameraCenter > 1)
        {
            //KhEngine.WriteFloat(CameraCenter.Address, (float)(cameraCenter - CenterSpeed));
            CameraCenter.WriteMemory(KhEngine, (float)(cameraCenter - CenterSpeed));
        }
        if (Math.Abs(cameraSpeed) == 1.0)  // This way it works for inverted camera
        {
            var speedMinusFour = KhEngine.ReadFloat(Speed.Address - 4);
            //KhEngine.WriteFloat(Speed.Address, (float)(cameraSpeed * OverallSpeed));
            Speed.WriteMemory(KhEngine, (float)(cameraSpeed * OverallSpeed));
            KhEngine.WriteFloat(Speed.Address - 4, (float)(speedMinusFour * OverallSpeedV));

        }
           
		
        if (currentSpeedH != 0)
        {
            if(Math.Abs(cameraInputH) > 0.05)
            {
                CurSpeedH.WriteMemory(KhEngine, (float)(Math.Min(Math.Max(currentSpeedH + cameraInputH * AccelerationSpeed, -0.44), 0.44)));

                // KhEngine.WriteFloat(CurSpeedH.Address,
                //     (float)(Math.Min(Math.Max(currentSpeedH + cameraInputH * AccelerationSpeed, -0.44), 0.44)));
            }
            else
            {
                CurSpeedH.WriteMemory(KhEngine, (float)(currentSpeedH * (1.0 - DeaccelerationSpeed * 10)));

                //KhEngine.WriteFloat(CurSpeedH.Address, (float)(currentSpeedH * (1.0 - DeaccelerationSpeed * 10)));
            }
        }
        if (currentSpeedV != 0)
        {
            if (Math.Abs(cameraInputV) > 0.05) 
            {
                CurSpeedV.WriteMemory(KhEngine, (float)(Math.Min(Math.Max(currentSpeedV - cameraInputV * AccelerationSpeedV, -0.44), 0.44)));
                // KhEngine.WriteFloat(CurSpeedV.Address,
                //     (float)(Math.Min(Math.Max(currentSpeedV - cameraInputV * AccelerationSpeedV, -0.44), 0.44)));
            }
            else
            {
                CurSpeedV.WriteMemory(KhEngine, (float)(currentSpeedV * (1.0 - DeaccelerationSpeedV * 10)));
                // KhEngine.WriteFloat(CurSpeedV.Address, (float)(currentSpeedV * (1.0 - DeaccelerationSpeedV * 10)));
            }
                
        }

        LastSpeedH = currentSpeedH;
        LastSpeedV = currentSpeedV;
    }
}