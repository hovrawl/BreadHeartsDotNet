LUAGUI_NAME = "CMix_Levelup_Tables"
LUAGUI_AUTH = "Xendra"
LUAGUI_DESC = "Level up tables for Critical Mix"

local offset = 0x3A0606

local btltbl = 0x2D1F3C0 - offset

local soraStatTable = btltbl+0x3AC0
local soraAbilityTable = btltbl+0x3BF8
local soraAbilityTable2 = soraAbilityTable-0xD0
local soraAbilityTable3 = soraAbilityTable-0x68
--
local donaldStatTable = soraStatTable+0x3F8
local goofyStatTable = donaldStatTable+0x198
--local donaldAbilityTable = soraAbilityTable+0x328
--local goofyAbilityTable = donaldAbilityTable+0x198
--
local world = 0x233CADC - offset
local room = 0x233CB44 - offset
local flag = 0x233CB48 - offset

local baseStr = 0x2DE59DA - offset
local baseMP = 0x2DE59D8 - offset
local baseHP = 0x2DE59D6 - offset
local baseItems = 0x2DE59F5 - offset
local baseAccessories = 0x2DE59EC - offset

local soraLevel = 0x2DE59D4 - offset
local strengthPerLevel = 0x2B0F8B - offset
local hpPerLevel = 0x2B0EE7 - offset

local goofyBaseDefense = 0x2DE5AC3 - offset
local goofyBaseAP = 0x2DE5AC1 - offset
local donaldBaseAP = 0x2DE5A4D - offset
-- Rando
local randoEnabledGummi = 0x2DF18DA - offset -- Unused Gummi 3


function _OnInit()
--------------------------------------------------------------------------------
	if GAME_ID == 0xAF71841E and ENGINE_TYPE == "BACKEND" then
		canExecute = true
		ConsolePrint("CMix_Levelup_Tables - installed")
	else
		ConsolePrint("CMix_Levelup_Tables - failed")
	end
--------------------------------------------------------------------------------
end


function set_level_up_amounts()	
	WriteByte(hpPerLevel, 2)
	WriteByte(strengthPerLevel, 1)
end

function _OnFrame()
	override_starting_stats()
	set_level_up_amounts()
	if ReadByte(randoEnabledGummi) == 0 then
		set_levelup_table()
	end
	
	set_goofy_table()
	set_donald_table()
	
end

function wipe_secondary_ability_tables()
	local value = 0x00
	for i = 0, 98 do
		WriteByte(soraAbilityTable + i, value)
		WriteByte(soraAbilityTable2 + i, value)
		WriteByte(soraAbilityTable3 + i, value)
	end
end

function override_starting_stats()
	if ReadByte(world) == 0 and ReadByte(room) == 0 and ReadByte(flag) == 2 then
		WriteByte(baseHP, 18)
		WriteByte(baseMP, 2)
		WriteByte(baseStr, 5)
		WriteByte(baseItems, 2)
		WriteByte(baseAccessories, 1)
		WriteByte(goofyBaseDefense, 13)
		WriteByte(goofyBaseAP, 50)
		WriteByte(donaldBaseAP, 50)
	end
end

function set_donald_table()
	if ReadShort(donaldStatTable) ~= 0x0501 then
		local tablePos = donaldStatTable - 2
		WriteByte(tablePos+3, 0x05) -- Defense
		WriteByte(tablePos+5, 0x05) -- Defense
		WriteByte(tablePos+7, 0x05) -- Defense
		WriteByte(tablePos+13, 0x05) -- Defense
		WriteByte(tablePos+17, 0x05) -- Defense
		WriteByte(tablePos+22, 0x05) -- Defense
		WriteByte(tablePos+28, 0x05) -- Defense
		WriteByte(tablePos+33, 0x05) -- Defense
		WriteByte(tablePos+37, 0x05) -- Defense
		WriteByte(tablePos+43, 0x05) -- Defense
		WriteByte(tablePos+47, 0x05) -- Defense
		WriteByte(tablePos+53, 0x05) -- Defense
		WriteByte(tablePos+57, 0x05) -- Defense
		WriteByte(tablePos+62, 0x05) -- Defense
		WriteByte(tablePos+11, 0x05) -- Defense
		WriteByte(tablePos+16, 0x05) -- Defense
		WriteByte(tablePos+21, 0x05) -- Defense
		WriteByte(tablePos+26, 0x05) -- Defense
		WriteByte(tablePos+31, 0x05) -- Defense
		WriteByte(tablePos+36, 0x05) -- Defense
		WriteByte(tablePos+41, 0x05) -- Defense
		WriteByte(tablePos+46, 0x05) -- Defense
		WriteByte(tablePos+51, 0x05) -- Defense
		WriteByte(tablePos+56, 0x05) -- Defense
		WriteByte(tablePos+61, 0x05) -- Defense
		WriteByte(tablePos+64, 0x05) -- Defense
		WriteByte(tablePos+90, 0x02) -- MP
		WriteByte(tablePos+100, 0x02) -- MP
	end
end

function set_goofy_table()
	if ReadShort(donaldStatTable) ~= 0x0404 then
		local tablePos = goofyStatTable - 2
		WriteByte(tablePos+2, 0x04) -- Strength
		WriteByte(tablePos+4, 0x04) -- Strength
		WriteByte(tablePos+6, 0x04) -- Strength
		WriteByte(tablePos+8, 0x04) -- Strength
		WriteByte(tablePos+14, 0x04) -- Strength
		WriteByte(tablePos+20, 0x04) -- Strength
		WriteByte(tablePos+24, 0x04) -- Strength
		WriteByte(tablePos+26, 0x04) -- Strength
		WriteByte(tablePos+30, 0x04) -- Strength
		WriteByte(tablePos+32, 0x04) -- Strength
		WriteByte(tablePos+38, 0x04) -- Strength
		WriteByte(tablePos+40, 0x04) -- Strength
		WriteByte(tablePos+46, 0x04) -- Strength
		WriteByte(tablePos+47, 0x04) -- Strength
		WriteByte(tablePos+50, 0x04) -- Strength
		WriteByte(tablePos+52, 0x04) -- Strength
		WriteByte(tablePos+56, 0x04) -- Strength
		WriteByte(tablePos+60, 0x04) -- Strength
		WriteByte(tablePos+61, 0x04) -- Strength
		WriteByte(tablePos+64, 0x04) -- Strength
		WriteByte(tablePos+65, 0x01) -- HP
		WriteByte(tablePos+68, 0x04) -- Strength
		WriteByte(tablePos+69, 0x01) -- HP
		WriteByte(tablePos+71, 0x04) -- Strength
		WriteByte(tablePos+72, 0x01) -- HP
		WriteByte(tablePos+74, 0x04) -- Strength
		WriteByte(tablePos+51, 0x05) -- Defense
		WriteByte(tablePos+55, 0x05) -- Defense
		WriteByte(tablePos+59, 0x05) -- Defense
		WriteByte(tablePos+63, 0x05) -- Defense
		WriteByte(tablePos+65, 0x05) -- Defense
		WriteByte(tablePos+67, 0x05) -- Defense
		WriteByte(tablePos+69, 0x05) -- Defense
	end
end

function set_levelup_table()
	if ReadShort(soraStatTable) ~= 0x8604 then
		wipe_secondary_ability_tables()
		local tablePos = soraStatTable - 2
		-- Add the level Sora will reach to insert the bonus for that level
		WriteByte(tablePos+02, 0x01) -- 
		WriteByte(tablePos+03, 0x86) -- Combo Plus
		WriteByte(tablePos+04, 0x04) -- 
		WriteByte(tablePos+05, 0xBC) -- Tech Boost
		WriteByte(tablePos+06, 0x01) -- 
		WriteByte(tablePos+07, 0x04) -- 
		WriteByte(tablePos+08, 0x01) -- HP
		WriteByte(tablePos+09, 0x9C) -- Lucky Strike
		WriteByte(tablePos+10, 0x04) -- STRENGTH
		WriteByte(tablePos+11, 0x01) -- HP
		WriteByte(tablePos+12, 0x01) -- HP
		WriteByte(tablePos+13, 0x04) -- 
		WriteByte(tablePos+14, 0x01) -- 
		WriteByte(tablePos+15, 0x01) -- HP
		WriteByte(tablePos+16, 0x04) -- STRENGTH
		WriteByte(tablePos+17, 0xA5) -- Frenzy
		WriteByte(tablePos+18, 0x06) -- 
		WriteByte(tablePos+19, 0x04) -- 
		WriteByte(tablePos+20, 0x02) -- MP
		WriteByte(tablePos+21, 0xAA) -- Critical MP
		WriteByte(tablePos+22, 0x04) -- 
		WriteByte(tablePos+23, 0xA7) -- Auto-Goof / Drain Stance
		WriteByte(tablePos+24, 0x01) -- HP
		WriteByte(tablePos+25, 0x04) -- STRENGTH
		WriteByte(tablePos+26, 0x01) -- HP
		WriteByte(tablePos+27, 0x04) -- STRENGTH
		WriteByte(tablePos+28, 0x04) -- STRENGTH
		WriteByte(tablePos+29, 0xA8) -- Auto-Duck
		WriteByte(tablePos+30, 0x06) -- 
		WriteByte(tablePos+31, 0x04) -- 
		WriteByte(tablePos+32, 0x01) -- HP
		WriteByte(tablePos+33, 0x04) -- STRENGTH
		WriteByte(tablePos+34, 0x01) -- HP
		WriteByte(tablePos+35, 0xAF) -- Finishing Pierce
		WriteByte(tablePos+36, 0x95) -- Hyper Guard
		WriteByte(tablePos+37, 0x04) -- 
		WriteByte(tablePos+38, 0x01) -- HP
		WriteByte(tablePos+39, 0xA6) -- Auto-Sora 
		WriteByte(tablePos+40, 0x04) -- STRENGTH
		WriteByte(tablePos+41, 0x01) -- HP
		WriteByte(tablePos+42, 0x06) -- 
		WriteByte(tablePos+43, 0x01) -- HP
		WriteByte(tablePos+44, 0xB0) -- Spirit Boost / Dark Boost
		WriteByte(tablePos+45, 0xA9) -- Fortify
		WriteByte(tablePos+46, 0x04) -- STRENGTH
		WriteByte(tablePos+47, 0x01) -- HP
		WriteByte(tablePos+48, 0x02) -- MP
		WriteByte(tablePos+49, 0x06) -- ITEM
		WriteByte(tablePos+50, 0x97) -- MP Haste
		-- BEYOND LEVEL 50
		WriteByte(tablePos+51, 0x01) -- HP
		WriteByte(tablePos+52, 0x01) -- HP
		WriteByte(tablePos+53, 0x01) -- HP
		WriteByte(tablePos+54, 0x04) -- STRENGTH
		WriteByte(tablePos+55, 0x01) -- HP
		WriteByte(tablePos+56, 0x01) -- HP
		WriteByte(tablePos+57, 0x01) -- HP
		WriteByte(tablePos+58, 0x04) -- STRENGTH
		WriteByte(tablePos+59, 0x01) -- HP
		WriteByte(tablePos+60, 0x01) -- HP
		WriteByte(tablePos+61, 0x01) -- HP
		WriteByte(tablePos+62, 0x04) -- STRENGTH
		WriteByte(tablePos+63, 0x01) -- HP
		WriteByte(tablePos+64, 0x01) -- HP
		WriteByte(tablePos+65, 0x01) -- HP
		WriteByte(tablePos+66, 0x04) -- STRENGTH
		WriteByte(tablePos+67, 0x01) -- HP
		WriteByte(tablePos+68, 0x01) -- HP
		WriteByte(tablePos+69, 0x01) -- HP
		WriteByte(tablePos+70, 0x04) -- STRENGTH
		WriteByte(tablePos+71, 0x01) -- HP
		WriteByte(tablePos+72, 0x01) -- HP
		WriteByte(tablePos+73, 0x01) -- HP
		WriteByte(tablePos+74, 0x04) -- STRENGTH
		WriteByte(tablePos+75, 0x02) -- MP
		WriteByte(tablePos+76, 0x01) -- HP
		WriteByte(tablePos+77, 0x01) -- HP
		WriteByte(tablePos+78, 0x04) -- STRENGTH
		WriteByte(tablePos+79, 0x01) -- HP
		WriteByte(tablePos+80, 0x01) -- HP
		WriteByte(tablePos+81, 0x01) -- HP
		WriteByte(tablePos+82, 0x04) -- STRENGTH
		WriteByte(tablePos+83, 0x01) -- HP
		WriteByte(tablePos+84, 0x01) -- HP
		WriteByte(tablePos+85, 0x01) -- HP
		WriteByte(tablePos+86, 0x04) -- STRENGTH
		WriteByte(tablePos+87, 0x01) -- HP
		WriteByte(tablePos+88, 0x01) -- HP
		WriteByte(tablePos+89, 0x01) -- HP
		WriteByte(tablePos+90, 0x04) -- STRENGTH
		WriteByte(tablePos+91, 0x01) -- HP
		WriteByte(tablePos+92, 0x01) -- HP
		WriteByte(tablePos+93, 0x01) -- HP
		WriteByte(tablePos+94, 0x04) -- STRENGTH
		WriteByte(tablePos+95, 0x01) -- HP
		WriteByte(tablePos+96, 0x01) -- hP
		WriteByte(tablePos+97, 0x02) -- MP
		WriteByte(tablePos+98, 0x01) -- HP
		WriteByte(tablePos+99, 0x01) -- HP	
		WriteByte(tablePos+100, 0x04) -- STRENGTH
	end
end





