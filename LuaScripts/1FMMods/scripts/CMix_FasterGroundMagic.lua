LUAGUI_NAME = "CMix_FasterMagic"
LUAGUI_AUTH = "Xendra"
LUAGUI_DESC = "Allows you to exit magic animations faster"





local offset = 0x3A0606
local soraPointer = 0x2534680 - offset
-- Customizable Magic Cancel Timings
local fastFireCancel = 5.0
local blizzardCancel = 31.0
local thunderCancel = 35.0
local cureCancel = 50.0
local gravityCancel = 31.0
local stopCancel = 35.0
local aeroCancel = 32.0


function _OnInit()
	if GAME_ID == 0xAF71841E and ENGINE_TYPE == "BACKEND" then
		canExecute = true
		ConsolePrint("CMix_FasterGroundMagic Installed")
	else
		ConsolePrint("CMix_FasterGroundMagic -- FAILED --")
	end
end

-- Fire Windup: 0x36
-- Blizzard: 0x37
-- Thunder: 0x38
-- Cure: 0x39
-- Gravity: 0x3A
-- Stop: 0x3B
-- Aero: 0x3C
-- Fire Cast: 0x3D

function _OnFrame()
	if not canExecute then
		goto done
	end
	local airborneStatus = ReadFloat(ReadLong(soraPointer)+0x70, true)
	local currentAnim = ReadLong(soraPointer)+0x164
	local animationTime = ReadFloat(ReadLong(soraPointer)+0x16C, true)
	local allowCancel = false
	
	

	if ReadByte(currentAnim, true) == 0x3D or ReadByte(currentAnim, true) == 0x8A then
		if animationTime > fastFireCancel then
			allowCancel = true
		end
	end
	
	if ReadByte(currentAnim, true) == 0x37 or ReadByte(currentAnim, true) == 0x84 then
		if animationTime > blizzardCancel then
			allowCancel = true
		end
	end
	
	if ReadByte(currentAnim, true) == 0x38 or ReadByte(currentAnim, true) == 0x85 then
		if animationTime > thunderCancel then
			allowCancel = true
		end
	end
	
	if ReadByte(currentAnim, true) == 0x39 or ReadByte(currentAnim, true) == 0x86 then
		if animationTime > cureCancel then
			allowCancel = true
		end
	end
	
	if ReadByte(currentAnim, true) == 0x3A or ReadByte(currentAnim, true) == 0x87 then
		if animationTime > gravityCancel then
			allowCancel = true
		end
	end
	
	if ReadByte(currentAnim, true) == 0x3B or ReadByte(currentAnim, true) == 0x88 then
		if animationTime > stopCancel then
			allowCancel = true
		end
	end
	
	if ReadByte(currentAnim, true) == 0x3c or ReadByte(currentAnim, true) == 0x89 then
		if animationTime > aeroCancel then
			allowCancel = true
		end
	end
	
	if allowCancel == true then
		local animCancel = ReadLong(soraPointer)
		WriteByte(animCancel, 0x03, true)
	end
	
	::done::
end




