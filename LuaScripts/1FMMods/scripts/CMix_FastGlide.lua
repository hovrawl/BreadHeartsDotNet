LUAGUI_NAME = "CMix_FastGlide"
LUAGUI_AUTH = "Xendra"
LUAGUI_DESC = "Makes glide faster so Superglide can be replaced."

local offset = 0x3A0606
local momentum = 0x42D5FC - offset
local soraPointer = 0x2534680 - offset
local currentAnim = ReadByte(ReadLong(soraPointer)+0x164, true)

function _OnInit()
	if GAME_ID == 0xAF71841E and ENGINE_TYPE == "BACKEND" then
		canExecute = true
		ConsolePrint("CMix_FastGlide - installed")
	else
		ConsolePrint("CMix_FastGlide - failed")
	end
end

function _OnFrame()
	local speed = 8.0
	currentAnim = ReadByte(ReadLong(soraPointer)+0x164, true)
	if currentAnim == 0x71 or currentAnim == 0x73 or currentAnim == 0x74 then
		speed = 20.0
	end
	WriteFloat(momentum, speed)
end


