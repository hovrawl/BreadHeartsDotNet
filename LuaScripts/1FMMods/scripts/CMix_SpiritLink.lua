LUAGUI_NAME = "CMix_SpiritLink"
LUAGUI_AUTH = "Xendra"
LUAGUI_DESC = "Adds Spirit Gague, and Spirit Link option in Items menu // STANDALONE VERSION"

local criticalMix = true

local offset = 0x3A0606
local swapped = ReadByte(0x22D6C7E - 0x3A0606)
ultimaCooldown = 0
local buttonInput = (ReadByte(0x233D035-0x3A0606)//(0x40 -(32*swapped)))%2 == 1
local rikuEnabledGummi = 0x2DF18DC - offset -- Unused Gummi 5
local noSpiritDrainGummi = 0x2DF18DD - offset -- Unused Gummi 6
local soraPointer = 0x2534680 - offset
local soraSlotOffset = ReadShort(ReadLong(soraPointer) + 0x6C, true) - 0x9000
local soraSlot = 0x2D59000 - offset + soraSlotOffset
local currentMP = soraSlot + 68
local maxMP = soraSlot + 72
local currentHP = soraSlot + 60
local maxHP = soraSlot + 64
local mpCharge = soraSlot + 190
local currentAnim = ReadLong(soraPointer)+0x164
local spiritValue = 0
local spiritNeeded = 0x72
local currentWeapon = 0x2DE5A06 - offset

local hpmpStart = 0x2812C68 - offset
local fillStart = 0x2812D28 - offset
local soraItemSlotAmount = 0x2DE59F5 - offset
local itemSlot1 = 0x2DE59F6 - offset
local itemsOpen = false
local soraItemSlotValue = 0
local inMenu = 0x232A600 - offset
local currentMenuType = 0x284EE10 - offset
local currentMenuPosition = 0x284EE14 - offset
local currentPartyHoverPosition = 0x284EE24 - offset
local currentItemHoverPosition = 0x284EE34 - offset
local linkedSpiritItem = 0x2DE5EFD - offset
local soraAnimSpeed = ReadLong(soraPointer)+0x284

local lastMenuType = 0
local lastMenuPosition = 0
local lastPauseType = 0
local lastItemTypeSelected = 0
local spiritItemId = 10

local boostedAmount = false

local currentForcedSlots = 0
local itemValue = 0

local soraRed = ReadLong(soraPointer)+0xA0
local soraGreen = ReadLong(soraPointer)+0xA4
local soraBlue = ReadLong(soraPointer)+0xA8

local spiritCheckTimer = 0
local currentLinkItem = 0x2DE5F51 - offset
local currentLink = ReadByte(currentLinkItem)
local spiritDrainTimer = 0
local spiritDrainDelay = 60
local dreamShieldRecharge = 8

local connectCounter = 0x29678B0 - offset
local comboPosition = 0x29678A1 - offset
local magicUnlocked = 0x2DE5A44 - offset
local speedup = 0x233C24C - offset

local totalDarkness = 0

-- 0  = unlinked

-- 1 = sora link
-- 30% Increased Animation Speed


-- 2 = donald link
-- 50% Reduced MP Cost
-- Instant MP Recovery

-- 3  = goofy link
-- Life Gain on Hit
-- No stagger?

-- Fire
local fireMP = 0x2D25318 - offset
local firaMP = 0x2D25388 - offset
local firagaMP = 0x2D253F8 - offset
-- Blizard
local blizzardMP = 0x2D25468 - offset
local blizzaraMP = 0x2D254d8 - offset
local blizzagaMP = 0x2D25548 - offset
-- Gravity
local gravityMP = 0x2D25858 - offset
local graviraMP = 0x2D258C8 - offset
local gravigaMP = 0x2D25938 - offset
-- Thunder
local thunderMP = 0x2D255B8 - offset
local thundaraMP = 0x2D25628 - offset
local thundagaMP = 0x2D25698 - offset
-- Cure
local cureMP = 0x2D25708 - offset
local curaMP = 0x2D25778 - offset
local curagaMP = 0x2D257E8 - offset
-- Stop
local stopMP = 0x2D259A8 - offset
local stopraMP = 0x2D25A18 - offset
local stopgaMP = 0x2D25A88 - offset
-- Aero
local aeroMP = 0x2D25AF8 - offset
local aeroraMP = 0x2D25B68 - offset
local aerogaMP = 0x2D25BD8 - offset

local animationTime = ReadFloat(ReadLong(soraPointer)+0x16C, true)


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



function set_spell_costs()

	if criticalMix == false then
		local small = 30
		local mid = 100
		local big = 200
		if currentLink == 2 then
			small = small * 0.5
			mid = mid * 0.5
			big = big * 0.5
		end
		-- Fire
		WriteByte(fireMP, small)
		WriteByte(firaMP, small)
		WriteByte(firagaMP, small)
		-- Blizard
		WriteByte(blizzardMP, small)
		WriteByte(blizzaraMP, small)
		WriteByte(blizzagaMP, small)
		-- Gravity
		WriteByte(gravityMP, mid)
		WriteByte(graviraMP, mid)
		WriteByte(gravigaMP, mid)
		-- Thunder
		WriteByte(thunderMP, mid)
		WriteByte(thundaraMP, mid)
		WriteByte(thundagaMP, mid)
		-- Cure
		WriteByte(cureMP, mid)
		WriteByte(curaMP, mid)
		WriteByte(curagaMP, mid)
		-- Stop
		WriteByte(stopMP, big)
		WriteByte(stopraMP, big)
		WriteByte(stopgaMP, big)
		-- Aero
		WriteByte(aeroMP, big)
		WriteByte(aeroraMP, big)
		WriteByte(aerogaMP, big)
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



function activate_spirit_link()
	local itemAnims = {0x3E, 0x3F, 0x8B}
	local activate = false
	if spiritCheckTimer > 0 then
		for i, anim in pairs(itemAnims) do
			if anim == ReadByte(currentAnim, true) then
				activate = true
				break
			end
		end
		spiritCheckTimer = spiritCheckTimer - 1
	end
	
	if activate == true then
		--ConsolePrint("SPIRIT LINK ")
		spiritCheckTimer = 0
		WriteByte(currentHP, ReadByte(maxHP))
		local link = 0
		local drainMulti = 1.0
		for i = 1, check_accessory_count(0x4E) do -- Paopu Fruit
			drainMulti = drainMulti * 2.0
		end
		if ReadByte(currentPartyHoverPosition) == 0 then -- Sora Link
			--ConsolePrint("- Sora Link -")
			link = 1
			spiritDrainDelay = math.floor(60 * drainMulti)
			
		elseif ReadByte(currentPartyHoverPosition) == 1 then -- Check ally in slot 1
			--ConsolePrint("- Link Ally 1 -")
			link = math.min(3, ReadByte(0x2DE5E5F - offset) + 1)	
			
		elseif ReadByte(currentPartyHoverPosition) == 2 then -- Check ally in slot 2
			link = math.min(3, ReadByte(0x2DE5E60 - offset) + 1)
			--ConsolePrint("- Link Ally 2 -")
		end
		
		if link == 2 then -- Donald Link MP Refill
			WriteByte(mpCharge, ReadByte(maxMP) * 30)
			WriteByte(currentMP, ReadByte(maxMP))
			spiritDrainDelay = math.floor(40 * drainMulti)
		elseif link == 3 then
			spiritDrainDelay = math.floor(60 * drainMulti)		
		end
		
		
		WriteByte(currentLinkItem, link)
	end
end



function spirit_link_effects()
	
	local r = 1.1
	local g = 1.1
	local b = 1.1

	if criticalMix == false then
		WriteFloat(soraAnimSpeed, 1.0, true)
	end
	
	if currentLink == 1 then
		if criticalMix == false then
			WriteFloat(soraAnimSpeed, 1.3, true)
		end
		r = 1.5
		b = 0.9
		g = 0.9
		
	elseif currentLink == 2 then
		r = 0.8
		g = 0.8
		b = 1.8
		
	elseif currentLink == 3 then
		g = 1.5
		r = 0.9
		b = 0.9
	end
	
	if ReadByte(rikuEnabledGummi) > 0 then
		g = 1.1
		r = 1.1
		b = 1.1
	end
	
	if ReadByte(magicUnlocked) == 0 and ReadByte(rikuEnabledGummi) == 0 then
		WriteByte(linkedSpiritItem, 0)
	end
	local color = true
	
	if criticalMix == true and currentLink == 0 then
		color = false
	end
	
	if color == true then
		WriteFloat(soraRed, r, true)
		WriteFloat(soraGreen, g, true)
		WriteFloat(soraBlue, b, true)
	end
end







function _OnInit()
	if GAME_ID == 0xAF71841E and ENGINE_TYPE == "BACKEND" then
		ConsolePrint("CMix_SpiritLink Installed")
		canExecute = true
	end
end

-- Some spirit link effects must be duplicated both here and in CMix files

function insert_dummy_item_to_make_menu_available()
	local value = ReadByte(soraItemSlotAmount)
	if soraItemSlotValue > 0 then
		value = soraItemSlotValue
	end
	
	if spiritValue >= spiritNeeded then
	
		local allEmpty = true
		
		for i = 0, value - 1 do
			if ReadByte(itemSlot1 + i) ~= 0 and ReadByte(itemSlot1 + i) ~= spiritItemId then
				allEmpty = false
			end
		end
		
		if allEmpty == true then
			if ReadByte(0x2DE59F6 - offset) ~= 0x45 and ReadByte(inMenu) == 0 then
				-- ConsolePrint("Empty Item Slots")
				WriteByte(itemSlot1, spiritItemId)
			end
		end
		
	elseif ReadByte(itemSlot1) == spiritItemId then
		WriteByte(itemSlot1, 0)
	end
	if ReadByte(inMenu) == 1 and ReadByte(itemSlot1) == spiritItemId then
		WriteByte(itemSlot1, 0x00)
	end
	
	for i = value + 1, 7 do
		if ReadByte(itemSlot1 + i) == spiritItemId then
			WriteByte(itemSlot1 + i, 0)
		end
	end
end

function calculate_spirit_drain()
	if ReadByte(noSpiritDrainGummi) > 0 then
		WriteByte(noSpiritDrainGummi, ReadByte(noSpiritDrainGummi) - 1)
	end
	if ReadByte(inMenu) == 0 then
		if spiritDrainTimer > 0 then
			spiritDrainTimer = spiritDrainTimer - 1
		else
			
			local drain = false
			if currentLink > 0 or ReadByte(rikuEnabledGummi) > 0 then
				drain = true
			end
			
			if drain == true and ReadByte(linkedSpiritItem) > 0 and ReadByte(noSpiritDrainGummi) == 0 then
				WriteByte(linkedSpiritItem, ReadByte(linkedSpiritItem) - 1)
			end
			local delay = spiritDrainDelay
			if ReadByte(rikuEnabledGummi) > 0 then
				delay = math.floor(13 / math.max(1, ReadByte(currentLinkItem) + 0))
				local s = 1.0
				if ReadFloat(speedup) > 0.0 then
					s = ReadFloat(speedup)
				end
				delay = math.floor(delay / s)
			end
			spiritDrainTimer = delay
		end
	end
end



function check_ultima_mode()
	if ultimaCooldown > 0 then
		ultimaCooldown = ultimaCooldown - 1
	end
	if ultimaCooldown == 0 and (ReadByte(0x233D034-0x3A0606)//(0x02))%2 == 1 then
		ultimaCooldown = 12
		if ReadByte(currentLinkItem) < 3 then
			WriteByte(currentLinkItem, ReadByte(currentLinkItem) + 1)
		else
			WriteByte(currentLinkItem, 1)
		end
	end
end


function dream_shield()
	if ReadByte(currentWeapon) == 0x53 and ReadByte(rikuEnabledGummi) == 0 then -- Dream Shield
		if dreamShieldRecharge > 0 then
			dreamShieldRecharge = dreamShieldRecharge - 1
		elseif ReadByte(linkedSpiritItem) < spiritNeeded then
			WriteByte(linkedSpiritItem, ReadByte(linkedSpiritItem) + 1)
			dreamShieldRecharge = 55
		end
	end
end


function dark_dodge()
	if ReadByte(currentAnim, true) == 0xDC and totalDarkness > 0 then
		-- Iframes
		if animationTime < 5.0 and ReadByte(inMenu) == 0 then
			WriteByte(linkedSpiritItem, ReadByte(linkedSpiritItem) - 1)
		end
	end
end

function calculate_total_darkness()
	totalDarkness = (spiritNeeded * ReadByte(currentLinkItem)) + ReadByte(linkedSpiritItem)
end

function _OnFrame()
	if canExecute == true then
		dream_shield()
		set_sora_pointer_data()
		soraRed = ReadLong(soraPointer)+0xA0
		soraGreen = ReadLong(soraPointer)+0xA4
		soraBlue = ReadLong(soraPointer)+0xA8
		animationTime = ReadFloat(ReadLong(soraPointer)+0x16C, true)
		
		
		if ReadByte(linkedSpiritItem) == 0 then
			if ReadByte(rikuEnabledGummi) == 0 then -- Default
				WriteByte(currentLinkItem, 0)
			else -- Riku
				if ReadByte(currentLinkItem) > 0 then
					WriteByte(currentLinkItem, ReadByte(currentLinkItem) - 1)
					WriteByte(linkedSpiritItem, spiritNeeded)
				end
			end
		end
		
		currentLink = ReadByte(currentLinkItem)
		calculate_spirit_drain()
		
		soraAnimSpeed = ReadLong(soraPointer)+0x284
		currentAnim = ReadLong(soraPointer)+0x164
		buttonInput = (ReadByte(0x233D035-0x3A0606)//(0x40 -(32*swapped)))%2 == 1
		if ReadByte(0x2DE59F6 - offset) ~= 0x45 then
			store_sora_item_slots()
		end
		if ReadByte(linkedSpiritItem) > spiritNeeded then
			if ReadByte(rikuEnabledGummi) == 0 then -- Default
				WriteByte(linkedSpiritItem, spiritNeeded)
			else -- Riku
				if ReadByte(currentLinkItem) < 3 then
					WriteByte(linkedSpiritItem, 7)
					WriteByte(currentLinkItem, ReadByte(currentLinkItem) +1)
				else
					WriteByte(linkedSpiritItem, spiritNeeded)
				end
			end
		end
		spiritValue = ReadByte(linkedSpiritItem)
		
		if ReadByte(currentWeapon) == 0x64 and ReadByte(rikuEnabledGummi) == 0 then -- Ultima Weapon
			check_ultima_mode()
			if ReadByte(currentLinkItem) == 0 then 
				WriteByte(currentLinkItem, 1)
			end
			WriteByte(linkedSpiritItem, spiritNeeded - 1)
		end
		
		if ReadByte(rikuEnabledGummi) == 0 then
			draw_spirit_bar()
		else
			draw_darkness_bar()
		end
		apply_bar_fill()
		if ReadByte(rikuEnabledGummi) == 0 then
			add_spirit_command()
		end
		lastMenuType = ReadByte(currentMenuType)
		lastMenuPosition = ReadByte(currentMenuPosition)
		lastPauseType = ReadByte(inMenu)
		insert_dummy_item_to_make_menu_available()
		
		
		if ReadByte(currentMenuType) == 2 then
			local equipped = {}
			
			for i = 0, 7 do
				if ReadByte(itemSlot1 + i) ~= 00 then
					table.insert(equipped, ReadByte(itemSlot1 + i))
				end
			end
			
			for i, equip in pairs(equipped) do
				if i - 1 == ReadByte(currentItemHoverPosition) then
					lastItemTypeSelected = equip
				end
			end
		end
		activate_spirit_link()
		spirit_link_effects()
		set_spell_costs()
		calculate_total_darkness()
		if ReadByte(rikuEnabledGummi) > 0 then
			dark_dodge()
		end
	end
end



-- Create an array of your items and use that instead




function add_spirit_command()
	if spiritValue >= spiritNeeded then
		WriteByte(itemSlot1 + ReadByte(soraItemSlotAmount), spiritItemId)
	end
end

function store_sora_item_slots()
	-- When you open the item menu, save Sora's current item slot amount
	local changeItemText = false
	local update = false
	itemValue = 0
	
	if spiritValue >= spiritNeeded and lastMenuType == 0 and ReadByte(currentMenuType) == 2 then
		soraItemSlotValue = ReadByte(soraItemSlotAmount)
		--ConsolePrint("Sora Item Slots Stored")
		itemValue = soraItemSlotValue + 1
		changeItemText = true
		update = true
		boostedAmount = true
	end
	if lastMenuPosition == 2 and lastMenuType >= 2 and ReadByte(currentMenuType) == 0 then
		--ConsolePrint("exited Item menu")
		update = true
		itemValue = soraItemSlotValue
		changeItemText = false
		boostedAmount = false
		
		--ConsolePrint(lastItemTypeSelected)
		--ConsolePrint(spiritItemId)
		if lastItemTypeSelected == spiritItemId then
		--	ConsolePrint("Start Spirit Timer")
			spiritCheckTimer = 10
		end
		
		
		
	end
	if lastPauseType == 0 and ReadByte(inMenu) == 1 and boostedAmount == true then
		--ConsolePrint("Entered Pause Menu")
		update = true
		itemValue = soraItemSlotValue
		changeItemText = false
	end
	if lastPauseType == 1 and ReadByte(inMenu) == 0 and boostedAmount == true then
		--ConsolePrint("Exited Pause Menu")
		itemValue = soraItemSlotValue + 1
		update = true
		changeItemText = true
	end
	
	if ReadByte(itemSlot1) == spiritItemId then
		itemValue = soraItemSlotValue
	end
	if update == true then
		if itemValue > 0 then
			--ConsolePrint("updating items")
			WriteByte(soraItemSlotAmount, itemValue)
		end
	end
	if boostedAmount == false and ReadByte(soraItemSlotAmount) > 6 then
		WriteByte(soraItemSlotAmount, 6)
	end
end



function draw_spirit_bar()
	WriteLong(hpmpStart+0x00, 0x0000014E00000146)
	WriteLong(hpmpStart+0x08, 0x0000003900000075) -- Bar Height and length
	WriteLong(hpmpStart+0x10, 0x0000001700000008)
	WriteLong(hpmpStart+0x18, 0x0000003F00000007)
	WriteLong(hpmpStart+0x20, 0x0000000000000000)
	WriteLong(hpmpStart+0x28, 0x0000008000000000)
		
	WriteLong(fillStart+0x10, 0x0000001700000008)
	WriteLong(fillStart+0x18, 0x0000003c00000007)
	
	if currentLink ~= 2 then
		WriteShort(fillStart+0x28, 0x0020)
	end
	WriteShort(fillStart+0x2A, 0x0000)
	
	if currentLink == 0 then -- No link
		if spiritValue >= spiritNeeded then -- Sora link
			WriteLong(fillStart+0x20, 0x000000A0000000D0)
		else
			WriteLong(fillStart+0x20, 0x0000007000000090)
		end
	elseif currentLink == 1 then -- Sora link
		WriteLong(fillStart+0x20, 0x00000050000000F0)
	
	elseif currentLink == 2 then-- Goofy Link
		WriteLong(fillStart+0x20, 0x0000007000000000)
		WriteShort(fillStart+0x28, 0x00FF)
		
	elseif currentLink == 3 then -- Donald Link
		WriteLong(fillStart+0x20, 0x000000F000000000)
		
	end
end

function draw_darkness_bar()
	WriteLong(hpmpStart+0x00, 0x0000014E00000146)
	WriteLong(hpmpStart+0x08, 0x0000003900000075) -- Bar Height and length
	WriteLong(hpmpStart+0x10, 0x0000001700000008)
	WriteLong(hpmpStart+0x18, 0x0000003F00000007)
	WriteLong(hpmpStart+0x20, 0x0000000000000000)
	WriteLong(hpmpStart+0x28, 0x0000008000000000)
		
	WriteLong(fillStart+0x10, 0x0000001700000008)
	WriteLong(fillStart+0x18, 0x0000003c00000007)
	
	if currentLink ~= 2 then
		WriteShort(fillStart+0x28, 0x0020)
	end
	WriteShort(fillStart+0x2A, 0x0000)
	
	if currentLink == 0 then -- DLv. 0
		WriteLong(fillStart+0x20, 0x0000005000000030) -- Green, Red
		WriteByte(fillStart+0x28, 0xFF) -- Blue
	elseif currentLink == 1 then -- DLv. 1
		WriteLong(fillStart+0x20, 0x0000003000000040) -- Green, Red
		WriteByte(fillStart+0x28, 0xFF) -- Blue
	
	elseif currentLink == 2 then-- DLv. 2
		WriteLong(fillStart+0x20, 0x0000002000000060) -- Green, Red
		WriteByte(fillStart+0x28, 0xFF) -- Blue
		
	elseif currentLink == 3 then -- DLv. 3
		WriteLong(fillStart+0x20, 0x00000020000000B0) -- Green, Red
		WriteByte(fillStart+0x28, 0xFF) -- Blue
		
	end
end


function apply_bar_fill()
	local fillAmount = 0x0000014F000001BA - spiritValue
	local fillAmount2 = 0x0000003000000000 + spiritValue
	
	WriteLong(fillStart+0x00, fillAmount) -- Increase to reduce bar
	WriteLong(fillStart+0x08, fillAmount2) -- Decrease to reduce bar
end


