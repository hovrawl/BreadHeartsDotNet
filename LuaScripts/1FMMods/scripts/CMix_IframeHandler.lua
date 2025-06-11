LUAGUI_NAME = "CMix_IframeHandler"
LUAGUI_AUTH = "Xendra"
LUAGUI_DESC = "Handles invincibility frames for Critical Mix"


local offset = 0x3A0606

local comboPosition = 0x29678A1 - offset
local soraPointer = 0x2534680 - offset
local currentAnim = ReadLong(soraPointer)+0x164
local soraSlotOffset = ReadShort(ReadLong(soraPointer) + 0x6C, true) - 0x9000
local soraSlot = 0x2D59000 - offset + soraSlotOffset
local currentMP = soraSlot + 68
local maxMP = soraSlot + 72
local currentHP = soraSlot + 60
local maxHP = soraSlot + 64
local mpCharge = soraSlot + 190
local connectCounter = 0x29678B0 - offset
local stateFlag = 0x2863958 - offset
local linkedSpiritItem = 0x2DE5EFD - offset
local rikuEnabledGummi = 0x2DF18DC - offset -- Unused Gummi 5
local animationTime = ReadFloat(ReadLong(soraPointer)+0x16C, true)
-- Sora's Base Stats before equipment
local soraBaseAP = 0x2DE59D9 - offset
local currentWeapon = 0x2DE5A06 - offset

--
local fullIframeAnims = {
0xD2, 0xD3, 0xD5, 0xD6, 0xD7, 0xD8, 0xD9, -- Ars Arcanum
0xE6, 0xE7, 0xE8, 0xED, 0xEE, -- Strike Raid
0xF0, 0xF1, 0xF2, 0xF3, 0xF4, 0xF5, -- Ragnarok
0xFA -- Trinity Limit
}
-- Sonic, Strike Raid, Arcanum Ragnarok, Trinity Limit
-- Treasure chest, performing trinity, etc? or maybe its automatic
local combatStates ={}

local desiredIframeState = 0



-- Account for leaf bracer

-- Add some iframes on guard startup


function dark_evasion()
	if ReadByte(rikuEnabledGummi) > 0 and ReadByte(linkedSpiritItem) > 1 and ReadByte(currentAnim, true) == 0xDC and animationTime < 23.0 then
		desiredIframeState = 1
	end
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

function set_sora_pointer_data()
	soraSlotOffset = ReadShort(ReadLong(soraPointer) + 0x6C, true) - 0x9000
	if soraSlotOffset > 0 then
		soraSlot = 0x2D59000 - offset + soraSlotOffset
		currentMP = soraSlot + 68
		maxMP = soraSlot + 72
		currentHP = soraSlot + 60
		mpCharge = soraSlot + 190
		maxHP = soraSlot + 64
	end
end


function _OnInit()
	if GAME_ID == 0xAF71841E and ENGINE_TYPE == "BACKEND" then
		canExecute = true
		ConsolePrint("CMix_IframeHandler Installed")
	else
		ConsolePrint("CMix_IframeHandler -- FAILED --")
	end
end



function _OnFrame()
	if not canExecute then
		goto done
	end
	animationTime = ReadFloat(ReadLong(soraPointer)+0x16C, true)
	currentAnim = ReadLong(soraPointer)+0x164
	desiredIframeState = 0
	local animationTime = ReadFloat(ReadLong(soraPointer)+0x16C, true)
	local animID = ReadByte(currentAnim, true)
	
	for i, anim in pairs(fullIframeAnims) do
		if anim == animID then
			desiredIframeState = 1
			break
		end
	end
	
	if ReadByte(currentWeapon) == 0x63 then -- Wishing Star Item Bracer
		if animID == 0x3E or animID == 0x3F then
			desiredIframeState = 1
		end
	end
	
	if animID == 0x39 then -- Leaf Bracer
		local bracer = check_ability_count(0x3E)
		if bracer > 0 then
			desiredIframeState = 1
		end
	end
	
	if ReadByte(stateFlag) == 0x0C or ReadByte(stateFlag) == 0x0D or ReadByte(stateFlag) == 0x0E or ReadByte(stateFlag) == 0x0F or ReadByte(stateFlag) == 0x09 then
		desiredIframeState = 1
	end
	local hyperguard = check_ability_count(0x15)
	if hyperguard > 0 and ReadByte(currentAnim, true) == 0xD4 and animationTime <= 10 then
		desiredIframeState = 1
	end
	dark_evasion()
	WriteByte(ReadLong(soraPointer)+0x03, desiredIframeState, true)
	
	::done::
end




