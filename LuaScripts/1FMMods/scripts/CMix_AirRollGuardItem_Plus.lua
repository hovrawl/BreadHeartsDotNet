LUAGUI_NAME = "CMix_AirRollGuardItem_Plus"
LUAGUI_AUTH = "Xendra / KSX"
LUAGUI_DESC = "Air Dodge, Guard, and Item. Customizable air stall time. Built in cancelling."


-- AIRANIMCHECK HAS A BUG THAT MAKES MAGIC DROP YOU TO THE GROUND
-- So we will set your last thing whether it was magic or item to determine


-- Customizable Timings
local guardStallTime = 33.5
local rollStallTime = 28.0
local itemStallTime = 25.0
local flyingForceSquareFrames = 0
--
local offset = 0x3A0606
local airRoll = 0x2A3410 - offset -- 85 Default, 82 Forced
local soraPointer = 0x2534680 - offset
local sorazposition = ReadLong(0x23ED050 - offset)+0x14, true
local zcord = ReadFloat(sorazposition, true)
local airItemCheck = 0x28FC0F - offset
local airAnimCheck = 0x29EF9D - offset -- 74 Default, 73 Forced

local lastMenuType = 0x5255B4 - offset
local currentCommandMenu = 0x284EE10 - offset

local stateFlag = 0x2863958 - offset
local forceSquare = 0x2A3406 - offset
local swapped = ReadByte(0x22D6C7E - offset)
local world = 0x233CB4C - offset


function _OnInit()
	if GAME_ID == 0xAF71841E and ENGINE_TYPE == "BACKEND" then
		ConsolePrint("CMix_AirRollGuardItem_Plus Installed")
		canExecute = true
	end
end


function _OnFrame()
	if canExecute == true then
		local airStall = false
		local currentAnim = ReadLong(soraPointer)+0x164
		local animID = ReadByte(currentAnim, true)
		local forceAnim = ReadLong(soraPointer)+0x168, true
		local forceAnimID = ReadByte(forceAnim, true)
		

		
		if (ReadByte(stateFlag) ~ 0x20) < ReadByte(stateFlag) then -- If flying, force square presses
			if ReadByte(0x233D037 - offset) == 0 and (ReadByte(0x233D035 - offset)//(0x80-(32*swapped)))%2 == 1 then
				flyingForceSquareFrames = 4
			end
		
		end
		
		if flyingForceSquareFrames == 1 then
			flyingForceSquareFrames = 0
			WriteByte(forceSquare, 0x84)
		elseif flyingForceSquareFrames > 0 then
			WriteByte(forceSquare, 0x82)
			flyingForceSquareFrames = flyingForceSquareFrames- 1
		end
		
		sorazposition = ReadLong(0x23ED050 - offset)+0x14, true
		-- Enable Air Roll
		WriteByte(airRoll, 0x82)
		-- Enable Air Item
		WriteByte(airItemCheck, 0x73)
		local animcheck = 0x74
		
		-- If you enter shortcuts, set last menu type to 1
		if ReadByte(currentCommandMenu) == 5 then
			WriteByte(lastMenuType, 1)
		end
		-- If you were in the item menu last, enable aerial ground anims
		if ReadByte(lastMenuType) == 2 then
			animcheck = 0x73
		end
		WriteByte(airAnimCheck, animcheck)
		-- Grab sora's last position before doing air abilities
		local storeAnim = false

		if animID ~= 0xDC and animID ~= 0xD4 and animID ~= 0x3E and animID ~= 0x3F then
			storeAnim = true
		end
		
		if forceAnimID <= 0x0A then
			storeAnim = true
		end
		
		
		
		if animID == 0xDC or animID == 0xD4 or animID == 0x3E or animID == 0x3F then
			airStall = true
		end
		
		local airborneStatus = ReadFloat(ReadLong(soraPointer)+0x70, true)
		
		if airborneStatus ~= 0x00 then
		
		-- Stop stalling a bit before the animation ends
		
			local animationTime = ReadFloat(ReadLong(soraPointer)+0x16C, true)
			if animationTime < 28.0 and animID == 0xD5 then -- If Countering in the air
				airStall = true
				storeAnim = false
			end
			if animID == 0x8A or animID == 0x84 or animID == 0x85 or animID == 0x86 or animID == 0x87 or animID == 0x88 or animID == 0x89 then -- If Magic in the air
				if animationTime <= 33.0 then
					airStall = true
					storeAnim = false
				end
			end
			if animID == 0xD4 and animationTime > guardStallTime then
				airStall = false
				WriteByte(forceAnim, 0x0A, true)
				local animCancel = ReadLong(soraPointer)
				WriteByte(animCancel, 0x03, true)
			end
			
			if animID == 0xDC and animationTime > rollStallTime then
				airStall = false
			end
			
			if animID == 0x3E or animID == 0x3F then
				if animationTime > itemStallTime then
					airStall = false
				end
			end
			if ReadByte(world) == 9 then
				airStall = false
			end
			
			if storeAnim == true then
				zcord = ReadFloat(sorazposition, true)
			end
			
			if airStall == true then
				WriteFloat(sorazposition, zcord, true)
			end
		end
	end
end


