LUAGUI_NAME = "Customize KHI Weapons"
LUAGUI_AUTH = "KSX, Values by Xendra"
LUAGUI_DESC = "Customize KHI Weapons"

local offset = 0x3A0606
local canExecute = false
local enableCriticalMix = true
local swapped = ReadByte(0x22D6C7E - offset)
local displayedCritDamage = 0
local displayedCritChance = 0
local extraStrength = 0

local shortcut1 = 0x2DE6214 - offset
local randoEnabledGummi = 0x2DF18DA - offset -- Unused Gummi 3
local rikuEnabledGummi = 0x2DF18DC - offset -- Unused Gummi 5
local currentLinkItem = 0x2DE5F51 - offset
local rikuStanceGummi = 0x2DF18DE - offset -- Unused Gummi 7

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
local currentAnim = ReadLong(soraPointer)+0x164
local soraSlot = 0x2D59000 - offset + soraSlotOffset
local maxGroundComboLength = soraSlot + 0xD4
local currentWeapon = 0x2DE5A06 - offset
local extraCritChance = 0
local airborneStatus = ReadFloat(ReadLong(soraPointer)+0x70, true)
local connectCounter = 0x29678B0 - offset

function _OnInit()
	if GAME_ID == 0xAF71841E and ENGINE_TYPE == "BACKEND" then
		canExecute = true
		ConsolePrint("Customize KHI Weapons - installed")
	else
		ConsolePrint("Customize KHI Weapons - failed")
	end
end

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
		local traverseStatus = 0x2DE78C0 - offset
		
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

function _OnFrame()
	if canExecute == true and ReadByte(randoEnabledGummi) == 0 then
		reset_keyblade_stats()
		reset_keyblade_crit()
		airborneStatus = ReadFloat(ReadLong(soraPointer)+0x70, true)
		currentAnim = ReadLong(soraPointer)+0x164
		set_sora_pointer_data()
		extraStrength = 0
		
		calculate_exp_zero_strength()
		
		extraCritChance = 0
		bonusCritDamage = 0
		if ReadByte(currentAnim, true) == 0xD5 then
			extraCritChance = 100
		end
		if ReadByte(rikuEnabledGummi) > 0 then
			
			bonusCritDamage = bonusCritDamage - 1
			local crit_stance = check_ability_count(0x31)
			if crit_stance > 0 and ReadByte(rikuStanceGummi) == 1 then
				bonusCritDamage = bonusCritDamage + (ReadByte(currentLinkItem) * 2)
			end
		
		end
		
		
		if airborneStatus < 0.1 and ReadByte(comboPosition) >= ReadByte(maxGroundComboLength) - 1 then
			bonusCritDamage = bonusCritDamage + 3
		end

		apply_accessories()
		
		

		critical_mp()
		
		change_def_text_to_crt()
		change_ap_text_to_sp()
		change_ap_text_to_crit_chance()
		if ReadByte(0x2E8EFB0 - offset) > 0x00 or (ReadByte(0x233D034-0x3A0606)//(0x08))%2 == 1 then
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
		
		
		bonusCritDamage = math.max(0, bonusCritDamage)
		
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

function reset_keyblade_stats()
	KingdomKeyAttack = 1
	KingdomKeyMagic = -1
	DreamSwordAttack = 4
	DreamSwordMagic = 0
	DreamShieldAttack = 4
	DreamShieldMagic = 0
	DreamRodAttack = 3
	DreamRodMagic = 2	
	WoodenSwordAttack = -2
	WoodenSwordMagic = 3
	JungleKingAttack = 6
	JungleKingMagic = -1
	ThreeWishesAttack = 4
	ThreeWishesMagic = 0
	CrabClawAttack = 3
	CrabClawMagic = 1
	PumpkinheadAttack = 2
	PumpkinheadMagic = 1
	FairyHarpAttack = 0
	FairyHarpMagic = 2
	WishingStarAttack = 4
	WishingStarMagic = 0
	SpellbinderAttack = 0
	SpellbinderMagic = 2
	MetalChocoboAttack = 8
	MetalChocoboMagic = -2
	OlympiaAttack = 5
	OlympiaMagic = 0
	LionheartAttack = 2
	LionheartMagic = 1
	LadyLuckAttack = 2
	LadyLuckMagic = 1
	DivineRoseAttack = 4
	DivineRoseMagic = 0
	OathkeeperAttack = 0
	OathkeeperMagic = 2
	OblivionAttack = 30
	OblivionMagic = -2
	DiamondDustAttack = -7
	DiamondDustMagic = 7
	OneWingedAngelAttack = 7
	OneWingedAngelMagic = -2
	UltimaAttack = 4
	UltimaMagic = 2
end





-- xw_ex_5010:Kingdom Key
-- xw_dh_5000:Dream Sword
-- xw_dh_5010:Dream Shield
-- xw_dh_5020:Dream Rod
-- xw_di_5000:Wooden Sword
-- xw_ex_5020:Jungle King
-- xw_ex_5030:Three Wishes
-- xw_ex_5040:Fairy Harp
-- xw_ex_5050:Pumpkinhead
-- xw_ex_5060:Crabclaw
-- xw_ex_5070:Divine Rose
-- xw_ex_5080:Spellbinder
-- xw_ex_5090:Olympia
-- xw_ex_5100:Lionheart
-- xw_ex_5110:Metal Chocobo
-- xw_ex_5120:Oathkeeper
-- xw_ex_5130:Oblivion
-- xw_ex_5140:Lady Luck
-- xw_ex_5150:Wishing Star
-- xw_ex_5160:Ultima Weapon
-- xw_ex_5190:Diamond Dust
-- xw_ex_5200:One-Winged Angel
-- xw_ex_5210:Mage´s Staff
-- xw_ex_5220:Morning Star
-- xw_ex_5230:Shooting Star
-- xw_ex_5240:Magus Staff
-- xw_ex_5250:Wisdom Staff
-- xw_ex_5260:Warhammer
-- xw_ex_5270:Silver Mallet
-- xw_ex_5280:Grand Mallet
-- xw_ex_5290:Lort Fortune
-- xw_ex_5300:Violetta
-- xw_ex_5330:Wizard´s Relic
-- xw_ex_5310:Dream Rod
-- xw_ex_5350:Meteor Strike
-- xw_ex_5360:Fantasista
-- xw_ex_5320:Save the Queen
-- xw_ex_5340:UnKown Staff(Crash)
-- xw_ex_5410:Knight´s Shield
-- xw_ex_5420:Mythril Shield
-- xw_ex_5430:Onyx Shield
-- xw_ex_5470:Smasher
-- xw_ex_5480:Gigas Fist
-- xw_ex_5440:Stout Shield
-- xw_ex_5450:Golem Shield
-- xw_ex_5460:Adamant Shield
-- xw_ex_5500:Herc´s Shield
-- xw_ex_5490:Genji Shield
-- xw_ex_5530:Defender
-- xw_ex_5510:Dream Shield
-- xw_ex_5560:Mighty Shield
-- xw_ex_5570:Seven Elements
-- xw_ex_5520:Save the King
-- xw_tz_5000:Tarzan Spear
-- xw_al_5000:Aladdin Saber
-- xw_lm_5030:Crash
-- xw_nm_5000:Crash
-- xw_pp_5000:Peter Pan Dagger
-- xw_pc_5000:Crash
-- xw_nothing:Crash