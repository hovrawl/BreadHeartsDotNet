LUAGUI_NAME = "CMix_MultiShortcut"
LUAGUI_AUTH = "Xendra"
LUAGUI_DESC = "Left and Right dpad switch between Main & Defensive shortcuts (Cure / Aero / Stop)"
local offset = 0x3A0606
local canExecute = false

local magicFlags = 0x2DE75EE - offset
local magicUnlock = 0x2DE5A44 - offset
local magicLevels = magicUnlock + 0x41E
local shortcut1address = 0x2DE6214 - offset
local shortcut2address = shortcut1address + 1
local shortcut3address = shortcut1address + 2

local storeShortcuts = true
local shortcut1 = 0x00
local shortcut2 = 0x00
local shortcut3 = 0x00
local currentMenu = 1

local inputCooldown = 0

-- Visuals

local shortcutHeaderRGB1 = 0x28500C0 - offset
local shortcutHeaderRGB2 = shortcutHeaderRGB1 + 4
local shortcutHeaderRGB3 = shortcutHeaderRGB1 + 8
local shortcutHeaderRGB4 = shortcutHeaderRGB1 + 12


local scColorTopLeft1 = 0x2850000 - offset
local scColorTopLeft2 = scColorTopLeft1 + 4
local scColorTopLeft3 = scColorTopLeft1 + 8
local scColorTopLeft4 = scColorTopLeft1 + 12

local scColorTopRight1 = 0x2850020 - offset
local scColorTopRight2 = scColorTopRight1 + 4
local scColorTopRight3 = scColorTopRight1 + 8
local scColorTopRight4 = scColorTopRight1 + 12

local scColorDownLeft1 = 0x2850010 - offset
local scColorDownLeft2 = scColorDownLeft1 + 4
local scColorDownLeft3 = scColorDownLeft1 + 8
local scColorDownLeft4 = scColorDownLeft1 + 12

local scColorDownRight1 = 0x2850030 - offset
local scColorDownRight2 = scColorDownRight1 + 4
local scColorDownRight3 = scColorDownRight1 + 8
local scColorDownRight4 = scColorDownRight1 + 12





function _OnInit()
	if GAME_ID == 0xAF71841E and ENGINE_TYPE == "BACKEND" then
		canExecute = true
		ConsolePrint("CMix_MultiShortcut - installed")
	end
end

function _OnFrame()
	if not canExecute then
		goto done
	end
	
	
	if inputCooldown > 0 then
		inputCooldown = inputCooldown - 1
	end
	check_input()
	store_shortcuts()

	:: done ::
end


function validate_shortcuts()
	for i=0,2 do
		local check = ReadByte(magicLevels + ReadByte(shortcut1address + i))
		
		
		if check == 0 or ReadByte(shortcut1address + i) > 6 then
			WriteByte(shortcut1address + i, 0xFF)
		end
	end
end

function show_shortcuts()
	if currentMenu == 0 then -- Defense
		local sc1 = 0x03
		local sc2 = 0x06
		local sc3 = 0x05
		
		if ReadByte(magicLevels + 3) == 0 then
			sc1 = 0xFF
		end
		if ReadByte(magicLevels + 6) == 0 then
			sc2 = 0xFF
		end
		if ReadByte(magicLevels + 5) == 0 then
			sc3 = 0xFF
		end
		
		WriteByte(shortcut1address, sc1)
		WriteByte(shortcut2address, sc2)
		WriteByte(shortcut3address, sc3)
		
		WriteByte(shortcutHeaderRGB1, 0x50)
		WriteByte(shortcutHeaderRGB2, 0xD0)
		WriteByte(shortcutHeaderRGB3, 0x70)
		WriteByte(shortcutHeaderRGB4, 0x70)
		
		WriteByte(scColorTopLeft1, 0x13)
		WriteByte(scColorTopLeft2, 0x80)
		WriteByte(scColorTopLeft3, 0x30)
		WriteByte(scColorTopLeft4, 0x90)
		
		WriteByte(scColorTopRight1, 0x20)
		WriteByte(scColorTopRight2, 0x40)
		WriteByte(scColorTopRight3, 0x20)
		WriteByte(scColorTopRight4, 0x80)
		
		WriteByte(scColorDownLeft1, 0x20)
		WriteByte(scColorDownLeft2, 0x40)
		WriteByte(scColorDownLeft3, 0x20)
		WriteByte(scColorDownLeft4, 0x80)
	
		WriteByte(scColorDownRight1, 0x10)
		WriteByte(scColorDownRight2, 0x20)
		WriteByte(scColorDownRight3, 0x10)
		WriteByte(scColorDownRight4, 0x80)
		
	elseif currentMenu == 1 then -- Default
		reset_shortcuts()
		
		WriteByte(shortcutHeaderRGB1, 0x50)
		WriteByte(shortcutHeaderRGB2, 0x70)
		WriteByte(shortcutHeaderRGB3, 0xD0)
		WriteByte(shortcutHeaderRGB4, 0x90)
		
		WriteByte(scColorTopLeft1, 0x13)
		WriteByte(scColorTopLeft2, 0x34)
		WriteByte(scColorTopLeft3, 0x80)
		WriteByte(scColorTopLeft4, 0x90)
		
		WriteByte(scColorTopRight1, 0x20)
		WriteByte(scColorTopRight2, 0x20)
		WriteByte(scColorTopRight3, 0x30)
		WriteByte(scColorTopRight4, 0x80)
		
		WriteByte(scColorDownLeft1, 0x20)
		WriteByte(scColorDownLeft2, 0x30)
		WriteByte(scColorDownLeft3, 0x30)
		WriteByte(scColorDownLeft4, 0x80)
	
		WriteByte(scColorDownRight1, 0x10)
		WriteByte(scColorDownRight2, 0x10)
		WriteByte(scColorDownRight3, 0x20)
		WriteByte(scColorDownRight4, 0x80)
		
		
	elseif currentMenu == 2 then -- Limit
		WriteByte(shortcut1address, 0x2C)
		WriteByte(shortcut2address, 0x13)
		WriteByte(shortcut3address, 0xC8)
	
	end

end



function check_input()
	if (ReadByte(0x233D035-0x3A0606)//0x04)%2 == 1 then -- L1
		
		storeShortcuts = false
		show_shortcuts()
		if inputCooldown == 0 then
			if (ReadByte(0x233D034-0x3A0606)//0x20)%2 == 1 then -- Dpad Right
				inputCooldown = 10
				currentMenu = currentMenu + 1
				if currentMenu > 1 then
					currentMenu = 0
				end
				show_shortcuts()

			end
			
			if (ReadByte(0x233D034-0x3A0606)//0x80)%2 == 1 then -- Dpad Left
				inputCooldown = 10
				currentMenu = currentMenu - 1
				if currentMenu < 0 then
					currentMenu = 1
				end
				show_shortcuts()

			end
		end
	end
	
	
	
	if (ReadByte(0x233D035-0x3A0606)//0x04)%2 ~= 1 then -- Not L1
		if storeShortcuts == false then
			reset_shortcuts()
		end
		storeShortcuts = true
	end
end


function store_shortcuts()
	if storeShortcuts == true then
		validate_shortcuts()
		shortcut1 = ReadByte(shortcut1address)
		shortcut2 = ReadByte(shortcut2address)
		shortcut3 = ReadByte(shortcut3address)
	end
end

function reset_shortcuts()
	WriteByte(shortcut1address, shortcut1)
	WriteByte(shortcut2address, shortcut2)
	WriteByte(shortcut3address, shortcut3)
end