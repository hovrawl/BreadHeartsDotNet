

LUAGUI_NAME = "CMix_PhoenixDown_RevivalHandler"
LUAGUI_AUTH = "Xendra"
LUAGUI_DESC = "Adds Phoenix Downs and handles revival effects"

local offset = 0x3A0606
local soraPointer = 0x2534680 - offset
local soraSlotOffset = ReadShort(ReadLong(soraPointer) + 0x6C, true) - 0x9000
local soraSlot = 0x2D59000 - offset + soraSlotOffset
local currentMP = soraSlot + 68
local maxMP = soraSlot + 72
local currentHP = soraSlot + 60
local maxHP = soraSlot + 64
local mpCharge = soraSlot + 190
---
local abilityState = 0x2D4FCA4 - offset
local itemSlot1 = 0x2DE59F6 - offset
local stateFlag = 0x2863958 - offset
local currentWeapon = 0x2DE5A06 - offset
local currentLinkItem = 0x2DE5F51 - offset
local linkedSpiritItem = 0x2DE5EFD - offset
local rikuEnabledGummi = 0x2DF18DC - offset -- Unused Gummi 5
---
--local autoLinkAvailable = false -- Auto-Link revives are used first
local necklaceAvailable = false -- Phoenix Necklace revives are used second
--local oathkeeperAvailable = false -- Oathkeeper revives are used third
-- Phoenix Down revives are the final layer used


function _OnInit()
--------------------------------------------------------------------------------
	if GAME_ID == 0xAF71841E and ENGINE_TYPE == "BACKEND" then
		canExecute = true
		ConsolePrint("CMix_PhoenixDown_RevivalHandler - installed")
	else
		ConsolePrint("CMix_PhoenixDown_RevivalHandler - failed")
	end
--------------------------------------------------------------------------------
end

function _OnFrame()
	if canExecute == true then
		set_sora_pointer_data()
		disable_second_chance()
		WriteByte(0x269CCF - offset, 0x74) -- No Death Sound
		check_auto_links()
		check_phoenix_necklace()
		check_oathkeeper()
		check_phoenix_down()
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


function check_phoenix_necklace() -- Reset when you exit combat
	local neck = check_accessory_count(0x2E)
	if neck >= 1 then
		
		if ReadByte(stateFlag) == 0x00 or ReadByte(stateFlag) == 0x20 then
			necklaceAvailable = true
		end
		if necklaceAvailable == true then
			enable_second_chance()
			local nrev = attempt_revive()
			if nrev == true then
				necklaceAvailable = false
				ShowPrompt({ "REVIVAL"}, { {"Revived With Phoenix", "Necklace!!"} }, -200)
			end
		end
	end
end


function attempt_revive()
	local rev = false
	if ReadByte(currentHP) == 1 then
		WriteByte(currentHP, ReadByte(maxHP))
		rev = true
	end
	return(rev)
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


function check_auto_links()
	if ReadByte(linkedSpiritItem) >= 0x72 and ReadByte(rikuEnabledGummi) == 0 then
		local goof = check_ability_count(0x27)
		local duck = check_ability_count(0x28)
		local sora = check_ability_count(0x26)
		local link = 0
		local rev = false
		
		if goof > 0 then
			rev = true
			link = 3
		elseif duck > 0 then
			rev = true
			link = 2
		elseif sora > 0 then
			rev = true
			link = 1
		end
		
		if rev == true then
			enable_second_chance()
			local r = attempt_revive()
			if r == true then -- Enter chosen link
				WriteByte(currentLinkItem, link)
				ShowPrompt({ "REVIVAL"}, { {"Revived With Spirit Link!!"} }, -200)
			end
		end
	end
end

function check_oathkeeper()
	if ReadByte(currentWeapon) == 0x60 and ReadByte(currentMP) >= 4 and ReadByte(rikuEnabledGummi) == 0 then
		enable_second_chance()
		local orev = attempt_revive()
		if orev == true then
			WriteByte(currentMP, ReadByte(currentMP) - 4)
			ShowPrompt({ "REVIVAL"}, { {"Revived With Oathkeeper!!"} }, -200)
		end
	end
end

function check_phoenix_down()
	for i = 0, 7 do
		if ReadByte(itemSlot1 + i) == 5 then -- Phoenix Down equipped
			enable_second_chance()
			local pdrev = attempt_revive()
			if pdrev == true then
				WriteByte(itemSlot1 + i, 0)
				ShowPrompt({ "REVIVAL"}, { {"Revived With Phoenix", "Down!!"} }, -200)
			end
			break
		end
	end
end

function disable_second_chance()
	if ReadByte(abilityState) ~ 0x10 < ReadByte(abilityState) then -- Disable by Default
		WriteByte(abilityState, ReadByte(abilityState) ~ 0x10)
	end
end

function enable_second_chance()
	if ReadByte(abilityState) | 0x10 > ReadByte(abilityState) then
		WriteByte(abilityState, ReadByte(abilityState) | 0x10)
	end
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

