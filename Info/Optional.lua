LUAGUI_NAME = "Optional"
LUAGUI_AUTH = "KSX"
LUAGUI_DESC = "Optional"

QuickOverworldWarpSetting = true
-- L2+R2+L3+R3 to Warp Overworld Map

UpdatedMagicSetting = true
-- Magic and Upgrade are equal

EncounterPlusMushroomSetting = true
-- EncounterPlus 100% White Mushroom

EXPZeroSetting = false
-- EXP Zero on any Difficult

StartWithBonusItemsSettings = false
-- Start the Game with Brave Warrior, EXP Necklace, 8x Power Up, 8x Defense Up, 4x AP Up on Any Difficult

StartWithSharedAbiltiesSetting = true
Slot1ID = 0x00
Slot2ID = 0x00
Slot3ID = 0x00
Slot4ID = 0x00
Slot5ID = 0x00
Slot6ID = 0x00
Slot7ID = 0x00
Slot8ID = 0x00
Slot9ID = 0x00
Slot10ID = 0x00
Slot11ID = 0x00
Slot12ID = 0x00
-- 0x81 High Jump
-- 0x82 Mermaid Kick
-- 0x83 Glide
-- 0x84 Superglide
-- 0x00 Nothing
-- Start the Game with High-Jump, Glide, Paraglide, Mermaidkick

InstantDeathSetting = false
-- Sora dies by every Hit (No matter if 255 HP or 1 HP, abilities can keep save)

NoOverworldTutorialMessagesSetting = true
-- No Chip and Dale Messages

InstantCollectItemsSetting = true
-- Collect Enemy Drops Instant

OpenChestSetting = false
-- Open Chests (In Battle / Outside Battle)

ActivateTrinitySetting = false
-- Activate Trinity (In Battle/ Outside Battle)

ExamineSetting = false
-- Examine (In Battle/ Outside Battle)

TalkingSetting = false
-- Talk to NPC (In Battle/ Outside Battle)

OpenMenuInBattleSetting = false
-- Allow to Open the Pause Menu in Battle

local offset = 0x3A0606
local canExecute = false
local worldid = 0x233CADC - offset
local roomid = 0x233CB44 - offset
local eventid = 0x233CB48 - offset
local gamestate = 0x233C240 - offset
local warp = 0x22E86DC - offset
local warprequirement1 = 0x22E86E0 - offset
local warprequirement2 = 0x233C240 - offset
local lastusedoverworldmap = 0x233CB68 - offset
local buttonpress = 0x233D034 - offset
local shoulderpress = 0x233D035 - offset
local Fire = 0x2DE5E62 - offset
local Blizzard = 0x2DE5E63 - offset
local Thunder = 0x2DE5E64 - offset
local Cure = 0x2DE5E65 - offset
local Gravity = 0x2DE5E66 - offset
local Stop = 0x2DE5E67 - offset
local Aero = 0x2DE5E68 - offset
local FireSlot = 0x2D1F200 - offset
local BlizzardSlot = 0x2D1F238 - offset
local ThunderSlot = 0x2D1F270 - offset
local CureSlot = 0x2D1F2A8 - offset
local GravitySlot = 0x2D1F2E0 - offset
local StopSlot = 0x2D1F318 - offset
local AeroSlot = 0x2D1F350 - offset
local SoraHUD = 0x280EB1C - offset
local itemcollect1 = 0x2A7ACA - offset
local itemcollect2 = 0x2BC10F - offset
local itemcollect3 = 0x2A7A1D - offset
local chestopenrequirement = 0x2B12C4 - offset
local trinityrequirement = 0x1A06CF - offset
local examinerequirement = 0x2903B9 - offset
local talkrequirement = 0x2903F9 - offset
local openmenuinbattle = 0x17A81A - offset
local overworldmessagesflag = 0x2DE78E9 - offset
local instantdeath = 0x232A3CB - offset
local bonusitems = 0x1AEEDA - offset
local expzero = 0x3070C4 - offset
local sharedabilityslot1 = 0x2DE5F69 - offset
-----------------------------------------------------------------------------------------------
-----------------------------------------------------------------------------------------------
function _OnInit()
	if GAME_ID == 0xAF71841E and ENGINE_TYPE == "BACKEND" then
		ConsolePrint("Optional Randomizer Settings - installed")
		canExecute = true
	else
		ConsolePrint("Optional Randomizer Settings - failed")
	end
end
-----------------------------------------------------------------------------------------------
-----------------------------------------------------------------------------------------------
function _OnFrame()
if canExecute == true then

if EncounterPlusMushroomSetting == true then
EncounterPlusMushroom()
end

if UpdatedMagicSetting == true then
MagicSpellsequaltoUpgrade()
end

if InstantCollectItemsSetting == true then
InstantCollectItems()
end

if OpenChestSetting == true then
OpenChest()
end

if ActivateTrinitySetting == true then
ActivateTrinity()
end

if ExamineSetting == true then
Examine()
end

if TalkingSetting == true then
Talking()
end

if OpenMenuInBattleSetting == true then
OpenMenuInBattle()
end

if NoOverworldTutorialMessagesSetting == true then
NoOverworldTutorialMessages()
end

if QuickOverworldWarpSetting == true then
QuickOverworldWarp()
end

if InstantDeathSetting == true then
InstantDeath()
end

if StartWithBonusItemsSettings == true then
StartWithBonusItems()
end

if EXPZeroSetting == true then
EXPZero()
end

if StartWithSharedAbiltiesSetting == true then
StartWithSharedAbilties()
end

end
end

function EncounterPlusMushroom()
	for encounterplusmushroom = 0x2DE5A14 - offset, 0x2DE5A43 - offset do
		if ReadByte(encounterplusmushroom) == 0x3D then
			if ReadByte(worldid) == 3 and ReadByte(roomid) == 6 then
				WriteByte(eventid, 19)
			elseif ReadByte(worldid) == 5 and ReadByte(roomid) == 12 then
				WriteByte(eventid, 19)
			elseif ReadByte(worldid) == 5 and ReadByte(roomid) == 0 then
				WriteByte(eventid, 19)
			elseif ReadByte(worldid) == 4 and ReadByte(roomid) == 13 then
				WriteByte(eventid, 19)
			elseif ReadByte(worldid) == 8 and ReadByte(roomid) == 35 then
				WriteByte(eventid, 19)
			elseif ReadByte(worldid) == 9 and ReadByte(roomid) == 4 then
				WriteByte(eventid, 19)
			elseif ReadByte(worldid) == 10 and ReadByte(roomid) == 2 then
				WriteByte(eventid, 24)
			elseif ReadByte(worldid) == 16 and ReadByte(roomid) == 28 then
				WriteByte(eventid, 16)
			end
	end
end
end

function MagicSpellsequaltoUpgrade()
	if ReadFloat(SoraHUD) == 1 then
		
		if ReadByte(Fire) > 0 then
			WriteByte(FireSlot, ReadByte(Fire))
		end
	
		if ReadByte(Blizzard) > 0 then
		WriteByte(BlizzardSlot, ReadByte(Blizzard))
		end
	
		if ReadByte(Thunder) > 0 then
		WriteByte(ThunderSlot, ReadByte(Thunder))
		end
	
		if ReadByte(Cure) > 0 then
		WriteByte(CureSlot, ReadByte(Cure))
		end
	
		if ReadByte(Gravity) > 0 then
		WriteByte(GravitySlot, ReadByte(Gravity))
		end

		if ReadByte(Stop) > 0 then
		WriteByte(StopSlot, ReadByte(Stop))
		end

		if ReadByte(Aero) > 0 then
		WriteByte(AeroSlot, ReadByte(Aero))
		end
	end
end

function InstantCollectItems()
WriteByte(itemcollect1, 0x75)
WriteByte(itemcollect2, 0x72)
WriteByte(itemcollect3, 0x86)
end

function OpenChest()
WriteByte(chestopenrequirement, 0x73)
end

function ActivateTrinity()
WriteByte(trinityrequirement, 0x71)
end

function Examine()
WriteByte(examinerequirement, 0x70)
end

function Talking()
WriteByte(talkrequirement, 0x70)
end

function OpenMenuInBattle()
WriteByte(openmenuinbattle, 0)
end

function NoOverworldTutorialMessages()
if ReadByte(gamestate) == 7 then -- Player is Overworld
WriteByte(overworldmessagesflag, 0xB1)
end
end

function QuickOverworldWarp()
if ReadByte(buttonpress) == 0x06 and ReadByte(shoulderpress) == 0x03 then
WriteByte(warp, 10)
WriteByte(lastusedoverworldmap, ReadByte(worldid))
if ReadByte(warp) == 10 then
WriteByte(warprequirement1, 6)
WriteByte(warprequirement2, 7)
end
end
end

function InstantDeath()
WriteByte(instantdeath, 1)
end

function StartWithBonusItems()
WriteByte(bonusitems, 0x82)
end

function EXPZero()
WriteByte(expzero, 0x7D)
end

function StartWithSharedAbilties()
if ReadByte(sharedabilityslot1) == 0 then
WriteByte(sharedabilityslot1, Slot1ID)
WriteByte(sharedabilityslot1+0x01, Slot2ID)
WriteByte(sharedabilityslot1+0x02, Slot3ID)
WriteByte(sharedabilityslot1+0x03, Slot4ID)
WriteByte(sharedabilityslot1+0x04, Slot5ID)
WriteByte(sharedabilityslot1+0x05, Slot6ID)
WriteByte(sharedabilityslot1+0x06, Slot7ID)
WriteByte(sharedabilityslot1+0x07, Slot8ID)
WriteByte(sharedabilityslot1+0x08, Slot9ID)
WriteByte(sharedabilityslot1+0x09, Slot10ID)
WriteByte(sharedabilityslot1+0x0A, Slot11ID)
WriteByte(sharedabilityslot1+0x0B, Slot12ID)
end
end