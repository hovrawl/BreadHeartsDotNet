LUAGUI_NAME = "CMix_AnimCancel"
LUAGUI_AUTH = "Xendra"
LUAGUI_DESC = "Allows you to cancel attacks into other actions, and Guard / Dodge into each other."

local offset = 0x3A0606
local swapped = ReadByte(0x22D6C7E - offset)

local soraPointer = 0x2534680 - offset
local menuStatus = 0x232A600 - offset
local buttonPress = 0x233D035 - offset
local cancelFinished = true
local forceSquareInput = 0x2A3406 - offset
local forceCircleInput = 0x2A33A4 - offset
local leftStickInput = 0x233D037 - offset
local forceSquareResetTimer = 0
local forceCircleResetTimer = 0
local world = 0x233CB4C - offset

local cancelAnimations = {0x6E, 0xC8, 0xC9, 0xCA, 0xCB, 0xCC, 0xCD, 0xCE, 0xD1, 0xCF, 0x70, 0xD2, 0xD3, 0xD5, 0xD7, 0xD8, 0xD9, 0xDA, 0x0C, 0xD0}
local jumpCancelExtraAnims = {0xD4, 0xDC}
airborneStatus = ReadFloat(ReadLong(soraPointer)+0x70, true)



function _OnInit()
	if GAME_ID == 0xAF71841E and ENGINE_TYPE == "BACKEND" then
		ConsolePrint("Critical Mix Animation Cancelling Installed")
		canExecute = true
	end
end


function _OnFrame()
	if canExecute == true then
		airborneStatus = ReadFloat(ReadLong(soraPointer)+0x70, true)
		if forceSquareResetTimer == 1 then
			WriteByte(forceSquareInput, 0x84)
		end
		if forceSquareResetTimer > 0 then
			forceSquareResetTimer = forceSquareResetTimer - 1
		end
		
		if forceCircleResetTimer == 1 then
			WriteByte(forceCircleInput, 0x74)
		end
		if forceCircleResetTimer > 0 then
			forceCircleResetTimer = forceCircleResetTimer - 1
		end
		
		local cancelInput = false
		local cancelButton = "square"
		if (ReadByte(0x233D035-0x3A0606)//(0x80-(32*swapped)))%2 == 1 then
			if (ReadByte(0x233D035-0x3A0606)//0x04)%2 ~= 1 then -- Not L1
				cancelInput = true
			end
		elseif (ReadByte(0x233D035-0x3A0606)//(0x20-(32*swapped)))%2 == 1 then
			cancelInput = true
			cancelButton = "circle"
		end
		
		if cancelInput then
			cancelFinished = true
		end
		
		local canCancel = false
		local currentAnim = ReadLong(soraPointer)+0x164
		local animationTime = ReadFloat(ReadLong(soraPointer)+0x16C, true)
		local animCancel = ReadLong(soraPointer)
		
		for i, anim in pairs(cancelAnimations) do
			if anim == ReadByte(currentAnim, true) then
				canCancel = true
				break
			end
		end
		
		if ReadByte(world) == 9 then
			if ReadByte(currentAnim, true) == 0 or ReadByte(currentAnim, true) == 0x7D then
				canCancel = true
			end
		end
		
		if ReadByte(leftStickInput) == 0 and ReadByte(currentAnim, true) == 0xDC then -- allow guarding out of dodge
			canCancel = true
		end
		
		if ReadByte(leftStickInput) ~= 0 and ReadByte(currentAnim, true) == 0xD4 and ReadByte(world) ~= 9 then -- allow dodging out of guard
			canCancel = true
		end

		if ReadByte(world) == 9 then
			airborneStatus = 0
		end
		if airborneStatus == 0x00 and cancelButton == "circle" then
			for i, anim in pairs(jumpCancelExtraAnims) do
				if anim == ReadByte(currentAnim, true) then
					canCancel = true
					break
				end
			end
		end
		if airborneStatus ~= 0x00 and cancelButton == "circle" then
			canCancel = false
		end
		-- Aerial Rush
		if ReadByte(currentAnim, true) == 0xD6 and airborneStatus ~= 0x00 and animationTime >= 15.0 then
			WriteByte(animCancel, 0x03, true)
		end
		-- Hurricane Blast
		if ReadByte(currentAnim, true) == 0xD1 and airborneStatus ~= 0x00 and animationTime >= 22.0 then
			WriteByte(animCancel, 0x03, true)
		end
		if cancelInput and canCancel == true and cancelFinished == true then
			
			WriteByte(animCancel, 0x03, true)
			if cancelButton == "square" then
				force_defensive_action()
			elseif cancelButton == "circle" then
				force_circle_action()
			end
			cancelFinished = false
		end
	end
end

function force_defensive_action()
	if ReadByte(world) ~= 9 then
		WriteByte(forceSquareInput, 0x82)
	end
	forceSquareResetTimer = 3
end

function force_circle_action()
	WriteByte(forceCircleInput, 0x72)
	forceCircleResetTimer = 3
end