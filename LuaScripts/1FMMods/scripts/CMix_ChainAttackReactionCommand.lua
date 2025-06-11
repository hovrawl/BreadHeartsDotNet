
LUAGUI_NAME = "CMix_ChainAttackReactionCommand"
LUAGUI_AUTH = "Xendra"
LUAGUI_DESC = "Adds chain attack Reaction Commands - Ability 28 / A8"

local offset = 0x3A0606
local rcOpacity = 0x2863394 - offset
local showingBurst = false
local soraPointer = 0x2534680 - offset
local currentAnim = ReadLong(soraPointer)+0x164
local animCancel = ReadLong(soraPointer)
local animationTime = ReadFloat(ReadLong(soraPointer)+0x16C, true)
local swapped = 0
local inputDelay = 4
local rcCommand = 0x2863390 - offset
local slot1item = ReadByte(0x2DE59F6)
local comboPosition = 0x29678A1 - offset

local burstTime = 48.0
local world = 0x233CADC - offset

local rikuEnabledGummi = 0x2DF18DC - offset -- Unused Gummi 5
local rikuStanceGummi = 0x2DF18DE - offset -- Unused Gummi 7

local burstAnims = {0xCB, 0xDA, 0xD9, 0xD2, 0xD7, 0xD8}
local airborneStatus = ReadFloat(ReadLong(soraPointer)+0x70, true)
local currentLinkItem = 0x2DE5F51 - offset
local linkedSpiritItem = 0x2DE5EFD - offset
local inMenu = 0x232A600 - offset

function _OnInit()
	if GAME_ID == 0xAF71841E and ENGINE_TYPE == "BACKEND" then
		ConsolePrint("CMix_ChainAttackReactionCommand Installed")
		canExecute = true
	end
end


function _OnFrame()
	if canExecute == true then
		currentAnim = ReadLong(soraPointer)+0x164
		animCancel = ReadLong(soraPointer)
		animationTime = ReadFloat(ReadLong(soraPointer)+0x16C, true)
		airborneStatus = ReadFloat(ReadLong(soraPointer)+0x70, true)
		disable_burst()
		
		if inputDelay < 4 then
			inputDelay = inputDelay + 1
		end
		if inputDelay == 1 or inputDelay == 2 then
			trigger_menu_press()
		elseif inputDelay == 3 then
			WriteByte(0x2DE59F6 - offset, slot1item)
		end
		local valid = check_ability_count(0x32)
		local t = burstTime
		if ReadByte(rikuEnabledGummi) > 0 then
			t = t - 19
		end
		
		local helm = check_ability_count(0x34)
		if airborneStatus ~= 0x00 and helm > 0 then -- Helm Breaker
			if ReadByte(rikuEnabledGummi) > 0 and ReadByte(currentLinkItem) >= 1 then 
				enable_burst()
			end
			if ReadByte(currentAnim, true) == 0xD5 and animationTime < 2.0 and ReadByte(inMenu) == 0 and ReadByte(rikuEnabledGummi) > 0 then
				WriteByte(linkedSpiritItem, math.max(0, ReadByte(linkedSpiritItem ) - 7))
			end
		end
		if ReadByte(world) ~= 0x00 and valid > 0 then -- Chain Attack
			if animationTime >= t then
				for i, anim in pairs(burstAnims) do
					if anim == ReadByte(currentAnim, true) then
						enable_burst()
						break
					end
				end
			end
		end
		
		
	end
end

function trigger_burst()
	if ReadShort(rcCommand) == 0 then
		
		local burstID = 0x45
	
		if ReadByte(0x2DE59F6 - offset) ~= burstID then
			slot1item = ReadByte(0x2DE59F6 - offset)
		end
		WriteByte(0x5255FC - offset, 0x00) -- item menu position
		WriteByte(0x284EE1C - offset, 0x00) -- item menu position
		WriteByte(0x284EE34 - offset, 0x00) -- item menu position
		WriteByte(0x2DE59F6 - offset, burstID)
		
		inputDelay = 0
		WriteByte(animCancel, 0x03, true)
		local command = 0x52558C - offset
		WriteByte(command, 2)
		trigger_menu_press()
		WriteByte(comboPosition, 0)
		disable_burst()
	end
end


function trigger_burst_attack()
-- Store item in slot 1. Then place Counter attack in slot 1, use it, and then place the regular item back into slot 1.



end

function enable_burst()
	if ReadByte(currentAnim, true) ~= 0xD5 and (ReadByte(0x233D035-offset)//(0x04))%2 ~= 1 then
		if (ReadByte(0x233D035 - offset)//(0x10))%2 == 1 then
			trigger_burst()
			return
		end
		WriteFloat(rcOpacity, 1.0)
	end
end

function disable_burst()
	if ReadShort(rcCommand) == 0 then
		WriteFloat(rcOpacity, 0.0)
	end
end



function trigger_menu_press()
	WriteInt(0x23D0600-offset, 0x01)
	WriteInt(0x232A444-offset, 0x01)
end


function check_ability_count(id)
	local abilitySlots = 0x2DE5A14 - offset
	local count = 0
	
	for i = 0, 47 do
		if id == ReadByte(abilitySlots + i) then
		count = count + 1
		end
	end
	return count
end


--Step 1: Force up False RC
--Step 2: Populate False RC
--Step 3: When triangle pressed, perform a quick item
--Step 4: The quick item puts counter into your item slots

-- Look into item menu transparency during it to hide
-- Look for dodge roll and guard in this


--0x2DE59F6 is item slot 1 id

-- Counter is 0x45
