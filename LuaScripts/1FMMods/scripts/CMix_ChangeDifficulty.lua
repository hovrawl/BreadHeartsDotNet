LUAGUI_NAME = "CMix_ChangeDifficulty"
LUAGUI_AUTH = "Xendra"
LUAGUI_DESC = "Allows you to change difficulty in the config menu"


local offset = 0x3A0606
local soraPointer = 0x2534680 - offset
local configOpen = 0x2E8F288 - offset
local configPosition = 0x2E95578 - offset
local difficulty = 0x2DFBDFC - offset
local menu = 0x2E8EFB0 - offset
local swapped = ReadByte(0x22D6C7E - offset)
local cooldown = 0
local startCooldown = 10

function _OnInit()
	if GAME_ID == 0xAF71841E and ENGINE_TYPE == "BACKEND" then
		canExecute = true
		ConsolePrint("CMix_ChangeDifficulty Installed")
	else
		ConsolePrint("CMix_ChangeDifficulty -- FAILED --")
	end
end


function _OnFrame()
	if not canExecute then
		goto done
	end
	if cooldown > 0 then
		cooldown = cooldown - 1
	end
	update_text()
	if cooldown <= 0 and ReadByte(menu) ~= 0 then
		if ReadByte(configOpen) == 0x03 and ReadByte(configPosition) == 0x06 then
			-- x button
			if (ReadByte(0x233D035-0x3A0606)//(0x40-(32*swapped)))%2 == 1 then
				increase_difficulty()
			end
			-- dpad right
			if (ReadByte(0x233D034-0x3A0606)//(0x20-(32*swapped)))%2 == 1 then
				increase_difficulty()
			end
			-- dpad left
			if (ReadByte(0x233D034-0x3A0606)//(0x80-(32*swapped)))%2 == 1 then
				decrease_difficulty()
			end
		end
	end
	::done::
end

function increase_difficulty()
	cooldown = startCooldown
	if ReadByte(difficulty) < 2 then
		WriteByte(difficulty, ReadByte(difficulty) + 1)
	else
		WriteByte(difficulty, 0x00)
	end
	
end

function decrease_difficulty()
	cooldown = startCooldown
	if ReadByte(difficulty) > 0 then
		WriteByte(difficulty, ReadByte(difficulty) - 1)
	else
		WriteByte(difficulty, 0x02)
	end
	
end


function update_text()

	local text = 0x2E19655 - offset
	WriteLong(text, 0x4601524547015833)
	WriteLong(text+0x08, 0x494B52454C470149)
	WriteLong(text+0x10, 0x0F014C584D5B0248)
	WriteLong(text+0x18, 0x0000000000580F57)
	WriteLong(text+0x20, 0x0000000000000000)
	WriteLong(text+0x22, 0x0000000000000000)

end