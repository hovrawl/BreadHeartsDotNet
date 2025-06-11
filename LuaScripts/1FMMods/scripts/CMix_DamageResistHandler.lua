LUAGUI_NAME = "CMix_DamageResistHandler"
LUAGUI_AUTH = "Xendra"
LUAGUI_DESC = "Changes to damage resistnace for Critical Mix"



local offset = 0x3A0606

local comboPosition = 0x29678A1 - offset
local soraPointer = 0x2534680 - offset
local soraSlotOffset = ReadShort(ReadLong(soraPointer) + 0x6C, true) - 0x9000
local soraSlot = 0x2D59000 - offset + soraSlotOffset
local currentAnim = ReadLong(soraPointer)+0x164
local currentWeapon = 0x2DE5A06 - offset

local physResist = soraSlot + 0x78
local fireResist = soraSlot + 0x80
local iceResist = soraSlot + 0x84
local thunderResist = soraSlot + 0x88
local darkResist = soraSlot + 0x8c
local soraDefense = soraSlot + 0x50

-- Location Info
local world = 0x233CADC - offset
local room = 0x233CB44 - offset
local flag = 0x233CB48 - offset


local difficulty = 0x2DFBDFC - offset

local beginnerSaveText = 0x2E1A452 - offset
local khfmSaveText = 0x2E1A31D - offset
local proudSaveText = 0x2E1A322 - offset
local proudSaveText2 = 0x2E1A32E - offset

local beginnerStartText = 0x2E1A43E - offset
local standardStartText = 0x2E17C43 - offset
local proudStartText = 0x2E17C4D - offset

local beginnerDescription = 0x2E1A3A5 - offset
local standardDescription = 0x2E1A3D5 - offset
local proudDescription = 0x2E1A40F - offset

local damageTakenMultiplier = 1.0
local physTakenMultiplier = 1.0
local elementalTakenMultiplier = 1.0

local currentMP = soraSlot + 68
local maxMP = soraSlot + 72
local currentHP = soraSlot + 60
local maxHP = soraSlot + 64
local mpCharge = soraSlot + 190
local rikuEnabledGummi = 0x2DF18DC - offset -- Unused Gummi 5
local currentLinkItem = 0x2DE5F51 - offset

local shortcut1 = 0x2DE6214 - offset


function _OnInit()
	if GAME_ID == 0xAF71841E and ENGINE_TYPE == "BACKEND" then
		canExecute = true
		ConsolePrint("CMix_DamageResistHandler Installed")
	else
		ConsolePrint("CMix_DamageResistHandler -- FAILED --")
	end
end

function set_sora_pointer_data()
	soraSlotOffset = ReadShort(ReadLong(soraPointer) + 0x6C, true) - 0x9000
	if soraSlotOffset > 0 then
		soraSlot = 0x2D59000 - offset + soraSlotOffset
		physResist = soraSlot + 0x78
		fireResist = soraSlot + 0x80
		iceResist = soraSlot + 0x84
		thunderResist = soraSlot + 0x88
		darkResist = soraSlot + 0x8c
		soraDefense = soraSlot + 0x50
		currentMP = soraSlot + 68
		maxMP = soraSlot + 72
		currentHP = soraSlot + 60
		maxHP = soraSlot + 64
		mpCharge = soraSlot + 190
	end
end

function set_difficulty_text()

	WriteLong(0x2E1A31D - offset, 0x3D2B37003E333C2D)
	WriteLong(0x2E1A31D+0x08 - offset, 0x3E333C2D003C2F3E)
	WriteLong(0x2E1A31D+0x10 - offset, 0x003C2F3E3D2B3700)
	
	local beg2 = 0x2E1A460 - offset
	WriteLong(beg2, 0x485645485245583D)
	WriteLong(beg2+0x08, 0x0000000000000000)
	
	WriteLong(beginnerStartText, 0x485645485245583D)
	WriteLong(0x2E1A446 - offset, 0x0000000000000000)
	WriteShort(0x2E1A446+0x08 - offset, 0x0000)
	WriteShort(0x2E1A446+0x0A - offset, 0x0000)
	WriteLong(beginnerDescription, 0x5749484D5A53563A)
	WriteLong(beginnerDescription+0x08, 0x5245504546014501)
	WriteLong(beginnerDescription+0x10, 0x50454C4701484947)
	WriteLong(beginnerDescription+0x18, 0x000068494B524950)
	WriteShort(beginnerDescription+0x20, 0x0000)
	WriteShort(beginnerDescription+0x22, 0x0000)
	
	local stand2 = 0x2E19609 - offset
	WriteLong(stand2, 0x5045474D584D562D)
	WriteByte(stand2+0x08, 0x00)	
	
	WriteLong(standardStartText, 0x5045474D584D562D)
	WriteByte(standardStartText+0x08, 0x00)
	WriteLong(standardDescription, 0x474D4A4A4D48012B)
	WriteLong(standardDescription+0x08, 0x50454C4701585059)
	WriteLong(standardDescription+0x10, 0x534A01494B524950)
	WriteLong(standardDescription+0x18, 0x45564958495A0156)
	WriteLong(standardDescription+0x20, 0x56495D4550540152)
	WriteShort(standardDescription+0x28, 0x6857)
	WriteShort(standardDescription+0x2A, 0x0000)
	WriteByte(standardDescription+0x2C, 0x00)

	WriteLong(proudStartText, 0x0000564958574537)
	WriteLong(proudStartText+0x08, 0x0000000000000000)
	local proud2 = 0x2E19613 - offset
	WriteLong(proud2, 0x0000564958574537)
	WriteLong(proud2+0x08, 0x0000000000000000)
	
	WriteLong(proudDescription, 0x5B535656454C012B)
	WriteLong(proudDescription+0x08, 0x5659534E014B524D)
	WriteLong(proudDescription+0x10, 0x53564C58015D4952)
	WriteLong(proudDescription+0x18, 0x01494C58014C4B59)
	WriteLong(proudDescription+0x20, 0x575749524F564548)
	WriteShort(proudDescription+0x28, 0x0068)
	WriteShort(proudDescription+0x2A, 0x0000)
	WriteShort(proudDescription+0x2C, 0x0000)

end

function _OnFrame()
	if not canExecute then
		goto done
	end
	damageTakenMultiplier = 1.0
	physTakenMultiplier = 1.0
	elementalTakenMultiplier = 1.0
	currentAnim = ReadLong(soraPointer)+0x164
	set_difficulty_text()
	set_sora_pointer_data()
	set_resistances()
	
	::done::
end


function apply_accessories()
	protect_chain()
	shell_chain()
	mighty_chain()
	strength_ring()
	power_chain()
	golem_chain()
	titan_chain()
	curaga_ring()
	ravens_claw()
	ribbon()
	prime_cap()
	aerogun_band()
end

function aerogun_band()
	for i = 1, check_accessory_count(0x23) do
		damageTakenMultiplier = damageTakenMultiplier * 0.9
	end
end



function prime_cap()
	for i = 1, check_accessory_count(0x3B) do
		damageTakenMultiplier = damageTakenMultiplier * 0.65
	end
end

function ribbon()
	for i = 1, check_accessory_count(0x3B) do
		damageTakenMultiplier = damageTakenMultiplier * 0.75
	end
end

function ravens_claw()
	for i = 1, check_accessory_count(0x36) do
		damageTakenMultiplier = damageTakenMultiplier * 1.15
	end
end

function curaga_ring()
	for i = 1, check_accessory_count(0x29) do
		damageTakenMultiplier = damageTakenMultiplier * 0.87
	end
end


function titan_chain()
	for i = 1, check_accessory_count(0x26) do
		damageTakenMultiplier = damageTakenMultiplier * 0.9
	end
end

function golem_chain()
	for i = 1, check_accessory_count(0x25) do
		damageTakenMultiplier = damageTakenMultiplier * 0.9
	end
end

function power_chain()
	for i = 1, check_accessory_count(0x24) do
		damageTakenMultiplier = damageTakenMultiplier * 0.9
	end
end

function strength_ring()
	for i = 1, check_accessory_count(0x1D) do
		damageTakenMultiplier = damageTakenMultiplier * 0.9
	end
end

function mighty_chain()
	for i = 1, check_accessory_count(0x13) do
		damageTakenMultiplier = damageTakenMultiplier * 0.75
	end
end

function shell_chain()
	for i = 1, check_accessory_count(0x12) do
		elementalTakenMultiplier = elementalTakenMultiplier * 0.8
	end
end


function protect_chain()
	for i = 1, check_accessory_count(0x11) do
		physTakenMultiplier = physTakenMultiplier * 0.8
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




function set_resistances()
	if soraSlotOffset > 0 then
		-- Difficulty Settings
		local base = 1.2
		local boost = 1.0
		local crit = false
		-- Critical
		if ReadByte(difficulty) == 1 then
			base = 2.25
			crit = true
		-- Master
		elseif ReadByte(difficulty) == 2 then
			base = 1.5
			crit = true
		end
		
		if crit == true then
			local traverseStatus = 0x2DE78C0 - offset
			local boosted = 0
			for i = 0, 8 do
				if ReadByte(traverseStatus + i) == 4 then
					boost = boost + 0.035
					if ReadByte(difficulty) == 2 then
						boost = boost + 0.035
					end
					boosted = boosted + 1
					if boosted >= 7 then
						break
					end
				end
			end
		end
		base = base * boost
		if ReadByte(0x2E90821 - offset) == 0x00 then
			WriteByte(0x2DE59DB - offset, 0x00) -- base defense
		end
		WriteByte(soraDefense, 0x00)
		
		if ReadByte(currentAnim, true) == 0xD4 then -- Hyper Guard
			local hyper = check_ability_count(0x15)
			for i = 1, hyper + 1 do
				base = base * 0.8
			end
		end
		
		if ReadByte(currentWeapon) == 0x51 then -- Kingdom Key
			for i = 0, 2 do
				if ReadByte(shortcut1 + i) == 0x06 then -- Aero
					base = base * 0.85
				end
			end
		end
		
		local frenzy = check_ability_count(0x25)
		for i = 1, frenzy do
			base = base * 1.2
		end
		apply_accessories()
		
		base = base * damageTakenMultiplier
		
		-- Fortify Aibility
		if ReadByte(currentHP) >= ReadByte(maxHP) then
			local fortify = check_ability_count(0x29)
			for i = 1, fortify do
				base = base * 0.7
			end
		end
		
		-- Ansem 3
		if ReadByte(world) == 0x10 and ReadByte(room) == 0x21 then
			base = base * 0.5
			ConsolePrint("Ansem")
		end
		
		if ReadByte(rikuEnabledGummi) > 0 then
			if ReadByte(base) == 1 then
				base = base * 0.9
			elseif ReadByte(currentLinkItem) == 2 then
				base = base * 0.8
			elseif ReadByte(currentLinkItem) == 3 then
				base = base * 0.7
			end
		end
		
		if ReadByte(currentWeapon) == 0x61 then -- Oblivion
			base = 66.6
			physTakenMultiplier = 1.0
			elementalTakenMultiplier= 1.0
		end
		WriteFloat(physResist, base * physTakenMultiplier)
		WriteFloat(fireResist, base * elementalTakenMultiplier)
		WriteFloat(iceResist, base * elementalTakenMultiplier)
		WriteFloat(thunderResist, base * elementalTakenMultiplier)
		WriteFloat(darkResist, base * elementalTakenMultiplier)
	end
end


