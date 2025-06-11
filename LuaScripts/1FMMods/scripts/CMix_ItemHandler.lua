LUAGUI_NAME = "CMix_ItemHandler"
LUAGUI_AUTH = "Xendra"
LUAGUI_DESC = "Item modifications for critical mix"

local offset = 0x3A0606
local itemBoosts = 0

local etherRecovery = 0x2D20E46 - offset
local megaEtherRecovery = 0x2D20E90 + 0x06 - offset
local potionRecovery = 0x2D20E18 + 0x06 - offset
local megaPotionRecovery = 0x2D20E7C + 0x06 - offset
local hiPotionRecovery = 0x2D20E2C + 0x06 - offset
local currentWeapon = 0x2DE5A06 - offset


function _OnInit()
	if GAME_ID == 0xAF71841E and ENGINE_TYPE == "BACKEND" then
		ConsolePrint("CMix_ItemHandler Installed")
		canExecute = true
	end
end


function _OnFrame()
	if canExecute == true then
		itemBoosts = 0
		activate_accessories()
		set_item_effects()

	end
end

function set_item_effects()
	local multi = 1.0
	if ReadByte(currentWeapon) == 0x63 then -- Wishing Star
		multi = multi + 1.0
	end
	WriteByte(etherRecovery, (3 + itemBoosts) * multi)
	WriteByte(megaEtherRecovery, (3 + itemBoosts) * multi)
	WriteByte(potionRecovery, (30 + (itemBoosts * 15)) * multi)
	WriteByte(megaPotionRecovery, (30 + (itemBoosts * 15)) * multi)
	WriteByte(hiPotionRecovery, (60 + (itemBoosts * 20)) * multi)
end


function activate_accessories()
	moogle_badge()
	item_pouch()
	gold_ring()
	nose_piece()
end

function nose_piece()
	for i = 1, check_accessory_count(0x38) do
		itemBoosts = itemBoosts + 1
	end
end

function gold_ring()
	for i = 1, check_accessory_count(0x4D) do
		itemBoosts = itemBoosts + 1
	end
end

function item_pouch()
	for i = 1, check_accessory_count(0x3A) do
		itemBoosts = itemBoosts + 1
	end
end


function moogle_badge()
	for i = 1, check_accessory_count(0x43) do
		itemBoosts = itemBoosts + 1
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
