LUAGUI_NAME = "CMix_KeybladeRecoilHandler"
LUAGUI_AUTH = "Xendra"
LUAGUI_DESC = "Intercepts Keyblade Recoil, allowing you to customize it with code. Has options."




-- Settings
local counterattackPierce = true
local counterattackFinisher = true
--
local offset = 0x3A0606 -- Offset adjusted to shift all values
local soraPointer = 0x2534680 - offset
local comboPosition = 0x29678A1 - offset
local maxGroundComboLength = 0x2E90914 - offset


kingdomkeyRecoil = 90
dreamswordRecoil = 90
dreamshieldRecoil = 90
dreamrodRecoil = 90
woodenswordRecoil = 90
junglekingRecoil = 90
threewishesRecoil = 90
crabclawRecoil = 90
pumpkinheadRecoil = 90
fairyharpRecoil = 90
wishingstarRecoil = 90
spellbinderRecoil = 90
metalchocoboRecoil = 90   
olympiaRecoil = 90
lionheartRecoil = 90
ladyluckRecoil = 90
divineroseRecoil = 90
oathkeeperRecoil = 90
oblivionRecoil = 90
diamonddustRecoil = 90
onewingedangelRecoil = 90
ultimaRecoil = 90


kingdomkeyRecoilAddress = 0x2D288E8 - offset + 0x03
dreamswordRecoilAddress = 0x2D28940 - offset+ 0x03
dreamshieldRecoilAddress = 0x2D28998 - offset+ 0x03
dreamrodRecoilAddress = 0x2D289F0 - offset+ 0x03
woodenswordRecoilAddress = 0x2D28A48 - offset+ 0x03
junglekingRecoilAddress = 0x2D28AA0 - offset+ 0x03
threewishesRecoilAddress = 0x2D28AF8 - offset+ 0x03
crabclawRecoilAddress = 0x2D28C00 - offset+ 0x03
pumpkinheadRecoilAddress = 0x2D28BA8 - offset+ 0x03
fairyharpRecoilAddress = 0x2D28B50 - offset+ 0x03
wishingstarRecoilAddress = 0x2D28F18 - offset+ 0x03
spellbinderRecoilAddress = 0x2D28CB0 - offset+ 0x03
metalchocoboRecoilAddress = 0x2D28DB8 - offset+ 0x03
olympiaRecoilAddress = 0x2D28D08 - offset+ 0x03
lionheartRecoilAddress = 0x2D28D60 - offset+ 0x03
ladyluckRecoilAddress = 0x2D28EC0 - offset+ 0x03
divineroseRecoilAddress = 0x2D28C58 - offset+ 0x03
oathkeeperRecoilAddress = 0x2D28E10 - offset+ 0x03
oblivionRecoilAddress = 0x2D28E68 - offset+ 0x03
diamonddustRecoilAddress = 0x2D28FC8 - offset+ 0x03
onewingedangelRecoilAddress = 0x2D29020 - offset+ 0x03
ultimaRecoilAddress = 0x2D28F70 - offset+ 0x03

local commandSlot1 = 0x525594 - offset
local counterPiercing = 0
local pierceDuration = 60

function _OnInit()
	if GAME_ID == 0xAF71841E and ENGINE_TYPE == "BACKEND" then
		ConsolePrint("CMix_KeybladeRecoilHandler Installed")
		canExecute = true
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


function _OnFrame()
	if canExecute == true then
		local bonusRecoil = 0
		local currentAnim = ReadLong(soraPointer)+0x164
		
		if counterattackPierce == true then
			if counterPiercing > 0 then
				counterPiercing = counterPiercing - 1
			end
			-- Also do it if you have the counter command in slot 1
			if ReadByte(commandSlot1) == 0x63 then
				counterPiercing = pierceDuration
				if ReadByte(0x2DE59F6 - offset) ~= 0x45 then
					WriteByte(comboPosition, ReadByte(maxGroundComboLength))
				end
			end
			
			if counterPiercing > 0 and ReadByte(currentAnim, true) ~= 0xD4 then
				bonusRecoil = 165
			end
		end
		local pierce = check_ability_count(0x2F)
		if pierce > 0 and ReadByte(comboPosition) >= ReadByte(maxGroundComboLength) - 1 and ReadByte(currentAnim, true) ~= 0xD4 then
			bonusRecoil = 165
		end
		-- Write Keyblade Recoil Values
		WriteByte(kingdomkeyRecoilAddress, kingdomkeyRecoil + bonusRecoil)
		WriteByte(dreamswordRecoilAddress, dreamswordRecoil + bonusRecoil)
		WriteByte(dreamshieldRecoilAddress, dreamshieldRecoil + bonusRecoil)
		WriteByte(dreamrodRecoilAddress, dreamrodRecoil + bonusRecoil)
		WriteByte(woodenswordRecoilAddress, woodenswordRecoil + bonusRecoil)
		WriteByte(junglekingRecoilAddress, junglekingRecoil + bonusRecoil)
		WriteByte(threewishesRecoilAddress, threewishesRecoil + bonusRecoil)
		WriteByte(crabclawRecoilAddress, crabclawRecoil + bonusRecoil)
		WriteByte(pumpkinheadRecoilAddress, pumpkinheadRecoil + bonusRecoil)
		WriteByte(fairyharpRecoilAddress, fairyharpRecoil + bonusRecoil)
		WriteByte(wishingstarRecoilAddress, wishingstarRecoil + bonusRecoil)
		WriteByte(spellbinderRecoilAddress, spellbinderRecoil + bonusRecoil)
		WriteByte(metalchocoboRecoilAddress, metalchocoboRecoil + bonusRecoil)
		WriteByte(olympiaRecoilAddress, olympiaRecoil + bonusRecoil)
		WriteByte(lionheartRecoilAddress, lionheartRecoil + bonusRecoil)
		WriteByte(ladyluckRecoilAddress, ladyluckRecoil + bonusRecoil)
		WriteByte(divineroseRecoilAddress, divineroseRecoil + bonusRecoil)
		WriteByte(oathkeeperRecoilAddress, oathkeeperRecoil + bonusRecoil)
		WriteByte(oblivionRecoilAddress, oblivionRecoil + bonusRecoil)
		WriteByte(diamonddustRecoilAddress, diamonddustRecoil + bonusRecoil)
		WriteByte(onewingedangelRecoilAddress, onewingedangelRecoil + bonusRecoil)
		WriteByte(ultimaRecoilAddress, ultimaRecoil + bonusRecoil)
	end
end

