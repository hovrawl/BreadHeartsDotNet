LUAGUI_NAME = "CMix_LenientReaction"
LUAGUI_AUTH = "Xendra"
LUAGUI_DESC = "Makes it easier to hit Reaction Commands"

local leniencyFrames = 9

local offset = 0x3A0606

local autoReaction = 0x232A460 - offset
local swapped = ReadByte(0x22D6C7E - offset)
local rcCommand = 0x2863390 - offset
local reactionTimer = 0


function _OnInit()
	if GAME_ID == 0xAF71841E and ENGINE_TYPE == "BACKEND" then
		canExecute = true
		ConsolePrint("CMix_LenientReaction Installed")
	else
		ConsolePrint("CMix_LenientReaction -- FAILED --")
	end
end


function _OnFrame()
	if not canExecute then
		goto done
	end
	
	WriteByte(0x2735E4 - offset, 0x84)
	WriteByte(0x2735E4-0x171 - offset, 0x80)
	
	--tart_rc_window()
	
	--if reactionTimer == 1 then
	--	WriteByte(autoReaction, 0)
	--	reactionTimer = 0
	--elseif reactionTimer > 0 then
	--	WriteByte(autoReaction, 1)
--		reactionTimer = reactionTimer - 1
	--end
	
	::done::
end



function start_rc_window()
	if ReadShort(rcCommand) == 0 and (ReadByte(0x233D035-0x3A0606)//(0x10-(32*swapped)))%2 == 1 then
		reactionTimer = leniencyFrames
	end
end