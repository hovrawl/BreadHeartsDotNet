LUAGUI_NAME = "CMix_MagicHandler"
LUAGUI_AUTH = "Xendra"
LUAGUI_DESC = "Intercepts magic system,  allowing you to customize it with code"



local magicArtsBoost = true
local criticalMixEnabled = true
--
local offset = 0x3A0606

local comboPosition = 0x29678A1 - offset
local currentWeapon = 0x2DE5A06 - offset

local soraPointer = 0x2534680 - offset
local animCancel = ReadLong(soraPointer)
local soraSlotOffset = ReadShort(ReadLong(soraPointer) + 0x6C, true) - 0x9000
local soraSlot = 0x2D59000 - offset + soraSlotOffset
local currentStrength = soraSlot + 76
local maxGroundComboLength = soraSlot + 0xD4
local maxAirComboLength = soraSlot + 0xD5
local currentLinkItem = 0x2DE5F51 - offset
local eleBoostMulti = 0.2
local rikuEnabledGummi = 0x2DF18DC - offset -- Unused Gummi 5

-- Costs and damage can be changed in real time while the spell anim is playing, and it will work since it doesnt spend immediately
-- Use this for magic arts 20% chance for free cast

-- Limits
raidMP = 0x2D1F510 - offset
arsMP = 0x2D1F50E - offset
ragnarokMP = 0x2D1F512 - offset
sonicMP = 0x2D1F50C - offset
-- Cure
cureCost = 200
cureCostText = 0x2E188B5 - offset
curaCostText = 0x2E188EB - offset
curagaCostText = 0x2E1892C - offset

-- Offensive Power
fireDamageAddress = 0x2D25330 - offset
firaDamageAddress = 0x2D253A0 - offset
firagaDamageAddress = 0x2D25410 - offset

blizzardDamageAddress = 0x2D25480 - offset
blizzaraDamageAddress = 0x2D254F0 - offset
blizzagaDamageAddress = 0x2D25560 - offset

thunderDamageAddress = 0x2D255D0 - offset
thundaraDamageAddress = 0x2D25640 - offset
thundagaDamageAddress = 0x2D256B0 - offset

gravityDamageAddress = 0x2D25870 - offset
graviraDamageAddress = 0x2D258E0 - offset
gravigaDamageAddress = 0x2D25950 - offset

fireBoostCopies = 0
fireDamage = 20
firaDamage = 30
firagaDamage = 40

iceBoostCopies = 0
blizzardDamage = 15
blizzaraDamage = 25
blizzagaDamage = 35

thunderBoostCopies = 0
thunderDamage = 15
thundaraDamage = 20
thundagaDamage = 25


gravityBoostCopies = 0
gravityDamage = 40
graviraDamage = 55
gravigaDamage = 70


-- Fire
fireMP = 0x2D25318 - offset
firaMP = 0x2D25388 - offset
firagaMP = 0x2D253F8 - offset
-- Blizard
blizzardMP = 0x2D25468 - offset
blizzaraMP = 0x2D254d8 - offset
blizzagaMP = 0x2D25548 - offset
-- Gravity
gravityMP = 0x2D25858 - offset
graviraMP = 0x2D258C8 - offset
gravigaMP = 0x2D25938 - offset
-- Thunder
thunderMP = 0x2D255B8 - offset
thundaraMP = 0x2D25628 - offset
thundagaMP = 0x2D25698 - offset
-- Cure
cureMP = 0x2D25708 - offset
curaMP = 0x2D25778 - offset
curagaMP = 0x2D257E8 - offset
-- Stop
stopMP = 0x2D259A8 - offset
stopraMP = 0x2D25A18 - offset
stopgaMP = 0x2D25A88 - offset
-- Aero
aeroMP = 0x2D25AF8 - offset
aeroraMP = 0x2D25B68 - offset
aerogaMP = 0x2D25BD8 - offset

-- Magic Arts
fireArts = 0x2DE5F07 - offset
blizzardArts = 0x2DE5F08 - offset
thunderArts = 0x2DE5F09 - offset
cureArts = 0x2DE5F0A - offset
gravityArts = 0x2DE5F0B - offset
stopArts = 0x2DE5F0C - offset
aeroArts = 0x2DE5F0D - offset

-- Sora RGB Modulate
local soraRedValue = 1.0
local soraGreenValue = 1.0
local soraBlueValue = 1.0


function _OnInit()
	if GAME_ID == 0xAF71841E and ENGINE_TYPE == "BACKEND" then
		canExecute = true
		ConsolePrint("CMix_MagicHandler Installed")
	else
		ConsolePrint("CMix_MagicHandler -- FAILED --")
	end
end

function set_sora_pointer_data()
	soraSlotOffset = ReadShort(ReadLong(soraPointer) + 0x6C, true) - 0x9000
	if soraSlotOffset > 0 then
		soraSlot = 0x2D59000 - offset + soraSlotOffset
		maxGroundComboLength = soraSlot + 0xD4
		currentStrength = soraSlot + 76
		maxAirComboLength = soraSlot + 0xD5
	
		
	end
end


function _OnFrame()
	if not canExecute then
		goto done
	end
	
	set_sora_pointer_data()
	currentAnim = ReadLong(soraPointer)+0x164
	animCancel = ReadLong(soraPointer)
	soraRed = ReadLong(soraPointer)+0xA0
	soraGreen = ReadLong(soraPointer)+0xA4
	soraBlue = ReadLong(soraPointer)+0xA8
	-- Execute Functions
	reset_boosts()
	if magicArtsBoost == true then
		reset_spell_costs()
		apply_white_mushroom_arts()
	end
	reset_combo_position()
	reset_sora_color_values()
	-- Handle Magic Damage
	initialize_magic_damage()	
	if criticalMixEnabled == true then
		activate_all_accessories()
	end
	apply_fire_boosts()
	apply_ice_boosts()
	apply_thunder_boosts()
	apply_gravity_boosts()
	apply_magic_finishers()
	apply_magic_power()
	-- Apply Color
	apply_sora_color()
	::done::
end

function reset_boosts()
	fireBoostCopies = 0
	iceBoostCopies = 0
	thunderBoostCopies = 0
	gravityBoostCopies = 0
end

function reset_spell_costs()
	local small = 30
	local mid = 100
	local big = 200
	local huge = 300
	local spellmulti = 1.0
	if ReadByte(currentLinkItem) == 2 and ReadByte(rikuEnabledGummi) == 0 then
		local linkmulti = 0.5
		if ReadByte(currentWeapon) == 0x64 then -- Ultima Weapon
			linkmulti = 0.4
		end
		small = small * linkmulti
		mid = mid * linkmulti
		big = big * linkmulti
	end
	
	local allMPCostMulti = 1.0
	
	if ReadByte(currentWeapon) == 0x54 then -- Dream Rod
		allMPCostMulti = allMPCostMulti * 0.65
	end
	for i = 1, check_accessory_count(0x35) do -- Holy Circlet
		spellmulti = spellmulti * 0.7
	end
	
	
	small = math.floor(small * allMPCostMulti * spellmulti)
	mid = math.floor(mid * allMPCostMulti * spellmulti)
	big = math.floor(big * allMPCostMulti * spellmulti)
	huge = math.floor(huge * allMPCostMulti)
	
	-- Fire
	local fireMulti = 1.0
	if ReadByte(currentWeapon) == 0x5E then -- Lionheart
		fireMulti = 0.0
	end
	WriteByte(fireMP, small * fireMulti)
	WriteByte(firaMP, small* fireMulti)
	WriteByte(firagaMP, small* fireMulti)
	-- Blizard
	WriteByte(blizzardMP, small)
	WriteByte(blizzaraMP, small)
	WriteByte(blizzagaMP, small)
	-- Gravity
	WriteByte(gravityMP, mid)
	WriteByte(graviraMP, mid)
	WriteByte(gravigaMP, mid)

	WriteShort(thunderMP, mid)
	WriteShort(thundaraMP, mid)
	WriteShort(thundagaMP, mid)
	
	WriteShort(aeroMP, big)
	WriteShort(aeroraMP, big)
	WriteShort(aerogaMP, big)
	
	WriteShort(stopMP, big)
	WriteShort(stopraMP, big)
	WriteShort(stopgaMP, big)
	
	WriteShort(raidMP, huge)
	WriteShort(arsMP, huge)
	WriteShort(ragnarokMP, huge)

	if criticalMixEnabled == true then
		critical_cost_changes()
		local cureMulti = 1.0
		if ReadByte(currentWeapon) == 0x58 then -- Fairy Harp
			cureMulti = 0.5
		end
		WriteShort(cureMP, big * cureMulti)
		WriteShort(curaMP, big * cureMulti)
		WriteShort(curagaMP, big * cureMulti)
	else
		WriteShort(cureMP, mid)
		WriteShort(curaMP, mid)
		WriteShort(curagaMP, mid)
		WriteShort(raidMP, big)
	end
end

function reset_combo_position()
	local cancelValues = {0x00, 0x01, 0x02, 0xD4, 0xDC, 0x04, 0x05, 0x06, 0x07}
	for i, value in pairs(cancelValues) do
		if value == ReadByte(currentAnim, true) then
			WriteByte(comboPosition, 0)
			break
		end
	end
end


function reset_sora_color_values()
	soraRedValue = 1.1
	soraGreenValue = 1.1
	soraBlueValue = 1.1
end


function apply_sora_color()
	if ReadByte(currentLinkItem) == 0 then
		WriteFloat(soraRed, soraRedValue, true)
		WriteFloat(soraGreen, soraGreenValue, true)
		WriteFloat(soraBlue, soraBlueValue, true)
	end
end

function initialize_magic_damage()
	local multi = 1.0
	if ReadByte(currentWeapon) == 0x56 then -- Jungle King
		multi = multi + (ReadByte(currentStrength) * 0.02)
	end
	fireDamage = math.floor(20 * multi)
	firaDamage = math.floor(30 * multi)
	firagaDamage = math.floor(40 * multi)

	blizzardDamage = math.floor(15 * multi)
	blizzaraDamage = math.floor(25 * multi)
	blizzagaDamage = math.floor(35 * multi)

	thunderDamage = math.floor(15 * multi)
	thundaraDamage = math.floor(20 * multi)
	thundagaDamage = math.floor(25 * multi)

	gravityDamage = math.floor(30 * multi)
	graviraDamage = math.floor(45 * multi)
	gravigaDamage = math.floor(60 * multi)
	
	if criticalMixEnabled == true then
		gravityDamage = gravityDamage - 10
		graviraDamage = graviraDamage - 10
		gravigaDamage = gravigaDamage - 10
	end
end

function apply_gravity_boosts()
	for i = 1, gravityBoostCopies do
		gravityDamage = gravityDamage + 5
		graviraDamage = graviraDamage + 5
		gravigaDamage = gravigaDamage + 5
	end
end

function apply_thunder_boosts()
	for i = 1, thunderBoostCopies do
		thunderDamage = math.floor(thunderDamage + (thunderDamage * eleBoostMulti))
		thundaraDamage = math.floor(thundaraDamage + (thundaraDamage * eleBoostMulti))
		thundagaDamage = math.floor(thundagaDamage + (thundagaDamage * eleBoostMulti))
	end
end

function apply_ice_boosts()
	for i = 1, iceBoostCopies do
		blizzardDamage = math.floor(blizzardDamage + (blizzardDamage * eleBoostMulti))
		blizzaraDamage = math.floor(blizzaraDamage + (blizzaraDamage * eleBoostMulti))
		blizzagaDamage = math.floor(blizzagaDamage + (blizzagaDamage * eleBoostMulti))
	end
end

function apply_fire_boosts()
	-- ConsolePrint("fire")
	for i = 1, fireBoostCopies do
		fireDamage = math.floor(fireDamage + (fireDamage * eleBoostMulti))
		firaDamage = math.floor(firaDamage + (firaDamage * eleBoostMulti))
		firagaDamage = math.floor(firagaDamage + (firagaDamage * eleBoostMulti))
	end
end


function apply_magic_finishers()
	local maxCombo = ReadByte(maxGroundComboLength)
	local airborneStatus = ReadFloat(ReadLong(soraPointer)+0x70, true)
	
	
	
	if airborneStatus ~= 0x00 then
		 maxCombo = ReadByte(maxAirComboLength)
	end

	if ReadByte(comboPosition) >= maxCombo - 1 then
	
		local bonus = 0
		if ReadByte(currentWeapon) == 0x5A then -- CrabClaw
			bonus = 100
		end
	
		soraRedValue = 1.3
		soraGreenValue = 1.3
		soraBlueValue = 1.6
		
		fireDamage = fireDamage + 10 + bonus
		firaDamage = firaDamage + 12 + bonus
		firagaDamage = firagaDamage + 14 + bonus

		blizzardDamage = blizzardDamage + 8 + bonus
		blizzaraDamage = blizzaraDamage + 9 + bonus
		blizzagaDamage = blizzagaDamage + 10 + bonus

		thunderDamage = thunderDamage + 6 + bonus
		thundaraDamage = thundaraDamage + 7 + bonus
		thundagaDamage = thundagaDamage + 8 + bonus

		gravityDamage = gravityDamage + 5 + bonus
		graviraDamage = graviraDamage + 5 + bonus
		gravigaDamage = gravigaDamage + 5 + bonus
	end
end

function apply_white_mushroom_arts()
	if ReadByte(fireArts) >= 0x01 then
		fireDamage = fireDamage + 4
		firaDamage = firaDamage + 4
		firagaDamage = firagaDamage + 4
	end
	if ReadByte(blizzardArts) >= 0x01 then
		blizzardDamage = blizzardDamage + 3
		blizzaraDamage = blizzaraDamage + 3
		blizzagaDamage = blizzagaDamage + 3
	end
	if ReadByte(thunderArts) >= 0x01 then
		thunderDamage = thunderDamage + 2
		thundaraDamage = thundaraDamage + 2
		thundagaDamage = thundagaDamage + 2
	end
	if ReadByte(gravityArts) >= 0x01 then
		gravityDamage = gravityDamage + 2
		graviraDamage = graviraDamage + 2
		gravigaDamage = gravigaDamage + 2
	end
	
	local rng = math.random(1, 100)
	
	if rng <= 20 and ReadByte(animCancel, true) ~= 3 then
		if ReadByte(cureArts) >= 0x01 then
			if ReadByte(currentAnim, true) == 0x39 or ReadByte(currentAnim, true) == 0x86 then
				WriteShort(cureMP, 0)
				WriteShort(curaMP, 0)
				WriteShort(curagaMP, 0)
			end
		end
		if ReadByte(stopArts) >= 0x01 then
			if ReadByte(currentAnim, true) == 0x3B or ReadByte(currentAnim, true) == 0x88 then
				WriteShort(stopMP, 0)
				WriteShort(stopraMP, 0)
				WriteShort(stopgaMP, 0)
			end
		end
		if ReadByte(aeroArts) >= 0x01 then
		if ReadByte(currentAnim, true) == 0x3C or ReadByte(currentAnim, true) == 0x89 then
				WriteShort(aeroMP, 0)
				WriteShort(aeroraMP, 0)
				WriteShort(aerogaMP, 0)
			end
		end
	end
end

function critical_cost_changes()
	local cost = cureCost
	
	WriteByte(cureCostText, 0x23)
	WriteByte(curaCostText, 0x23)
	WriteByte(curagaCostText, 0x23)
end

function apply_magic_power()
	WriteByte(fireDamageAddress, fireDamage)
	WriteByte(firaDamageAddress, firaDamage)
	WriteByte(firagaDamageAddress, firagaDamage)

	WriteByte(blizzardDamageAddress, blizzardDamage)
	WriteByte(blizzaraDamageAddress, blizzaraDamage)
	WriteByte(blizzagaDamageAddress, blizzagaDamage)

	WriteByte(thunderDamageAddress, thunderDamage)
	WriteByte(thundaraDamageAddress, thundaraDamage)
	WriteByte(thundagaDamageAddress, thundagaDamage)

	WriteByte(gravityDamageAddress, gravityDamage)
	WriteByte(graviraDamageAddress, graviraDamage)
	WriteByte(gravigaDamageAddress, gravigaDamage)
end


-- Critical Mix Accessory Effects Below Here
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


function activate_all_accessories()
	acc_fire_ring()
	acc_fira_ring()
	acc_firaga_ring()
	acc_firagun_band()
	acc_ifrit_belt()
	
	acc_blizzard_ring()
	acc_blizzara_ring()
	acc_blizzaga_ring()
	acc_blizzagun_band()
	acc_shiva_belt()
	
	acc_thunder_ring()
	acc_thundara_ring()
	acc_thundaga_ring()
	acc_thundagun_band()
	acc_ramuh_belt()	
	
	acc_white_flower()
end


function acc_gravigun_band()
	for i = 1, check_accessory_count(0x2D) do
		gravityBoostCopies = gravityBoostCopies + 2
	end
end



function acc_thunder_ring()
	for i = 1, check_accessory_count(0x1A) do
		thunderBoostCopies = thunderBoostCopies + 1
	end
end

function acc_thundara_ring()
	for i = 1, check_accessory_count(0x1B) do
		thunderBoostCopies = thunderBoostCopies + 1
	end
end

function acc_thundaga_ring()
	for i = 1, check_accessory_count(0x1C) do
		thunderBoostCopies = thunderBoostCopies + 2
	end
end


function acc_thundagun_band()
	for i = 1, check_accessory_count(0x3F) do
		thunderBoostCopies = thunderBoostCopies + 2
	end
end

function acc_ramuh_belt()
	for i = 1, check_accessory_count(0x42) do
		thunderBoostCopies = thunderBoostCopies + 1
	end
end

function acc_ifrit_belt()
	for i = 1, check_accessory_count(0x40) do
		fireBoostCopies = fireBoostCopies + 1
	end
end

function acc_shiva_belt()
	for i = 1, check_accessory_count(0x41) do
		iceBoostCopies = iceBoostCopies + 1
	end
end

function acc_blizzard_ring()
	for i = 1, check_accessory_count(0x17) do
		iceBoostCopies = iceBoostCopies + 1
	end
end

function acc_blizzara_ring()
	for i = 1, check_accessory_count(0x18) do
		iceBoostCopies = iceBoostCopies + 1
	end
end

function acc_blizzaga_ring()
	for i = 1, check_accessory_count(0x19) do
		iceBoostCopies = iceBoostCopies + 2
	end
end

function acc_blizzagun_band()
	for i = 1, check_accessory_count(0x3E) do
		iceBoostCopies = iceBoostCopies + 2
	end
end

function acc_fire_ring()
	for i = 1, check_accessory_count(0x14) do
		fireBoostCopies = fireBoostCopies + 1
	end
end

function acc_fira_ring()
	for i = 1, check_accessory_count(0x15) do
		fireBoostCopies = fireBoostCopies + 1
	end
end

function acc_firaga_ring()
	for i = 1, check_accessory_count(0x16) do
		fireBoostCopies = fireBoostCopies + 2
	end
end

function acc_firagun_band()
	for i = 1, check_accessory_count(0x3D) do
		fireBoostCopies = fireBoostCopies + 2
	end
end



function acc_white_flower()
	for i = 1, check_accessory_count(0x31) do
		WriteShort(cureMP, ReadShort(cureMP) * 0.5)
		WriteShort(curaMP, ReadShort(curaMP) * 0.5)
		WriteShort(curagaMP, ReadShort(curagaMP) * 0.5)
	end
end