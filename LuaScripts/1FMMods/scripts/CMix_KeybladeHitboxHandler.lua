LUAGUI_NAME = "CMix_KeybladeHitboxHandler"
LUAGUI_AUTH = "Xendra"
LUAGUI_DESC = "Intercepts Keyblade Hitbox, allowing you to customize it with code. Has options."



--
local offset = 0x3A0606 -- Offset adjusted to shift all values
local soraPointer = 0x2534680 - offset
local comboPosition = 0x29678A1 - offset
local maxGroundComboLength = 0x2E90914 - offset
local bonusHitbox = 0.0
local currentWeapon = 0x2DE5A06 - offset

local kingdomkeyHitbox = 55.0
local dreamswordHitbox = 55.0
local dreamshieldHitbox = 55.0
local dreamrodHitbox = 55.0
local woodenswordHitbox = 55.0
local junglekingHitbox = 55.0
local threewishesHitbox = 55.0
local crabclawHitbox = 55.0
local pumpkinheadHitbox = 55.0
local fairyharpHitbox = 55.0
local wishingstarHitbox = 55.0
local spellbinderHitbox = 55.0
local metalchocoboHitbox = 55.0  
local olympiaHitbox = 55.0
local lionheartHitbox = 55.0
local ladyluckHitbox = 55.0
local divineroseHitbox = 55.0
local oathkeeperHitbox = 55.0
local oblivionHitbox = 55.0
local diamonddustHitbox = 55.0
local onewingedangelHitbox = 55.0
local ultimaHitbox = 55.0


kingdomkeyHitboxAddress = 0x2D288E8 - offset - 0x10
dreamswordHitboxAddress = 0x2D28940 - offset- 0x10
dreamshieldHitboxAddress = 0x2D28998 - offset- 0x10
dreamrodHitboxAddress = 0x2D289F0 - offset- 0x10
woodenswordHitboxAddress = 0x2D28A48 - offset- 0x10
junglekingHitboxAddress = 0x2D28AA0 - offset- 0x10
threewishesHitboxAddress = 0x2D28AF8 - offset- 0x10
crabclawHitboxAddress = 0x2D28C00 - offset- 0x10
pumpkinheadHitboxAddress = 0x2D28BA8 - offset- 0x10
fairyharpHitboxAddress = 0x2D28B50 - offset- 0x10
wishingstarHitboxAddress = 0x2D28F18 - offset- 0x10
spellbinderHitboxAddress = 0x2D28CB0 - offset- 0x10
metalchocoboHitboxAddress = 0x2D28DB8 - offset- 0x10
olympiaHitboxAddress = 0x2D28D08 - offset- 0x10
lionheartHitboxAddress = 0x2D28D60 - offset- 0x10
ladyluckHitboxAddress = 0x2D28EC0 - offset- 0x10
divineroseHitboxAddress = 0x2D28C58 - offset- 0x10
oathkeeperHitboxAddress = 0x2D28E10 - offset- 0x10
oblivionHitboxAddress = 0x2D28E68 - offset- 0x10
diamonddustHitboxAddress = 0x2D28FC8 - offset- 0x10
onewingedangelHitboxAddress = 0x2D25020 - offset- 0x10
ultimaHitboxAddress = 0x2D28F70 - offset- 0x10

function _OnInit()
	if GAME_ID == 0xAF71841E and ENGINE_TYPE == "BACKEND" then
		ConsolePrint("CMix_KeybladeHitboxHandler Installed")
		canExecute = true
	end
end

function activate_accessories()
	olympus_medal()
end

function olympus_medal()
	for i = 1, check_accessory_count(0x49) do
		bonusHitbox = bonusHitbox * 1.1
		bonusHitbox = bonusHitbox + 50
	end
end

function brave_warrior()
	for i = 1, check_accessory_count(0x30) do
		bonusHitbox = bonusHitbox + 35
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



function _OnFrame()
	if canExecute == true then
		
		local currentAnim = ReadLong(soraPointer)+0x164			
		bonusHitbox = 0.0
		
		if ReadByte(0x2DE5EFA - offset) >= 1 then -- Sword
			bonusHitbox = bonusHitbox + 25.0
		end
		
		if ReadByte(comboPosition) >= ReadByte(maxGroundComboLength) -1 then
			bonusHitbox = bonusHitbox + 40.0
			brave_warrior()
		end
		if ReadByte(currentWeapon) == 0x5D then -- Olympia
			bonusHitbox = bonusHitbox + 90.0
		end
		activate_accessories()
		-- Write Keyblade Hitbox Values
		WriteFloat(kingdomkeyHitboxAddress, kingdomkeyHitbox + bonusHitbox)
		WriteFloat(dreamswordHitboxAddress, dreamswordHitbox + bonusHitbox)
		WriteFloat(dreamshieldHitboxAddress, dreamshieldHitbox + bonusHitbox)
		WriteFloat(dreamrodHitboxAddress, dreamrodHitbox + bonusHitbox)
		WriteFloat(woodenswordHitboxAddress, woodenswordHitbox + bonusHitbox)
		WriteFloat(junglekingHitboxAddress, junglekingHitbox + bonusHitbox)
		WriteFloat(threewishesHitboxAddress, threewishesHitbox + bonusHitbox)
		WriteFloat(crabclawHitboxAddress, crabclawHitbox + bonusHitbox)
		WriteFloat(pumpkinheadHitboxAddress, pumpkinheadHitbox + bonusHitbox)
		WriteFloat(fairyharpHitboxAddress, fairyharpHitbox + bonusHitbox)
		WriteFloat(wishingstarHitboxAddress, wishingstarHitbox + bonusHitbox)
		WriteFloat(spellbinderHitboxAddress, spellbinderHitbox + bonusHitbox)
		WriteFloat(metalchocoboHitboxAddress, metalchocoboHitbox + bonusHitbox)
		WriteFloat(olympiaHitboxAddress, olympiaHitbox + bonusHitbox)
		WriteFloat(lionheartHitboxAddress, lionheartHitbox + bonusHitbox)
		WriteFloat(ladyluckHitboxAddress, ladyluckHitbox + bonusHitbox)
		WriteFloat(divineroseHitboxAddress, divineroseHitbox + bonusHitbox)
		WriteFloat(oathkeeperHitboxAddress, oathkeeperHitbox + bonusHitbox)
		WriteFloat(oblivionHitboxAddress, oblivionHitbox + bonusHitbox)
		WriteFloat(diamonddustHitboxAddress, diamonddustHitbox + bonusHitbox)
		WriteFloat(onewingedangelHitboxAddress, onewingedangelHitbox + bonusHitbox)
		WriteFloat(ultimaHitboxAddress, ultimaHitbox + bonusHitbox)
	end
end

