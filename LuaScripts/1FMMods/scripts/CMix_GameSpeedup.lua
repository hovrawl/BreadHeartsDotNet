LUAGUI_NAME = "CMix_GameSpeed_SlowMenu_FastLadders"
LUAGUI_AUTH = "Xendra & denhonator"
LUAGUI_DESC = "Faster Gameplay, Command Menu Slowdown"

local criticalMixEnabled = true
local summonSpeedup = true
local offset = 0x3A0606
--
local gameSpeed = 1.1
local soraSpeed = 1.0
local soraSpeedMulti = 1.0
local boostSpeed = 2.0
local climbSpeed = 2.0
local menuSpeed = 0.1
local menuCameraSpeed = 10.0
local currentWeapon = 0x2DE5A06 - offset
local rikuEnabledGummi = 0x2DF18DC - offset -- Unused Gummi 5
--

local soraHUD = 0x280EB1C - offset
local speedup = 0x233C24C - offset
local stateFlag = 0x2863958 - offset
local speedupFlags = {0x00, 0x01, 0x11, 0x20, 0x21}
local currentCommandMenu = 0x284EE10 - offset
local menu = 0x2E90820 - offset
local inMenu = 0x232A600 - offset
local swapped = ReadByte(0x22D6C7E - offset)
local canExecute = false
--
local soraPointer = 0x2534680 - offset
local soraSlotOffset = ReadShort(ReadLong(soraPointer) + 0x6C, true) - 0x9000
local soraSlot = 0x2D59000 - offset + soraSlotOffset
local currentAnim = ReadLong(soraPointer)+0x164
--
local walkSpeed = soraSlot+0x04
local runSpeed = soraSlot+0x08
local runMulti = 1.0
local currentLinkItem = 0x2DE5F51 - offset
local shortcut1 = 0x2DE6214 - offset

function _OnInit()
	if GAME_ID == 0xAF71841E and ENGINE_TYPE == "BACKEND" then
		canExecute = true
		ConsolePrint("KH1 detected, running script CMix_GameSpeedup")
	else
		ConsolePrint("KH1 not detected, not running script CMix_GameSpeedup")
	end
end


function set_sora_pointer_data()
	soraSlotOffset = ReadShort(ReadLong(soraPointer) + 0x6C, true) - 0x9000
	if soraSlotOffset > 0 then
		soraSlot = 0x2D59000 - offset + soraSlotOffset
		walkSpeed = soraSlot+0x04
		runSpeed = soraSlot+0x08
	end
end

function apply_movement_speed()
	if soraSlotOffset > 0 then
		WriteFloat(walkSpeed, 4.0 * runMulti)
		WriteFloat(runSpeed, 11.0 * runMulti)
	end
end

function _OnFrame()
	if not canExecute then
		goto done
	end
	
	set_sora_pointer_data()
	soraSpeedMulti = 1.0
	runMulti = 1.0
	gameSpeed = 1.1
	
	if ReadByte(currentWeapon) == 0x66 then -- Dream Sword
		gameSpeed = 1.0
		runMulti = 1.13
		soraSpeedMulti = 1.13
	end
	
	if ReadByte(currentWeapon) == 0x51 then -- Kingdom Key
		for i = 0, 2 do
			if ReadByte(shortcut1 + i) == 0x05 then -- Stop
				soraSpeedMulti = soraSpeedMulti + 0.07
			end
		end
	end
	
	if ReadByte(currentLinkItem) == 1 and ReadByte(rikuEnabledGummi) == 0 then
		soraSpeedMulti = soraSpeedMulti + 0.15
		runMulti = runMulti + 0.1
		if ReadByte(currentWeapon) == 0x64 then -- Ultima Weapon
			soraSpeedMulti = soraSpeedMulti + 0.07
			runMulti = runMulti + 0.05
		end
	end
	
	if ReadByte(rikuEnabledGummi) > 0 then
		if ReadByte(currentLinkItem) == 0 then
			soraSpeedMulti = 1.0
			runMulti = 1.0
		elseif ReadByte(currentLinkItem) == 1 then
			soraSpeedMulti = 1.03
			runMulti = 1.03
			gameSpeed = gameSpeed + 0.03
		elseif ReadByte(currentLinkItem) == 2 then
			soraSpeedMulti = 1.06
			runMulti = 1.06
			gameSpeed = gameSpeed + 0.03
		elseif ReadByte(currentLinkItem) == 3 then
			soraSpeedMulti = 1.1
			runMulti = 1.1
			gameSpeed = gameSpeed + 0.04
		end
		
	
	end
	
	local cutscene = ReadInt(0x2378B60-offset)
	local skippable = ReadInt(0x23944E4-offset)
	local summoning = ReadInt(0x2D5D62C-offset)
	local world = ReadByte(0x233CADC-offset)
	local room = ReadByte(0x233CB44-offset)
	local minitimer = ReadInt(0x232A684-offset)
	local camstate = ReadByte(0x2998188-offset)
	local currentSpeed = 1.0

	local soraAnimSpeed = ReadLong(soraPointer)+0x284
	currentAnim = ReadLong(soraPointer)+0x164	
	
	if criticalMixEnabled then
		apply_all_accessories()
		apply_accelerate()
	end

	
	for index, flag in pairs(speedupFlags) do
		if ReadByte(stateFlag) == flag then
			currentSpeed = gameSpeed
			break
		end
	end
	local boost = false
	if ReadFloat(soraHUD) < 1 and cutscene > 0 and cutscene ~= 8 
		and skippable ~= 1025 and (summoning == 0 or summonSpeedup)
		and not (world==6 and room==8 and minitimer>=18000.0/boostSpeed)
		and not (world==1 and room==2 and (camstate>=1 and camstate<=5)) then
		boost = true
	end
	
	if ReadByte(currentAnim, true) == 0x15 or ReadByte(currentAnim, true) == 0x16 or ReadByte(currentAnim, true) == 0x1E or ReadByte(currentAnim, true) == 0x1F then
		currentSpeed = climbSpeed
	end
	
	local camSpeed = 0x503A1C - offset
	WriteFloat(camSpeed, 1.0)
	
	local menuSlow = false
	
	if ReadByte(menu) == 0x00 and ReadByte(currentCommandMenu) > 0x00 and ReadByte(currentCommandMenu) < 0x05 and ReadByte(inMenu) == 0x00 then
		menuSlow = true
	end
	
		
	if (ReadByte(0x233D035-0x3A0606)//(0x04))%2 == 1 then
		menuSlow = false
	end
	
	if boost == true then
		currentSpeed = boostSpeed
	end
	
	if menuSlow == true then
		currentSpeed = menuSpeed
		WriteFloat(camSpeed, menuCameraSpeed)
	end
	WriteFloat(soraAnimSpeed, soraSpeed * soraSpeedMulti, true)
	WriteFloat(speedup, currentSpeed)
	apply_movement_speed()
	::done::
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

function apply_accelerate()
	for i = 1, check_ability_count(0x2B) do
		gameSpeed = gameSpeed + 0.2
	end
end

function apply_all_accessories()
	acc_haste_ring()
	acc_hastega_ring()
end

function acc_haste_ring()
	for i = 1, check_accessory_count(0x1E) do
		runMulti = runMulti + 0.1
		soraSpeedMulti = soraSpeedMulti + 0.1
	end
end


function acc_hastega_ring()
	for i = 1, check_accessory_count(0x1F) do
		runMulti = runMulti + 0.15
		soraSpeedMulti = soraSpeedMulti + 0.15
	end
end

