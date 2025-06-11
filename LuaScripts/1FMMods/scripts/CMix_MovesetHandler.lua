LUAGUI_NAME = "CMix_MovesetHandler"
LUAGUI_AUTH = "Xendra"
LUAGUI_DESC = "Changes to accomodate Critical Mix sora .mset"


-- Final feature: Prevent usage when all item slots are empty

local offset = 0x3A0606

local comboPosition = 0x29678A1 - offset

local soraPointer = 0x2534680 - offset
local animCancel = ReadLong(soraPointer)
local soraSlotOffset = ReadShort(ReadLong(soraPointer) + 0x6C, true) - 0x9000
local soraSlot = 0x2D59000 - offset + soraSlotOffset
local maxGroundComboLength = soraSlot + 0xD4
local maxAirComboLength = soraSlot + 0xD5
local currentAnim = ReadLong(soraPointer)+0x164

function _OnInit()
	if GAME_ID == 0xAF71841E and ENGINE_TYPE == "BACKEND" then
		canExecute = true
		ConsolePrint("CMix_MovesetHandler Installed")
	else
		ConsolePrint("CMix_MovesetHandler -- FAILED --")
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



function _OnFrame()
	if not canExecute then
		goto done
	end
	set_sora_pointer_data()
	currentAnim = ReadLong(soraPointer)+0x164
	animCancel = ReadLong(soraPointer)
	if ReadByte(currentAnim, true) == 0xCE then
		WriteByte(comboPosition, 0)
	end
	
	if ReadByte(comboPosition) >= ReadByte(maxGroundComboLength) + 2 then
		WriteByte(comboPosition, 0)
	end
	
	::done::
end




