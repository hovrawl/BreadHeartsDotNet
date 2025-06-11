LUAGUI_NAME = "CMix_StatHandler"
LUAGUI_AUTH = "Xendra"
LUAGUI_DESC = "Changes to stats and systems for Critical Mix"


local offset = 0x3A0606

local comboPosition = 0x29678A1 - offset
local soraPointer = 0x2534680 - offset
local soraSlotOffset = ReadShort(ReadLong(soraPointer) + 0x6C, true) - 0x9000
local soraSlot = 0x2D59000 - offset + soraSlotOffset
local currentMP = soraSlot + 68
local maxMP = soraSlot + 72
local currentHP = soraSlot + 60
local maxHP = soraSlot + 64
local mpCharge = soraSlot + 190
local connectCounter = 0x29678B0 - offset

local linkedSpiritItem = 0x2DE5EFD - offset
local currentLinkItem = 0x2DE5F51 - offset
local knockback = 0x297717 - offset
local stateFlag = 0x2863958 - offset
local shortcut1 = 0x2DE6214 - offset
local swapped = ReadByte(0x22D6C7E - offset)
local baseAccessories = 0x2DE59EC - offset
local speedup = 0x233C24C - offset

-- Sora's Base Stats before equipment
local soraBaseAP = 0x2DE59D9 - offset
local currentWeapon = 0x2DE5A06 - offset

--
local currentAnim = ReadLong(soraPointer)+0x164

local prizeDrop = 0x2A1C1E - offset
local itemDrop = 0x2A1C14 - offset
-- World Status
local traverseStatus = 0x2DE78C0 - offset
local wonderlandStatus = 0x2DE78C1 - offset
local olympusStatus = 0x2DE78C2 - offset
local jungleStatus = 0x2DE78C3 - offset
local agrabahStatus = 0x2DE78C4 - offset
local halloweenStatus = 0x2DE78C5 - offset
local atlanticaStatus = 0x2DE78C6 - offset
local neverlandStatus = 0x2DE78C7 - offset
local hollowBastionStatus = 0x2DE78C8 - offset
local eotwStatus = 0x2DE78C9 - offset
local world = 0x233CADC - offset
local room = 0x233CB44 - offset
local flag = 0x233CB48 - offset
-- Gummi items are used to communicate data between scripts --
CriticalMPTrackingGummi = 0x2DF18D8 - offset -- Unused Gummi 1
local randoEnabledGummi = 0x2DF18DA - offset -- Unused Gummi 3
local randoNaviGummi = 0x2DF18DB - offset -- Unused Gummi 4
local rikuEnabledGummi = 0x2DF18DC - offset -- Unused Gummi 5
local noSpiritDrainGummi = 0x2DF18DD - offset -- Unused Gummi 6
local rikuStanceGummi = 0x2DF18DE - offset -- Unused Gummi 7
-- Stance 0: Darkness
-- Stance 1: Critical
-- Stance 2: Drain
-- Stance 3: Mage

-- Gummi items are used to communicate data between scripts --
local enemyFireResistSlot3 = 0x2D59510 - offset
local enemyIceResistSlot3 = 0x2D59514 - offset
local enemyThunderResistSlot3 = 0x2D59518 - offset

local partyMember1 = 0x2DE5E5E - offset
local partyMember2 = partyMember1 + 1
local partyMember3 = partyMember1 + 2
local partyMember4 = partyMember1 + 3


local lifeOnHit = 0
local bonuscharge = 0
spellbinderCooldown = 1
spellbinderDelay = 7
kingdomKeyRegenDelay = 60

local enemyEleResTarget = 1.0
local notifShowing_WrongText = false

local l3Cooldown = 0

function toggle_stance()
	if l3Cooldown > 0 then
		l3Cooldown = l3Cooldown - 1
	else
		if ReadByte(rikuEnabledGummi) > 0 and (ReadByte(0x233D034-0x3A0606)//(0x02))%2 == 1 then -- L3 Press
			l3Cooldown = 10
			local target_stance = ReadByte(rikuStanceGummi) + 1
			local crit = check_ability_count(0x31)
			local drain = check_ability_count(0x27)
			local mage = check_ability_count(0x28)
			local end_stance = 3
			
			if crit == 0 and target_stance == 1 then
				target_stance = 2
			end
			if drain == 0 and target_stance == 2 then
				target_stance = 3
			end
			if mage == 0 and target_stance == 3 then
				target_stance = 0
			end
			if target_stance > end_stance then
				target_stance = 0
			end
			if ReadByte(world) == 3 and ReadByte(room) == 2 and ReadByte(flag) == 2 then
				ShowPrompt({ nil, "BOSS" }, { nil, {"Dark Powers Blocked", "by Guard Armor!"}  }, 0)
			else
				if target_stance == 0 then
					ShowPrompt({ nil, "STANCE" }, { nil, {"Dark Stance", "Gaining Extra Darkness"}  }, 0)
				elseif target_stance == 1 then
					ShowPrompt({ nil, "STANCE" }, { nil, {"Critical Stance", "Darkness Boosts Criticals"}  }, 0)
				elseif target_stance == 2 then
					ShowPrompt({ nil, "STANCE" }, { nil, {"Drain Stance", "Darkness Grants Lifesteal"}  }, 0)
				elseif target_stance == 3 then
					ShowPrompt({ nil, "STANCE" }, { nil, {"Mage Stance", "Darkness Grants MP Charge"}  }, 0)
				end
				WriteByte(rikuStanceGummi, target_stance)
			end
		end
	end
end

function set_navi_gummi()
	local navi1 = 0x2DE5F34 - offset
	local navi2 = 0x2DE5F35 - offset
	if ReadByte(0x2DE6ED4 - offset) < 0x60 then -- Traverse Town Cutscene Flag
		if ReadByte(randoNaviGummi) == 0 then 
			if ReadByte(traverseStatus) >= 0x04 then -- TT Sealed
				WriteByte(navi1, 1)
			end
			if ReadByte(0x2DE6EDD - offset) >= 0x6E then -- Neverland Cutscene Flag
				WriteByte(navi2, 1)
			end
		end
	else -- Wipe navi gummis if you have already installed them
		WriteByte(navi1, 0)
		WriteByte(navi2, 0)
	end
	if ReadByte(world) == 3 and ReadByte(room) == 0 then
		if ReadByte(navi1) > 0 and ReadByte(navi2) > 0 then
			WriteByte(flag, 5)
		end
		if ReadByte(0x2DE6EDE - offset) >= 0xA0 then -- Hollow Bastion Cutscene Flag
			WriteByte(flag, 5)
		end
	end
end

function prevent_duplicate_soras()
	for i = 0, 2 do
		if ReadByte(partyMember2 + i) == 0 then
			WriteByte(partyMember2 + i, 0xFF)
		end
	end
end

function set_enemy_resistances()
	enemyEleResTarget = 1.0
	if ReadByte(rikuEnabledGummi) == 0 then
		for i = 1, check_ability_count(0x2E) do -- Overload, Sora Exclusive
			enemyEleResTarget = enemyEleResTarget + 0.25
			if ReadByte(currentMP) > 3 then
				WriteByte(currentMP, 3)
			end
		end
	end
	
	local start = 0
	
	if soraSlotOffset > 910 then -- Slot 3+ Sora
		start = 1
	end
	
	for i = start, 8 do
		local res = ReadFloat(enemyFireResistSlot3 + (i * 0x100))
		if res >= 0.01 and res < enemyEleResTarget * 0.8 then
			WriteFloat(enemyFireResistSlot3 + (i * 0x100), enemyEleResTarget)
		end
		
		local res = ReadFloat(enemyIceResistSlot3 + (i * 0x100))
		if res >= 0.01 and res < enemyEleResTarget then
			WriteFloat(enemyIceResistSlot3 + (i * 0x100), enemyEleResTarget * 1.3)
		end
		
		local res = ReadFloat(enemyThunderResistSlot3 + (i * 0x100))
		if res >= 0.01 and res < enemyEleResTarget then
			WriteFloat(enemyThunderResistSlot3 + (i * 0x100), enemyEleResTarget * 1.2)
		end
	end

end




function check_accessory_slot_amount()
	local sealed = 0
	local accessories = 1
	
	
	if ReadByte(0x2DE6ED7 - offset) >= 0x30 then -- Trickmaster Cutscene Flag
		sealed = sealed + 1
	end
	if ReadByte(jungleStatus) >= 0x04 then -- Deep Jungle, Automatically puts you onto gummi map
		sealed = sealed + 1
	end
	if ReadByte(0x2DE6ED6 - offset) >= 0x3C then -- Olympus Cutscene Flag
		sealed = sealed + 1
	end
	if ReadByte(0x2DE6ED8 - offset) >= 0x6E then -- Agrabah Cutscene Flag
		sealed = sealed + 1
	end
	if ReadByte(0x2DE6ED9 - offset) >= 0x46 then -- Parasite Cage 2 Cutscene Flag
		sealed = sealed + 1
	end
	if ReadByte(0x2DE6EDA - offset) >= 0x64 then -- Atlantica Cutscene Flag
		sealed = sealed + 1
	end
	if ReadByte(0x2DE6EDC - offset) >= 0x6E then -- Halloween Town Cutscene Flag
		sealed = sealed + 1
	end
	if ReadByte(0x2DE6EDD - offset) >= 0x6E then -- Neverland Cutscene Flag
		sealed = sealed + 1
	end
	if ReadByte(0x2DE6EE2 - offset) >= 0x14 then -- Opposite Armor Cutscene Flag
		sealed = sealed + 1
	end
	if ReadByte(0x2DE6EDE - offset) >= 0xC3 then -- Hollow Bastion Cutscene Flag
		sealed = sealed + 1
	end
	
	if ReadByte(eotwStatus) >= 4 then
		sealed = sealed + 1
	end
	
	
	if sealed >= 1 then
		accessories = 2
	end
	if sealed >= 4 then
		accessories = 3
	end
	if sealed >= 8 then
		accessories = 4
	end
	if accessories > ReadByte(baseAccessories) and ReadByte(baseAccessories) > 0 then
		notify_gained_accessory_slot()
	end
	WriteByte(baseAccessories, accessories)
end


function _OnFrame()
	if not canExecute then
		goto done
	end
	
	if soraSlotOffset == 910 then -- Slot 2 Sora
		connectCounter = 0x2967910 - offset
	else -- Slot 1 Sora
		connectCounter = 0x29678B0 - offset
	end
	set_navi_gummi()
	prevent_duplicate_soras()
	notify_wrong_shop_text()
	set_sora_pointer_data()
	WriteShort(0x2EE55E0 - offset, 0xFFFF) -- No Title AMV
	WriteByte(0x269CCF - offset, 0x74) -- No Death Sound
	if ReadByte(currentWeapon) == 0x66 then -- One Winged Angel
		WriteByte(stateFlag, ReadByte(stateFlag) | 0x20)
	end
	currentAnim = ReadLong(soraPointer)+0x164
	
	local prize = 2.0
	local item = 2.0
	
	if ReadByte(currentWeapon) == 0x57 then -- Three Wishes
		prize = prize * 4
	end
	
	if ReadByte(currentWeapon) == 0x62 then -- Lady Luck
		item = item * 4
	end
	check_accessory_slot_amount()
	WriteFloat(prizeDrop, prize)
	WriteFloat(itemDrop, item)
	activate_on_hit_effects()
	spellbinder_regen()
	kingdom_key_regen()
	check_knockback_state()
	set_enemy_resistances()
	set_riku_stats()
	toggle_stance()
	
	::done::
end


function check_knockback_state()
	local knock = 0x84
	if ReadByte(currentWeapon) == 0x5F and ReadByte(currentAnim, true) ~= 0xD4 then -- Metal Chocobo
		knock = 0x85
	end
	
	local firagun = check_accessory_count(0x3D)
	local blizzagun = check_accessory_count(0x3E)
	local thundagun = check_accessory_count(0x3F)
	local aerogun = check_accessory_count(0x23)
	
	if firagun > 0 then
		if ReadByte(currentAnim, true) == 0x36 or ReadByte(currentAnim, true) == 0x3D then
			knock = 0x85
		end
	end	
	if blizzagun > 0 and ReadByte(currentAnim, true) == 0x37 then 
		knock = 0x85
	end	
	if thundagun > 0 and ReadByte(currentAnim, true) == 0x37 then 
		knock = 0x85
	end
	if aerogun > 0 and ReadByte(currentAnim, true) == 0x3C then 
		knock = 0x85
	end
	
	WriteByte(knockback, knock)

end



function kingdom_key_regen()
	if ReadByte(currentWeapon) == 0x51 then
		if kingdomKeyRegenDelay > 0 then
			kingdomKeyRegenDelay = kingdomKeyRegenDelay - 1
		end
		local delay = false
		for i = 0, 2 do
			if ReadByte(shortcut1 + i) == 0x03 then -- Cure
				if kingdomKeyRegenDelay == 0 then
					WriteByte(currentHP, math.min(ReadByte(maxHP), ReadByte(currentHP) + 1))
					delay = true
				end
			end
		end
		if delay == true then
			local s = 1.0
			if ReadFloat(speedup) > 0.0 then
				s = ReadFloat(speedup)
			end
			kingdomKeyRegenDelay = math.floor(70 / s)
		end
	end
end



function spellbinder_regen()
	if ReadByte(currentWeapon) == 0x5C and ReadByte(currentMP) < 2 then -- Spellbinder
		
		if spellbinderCooldown == 0 then
			WriteByte(mpCharge, ReadByte(mpCharge) + 1)
			local s = 1.0
			if ReadFloat(speedup) > 0.0 then
				s = ReadFloat(speedup)
			end
			spellbinderCooldown = math.floor(spellbinderDelay / s)
		end
		
		if spellbinderCooldown > 0 then
			spellbinderCooldown = spellbinderCooldown - 1
		end
		
	end
end


function activate_on_hit_effects()
	if ReadByte(connectCounter) == 1 then
		local getExtraRecharge = true
		if ReadByte(rikuEnabledGummi) > 0 then
			local d = 70
			if ReadByte(currentWeapon) == 0x60 then -- Oathbreaker
				d = d + 13
			end
			WriteByte(noSpiritDrainGummi, d)
			if ReadByte(currentLinkItem) == 0 then
				getExtraRecharge = false
			end
		end
		bonuscharge = check_ability_count(0x17) -- MP Haste
		bonuscharge = bonuscharge * 2
		lifeOnHit = 0
		
		activate_accessories()

		if ReadByte(currentWeapon) == 0x5B then -- Divine Rose
			lifeOnHit = lifeOnHit + 3
		end
		
		if ReadByte(0x2DE5EFC - offset) >= 1 then -- Shield
			lifeOnHit = lifeOnHit + 1
		end

		if ReadByte(0x2DE5EFB - offset) >= 1 then-- Rod
			bonuscharge = bonuscharge+ 2
		end
		
		
		if getExtraRecharge == true then
			local c = 1
			if ReadByte(rikuEnabledGummi) > 0 then
				c = 0
				if ReadByte(rikuStanceGummi) == 0 and ReadByte(currentMP) > 0 then
					c = -1
				elseif ReadByte(rikuStanceGummi) == 3 then
					c = ReadByte(currentLinkItem)
					if ReadByte(currentLinkItem) >= 2 then
						c = c + 1 -- Level 2+ Stance Bonus
					end
				end
			end
			bonuscharge = bonuscharge + c -- Base added mp recovery
		end
		-- Critical MP
		for i = 1, check_ability_count(0x2A) do 
			for i = 1, check_ability_count(0x08) do -- 08 Critical Plus
				if math.random(1, 100) <= 5 then
					bonuscharge = bonuscharge + math.floor(ReadByte(CriticalMPTrackingGummi) * 0.5)
				end
			end
		end
		
		if ReadByte(currentLinkItem) > 0 and ReadByte(rikuEnabledGummi) == 0 then
			local drainamount = 2
			for i = 1, check_accessory_count(0x4E) do -- Paopu Fruit
				drainamount = 1
			end
			WriteByte(linkedSpiritItem, math.max(0, ReadByte(linkedSpiritItem) - drainamount))
		else
			local bonusSpirit = check_ability_count(0x30)
			local amount = math.max(1, ReadByte(comboPosition) - 1 + bonusSpirit)
			if ReadByte(rikuEnabledGummi) > 0 then
				amount = amount + 7 - ReadByte(currentLinkItem)
				if ReadByte(currentLinkItem) == 0 then
					amount = amount + 4
				end
				if ReadByte(rikuStanceGummi) > 0 then
					amount = 1
				end
				if ReadByte(currentWeapon) == 0x64 then -- Ultima Weapon
					amount = amount * 3
				end
			end
			WriteByte(linkedSpiritItem, math.max(0, ReadByte(linkedSpiritItem) + amount)) 
		end
		if ReadByte(rikuStanceGummi) == 2 then
			lifeOnHit = lifeOnHit + ReadByte(currentLinkItem)
			if ReadByte(currentLinkItem) >= 2 then
				lifeOnHit = lifeOnHit + 1 -- Level 2+ Stance Bonus
			end
		end
		
		if ReadByte(currentLinkItem) == 3 then
			if ReadByte(rikuEnabledGummi) == 0 then
				lifeOnHit = lifeOnHit + 2
				if ReadByte(currentWeapon) == 0x64 then -- Ultima Weapon
					lifeOnHit = lifeOnHit + 1
				end
			end
		end
		
		
		
		WriteByte(mpCharge, math.max(math.min(ReadByte(maxMP) * 30, ReadByte(mpCharge) + bonuscharge), 0))
		if lifeOnHit> 0 then
			WriteByte(currentHP, math.min(ReadByte(currentHP) + lifeOnHit, ReadByte(maxHP)))
		end
		if ReadByte(connectCounter) == 1 then
			WriteByte(connectCounter, 0)
		end
	end
end


function activate_accessories()
	drain_brace()
	siphon_brace()
end

function siphon_brace()
	for i = 1, check_accessory_count(0x22) do
		lifeOnHit = lifeOnHit + 1
	end
end


function drain_brace()
	for i = 1, check_accessory_count(0x39) do
		lifeOnHit = lifeOnHit + 1
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




function set_riku_stats()
	if soraSlotOffset > 0 and ReadByte(rikuEnabledGummi) > 0 then
		WriteFloat(ReadLong(soraPointer)+0x40, 1.1, true)
		WriteFloat(ReadLong(soraPointer)+0x44, 1.1, true)
		WriteFloat(ReadLong(soraPointer)+0x48, 1.1, true)
		
		WriteFloat(0xD2ACA0 - offset, 0.95)
		WriteFloat(0xD2ACA4 - offset, 0.95)
		WriteFloat(0xD2ACA8 - offset, 0.95)
	end
end


function _OnInit()
	if GAME_ID == 0xAF71841E and ENGINE_TYPE == "BACKEND" then
		canExecute = true
		ConsolePrint("CMix_StatHandler Installed")
	else
		ConsolePrint("CMix_StatHandler -- FAILED --")
	end
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


function notify_gained_accessory_slot()
	local _titleBoxes = { "KEYHOLE SEALED"}
	local _levelBoxes = { {"Gained Accessory Slot!!"} }
	ShowPrompt(_titleBoxes, _levelBoxes, -500)
end



function notify_wrong_shop_text()
	if ReadByte(world) == 3 then
		if ReadByte(room) == 0x0A or ReadByte(room) == 0x09 then
			if notifShowing_WrongText == false then
				ShowPrompt({ "NOTIFICATION"}, { {"Accessory Descriptions In", "Shops Are Wrong!"}  }, -30000)
				notifShowing_WrongText = true
			end
		else
			notifShowing_WrongText = false
		end
	end
end