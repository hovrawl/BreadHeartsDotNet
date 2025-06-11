LUAGUI_NAME = "CMix_SynthReplacement"
LUAGUI_AUTH = "Xendra"
LUAGUI_DESC = "Changes synthesis"


local offset = 0x3A0606
local synthRequirements = 0x544320 - offset
local randoEnabledGummi = 0x2DF18DA - offset -- Unused Gummi 3
local synthItems = synthRequirements + 0x1E0
local moogleLevel = 0x2DE73A0 - offset
local heardSynthExplanation = 0x2DE670B - offset

local traverseStatus = 0x2DE78C0 - offset


function _OnInit()
	if GAME_ID == 0xAF71841E and ENGINE_TYPE == "BACKEND" then
		canExecute = true
		ConsolePrint("CMix_SynthReplacement Installed")
	else
		ConsolePrint("CMix_SynthReplacement -- FAILED --")
	end
end



function _OnFrame()
	if not canExecute then
		goto done
	end
	
	if ReadByte(randoEnabledGummi) == 0 then
		write_synth_items()
	end
	write_dream_sword_synth()
	handle_moogle_stock()
	
	::done::
end

function handle_moogle_stock()
	local bonus = 0
	local neg = 1
	for i = 0, 9 do
		if ReadByte(traverseStatus + i) == 4 then
			bonus = bonus + 1
		end
	end
		
	
	if bonus >= 4 then
		neg = neg + 1
	end
	
	if bonus >= 7 then
		neg = neg + 1
	end
	
	bonus = math.max(0, bonus - neg)
	
	if ReadByte(heardSynthExplanation) > 0 then
		if bonus > ReadByte(moogleLevel) and bonus <= 5 then
			ShowPrompt({ "KEYHOLE BONUS"}, { {"Reached Synthesis Level " .. tostring(bonus + 1) .. "!"} }, -1000)
		end
		WriteByte(moogleLevel, math.min(bonus, 5))
	end
end

function write_dream_sword_synth()
	if ReadByte(randoEnabledGummi) == 0 then
		WriteByte(synthItems+00, 0x52) -- Mega Potion > Dream Sword
	end
	WriteByte(synthRequirements+00, 0xC3) -- Ingredient : Memory
	WriteByte(synthRequirements+02, 7) -- Amount
	WriteByte(synthRequirements+04, 0xFF) -- Ingredient : Orichalcum
	WriteByte(synthRequirements+06, 7) -- Amount
	WriteByte(synthRequirements+08, 0xF8) -- Ingredient : Bright Shard
	WriteByte(synthRequirements+10, 7) -- Amount
end

function write_synth_items() -- 0x10 Between Entries
	
	WriteByte(synthItems+10, 0x06) -- Cottage > Mega Potion
	WriteByte(synthItems+50, 0x4D) -- Gold Ring
	
	
	WriteByte(synthItems+120, 0x30) -- AP Up > Brave Warrior
	WriteByte(synthItems+190, 0x2C) -- Defense Up > Atlas armlet
	WriteByte(synthItems+220, 0x31) -- Atlas Armlet > White Flower
	
	WriteByte(synthItems+260, 0x05) -- Power Up > Phoenix Down
	
	
	
	--WriteByte(synthRequirements + 0x02 + ((i - 1) * 4), 2)
	
	
	WriteByte(synthRequirements + 0x02 + ((17 - 1) * 4), 1) -- Gold Ring Dark Matter
	WriteByte(synthRequirements + 0x02 + ((35 - 1) * 4), 3) -- Moogle Badge Mythril
	WriteByte(synthRequirements + 0x02 + ((40 - 1) * 4), 1) -- Brave Warrior Mythril
	WriteByte(synthRequirements + 0x02 + ((52 - 1) * 4), 1) -- Mythril Mythril Shard
	WriteByte(synthRequirements + ((54 - 1) * 4), 0xF8) -- Mythril Mystery Goo > Bright Shard
	
	WriteByte(synthRequirements + 0x02 + ((80 - 1) * 4), 2) -- Dark Matter Lucid Shards
	WriteByte(synthRequirements + 0x02 + ((81 - 1) * 4), 1) -- Dark Matter Gale
	WriteByte(synthRequirements + 0x02 + ((82 - 1) * 4), 1) -- Dark Matter Mythril
	
	
	
	WriteByte(synthRequirements + 0x02 + ((106 - 1) * 4), 1) -- D&G  Ultimates
	WriteByte(synthRequirements + 0x02 + ((107 - 1) * 4), 1) -- D&G  Ultimates
	WriteByte(synthRequirements + 0x02 + ((108 - 1) * 4), 1) -- D&G  Ultimates
	WriteByte(synthRequirements + 0x02 + ((109 - 1) * 4), 1) -- D&G  Ultimates
	WriteByte(synthRequirements + 0x02 + ((110 - 1) * 4), 1) -- D&G  Ultimates
	WriteByte(synthRequirements + 0x02 + ((111 - 1) * 4), 1) -- D&G  Ultimates
	WriteByte(synthRequirements + 0x02 + ((112 - 1) * 4), 1) -- D&G  Ultimates
	WriteByte(synthRequirements + 0x02 + ((113 - 1) * 4), 1) -- D&G  Ultimates
	
	
	WriteByte(synthRequirements + 0x02 + ((114 - 1) * 4), 1) -- Ultima Thunder Gem
	WriteByte(synthRequirements + 0x02 + ((115 - 1) * 4), 1) -- Ultima Mystery Goo
	WriteByte(synthRequirements + 0x02 + ((116 - 1) * 4), 2) -- Ultima Serenity Power
	WriteByte(synthRequirements + 0x02 + ((117 - 1) * 4), 2) -- Ultima Stormy Stone
	
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






