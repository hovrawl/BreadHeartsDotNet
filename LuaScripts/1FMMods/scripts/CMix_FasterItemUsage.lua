LUAGUI_NAME = "CMix_FasterItemUsage"
LUAGUI_AUTH = "Xendra"
LUAGUI_DESC = "Allows you to exit the item animation faster"


-- Sora Item: 0x3E
-- Ally Item: 0x3F

local offset = 0x3A0606
local soraPointer = 0x2534680 - offset
local cancelTime = 30.0

function _OnInit()
	if GAME_ID == 0xAF71841E and ENGINE_TYPE == "BACKEND" then
		canExecute = true
		ConsolePrint("CMix_FasterItemUsage Installed")
	else
		ConsolePrint("CMix_FasterItemUsage -- FAILED --")
	end
end



function _OnFrame()
	if not canExecute then
		goto done
	end
	
	local currentAnim = ReadLong(soraPointer)+0x164
	local animationTime = ReadFloat(ReadLong(soraPointer)+0x16C, true)
	
	if ReadByte(currentAnim, true) == 0x3E or ReadByte(currentAnim, true) == 0x3F then
		if animationTime > cancelTime then
			local animCancel = ReadLong(soraPointer)
			WriteByte(animCancel, 0x03, true)
		end
	end

	
	::done::
end




