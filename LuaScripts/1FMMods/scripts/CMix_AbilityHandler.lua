LUAGUI_NAME = "CMix_AbilityHandler"
LUAGUI_AUTH = "Xendra"
LUAGUI_DESC = "Changes to abilities for Critical Mix"


local offset = 0x3A0606

local comboPosition = 0x29678A1 - offset
local soraPointer = 0x2534680 - offset
local forceGuard = 0x2A342D - offset
--
local world = 0x233CADC - offset
local room = 0x233CB44 - offset
local flag = 0x233CB48 - offset
--
local expMultiplier = 0x2A1C28 - offset
local soraEquippedAbilities = 0x2DE5A14 - offset
local accessoryAbilityList = {}
local currentWeapon = 0x2DE5A06 - offset
--
local soraBaseAP = 0x2DE59D9 - offset
local inMenu = 0x232A600 - offset
local randoEnabledGummi = 0x2DF18DA - offset -- Unused Gummi 3
local rikuEnabledGummi = 0x2DF18DC - offset -- Unused Gummi 5


function _OnInit()
	if GAME_ID == 0xAF71841E and ENGINE_TYPE == "BACKEND" then
		canExecute = true
		ConsolePrint("CMix_StatHandler Installed")
	else
		ConsolePrint("CMix_StatHandler -- FAILED --")
	end
end



function _OnFrame()
	if not canExecute then
		goto done
	end
	WriteByte(soraBaseAP, 100)
	WriteByte(forceGuard, 0x72)
	if ReadByte(randoEnabledGummi) == 0 then
		WriteFloat(expMultiplier, 1.0)
	end
	check_exp_zero()
	if ReadByte(inMenu) == 1 then
		insert_accessory_abilities()
	end
	local currentAnim = ReadLong(soraPointer)+0x164
	
	if ReadByte(world) == 0 then
		WriteFloat(expMultiplier, 0.0)
		grant_dream_spirit()
		if ReadByte(room) == 0 and ReadByte(flag) == 2 then
			create_starter_ability_list()
		end
	end

	
	::done::
end

function grant_dream_spirit()
	
	if ReadByte(currentWeapon) == 0x52 then -- Sword
		WriteByte(0x2DE5EFA - offset, 0x01)
	elseif ReadByte(currentWeapon) == 0x53 then -- Shield
		WriteByte(0x2DE5EFC - offset, 0x01)
	elseif ReadByte(currentWeapon) == 0x54 then -- Rod
		WriteByte(0x2DE5EFB - offset, 0x01)
	end
end

function create_starter_ability_list()
	WriteByte(soraEquippedAbilities + 4, 0x16) -- Dodge Roll
	WriteByte(soraEquippedAbilities + 5, 0x05) -- Treasure Magnet
	WriteByte(soraEquippedAbilities + 6, 0x3D) -- Encounter Plus
	WriteByte(soraEquippedAbilities + 7, 0xAB) -- Accelerate
	WriteByte(soraEquippedAbilities + 8, 0xAD) -- New Zero EXP
	if ReadByte(rikuEnabledGummi) > 0 then
		WriteByte(soraEquippedAbilities + 9, 0x31) -- Critical Stance
		WriteByte(soraEquippedAbilities + 10, 0x34) -- Helm Breaker
	end
end

function wipe_duplicate_encounter_plus()
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

function check_exp_zero()
	for i = 1, check_ability_count(0x2D) do
		WriteFloat(expMultiplier, 0.0)
		WriteInt(0x2DE5A10 - offset, -999) -- Current Sora EXP
	end
end


function insert_accessory_abilities()

	for i = 0, 3 do
		WriteByte(soraEquippedAbilities + i, 0xAC)
	end
	
	local reserveAbilityAddresses = {}
	accessoryAbilityList = {}
	-- Keyblades
	riku_oathbreaker()
	-- Accessories
	trinity_sigil()
	cure_ring()
	cura_ring()
	curaga_ring()
	magic_armlet()
	rune_armlet()
	atlas_armlet()
	triple_bite()
	shiva_belt()
	ramuh_belt()
	unity_sigil()
	ancient_ring()
	dragon_fang()
	siphon_brace()
	gold_ring()
	if ReadByte(currentWeapon) == 0x58 then -- Fairy Harp
		table.insert(accessoryAbilityList, 0x3E) -- Leaf Bracer
	end
	-- End of accessories	
	
	for i = 0, 47 do
		if ReadByte(soraEquippedAbilities + i) == 0xAC then
			table.insert(reserveAbilityAddresses, soraEquippedAbilities + i)
		end
	end
	for a, abil in pairs(accessoryAbilityList) do
		for r, reserve in pairs(reserveAbilityAddresses) do
			if ReadByte(reserve) == 0xAC then
				WriteByte(reserve, abil)
				break
				
			end
		end
	end
end

function gold_ring()
	for i = 1, check_accessory_count(0x4D) do
		table.insert(accessoryAbilityList, 0x1B) -- Jackpot
	end
end


function dragon_fang()
	for i = 1, check_accessory_count(0x4A) do
		table.insert(accessoryAbilityList, 0x08) -- Critical Plus
	end
end


function ancient_ring()
	for i = 1, check_accessory_count(0x48) do
		table.insert(accessoryAbilityList, 0x17) -- MP Haste
	end
end

function unity_sigil()
	for i = 1, check_accessory_count(0x44) do
		table.insert(accessoryAbilityList, 0x3E) -- Leaf Bracer
	end
end


function ramuh_belt()
	for i = 1, check_accessory_count(0x42) do
		table.insert(accessoryAbilityList, 0x08) -- Critical Plus
	end
end

function shiva_belt()
	for i = 1, check_accessory_count(0x41) do
		table.insert(accessoryAbilityList, 0x18) -- MP Rage
	end
end

function riku_oathbreaker()
	if ReadByte(rikuEnabledGummi) > 0 and ReadByte(currentWeapon) == 0x60 then -- Oathbreaker
		table.insert(accessoryAbilityList, 0x18) -- MP Rage
	end
end

function triple_bite()
	for i = 1, check_accessory_count(0x32) do
		table.insert(accessoryAbilityList, 0x08) -- Critical Plus
	end
end


function atlas_armlet()
	for i = 1, check_accessory_count(0x2C) do
		table.insert(accessoryAbilityList, 0x17) -- MP Haste
	end
end

function rune_armlet()
	for i = 1, check_accessory_count(0x2B) do
		table.insert(accessoryAbilityList, 0x17) -- MP Haste
	end
end


function magic_armlet()
	for i = 1, check_accessory_count(0x2A) do
		table.insert(accessoryAbilityList, 0x17) -- MP Haste
	end
end



function curaga_ring()
	for i = 1, check_accessory_count(0x29) do
		table.insert(accessoryAbilityList, 0x3E) -- Leaf Bracer
	end
end

function cura_ring()
	for i = 1, check_accessory_count(0x28) do
		table.insert(accessoryAbilityList, 0x3E) -- Leaf Bracer
	end
end


function cure_ring()
	for i = 1, check_accessory_count(0x27) do
		table.insert(accessoryAbilityList, 0x3E) -- Leaf Bracer
	end
end


function trinity_sigil()
	for i = 1, check_accessory_count(0x21) do
		table.insert(accessoryAbilityList, 0x08) -- Critical Plus
	end
end


function siphon_brace()
	for i = 1, check_accessory_count(0x22) do
		table.insert(accessoryAbilityList, 0x17) -- MP Haste
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








