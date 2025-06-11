LUAGUI_NAME = "CMix_QualityOfLife"
LUAGUI_AUTH = "Xendra / KSX / Denhonator / TopazTK"
LUAGUI_DESC = "Compiles many QoL features into a single script."


local canExecute = false

local lastInput = 0
local lastFade = 0

local offset = 0x3A0606

local lastCutscene = 0
local lastSkippable = 0

local world = 0x233CADC - 0x3A0606
local room = 0x233CB44 - offset
local flag = 0x233CB48 - offset
camera = 0x1E0D74 - offset -- 0x84 Default
campatchbypassxblock = 0x1DD5A9 - offset -- 0x73 Default
campatchxoutofboundsfix = 0x1DD453 - offset -- 0x85 Default
campatchwallrotation = 0x1DD89C - offset
camobjectrestore = 0x1DD628 - offset
campatchinsiderotation = 0x1E4357 - offset -- 0x72 Default
campatchrotationblock = 0x1E4EEF - offset -- 0x77 Default
campatchup = 0x1E2165 - offset -- 0x76 Default
camwallrestore = 0x1E2113 - offset
camsmoothwall = 0x1E2B97 - offset -- 0x74 Default
camcorner = 0x1E4EF9 - offset -- 0x77 Default
camsmoothinside = 0x1E4BBE - offset -- 0x7A Default
caminsiderestore = 0x1DD628 - offset
camupdownfix = 0x1DD464 - offset

local worldWarpBase = 0x50B940
local cutsceneFlagBase = 0x2DE65D0-0x200 - offset
local djProgressFlag = 0x2DE79D0+0x6C+0x40
local neverlandProgressFlag = 0x2DE79D0+0x6C+0xED
local neverlandStatus = 0x2DE78C7 - offset
local traverseStatus = 0x2DE78C0 - offset

local overallSpeed = 1.5
local accelerationSpeed = 0.01
local accel = 0x3E7F58 - offset
local deaccel = 0x3E7F5C - offset
local curSpeedV = 0x25344C0 - offset
local curSpeedH = 0x25344C4 - offset
local cameraInputH = 0x233D060 - offset
local cameraInputV = 0x233D064 - offset
-----
local snap = 0x1DD299 - offset
local accelHack = 0x1E2924 - offset
local deaccelHack = 0x1E291B - offset
local speed = 0x503A1C - offset

local versionCheck = 0x3D6AB8 - offset

local lastSpeedH = 0
local lastSpeedV = 0

local extraSafety = false
local offset = 0x3A0606
local addgummi = 0
local lastInput = 0
local prevHUD = 0
local revertCode = false
local removeWhite = 0
local lastDeathPointer = 0
local soraHUD = 0x280EB1C - offset
local soraHP = 0x2D592CC - offset
local stateFlag = 0x2863958 - offset
local deathCheck = 0x2978E0 - offset
local safetyMeasure = 0x297746 - offset
local whiteFade = 0x233C49C - offset
local blackFade = 0x4D93B8 - offset
local closeMenu = 0x2E90820 - offset
local deathPointer = 0x23944B8 - offset
local warpTrigger = 0x22E86DC - offset
local warpType1 = 0x233C240 - offset
local warpType2 = 0x22E86E0 - offset
local title = 0x233CAB8 - offset
local continue = 0x2DFC5D0 - offset
local config = 0x2DFBDD0 - offset
local cam = 0x503A18 - offset

local blacklist1 = 0x541FA0 - offset
local scan = 0x2A058C - offset


FieldOfView = 600
CamLeftRightPosition = -50
CamHigh = -150
camy = 0x253466C - offset
camx = 0x2534678 - offset
camz = 0x2534674 - offset
fovontarget = 0x503958 - offset
fovclimb= 0x503978 - offset
fovhold = 0x503998 - offset
fovclimbpole = 0x5039B8 - offset
fovslideminigame = 0x2DE5794 - offset

local Trinity = 0x1A06CF - offset
local Chests = 0x2B12C3 - offset

local partymember1hudxpos = 0x523FB0 - offset
local partymember1hudypos = 0x523FB4 - offset
local partymember2hudxpos = 0x523FF0 - offset
local partymember2hudypos = 0x523FF4 - offset

function _OnInit()
    if GAME_ID == 0xAF71841E and ENGINE_TYPE == "BACKEND" then
        canExecute = true
        ConsolePrint("KH1 detected, running script")
		if ReadShort(deathCheck) == 0x2E74 then
			ConsolePrint("Global version detected")	
		elseif ReadShort(deathCheck-0x1C0) == 0x2E74 then
			deathCheck = deathCheck-0x1C0
			safetyMeasure = safetyMeasure-0x1C0
			extraSafety = false
			ConsolePrint("JP detected")
		end
		-- Enables instant camera centering
		if ReadInt(snap) == 0x0215EFBF then
			WriteInt(snap, 0x02357487)
		end
        if ReadInt(-0x22A5AA) == 0xC3C0940F then
            WriteArray(-0x22A5AA, { 0x0F, 0x9E, 0xC0, 0xC3 })
            WriteArray(-0x225763, { 0x7E, 0x10, 0x85, 0xDB })
        elseif ReadInt(-0x22A75A) == 0xC3C0940F then
            WriteArray(-0x22A75A, { 0x0F, 0x9E, 0xC0, 0xC3 })
            WriteArray(-0x225913, { 0x7E, 0x10, 0x85, 0xDB })
        end
    else
        ConsolePrint("KH1 not detected, not running script")
    end
	lastDeathPointer = ReadLong(deathPointer)
	WriteInt(Chests, 3107615744)
end

function _OnFrame()
	if not canExecute then
		goto done
	end
	EarlySkip()
	FastCameraModified()
	InstantGummi()
	SoftResetScript()
	Unskippable()
	TrinityInBattle()
	CameraPatches()
	NoR3Center()
	ComboMaster()
	WideFieldOfView()
	TextSpeed()
	SkipTitle()
	NoWeaponBlacklist()
	WriteArray(scan, {0x90, 0x90, 0x90, 0x90, 0x90, 0x90}) -- Enable Scan
	HudReposition()
	SaveMenu()
	IslandSkip()
	
	:: done ::
	
end

function IslandSkip()
	if ReadByte(world) == 0x01 and ReadByte(room) == 0x00 then
		ConsolePrint("Skipped Destiny Island")
		WriteByte(room, 0x09)
	end
end

function SaveMenu()
	if ReadByte(0x2DE5A44 - offset) > 0x00 and ReadByte(closeMenu) == 0x00 then
		WriteByte(0x2E1CBA0 - offset, 0x00)
		WriteByte(0x2E1CBA4 - offset, 0x01)
		WriteByte(0x2E1CBA8 - offset, 0x02)
		WriteByte(0x2E1CBAC - offset, 0x03)
		WriteByte(0x2E1CBB0 - offset, 0x04)
		WriteByte(0x2E1CB9C - offset, 0x05)
		WriteByte(0x2E1CC28 - offset, 0x03)
		WriteByte(0x2E8F450 - offset, 0x05)
		WriteByte(0x2E8F452 - offset, 0x05)
		WriteByte(0x2D64A5 - offset, 0x00)
	end
end

function HudReposition()
	WriteShort(partymember1hudxpos, 0x0049)
	WriteShort(partymember1hudypos, 0x00B2)
	WriteShort(partymember2hudxpos, 0x0049)
	WriteShort(partymember2hudypos, 0x006C)
end

function NoWeaponBlacklist()
	WriteByte(blacklist1, 0)
	WriteByte(blacklist1 +4, 0)
	WriteByte(blacklist1 +8, 0)
	WriteByte(blacklist1 +12, 0)
end

function SkipTitle()
	if ReadByte(0x2EE55EC - offset) == 0 then
		WriteByte(0x233CAB8 - offset, 1)
	end
end

function TextSpeed()
	WriteFloat(0x16EE9B - offset, 0)
end


function WideFieldOfView()
	WriteFloat(camy, FieldOfView)
	WriteFloat(camx, CamLeftRightPosition)
	WriteFloat(camz, CamHigh)
	WriteFloat(fovontarget, FieldOfView - 120)
	WriteFloat(fovclimb, FieldOfView)
	WriteFloat(fovclimbpole, FieldOfView)
	WriteFloat(fovhold, FieldOfView)
	WriteFloat(fovslideminigame, FieldOfView)
end



function ComboMaster()
	WriteByte(0x2A2F03 - offset, 0x71)
	WriteByte(0x2A2F1B - offset, 0x82)
end

function CameraPatches()
	local cameravalue = 0x85
	if ReadByte(world) == 0x05 and ReadByte(room) == 0x09 then -- Waterfall cavern fix
		cameravalue = 0x84
	end
	if ReadByte(world) == 0x06 then
		cameravalue = 0x84
	end
	WriteByte(camera, cameravalue)
	WriteByte(campatchbypassxblock, 0x72)
	WriteByte(campatchxoutofboundsfix, 0x81)
	WriteByte(camsmoothwall, 0x72)
	WriteByte(campatchup, 0x71)
	WriteByte(camcorner, 0x72)
	WriteByte(campatchrotationblock, 0x75)
	WriteByte(campatchinsiderotation, 0x7D)
	WriteByte(camsmoothinside, 0x7D)
	WriteByte(caminsiderestore, 0x81)
	WriteByte(camupdownfix, 0x82)
end


function NoR3Center()
	if ReadByte(0x1E19BE - offset) == 0x87 then
		WriteByte(0x1E19BE - offset, 0x86)
		ConsolePrint("Disable R3 Camera Central (1.0.0.2) - installed")
	elseif ReadByte(0x1E19BE - offset-0x1B0) == 0x87 then
		WriteByte(0x1E19BE - offset-0x1B0, 0x86)
		ConsolePrint("Disable R3 Camera Central (1.0) - installed")
	end
end

function TrinityInBattle()
	local dg = 0
	if ReadByte(0x2DE5E5F - offset) == 1 or ReadByte(0x2DE5E5F - offset) == 2 then
		dg = dg + 1
	end
	if ReadByte(0x2DE5E60 - offset) == 1 or ReadByte(0x2DE5E60 - offset) == 2 then
		dg = dg + 1
	end
	if dg >= 2 then
		WriteInt(Trinity, 0x03B90AEB) -- Forced
	else
		WriteInt(Trinity, 0x03B90A75) -- Default
	end
end


function Unskippable()
	
	local cutsceneNow = ReadInt(0x233AE74-0x3A0606)
	local skippableStatus = ReadByte(0x23944E4-0x3A0606)
	local summoning = ReadInt(0x2D5D62C-0x3A0606)
	local HUD = ReadFloat(0x280EB1C-0x3A0606)
	local blackFade = ReadByte(0x4D93B8-0x3A0606)
	if cutsceneNow > 0 and (ReadByte(world) == 4 or ReadByte(world) >= 0xF) and summoning == 0 then
		WriteByte(0x23944E4-0x3A0606, 1) --make skippable
	end
	
	lastSkippable = skippableStatus
	lastCutscene = cutsceneNow
end

function SoftReset()
	ConsolePrint("Soft reset")
	WriteByte(warpType1, 3)
	WriteByte(warpType2, 1)
	if ReadByte(title) == 0 then
		WriteByte(title, 1)
	end
	WriteByte(warpTrigger, 2)
end

function SoftResetScript()
	local input = ReadInt(0x233D034-offset)
	local savemenuopen = ReadByte(0x232A604-offset)


	if input == 3848 and lastInput ~= 3848 then
		SoftReset()
	end
	
	lastInput = input
	lastDeathPointer = ReadLong(deathPointer)
	
	if ReadFloat(soraHUD) == 1 and prevHUD < 1 then
		local f = io.open("autosave.dat", "wb")
		f:write(ReadString(continue, 0x16C00))
		f:close()
		ConsolePrint("Wrote autosave")
	end
	prevHUD = ReadFloat(soraHUD)
	
end

function EarlySkip()
    if ReadInt(-0x22A5AA) ~= 0xC3C09E0F and ReadInt(-0x22A75A) ~= 0xC3C09E0F then
        nowInput = ReadInt(0x233D034-0x3A0606)
        if canExecute and ReadInt(0x233AE74-0x3A0606)==1 then
            local curFade = math.min(ReadInt(0x233C450-0x3A0606)+20, 128)
            if curFade-30 > 0 and lastFade < curFade then
                WriteInt(0x233C49C-0x3A0606, 0) --white screen off
                WriteInt(0x233C450-0x3A0606, curFade) --canskip
                WriteInt(0x233C454-0x3A0606, curFade) --canskip
                WriteInt(0x233C458-0x3A0606, curFade) --canskip
                WriteInt(0x233C45C-0x3A0606, curFade) --canskip
                WriteInt(0x233C5B8-0x3A0606, 0) --canskip
                WriteInt(0x233CAA0-0x3A0606, 0) --canskip
                WriteInt(0x233CAA4-0x3A0606, 0) --canskip
            end
            lastFade = curFade
        end
        lastInput = nowInput
    end 
end


function FastCameraModified()
	local currentSpeedH = ReadFloat(curSpeedH)
	local currentSpeedV = ReadFloat(curSpeedV)
	local difH = currentSpeedH - lastSpeedH
	local difV = currentSpeedV - lastSpeedV
	
	if math.abs(ReadFloat(speed)) == 1.0 then -- This way it works for inverted camera
		WriteFloat(speed, ReadFloat(speed) * overallSpeed)
	end
	
	if math.abs(ReadFloat(cameraInputH)) > 0.05 then
		WriteFloat(curSpeedH, math.min(math.max(currentSpeedH + ReadFloat(cameraInputH) * accelerationSpeed, -0.44), 0.44))
	else
		WriteFloat(curSpeedH, currentSpeedH * (1.0 - accelerationSpeed * 10))
	end
	if math.abs(ReadFloat(cameraInputV)) > 0.05 then
		WriteFloat(curSpeedV, math.min(math.max(currentSpeedV - ReadFloat(cameraInputV) * accelerationSpeed, -0.44), 0.44))
	else
		WriteFloat(curSpeedV, currentSpeedV * (1.0 - accelerationSpeed * 10))
	end
	lastSpeedH = currentSpeedH
	lastSpeedV = currentSpeedV
end



function InstantGummi()
	local selection = ReadInt(0x503CEC-offset)
	local realSelection = selection
	local realWorld = ReadByte(0x503C04-offset)
	local soraWorld = ReadByte(0x233CADC-offset)
	local room = ReadByte(0x25346D0-offset)
	
	local monstroOpen = ReadByte(0x2DE78CA-offset) > 1
	local neverlandState = ReadByte(cutsceneFlagBase+0xB0D) < 0x14
	local deepJungleState = ReadByte(cutsceneFlagBase+0xB05) < 0x10

	WriteByte(worldWarpBase+0x2A-offset, deepJungleState and 0 or 0xE)
	WriteByte(worldWarpBase+0x2C-offset, deepJungleState and 0 or 0x2D)
	WriteByte(worldWarpBase+0x9A-offset, neverlandState and 6 or 0x7)
	WriteByte(worldWarpBase+0x9C-offset, neverlandState and 0x18 or 0x25)

	if room > 0 and soraWorld ~= selection then
		WriteInt(0x503CEC-offset, soraWorld)
	end
	
	-- Replace Neverland with Monstro at first
	if selection == 0x0D and ReadByte(neverlandStatus) == 2 then
		selection = 0x11
		WriteInt(0x503CEC-offset, selection)
	end
	if soraWorld == 0x0C and ReadByte(neverlandStatus) < 3 then
		WriteByte(neverlandStatus, 3)
	end
	-- Change warp to Hollow Bastion
	if selection == 25 then 
		selection = 15
		WriteInt(0x503CEC-offset, selection)
	end
	-- Change warp to Agrabah
	if selection == 21 then
		selection = 8
		WriteInt(0x503CEC-offset, selection)
	end
	
	
	
	-- Go directly to location
	local curDest = ReadInt(0x5041F0-offset)
	if curDest < 40 then
		selection = selection > 20 and 0 or selection
		WriteInt(0x5041F0-offset, selection)
		WriteInt(0x503C00-offset, selection)
		WriteInt(0x2685EEC-offset, 0)
	else
		WriteInt(0x503C00-offset, realSelection)
	end
	
	-- Cid Fix
	if ReadByte(traverseStatus) < 4 and soraWorld == 3 and ReadByte(0x233CB44 - offset) == 0x0A then
		WriteByte(0x233CB48 - offset, 2)
	end
end