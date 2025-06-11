LUAGUI_NAME = "CMix_QuickItem"
LUAGUI_AUTH = "Xendra"
LUAGUI_DESC = "Press R2 to use items"


local offset = 0x3A0606
local soraPointer = 0x2534680 - offset
local command = 0x52558C -offset
local cooldown = 0
local delayTargets = {1, 2}
local baseInputDelay = 3
local inputDelay = baseInputDelay
local releaseDelay = 3
local usageFinished = true
local soraItemSlots = 0x2DE59F6 - offset
local soraItemSlotAmount = 0x2DE59F5 - offset
local inputLength = 0
local soraPointer = 0x2534680 - offset
local animCancel = ReadLong(soraPointer)
local blockItemInput = false

local swapped = ReadByte(0x22D6C7E - 0x3A0606)
local itemInput = (ReadByte(0x233D035-0x3A0606)//(02-(32*swapped)))%2 == 1


function _OnInit()
	if GAME_ID == 0xAF71841E and ENGINE_TYPE == "BACKEND" then
		canExecute = true
		ConsolePrint("CMix_QuickItem Installed")
	else
		ConsolePrint("CMix_QuickItem -- FAILED --")
	end
end

function check_cooldown_input_block()
	if cooldown > 0 and not itemInput then
		blockItemInput = true
	end
	if cooldown == 0 then
		blockItemInput = false
	end
end



function _OnFrame()
	itemInput = (ReadByte(0x233D035-0x3A0606)//02)%2 == 1
	if not canExecute then
		goto done
	end

	
	
	animCancel = ReadLong(soraPointer)
	if itemInput then
		inputLength = inputLength + 1
	else
		inputLength = 0
	end
	
	if inputLength >= 4 then
		quick_item()
	end
	
	-- if input length is 8, back out by 1 step in the menu
	
	
	
	local input = itemInput
	if blockItemInput == true then
		input = false
	end
	
	if inputDelay < baseInputDelay then
		if inputDelay == baseInputDelay - 2 then
			trigger_menu()
		elseif inputDelay == baseInputDelay - 1 and not input then
			trigger_menu()
			WriteByte(command, 0)
			inputDelay = baseInputDelay
			usageFinished = true
		end
		if inputDelay < baseInputDelay - 1 then
			inputDelay = inputDelay + 1
		end
	end
	if cooldown > 0 then
		cooldown = cooldown - 1
	end
	::done::
end

-- don't do 2nd quick item input if the selected item is a power stone

function quick_item()
	local currentAnim = ReadLong(soraPointer)+0x164
	
	
	if cooldown <= 0 then
		valid = true
	end
	if ReadByte(currentAnim, true) == 0x3E then
		valid = false
	end
	local allEmpty = true
	for i= 0, ReadByte(soraItemSlotAmount) - 1 do
		if ReadByte(soraItemSlots + i) ~= 00 then
			allEmpty = false
			break
		end
	end
	if allEmpty == true then
		valid = false
	end
	if usageFinished == false then
		valid = false
	end
	
	if ReadByte(animCancel, true) == 7 then
		valid = false
	end
	
	
	if valid == true then
		usageFinished = false
		inputDelay = 0
		cooldown = 15
		WriteByte(command, 2)
		WriteByte(0x284EE10 - offset, 2)
		WriteByte(0x284EE14 - offset, 2)
		trigger_menu()
	end
end

function trigger_menu()
	WriteInt(0x23D0600-offset, 0x01)
	WriteInt(0x232A444-offset, 0x01)
	
end