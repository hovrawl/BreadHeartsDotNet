LUAGUI_NAME = "CMix_FasterGuardCancel"
LUAGUI_AUTH = "Xendra"
LUAGUI_DESC = "Allows you to exit the guard animation faster on the ground"


local offset = 0x3A0606
local soraPointer = 0x2534680 - offset
local cancelTime = 24.0

function _OnInit()
	if GAME_ID == 0xAF71841E and ENGINE_TYPE == "BACKEND" then
		canExecute = true
		ConsolePrint("CMix_FasterGuardCancel Installed")
	else
		ConsolePrint("CMix_FasterGuardCancel -- FAILED --")
	end
end



function _OnFrame()
	if not canExecute then
		goto done
	end
	
	local currentAnim = ReadLong(soraPointer)+0x164
	local animationTime = ReadFloat(ReadLong(soraPointer)+0x16C, true)
	local airborneStatus = ReadFloat(ReadLong(soraPointer)+0x70, true)
	if airborneStatus == 0x00 then
		if ReadByte(currentAnim, true) == 0xD4 then
			if animationTime > cancelTime then
				local animCancel = ReadLong(soraPointer)
				WriteByte(animCancel, 0x03, true)
			end
		end
	end
	
	::done::
end




