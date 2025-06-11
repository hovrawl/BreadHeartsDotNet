LUAGUI_NAME = "CMix_JumpHeight"
LUAGUI_AUTH = "Xendra"
LUAGUI_DESC = "Increases Sora's Jump HEight"

local offset = 0x3A0606

local baseJump = 0x2D1F46C - offset
local highJump = 0x2D1F46E - offset


function _OnInit()
	if GAME_ID == 0xAF71841E and ENGINE_TYPE == "BACKEND" then
		ConsolePrint("CMix_JumpHeight Installed")
		canExecute = true
	end
end


function _OnFrame()
	if canExecute == true then
		local jumpMulti = 1.0
		if ReadByte(0x2DE5F0F - offset) >= 1 then -- matsutake
			jumpMulti = jumpMulti + 0.2
		end
		activate_accessories()
		WriteShort(baseJump, 210 * jumpMulti)
		WriteShort(highJump, 350 * jumpMulti)
	end
end



function activate_accessories()
	gravigun_band()
end

function gravigun_band()
	for i = 1, check_accessory_count(0x2D) do
		jumpMulti = jumpMulti + 0.2
	end
end



function check_accessory_count(id)
	local accessorySlots = 0x2DE59ED - offset
	local count = 0
	
	for i = 0, 7 do
		if id == ReadByte(accessorySlots + i) then
		count = count + 1
		end
	end
	return count
end
