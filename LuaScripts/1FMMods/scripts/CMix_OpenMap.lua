LUAGUI_NAME = "CMix_OpenMap"
LUAGUI_AUTH = "Xendra"
LUAGUI_DESC = "Opens up the Gummi Map"

local offset = 0x3A0606

local pathway1 = 0x2DE78E2 - offset
local pathway2 = pathway1 + 0x01
local pathway3 = pathway1 + 0x02
local pathway4 = pathway1 + 0x03

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
local monstroStatus = 0x2DE78CA - offset

local cutsceneFlagBase = 0x2DE65D0-0x200 - offset
local djProgressFlag = 0x2DE79D0+0x6C+0x40
local neverlandProgressFlag = 0x2DE79D0+0x6C+0xED


local immediateWorlds = {traverseStatus, wonderlandStatus, olympusStatus, jungleStatus, agrabahStatus, halloweenStatus, atlanticaStatus, }



function _OnInit()
	if GAME_ID == 0xAF71841E and ENGINE_TYPE == "BACKEND" then
		ConsolePrint("CMix_OpenMap Installed")
		canExecute = true
	end
end


function _OnFrame()
	if canExecute == true then
		-- ConsolePrint(ReadByte(djProgressFlag))
		-- Make Worlds Explorable
		if ReadByte(neverlandStatus) < 2 then
			WriteByte(neverlandStatus, 2)
		end
		for index, world in pairs(immediateWorlds) do
			if ReadByte(world) < 0x03 then
				WriteByte(world, 0x03)
			end
		end
		if ReadByte(monstroStatus) < 0x02 then
			WriteByte(monstroStatus, 0x02)
		end
		-- Unlock Gummi Pathways
		if ReadByte(pathway4) < 0xF0 then
			WriteByte(pathway1, 0xFE)
			WriteByte(pathway2, 0xF0)
			WriteByte(pathway3, 0xFC)
			WriteByte(pathway4, 0xF0)
		end
	end
end




