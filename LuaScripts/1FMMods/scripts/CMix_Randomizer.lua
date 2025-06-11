LUAGUI_NAME = "CMix_Randomizer"
LUAGUI_AUTH = "Xendra"
LUAGUI_DESC = "Randomizes stuff based on your choices in the program."

-- Uses an unused gummi item to tell other scripts that the randomizer is enabled.
-- Contains a modified full copy of "Customize KH1 Weapons.lua" from Critical Mix because it was the easiest way.


local offset = 0x3A0606
local soraHUD = 0x280EB1C - offset
local chestTable = 0x5259E0 - offset
local stateFlag = 0x2863958 - offset
local stateCheckTimer = 0
-- Tracking Gummis
local randoEnabledGummi = 0x2DF18DA - offset -- Unused Gummi 3
-- Btltbl
local btltbl = 0x2D1F3C0 - offset
local rewardTable = btltbl+0xC6A8
local soraStatTable = btltbl+0x3AC0
local itemTable = 0x2D20E18 - offset
-- Synthesis
local synthRequirements = 0x544320 - offset
local synthItems = synthRequirements + 0x1E0
local moogleLevel = 0x2DE73A0 - offset
-- Location Info
local world = 0x233CADC - offset
local room = 0x233CB44 - offset
local flag = 0x233CB48 - offset
-- Keyblade info
local currentWeapon = 0x2DE5A06 - offset
-- Checks
local emblemCount = 0x2DE787D - offset

local enableCriticalMix = true
local swapped = ReadByte(0x22D6C7E - offset)
local displayedCritDamage = 0
local displayedCritChance = 0
local extraStrength = 0

local shortcut1 = 0x2DE6214 - offset
local expMultiplier = 0x2A1C28 - offset

-- Unlock Info
local magicFlags = 0x2DE75EE - offset
local magicUnlock = 0x2DE5A44 - offset
local magicLevels = magicUnlock + 0x41E
local lastLearnedMagic = ""
local lastReplacedMagic = ""

local fireSlot = 0x2D1F200 - offset
local blizzardSlot = 0x2D1F238 - offset
local thunderSlot = 0x2D1F270 - offset
local cureSlot = 0x2D1F2A8 - offset
local gravitySlot = 0x2D1F2E0 - offset
local stopSlot = 0x2D1F318 - offset
local aeroSlot = 0x2D1F350 - offset

local trinityUnlock = magicUnlock + 0x1BA7
local trinityList = {1, 2, 3, 4, 5}
local magicList = {1, 2, 3, 4, 5, 6, 7}
local lastTrinityState = ReadByte(trinityUnlock)


-- Progress Info
local worldFlagBase = 0x2DE79D0+0x6C - offset
local cutsceneFlags = 0x2DE65D0-0x200 - offset
local chronicles = 0x2DE7367 - offset
local journalCharacters = 0x2DE70B3 - offset
local OCCupUnlock = 0x2DE77D0 - offset
local OCCupDialog = 0x23966B0 - offset
local traverseFlags = 0x2DE6ED4 - offset

-- Rando Options
local emblemRando = false
local experienceMultiplierAmount = 1.0


-- Gummi items are used to communicate data between scripts --
CriticalMPTrackingGummi = 0x2DF18D8 - offset -- Unused Gummi 1
-- Gummi items are used to communicate data between scripts --

KingdomKeyAttack = 1
KingdomKeyMagic = -1
KingdomKeyCriical = 30
KingdomKeyBonus = 2
KingdomKeyModel = "xw_di_5000"
DreamSwordAttack = 4
DreamSwordMagic = 0
DreamSwordCriical = 25
DreamSwordBonus = 4
DreamSwordModel = "xw_di_5000"
DreamShieldAttack = 4
DreamShieldMagic = 0
DreamShieldCriical = 25
DreamShieldBonus = 4
DreamShieldModel = "xw_di_5000"
DreamRodAttack = 3
DreamRodMagic = 2
DreamRodCriical = 0
DreamRodBonus = 0
DreamRodModel = "xw_di_5000"
WoodenSwordAttack = -2
WoodenSwordMagic = 3
WoodenSwordCriical = 0
WoodenSwordBonus = 0
WoodenSwordModel = "xw_di_5000"
JungleKingAttack = 6
JungleKingMagic = -1
JungleKingCriical = 25
JungleKingBonus = 4
JungleKingModel = "xw_di_5000"
ThreeWishesAttack = 4
ThreeWishesMagic = 0
ThreeWishesCriical = 25
ThreeWishesBonus = 7
ThreeWishesModel = "xw_di_5000"
CrabClawAttack = 3
CrabClawMagic = 1
CrabClawCriical = 20
CrabClawBonus = 4
CrabClawModel = "xw_di_5000"
PumpkinheadAttack = 2
PumpkinheadMagic = 1
PumpkinheadCriical = 25
PumpkinheadBonus = 4
PumpkinheadModel = "xw_di_5000"
FairyHarpAttack = 0
FairyHarpMagic = 2
FairyHarpCriical = 25
FairyHarpBonus = 2
FairyHarpModel = "xw_di_5000"
WishingStarAttack = 4
WishingStarMagic = 0
WishingStarCriical = 30
WishingStarBonus = 2
WishingStarModel = "xw_di_5000"
SpellbinderAttack = 0
SpellbinderMagic = 2
SpellbinderCriical = 25
SpellbinderBonus = 2
SpellbinderModel = "xw_di_5000"
MetalChocoboAttack = 8
MetalChocoboMagic = -2
MetalChocoboCriical = 20
MetalChocoboBonus = 2
MetalChocoboModel = "xw_di_5000"
OlympiaAttack = 5
OlympiaMagic = 0
OlympiaCriical = 20
OlympiaBonus = 2
OlympiaModel = "xw_di_5000"
LionheartAttack = 2
LionheartMagic = 1
LionheartCriical = 20
LionheartBonus = 4
LionheartModel = "xw_di_5000"
LadyLuckAttack = 2
LadyLuckMagic = 1
LadyLuckCriical = 200
LadyLuckBonus = 7
LadyLuckModel = "xw_di_5000"
DivineRoseAttack = 4
DivineRoseMagic = 0
DivineRoseCriical = 25
DivineRoseBonus = 4
DivineRoseModel = "xw_di_5000"
OathkeeperAttack = 0
OathkeeperMagic = 2
OathkeeperCriical = 20
OathkeeperBonus = 4
OathkeeperModel = "xw_di_5000"
OblivionAttack = 30
OblivionMagic = -2
OblivionCriical = 200
OblivionBonus = 60
OblivionModel = "xw_di_5000"
DiamondDustAttack = -7
DiamondDustMagic = 7
DiamondDustCriical = 0
DiamondDustBonus = 0
DiamondDustModel = "xw_di_5000"
OneWingedAngelAttack = 7
OneWingedAngelMagic = -2
OneWingedAngelCriical = 200
OneWingedAngelBonus = 60
OneWingedAngelModel = "xw_di_5000"
UltimaAttack = 4
UltimaMagic = 2
UltimaCriical = 20
UltimaBonus = 2
UltimaModel = "xw_di_5000"


kingdomkeyattack = 0x2D288E8 - offset
kingdomkeymagic = 0x2D288F0 - offset
kingdomkeycritical = 0x2D288E9 - offset
kingdomkeybonus = 0x2D288EA - offset
kingdomkeymodel = 0x2D288B8 - offset
dreamswordattack = 0x2D28940 - offset
dreamswordmagic = 0x2D28948 - offset
dreamswordcritical = 0x2D28941 - offset
dreamswordbonus = 0x2D28942 - offset
dreamswordmodel = 0x2D28910 - offset
dreamshieldattack = 0x2D28998 - offset
dreamshieldmagic = 0x2D289A0 - offset
dreamshieldcritical = 0x2D28999 - offset
dreamshieldbonus = 0x2D2899A - offset
dreamshieldmodel = 0x2D28968 - offset
dreamrodattack = 0x2D289F0 - offset
dreamrodmagic = 0x2D289F8 - offset
dreamrodcritical = 0x2D289F1 - offset
dreamrodbonus = 0x2D289F2 - offset
dreamrodmodel = 0x2D289C0 - offset
woodenswordattack = 0x2D28A48 - offset
woodenswordmagic = 0x2D28A50 - offset
woodenswordcritical = 0x2D28A49 - offset
woodenswordbonus = 0x2D28A4A - offset
woodenswordmodel = 0x2D28A18 - offset
junglekingattack = 0x2D28AA0 - offset
junglekingmagic = 0x2D28AA8 - offset
junglekingcritical = 0x2D28AA1 - offset
junglekingbonus = 0x2D28AA1 - offset
junglekingmodel = 0x2D28A70 - offset
threewishesattack = 0x2D28AF8 - offset
threewishesmagic = 0x2D28B00 - offset
threewishescritical = 0x2D28AF9 - offset
threewishesbonus = 0x2D28AFA - offset
threewishesmodel = 0x2D28AC8 - offset
crabclawattack = 0x2D28C00 - offset
crabclawmagic = 0x2D28C08 - offset
crabclawcritical = 0x2D28C01 - offset
crabclawbonus = 0x2D28C02 - offset
crabclawmodel = 0x2D28BD0 - offset
pumpkinheadattack = 0x2D28BA8 - offset
pumpkinheadmagic = 0x2D28BB0 - offset
pumpkinheadcritical = 0x2D28BA9 - offset
pumpkinheadbonus = 0x2D28BAA - offset
pumpkinheadmodel = 0x2D28B78 - offset
fairyharpattack = 0x2D28B50 - offset
fairyharpmagic = 0x2D28B58 - offset
fairyharpcritical = 0x2D28B51 - offset
fairyharpbonus = 0x2D28B52 - offset
fairyharpmodel = 0x2D28B20 - offset
wishingstarattack = 0x2D28F18 - offset
wishingstarmagic = 0x2D28F20 - offset
wishingstarcritical = 0x2D28F19 - offset
wishingstarbonus = 0x2D28F1A - offset
wishingstarmodel = 0x2D28EE8 - offset
spellbinderattack = 0x2D28CB0 - offset
spellbindermagic = 0x2D28CB8 - offset
spellbindercritical = 0x2D28CB1 - offset
spellbinderbonus = 0x2D28CB2 - offset
spellbindermodel = 0x2D28C80 - offset
metalchocoboattack = 0x2D28DB8 - offset
metalchocobomagic = 0x2D28DC0 - offset
metalchocobocritical = 0x2D28DB9 - offset
metalchocobobonus = 0x2D28DBA - offset
metalchocobomodel = 0x2D28D88 - offset
olympiaattack = 0x2D28D08 - offset
olympiamagic = 0x2D28D10 - offset
olympiacritical = 0x2D28D09 - offset
olympiabonus = 0x2D28D0A - offset
olympiamodel = 0x2D28CD8 - offset
lionheartattack = 0x2D28D60 - offset
lionheartmagic = 0x2D28D68 - offset
lionheartcritical = 0x2D28D61 - offset
lionheartbonus = 0x2D28D62 - offset
lionheartmodel = 0x2D28D30 - offset
ladyluckattack = 0x2D28EC0 - offset
ladyluckmagic = 0x2D28EC8 - offset
ladyluckcritical = 0x2D28EC1 - offset
ladyluckbonus = 0x2D28EC2 - offset
ladyluckmodel = 0x2D28E90 - offset
divineroseattack = 0x2D28C58 - offset
divinerosemagic = 0x2D28C60 - offset
divinerosecritical = 0x2D28C59 - offset
divinerosebonus = 0x2D28C5A - offset
divinerosemodel = 0x2D28C28 - offset
oathkeeperattack = 0x2D28E10 - offset
oathkeepermagic = 0x2D28E18 - offset
oathkeepercritical = 0x2D28E11 - offset
oathkeeperbonus = 0x2D28E12 - offset
oathkeepermodel = 0x2D28DE0 - offset
oblivionattack = 0x2D28E68 - offset
oblivionmagic = 0x2D28E70 - offset
oblivioncritical = 0x2D28E69 - offset
oblivionbonus = 0x2D28E6A - offset
oblivionmodel = 0x2D28E38 - offset
diamonddustattack = 0x2D28FC8 - offset
diamonddustmagic = 0x2D28FD0 - offset
diamonddustcritical = 0x2D28FC9 - offset
diamonddustbonus = 0x2D28FCA - offset
diamonddustmodel = 0x2D28F98 - offset
onewingedangelattack = 0x2D29020 - offset
onewingedangelmagic = 0x2D29028 - offset
onewingedangelcritical = 0x2D29021 - offset
onewingedangelbonus = 0x2D29022 - offset
onewingedangelmodel = 0x2D28FF0 - offset
ultimaattack = 0x2D28F70 - offset
ultimamagic = 0x2D28F78 - offset
ultimacritical = 0x2D28F71 - offset
ultimabonus = 0x2D28F72 - offset
ultimamodel = 0x2D28F40 - offset


local bonusCritDamage = 0
local comboPosition = 0x29678A1 - offset
local soraPointer = 0x2534680 - offset
local soraSlotOffset = ReadShort(ReadLong(soraPointer) + 0x6C, true) - 0x9000
local soraSlot = 0x2D59000 - offset + soraSlotOffset
local maxGroundComboLength = soraSlot + 0xD4

local extraCritChance = 0
local airborneStatus = ReadFloat(ReadLong(soraPointer)+0x70, true)
local connectCounter = 0x29678B0 - offset

local traverseStatus = 0x2DE78C0 - offset


function set_sora_pointer_data()
	soraSlotOffset = ReadShort(ReadLong(soraPointer) + 0x6C, true) - 0x9000
	if soraSlotOffset > 0 then
		soraSlot = 0x2D59000 - offset + soraSlotOffset
		maxGroundComboLength = soraSlot + 0xD4
		
		maxAirComboLength = soraSlot + 0xD5
	
		
	end
end

function apply_accessories()
	haste_ring()
	hastega_ring()
	ramuh_belt()
	-- Abilities
	
end


function critical_mp()
	local abils = check_ability_count(0x2A) -- Critical MP
	if abils >= 1 then
		get_current_crit_damage()
		WriteByte(CriticalMPTrackingGummi, displayedCritChance)
		extraCritChance = -255
	end
end

function ramuh_belt()
	for i = 1, check_accessory_count(0x42) do
		bonusCritDamage = bonusCritDamage + 10
	end
end

function critical_arts()
	for i = 1, check_accessory_count(0x20) do
		extraCritChance = 100
	end
end

function hastega_ring()
	for i = 1, check_accessory_count(0x1F) do
		bonusCritDamage = bonusCritDamage + 5
	end
end

function haste_ring()
	for i = 1, check_accessory_count(0x1E) do
		bonusCritDamage = bonusCritDamage + 3
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


function change_def_text_to_crt()
	-- Accessory Screen
	local defText = 0x2E18362 - offset
	WriteByte(defText, 0x2D)
	WriteByte(defText + 1, 0x3C)
	WriteByte(defText + 2, 0x3E)
	WriteByte(0x2E18376 - offset, 0x00)
	-- Status Screen
	defText = 0x2E1931D - offset
	WriteByte(defText, 0x2D)
	WriteByte(defText + 1, 0x3C)
	WriteByte(defText + 2, 0x3E)
	-- While the pause menu is open, defense is equal to crit damage.
	-- If menu visible:
end


function change_ap_text_to_crit_chance()
	local apText = 0x2E192DA - offset
	WriteLong(apText, 0x5045474D584D562D)
	WriteLong(apText+0x08, 0x01494752454c2d01)
	WriteShort(apText+0x10, 0x0101)
	WriteShort(apText+0x12, 0x0101)
	
	WriteByte(0x2E192FA - offset, 0x62)
	WriteLong(0x2E192EF - offset, 0x0101010101010101)
	WriteLong(0x2E192FB - offset, 0x0000000000000000)
	WriteLong(0x2E192FB+0x08 - offset, 0x7F7F080000000000)
	
end

function change_ap_text_to_sp()
	local apText = 0x2E18317 - offset
	local apColor = 0x2E18314 - offset
	WriteByte(apText, 0x3D)
	WriteShort(apColor, 0x0084)
	WriteByte(0x2E18332 - offset, 0x00)
end


function calculate_exp_zero_strength()

	local z = check_ability_count(0x2D) -- Exp Zero
	if z >= 1 then
	
		local bonus = 0
		
		
		for i = 0, 9 do
			if ReadByte(traverseStatus + i) == 4 then
				bonus = bonus + 3
			end
		end
		local soraLevel = 0x2DE59D4 - offset
		bonus = bonus * (1 - (math.min(50, (ReadByte(soraLevel) - 1)) / 50))
		extraStrength = extraStrength + bonus
	end
end

function customize_keyblades()
	if canExecute == true then
		KingdomKeyAttack = 1
		KingdomKeyMagic = -1
		reset_keyblade_crit()
		airborneStatus = ReadFloat(ReadLong(soraPointer)+0x70, true)
		set_sora_pointer_data()
		extraStrength = 0
		
		calculate_exp_zero_strength()
		
		extraCritChance = 0
		bonusCritDamage = 0


		if airborneStatus < 0.1 and ReadByte(comboPosition) >= ReadByte(maxGroundComboLength) - 1 then
			bonusCritDamage = bonusCritDamage + 3
		end

		apply_accessories()

		critical_mp()
		
		change_def_text_to_crt()
		change_ap_text_to_sp()
		change_ap_text_to_crit_chance()
		if ReadByte(0x2E8EFB0 - offset) > 0x00 or (ReadByte(0x233D034-0x3A0606)//(0x08-(32*swapped)))%2 == 1 then
			get_current_crit_damage()
		end
		-- Critical Arts Forced Crit
		critical_arts()
		-- Zero EXP: +2 strength per sealed keyhole, but the bonus decays based on your level, until 50 where it is gone completely

		-- Pumpkinhead Ability
		PumpkinheadBonus = PumpkinheadBonus + (ReadByte(comboPosition) * 3)


		-- Frenzy
		local frenzy = check_ability_count(0x25)
		extraStrength = math.floor(extraStrength + (frenzy * 3))
		-- Write Keyblade Stats

		-- Kingdom Key Infusion
		if ReadByte(0x2DE5A44 - offset) == 0x00 then -- If no magic
			KingdomKeyAttack = KingdomKeyAttack + 4
		else
			for i = 0, 2 do
				if ReadByte(shortcut1 + i) == 0 or ReadByte(shortcut1 + i) == 0xFF then -- Fire or Nothing
					KingdomKeyAttack = KingdomKeyAttack + 2
				end
				if ReadByte(shortcut1 + i) == 1 then -- Blizzard
					KingdomKeyMagic = KingdomKeyMagic + 1
				end
				if ReadByte(shortcut1 + i) == 4 then -- Gravity
					KingdomKeyCriical = KingdomKeyCriical + 20
				end
				if ReadByte(shortcut1 + i) == 2 then -- Thunder
					KingdomKeyBonus = KingdomKeyBonus + 5
				end
			end
		end
		WriteByte(kingdomkeyattack, KingdomKeyAttack + extraStrength)
		WriteByte(kingdomkeymagic, KingdomKeyMagic)
		WriteByte(kingdomkeycritical, math.max(0, KingdomKeyCriical + extraCritChance))
		WriteByte(kingdomkeybonus, KingdomKeyBonus + bonusCritDamage)
		--WriteString(kingdomkeymodel, KingdomKeyModel)
		WriteByte(dreamswordattack, DreamSwordAttack + extraStrength)
		WriteByte(dreamswordmagic, DreamSwordMagic)
		WriteByte(dreamswordcritical, math.max(0, DreamSwordCriical + extraCritChance))
		WriteByte(dreamswordbonus, DreamSwordBonus + bonusCritDamage)
		--WriteString(dreamswordmodel, DreamSwordModel)
		WriteByte(dreamshieldattack, DreamShieldAttack + extraStrength)
		WriteByte(dreamshieldmagic, DreamShieldMagic)
		WriteByte(dreamshieldcritical, math.max(0, DreamShieldCriical + extraCritChance))
		WriteByte(dreamshieldbonus, DreamShieldBonus + bonusCritDamage)
		--WriteString(dreamshieldmodel, DreamShieldModel)
		WriteByte(dreamrodattack, DreamRodAttack + extraStrength)
		WriteByte(dreamrodmagic, DreamRodMagic)
		WriteByte(dreamrodcritical, math.max(0, DreamRodCriical + extraCritChance))
		WriteByte(dreamrodbonus, DreamRodBonus + bonusCritDamage)
		--WriteString(dreamrodmodel, DreamRodModel)
		WriteByte(woodenswordattack, WoodenSwordAttack + extraStrength)
		WriteByte(woodenswordmagic, WoodenSwordMagic)
		WriteByte(woodenswordcritical, math.max(0, WoodenSwordCriical + extraCritChance))
		WriteByte(woodenswordbonus, WoodenSwordBonus + bonusCritDamage)
		--WriteString(woodenswordmodel, WoodenSwordModel)
		WriteByte(junglekingattack, JungleKingAttack + extraStrength)
		WriteByte(junglekingmagic, JungleKingMagic)
		WriteByte(junglekingcritical, math.max(0, JungleKingCriical + extraCritChance))
		WriteByte(junglekingbonus, JungleKingBonus + bonusCritDamage)
		--WriteString(junglekingmodel, JungleKingModel)
		WriteByte(threewishesattack, ThreeWishesAttack + extraStrength)
		WriteByte(threewishesmagic, ThreeWishesMagic)
		WriteByte(threewishescritical, math.max(0, ThreeWishesCriical + extraCritChance))
		WriteByte(threewishesbonus, ThreeWishesBonus+ bonusCritDamage)
		--WriteString(threewishesmodel, ThreeWishesModel)
		WriteByte(crabclawattack, CrabClawAttack + extraStrength)
		WriteByte(crabclawmagic, CrabClawMagic)
		WriteByte(crabclawcritical, math.max(0, CrabClawCriical + extraCritChance))
		WriteByte(crabclawbonus, CrabClawBonus + bonusCritDamage)
		--WriteString(crabclawmodel, CrabClawModel)
		WriteByte(pumpkinheadattack, PumpkinheadAttack + extraStrength)
		WriteByte(pumpkinheadmagic, PumpkinheadMagic)
		WriteByte(pumpkinheadcritical, math.max(0, PumpkinheadCriical + extraCritChance))
		WriteByte(pumpkinheadbonus, PumpkinheadBonus + bonusCritDamage)
		--WriteString(pumpkinheadmodel, PumpkinheadModel)
		WriteByte(fairyharpattack, FairyHarpAttack + extraStrength)
		WriteByte(fairyharpmagic, FairyHarpMagic)
		WriteByte(fairyharpcritical, math.max(0, FairyHarpCriical + extraCritChance))
		WriteByte(fairyharpbonus, FairyHarpBonus + bonusCritDamage)
		--WriteString(fairyharpmodel, FairyHarpModel)
		WriteByte(wishingstarattack, WishingStarAttack + extraStrength)
		WriteByte(wishingstarmagic, WishingStarMagic)
		WriteByte(wishingstarcritical, math.max(0, WishingStarCriical + extraCritChance))
		WriteByte(wishingstarbonus, WishingStarBonus + bonusCritDamage)
		--WriteString(wishingstarmodel, WishingStarModel)
		WriteByte(spellbinderattack, SpellbinderAttack + extraStrength)
		WriteByte(spellbindermagic, SpellbinderMagic)
		WriteByte(spellbindercritical, math.max(0, SpellbinderCriical + extraCritChance))
		WriteByte(spellbinderbonus, SpellbinderBonus + bonusCritDamage)
		--WriteString(spellbindermodel, SpellbinderModel)
		WriteByte(metalchocoboattack, MetalChocoboAttack + extraStrength)
		WriteByte(metalchocobomagic, MetalChocoboMagic)
		WriteByte(metalchocobocritical, math.max(0, MetalChocoboCriical + extraCritChance))
		WriteByte(metalchocobobonus, MetalChocoboBonus + bonusCritDamage)
		--WriteString(metalchocobomodel, MetalChocoboModel)
		WriteByte(olympiaattack, OlympiaAttack + extraStrength)
		WriteByte(olympiamagic, OlympiaMagic)
		WriteByte(olympiacritical, math.max(0, OlympiaCriical + extraCritChance))
		WriteByte(olympiabonus, OlympiaBonus + bonusCritDamage)
		--WriteString(olympiamodel, OlympiaModel)
		WriteByte(lionheartattack, LionheartAttack + extraStrength)
		WriteByte(lionheartmagic, LionheartMagic)
		WriteByte(lionheartcritical, math.max(0, LionheartCriical + extraCritChance))
		WriteByte(lionheartbonus, LionheartBonus + bonusCritDamage)
		--WriteString(lionheartmodel, LionheartModel)
		WriteByte(ladyluckattack, LadyLuckAttack + extraStrength)
		WriteByte(ladyluckmagic, LadyLuckMagic)
		WriteByte(ladyluckcritical, math.max(0, LadyLuckCriical + extraCritChance))
		WriteByte(ladyluckbonus, LadyLuckBonus + bonusCritDamage)
		--WriteString(ladyluckmodel, LadyLuckModel)
		WriteByte(divineroseattack, DivineRoseAttack + extraStrength)
		WriteByte(divinerosemagic, DivineRoseMagic)
		WriteByte(divinerosecritical, math.max(0, DivineRoseCriical + extraCritChance))
		WriteByte(divinerosebonus, DivineRoseBonus + bonusCritDamage)
		--WriteString(divinerosemodel, DivineRoseModel)
		WriteByte(oathkeeperattack, OathkeeperAttack + extraStrength)
		WriteByte(oathkeepermagic, OathkeeperMagic)
		WriteByte(oathkeepercritical, math.max(0, OathkeeperCriical + extraCritChance))
		WriteByte(oathkeeperbonus, OathkeeperBonus + bonusCritDamage)
		--WriteString(oathkeepermodel, OathkeeperModel)
		WriteByte(oblivionattack, OblivionAttack + extraStrength)
		WriteByte(oblivionmagic, OblivionMagic)
		WriteByte(oblivioncritical, math.max(0, OblivionCriical + extraCritChance))
		WriteByte(oblivionbonus, OblivionBonus + bonusCritDamage)
		--WriteString(oblivionmodel, OblivionModel)
		WriteByte(diamonddustattack, DiamondDustAttack + extraStrength)
		WriteByte(diamonddustmagic, DiamondDustMagic)
		WriteByte(diamonddustcritical, math.max(0, DiamondDustCriical + extraCritChance))
		WriteByte(diamonddustbonus, DiamondDustBonus + bonusCritDamage)
		--WriteString(diamonddustmodel, DiamondDustModel)
		WriteByte(onewingedangelattack, OneWingedAngelAttack + extraStrength)
		WriteByte(onewingedangelmagic, OneWingedAngelMagic)
		WriteByte(onewingedangelcritical, math.max(0, OneWingedAngelCriical + extraCritChance))
		WriteByte(onewingedangelbonus, OneWingedAngelBonus + bonusCritDamage)
		--WriteString(onewingedangelmodel, OneWingedAngelModel)
		WriteByte(ultimaattack, UltimaAttack + extraStrength)
		WriteByte(ultimamagic, UltimaMagic)
		WriteByte(ultimacritical, math.max(0, UltimaCriical + extraCritChance))
		WriteByte(ultimabonus, UltimaBonus + bonusCritDamage)
		--WriteString(ultimamodel, UltimaModel)
	end
end

function get_current_crit_damage()
	displayedCritDamage = 0
	displayedCritChance = 0
	if ReadByte(comboPosition) < ReadByte(maxGroundComboLength) - 1 then
		displayedCritDamage = displayedCritDamage + 3
	end
	if ReadByte(currentWeapon) == 0x51 then -- Kingdom Key
		displayedCritDamage = displayedCritDamage + ReadByte(kingdomkeybonus)
		displayedCritChance = math.max(0, 30 + extraCritChance)
	elseif ReadByte(currentWeapon) == 0x52 then -- Sword
		displayedCritDamage = displayedCritDamage + ReadByte(dreamswordbonus)
		displayedCritChance = math.max(0, 25 + extraCritChance)
	elseif ReadByte(currentWeapon) == 0x53 then -- Shield
		displayedCritDamage = displayedCritDamage + ReadByte(dreamshieldbonus)
		displayedCritChance = math.max(0, 25 + extraCritChance)
	elseif ReadByte(currentWeapon) == 0x54 then -- Rod
		displayedCritDamage = displayedCritDamage + ReadByte(dreamrodbonus)
		displayedCritChance = math.max(0, 25 + extraCritChance)
	elseif ReadByte(currentWeapon) == 0x55 then -- Wooden
		displayedCritDamage = displayedCritDamage + ReadByte(woodenswordbonus)
		displayedCritChance = math.max(0, 25 + extraCritChance)
	elseif ReadByte(currentWeapon) == 0x56 then -- Jungle King
		displayedCritDamage = displayedCritDamage + ReadByte(junglekingbonus)
		displayedCritChance = math.max(0, 25 + extraCritChance)
	elseif ReadByte(currentWeapon) == 0x57 then -- Three Wishes
		displayedCritDamage = displayedCritDamage + ReadByte(threewishesbonus)
		displayedCritChance = math.max(0, 20 + extraCritChance)
	elseif ReadByte(currentWeapon) == 0x58 then -- Fairy Harp
		displayedCritDamage = displayedCritDamage + ReadByte(fairyharpbonus)
		displayedCritChance = math.max(0, 25 + extraCritChance)
	elseif ReadByte(currentWeapon) == 0x59 then -- Pumpkin
		displayedCritDamage = displayedCritDamage + ReadByte(pumpkinheadbonus)
		displayedCritChance = math.max(0, 25 + extraCritChance)
	elseif ReadByte(currentWeapon) == 0x5A then -- Crabclaw
		displayedCritDamage = displayedCritDamage + ReadByte(crabclawbonus)
		displayedCritChance = math.max(0, 20 + extraCritChance)
	elseif ReadByte(currentWeapon) == 0x5B then -- Div Rose
		displayedCritDamage = displayedCritDamage + ReadByte(divinerosebonus)
		displayedCritChance = math.max(0, 25 + extraCritChance)
	elseif ReadByte(currentWeapon) == 0x5C then -- SpellB
		displayedCritDamage = displayedCritDamage + ReadByte(spellbinderbonus)
		displayedCritChance = math.max(0, 25 + extraCritChance)
	elseif ReadByte(currentWeapon) == 0x5D then -- Olymp
		displayedCritDamage = displayedCritDamage + ReadByte(olympiabonus)
		displayedCritChance = math.max(0, 25 + extraCritChance)
	elseif ReadByte(currentWeapon) == 0x5E then -- Lion
		displayedCritDamage = displayedCritDamage + ReadByte(lionheartbonus)
		displayedCritChance = math.max(0, 20 + extraCritChance)
	elseif ReadByte(currentWeapon) == 0x5F then -- Chocobo
		displayedCritDamage = displayedCritDamage + ReadByte(metalchocobobonus)
		displayedCritChance = math.max(0, 25 + extraCritChance)
	elseif ReadByte(currentWeapon) == 0x60 then -- Oath
		displayedCritDamage = displayedCritDamage + ReadByte(oathkeeperbonus)
		displayedCritChance = math.max(0, 25 + extraCritChance)
	elseif ReadByte(currentWeapon) == 0x61 then -- Oblivion
		displayedCritDamage = displayedCritDamage + ReadByte(oblivionbonus)
		displayedCritChance = math.max(0, 100 + extraCritChance)
	elseif ReadByte(currentWeapon) == 0x62 then -- Lady
		displayedCritDamage = displayedCritDamage + ReadByte(ladyluckbonus)
		displayedCritChance = math.max(0, 100 + extraCritChance)
	elseif ReadByte(currentWeapon) == 0x63 then -- Wish
		displayedCritDamage = displayedCritDamage + ReadByte(wishingstarbonus)
		displayedCritChance = math.max(0, 30 + extraCritChance)
	elseif ReadByte(currentWeapon) == 0x64 then -- Ultima
		displayedCritDamage = displayedCritDamage + ReadByte(ultimabonus)
		displayedCritChance = math.max(0, 25 + extraCritChance)
	elseif ReadByte(currentWeapon) == 0x65 then -- Diamond
		displayedCritDamage = displayedCritDamage + ReadByte(diamonddustbonus)
		displayedCritChance = math.max(0, 0 + extraCritChance)
	elseif ReadByte(currentWeapon) == 0x66 then -- Angel
		displayedCritDamage = displayedCritDamage + ReadByte(onewingedangelbonus)
		displayedCritChance = math.max(0, 100 + extraCritChance)
	end
	
	local multi = 1
	for i = 1, check_ability_count(0x08) do
		multi = multi + 1
	end
	
	displayedCritChance = displayedCritChance * multi
	
	local digit1address = 0x2E192F8 - offset
	local digit2address = 0x2E192F9 - offset
	if displayedCritChance >= 100 then
		displayedCritChance = 100
		WriteByte(digit1address - 0x01, 0x22)
		WriteByte(digit1address, 0x21)
		WriteByte(digit2address, 0x21)
	else
		WriteByte(digit1address - 0x01, 0x01)
		local digit1 = 0x21
		digit1 = digit1 + math.floor(displayedCritChance / 10)
		WriteByte(digit1address, digit1)
		
		local digit2 = 0x21
		local offset = displayedCritChance - (math.floor(displayedCritChance / 10) * 10)
		WriteByte(digit2address, digit2 + offset)
	
	end
	
	WriteByte(0x2DE59DB - offset, displayedCritDamage) -- base defense for visual
	
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

function reset_keyblade_crit()
	KingdomKeyCriical = 30
	KingdomKeyBonus = 2
	DreamSwordCriical = 25
	DreamSwordBonus = 4
	DreamShieldCriical = 25
	DreamShieldBonus = 4
	DreamRodCriical = 0
	DreamRodBonus = 0
	WoodenSwordCriical = 0
	WoodenSwordBonus = 0
	JungleKingCriical = 25
	JungleKingBonus = 2
	ThreeWishesCriical = 25
	ThreeWishesBonus = 7
	CrabClawCriical = 20
	CrabClawBonus = 4
	PumpkinheadCriical = 25
	PumpkinheadBonus = 4
	FairyHarpCriical = 25
	FairyHarpBonus = 2
	WishingStarCriical = 30
	WishingStarBonus = 2
	SpellbinderCriical = 25
	SpellbinderBonus = 2
	MetalChocoboCriical = 20
	MetalChocoboBonus = 2
	OlympiaCriical = 20
	OlympiaBonus = 2
	LionheartCriical = 20
	LionheartBonus = 4
	LadyLuckCriical = 200
	LadyLuckBonus = 7
	DivineRoseCriical = 25
	DivineRoseBonus = 4
	OathkeeperCriical = 20
	OathkeeperBonus = 4
	OblivionCriical = 200
	OblivionBonus = 60
	DiamondDustCriical = 0
	DiamondDustBonus = 0
	OneWingedAngelCriical = 200
	OneWingedAngelBonus = 60
	UltimaCriical = 20
	UltimaBonus = 2
end




function GetKHSCII(INPUT)
    local _charTable = {
        [' '] =  0x01,
        ['\n'] =  0x02,
        ['-'] =  0x6E,
        ['!'] =  0x5F,
        ['?'] =  0x60,
        ['%'] =  0x62,
        ['/'] =  0x66,
        ['.'] =  0x68,
        [','] =  0x69,
        [';'] =  0x6C,
        [':'] =  0x6B,
        ['\''] =  0x71,
        ['('] =  0x74,
        [')'] =  0x75,
        ['['] =  0x76,
        [']'] =  0x77,
        ['¡'] =  0xCA,
        ['¿'] =  0xCB,
        ['À'] =  0xCC,
        ['Á'] =  0xCD,
        ['Â'] =  0xCE,
        ['Ä'] =  0xCF,
        ['Ç'] =  0xD0,
        ['È'] =  0xD1,
        ['É'] =  0xD2,
        ['Ê'] =  0xD3,
        ['Ë'] =  0xD4,
        ['Ì'] =  0xD5,
        ['Í'] =  0xD6,
        ['Î'] =  0xD7,
        ['Ï'] =  0xD8,
        ['Ñ'] =  0xD9,
        ['Ò'] =  0xDA,
        ['Ó'] =  0xDB,
        ['Ô'] =  0xDC,
        ['Ö'] =  0xDD,
        ['Ù'] =  0xDE,
        ['Ú'] =  0xDF,
        ['Û'] =  0xE0,
        ['Ü'] =  0xE1,
        ['ß'] =  0xE2,
        ['à'] =  0xE3,
        ['á'] =  0xE4,
        ['â'] =  0xE5,
        ['ä'] =  0xE6,
        ['ç'] =  0xE7,
        ['è'] =  0xE8,
        ['é'] =  0xE9,
        ['ê'] =  0xEA,
        ['ë'] =  0xEB,
        ['ì'] =  0xEC,
        ['í'] =  0xED,
        ['î'] =  0xEE,
        ['ï'] =  0xEF,
        ['ñ'] =  0xF0,
        ['ò'] =  0xF1,
        ['ó'] =  0xF2,
        ['ô'] =  0xF3,
        ['ö'] =  0xF4,
        ['ù'] =  0xF5,
        ['ú'] =  0xF6,
        ['û'] =  0xF7,
        ['ü'] =  0xF8
    }

    local _returnArray = {}

    local i = 1
    local z = 1

    while z <= #INPUT do
        local _char = INPUT:sub(z, z)

        if _char >= 'a' and _char <= 'z' then     
            _returnArray[i] = string.byte(_char) - 0x1C
            z = z + 1
        elseif _char >= 'A' and _char <= 'Z' then 
            _returnArray[i] = string.byte(_char) - 0x16
            z = z + 1
        elseif _char >= '0' and _char <= '9' then 
            _returnArray[i] = string.byte(_char) - 0x0F
            z = z + 1
        elseif _char == '{' then
            local _str = 
            { 
                INPUT:sub(z + 1, z + 1), 
                INPUT:sub(z + 2, z + 2),
                INPUT:sub(z + 3, z + 3), 
                INPUT:sub(z + 4, z + 4), 
                INPUT:sub(z + 5, z + 5)
            } 

            if _str[1] == '0' and _str[2] == 'x' and _str[5] == '}' then

                local _s = _str[3] .. _str[4]

                _returnArray[i] = tonumber(_s, 16)
                z = z + 6
            end
        else
            if _charTable[_char] ~= nil then
                _returnArray[i] = _charTable[_char]
                z = z + 1
            else
                _returnArray[i] = 0x01
                z = z + 1
            end
        end

        i = i + 1
    end
    
    table.insert(_returnArray, 0x00)
    return _returnArray
end

function ShowPrompt(inputTitle, inputParty, duration)
    local _boxMemory = 0x249740A
    local _textMemory = 0x2A1379A;

    local _partyOffset = 0x3A20;

    for i = 1, #inputTitle do
        if inputTitle[i] then
            WriteArray(_textMemory + 0x20 * (i - 1), GetKHSCII(inputTitle[i]))
        end
    end

    for z = 1, 3 do
        local _boxArray = inputParty[z];

        local _colorBox = 0x018408A + 0x10 * (z - 1)
        local _colorText = 0x01840CA + 0x10 * (z - 1)

        if _boxArray then
            local _textAddress = (_textMemory + 0x70) + (0x140 * (z - 1)) + (0x40 * 0)
            local _boxAddress = _boxMemory + (_partyOffset * (z - 1)) + (0xBA0 * 0)

            -- Write the box count.
            WriteInt(0x24973FA + 0x04 * (z - 1), 1)

            -- Write the Title Pointer.
            WriteLong(_boxAddress + 0x30, BASE_ADDR  + _textMemory + 0x20 * (z - 1))

            if _boxArray[2] then
                -- String Count is 2.
                WriteInt(_boxAddress + 0x18, 0x02)

                -- Second Line Text.
                WriteArray(_textAddress + 0x20, GetKHSCII(_boxArray[2]))
                WriteLong(_boxAddress + 0x28, BASE_ADDR  + _textAddress + 0x20)
            else
                -- String Count is 1
                WriteInt(_boxAddress + 0x18, 0x01)
            end

            -- First Line Text
            WriteArray(_textAddress, GetKHSCII(_boxArray[1]))
            WriteLong(_boxAddress + 0x20, BASE_ADDR  + _textAddress)

            -- Reset box timers.
            WriteInt(_boxAddress + 0x0C, duration)
            WriteFloat(_boxAddress + 0xB80, 1)

            -- Set box colors.
            WriteLong(_boxAddress + 0xB88, BASE_ADDR  + _colorBox)
            WriteLong(_boxAddress + 0xB90, BASE_ADDR  + _colorText)

            -- Show the box.
            WriteInt(_boxAddress, 0x01)
        end
    end
end








function _OnInit()
	if GAME_ID == 0xAF71841E and ENGINE_TYPE == "BACKEND" then
		canExecute = true
		ConsolePrint("CMix_Randomizer Installed")
	else
		ConsolePrint("CMix_Randomizer -- FAILED --")
	end
end


function randomize_emblem_location()
	local emblems = ReadByte(0x2DE5F25 - offset) + ReadByte(0x2DE5F26 - offset) + ReadByte(0x2DE5F27 - offset) + ReadByte(0x2DE5F28 - offset)
	if emblems >= 4 then
		WriteByte(emblemCount, 4)
		WriteByte(0x2DE5F25 - offset, 2)
		WriteByte(0x2DE5F26 - offset, 2)
		WriteByte(0x2DE5F27 - offset, 2)
		WriteByte(0x2DE5F28 - offset, 2)
	else
		WriteByte(emblemCount, 0)
	end
end


function _OnFrame()
	if not canExecute then
		goto done
	end
	
	if ReadByte(chronicles+0x10) == 0x20 then
		WriteByte(0x2DE61A1-offset, 2)
	end
	
	if emblemRando == true then
		randomize_emblem_location()
	end
	
	early_opposite_armor()
	WriteByte(randoEnabledGummi, 1)
	WriteShort(rewardTable+64, 0xFFF0)
	randomizer_effects()
	OblivionAttack = OblivionAttack + 30
	DiamondDustMagic = DiamondDustMagic + 4
	DiamondDustAttack = DiamondDustAttack - 6
	customize_keyblades()
	set_trinity_unlocks()
	replace_magic()
	WriteFloat(expMultiplier, experienceMultiplierAmount)
	
	
	::done::
end

function set_trinity_unlocks()
	local store = true
	
	if ReadByte(world) == 0x0B and ReadByte(room) == 0x02 then 
		store = false
	end
	
	if trinityList ~= {} then
		local unlock = 0
		
		if ReadByte(cutsceneFlags+0xB04) >= 0x31 then -- Blue Trinity
			unlock = unlock + (2^(trinityList[1]-1))
		end
		
		if ReadByte(chronicles+0xC) == 0x20 then -- Red Trinity
			unlock = unlock + (2^(trinityList[2]-1))
		end
		
		if ReadByte(0x2DE61A1-offset) == 0x02 then -- Green Trinity
			unlock = unlock + (2^(trinityList[3]-1))
		end
		
		if ReadByte(OCCupUnlock+2) == 1 then -- Yellow Trinity
			unlock = unlock + (2^(trinityList[4]-1))
		end
		
		if (ReadByte(journalCharacters+1) // 8) % 2 == 1 then -- White Trinity
			unlock = unlock + (2^(trinityList[5]-1))
		end
		
		if ReadByte(worldFlagBase+0x94) < 4 and ReadByte(world) == 11 and ReadByte(room) == 1 then -- Colliseum Fix
			WriteByte(trinityUnlock, 0)
		else
			WriteByte(trinityUnlock, unlock)
		end
		if store == true then
			trinity_replacement_notification()
		end
	end
	
	if store then
		lastTrinityState = ReadByte(trinityUnlock)
	end
end

function get_trinity_text(index)
	local text = "Blue"
	
	if index == 2 then
		text = "Red"
	elseif index == 3 then
		text = "Green"
	elseif index == 4 then
		text = "Yellow"
	elseif index == 5 then
		text = "White"
	end
	return(text)
end

function trinity_replacement_notification()
	if ReadByte(trinityUnlock) > lastTrinityState then
		local color_text = ""
		local replace_text = ""
		if ReadByte(world) == 0x03 and ReadByte(room) == 0 then -- First District
			color_text = get_trinity_text(trinityList[1])
			replace_text = "Blue"
		end
		if ReadByte(world) == 0x05 and ReadByte(room) == 0x0E then -- Tent Red Trinity
			color_text = get_trinity_text(trinityList[2])
			replace_text = "Red"
		end
		if ReadByte(world) == 0x08 and ReadByte(room) == 0x12 then -- Agrabah Green Trinity
			color_text = get_trinity_text(trinityList[3])
			replace_text = "Green"
		end
		if ReadByte(world) == 0x0B and lastTrinityState > 0 then -- Olympus Yellow
			color_text = get_trinity_text(trinityList[4])
			replace_text = "Yellow"
		end
		if ReadByte(world) == 0x0F and ReadByte(room) == 0x04 then -- Riku White Trinity
			color_text = get_trinity_text(trinityList[5])
			replace_text = "White"
		end
		if color_text ~= "" then
			ShowPrompt({ "RANDOMIZATION"}, { {"Learned " .. color_text .. " Trinity!!", "(Replaced " .. replace_text .. ")"} }, -1000)
		end
	end
end




function replace_magic()

	local isLoading = 0x233CAC4 - offset

	local forced_magic_levels = {0, 0, 0, 0, 0, 0, 0}
	if ReadByte(stateFlag) ~= 0x00 and ReadByte(stateFlag) ~= 0x20 then
		stateCheckTimer = 20
	end
	if stateCheckTimer > 0 then
		stateCheckTimer = stateCheckTimer - 1
	end
	local prefix = "Learned "
	if magicList ~= {} then
		local unlock = 0 
		
		for i=1,7 do
			-- Check Base Unlocks
			if ReadByte(magicFlags + i - 1) > 0 then
				unlock = unlock + (2^(magicList[i]-1))
				
				local affected_magic_level = ReadByte(magicLevels + magicList[i] - 1)
				if ReadByte(magicFlags + i - 1) > affected_magic_level then
					if affected_magic_level > 0 then
						prefix = "Upgraded "
					end
					lastLearnedMagic = "Fire"
					lastReplacedMagic = "Fire"
					if i == 2 then
						lastReplacedMagic = "Blizzard"
					elseif i == 3 then
						lastReplacedMagic = "Thunder"
					elseif i == 4 then
						lastReplacedMagic = "Cure"
					elseif i == 5 then
						lastReplacedMagic = "Gravity"
					elseif i == 6 then
						lastReplacedMagic = "Stop"
					elseif i == 7 then
						lastReplacedMagic = "Aero"
					end
					
					if magicList[i] == 2 then
						lastLearnedMagic = "Blizzard"
					elseif magicList[i] == 3 then
						lastLearnedMagic = "Thunder"
					elseif magicList[i] == 4 then
						lastLearnedMagic = "Cure"
					elseif magicList[i] == 5 then
						lastLearnedMagic = "Gravity"
					elseif magicList[i] == 6 then
						lastLearnedMagic = "Stop"
					elseif magicList[i] == 7 then
						lastLearnedMagic = "Aero"
					end
					
				-- Notification about learning a new spell
				end
				
			end
			
			local m = 0
			if ReadByte(isLoading) == 1 then
				m = 1
			end
			WriteByte(magicLevels + magicList[i] - 1, math.max(m, ReadByte(magicFlags + i - 1))) -- Set Magic Upgrade Status
	
			if ReadFloat(soraHUD) > 0 then
				WriteByte(fireSlot + ((magicList[i] - 1) * 0x38), math.max(1, ReadByte(magicFlags + i - 1))) -- Set Magic Command Status
			end

		end
		if lastLearnedMagic ~= "" and stateCheckTimer == 0 then
			if ReadByte(stateFlag) == 0x00 or ReadByte(stateFlag) == 0x20 or ReadByte(stateFlag) == 0x21 or ReadByte(stateFlag) == 0x01 then
				ShowPrompt({nil, "RANDOMIZATION"}, { nil ,{prefix .. lastLearnedMagic .. " Magic!!", "(Replaced " .. lastReplacedMagic .. ")"} }, -1000)
				lastLearnedMagic = ""
			end
		end
		WriteByte(magicUnlock, unlock)
	end
end

function early_opposite_armor()
	if ReadByte(traverseFlags) == 0x3E then
		WriteByte(traverseFlags, 0x42)
	end
	
	if ReadByte(traverseFlags) >= 0x42 and ReadByte(0x2DE6EE2 - offset) < 0x14 and ReadByte(world) == 3 and ReadByte(room) == 1 and ReadByte(traverseStatus) < 4 then
		WriteByte(flag, 3)
	end
end



--RANDO_START