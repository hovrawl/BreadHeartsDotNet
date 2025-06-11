LUAGUI_NAME = "CMix_RewardReplacement"
LUAGUI_AUTH = "Xendra"
LUAGUI_DESC = "Changes rewards"


local offset = 0x3A0606
local btltbl = 0x2D1F3C0 - offset
local rewardTable = btltbl+0xC6A8
local hollowBastionStatus = 0x2DE78C8 - offset
local randoEnabledGummi = 0x2DF18DA - offset -- Unused Gummi 3

function _OnInit()
	if GAME_ID == 0xAF71841E and ENGINE_TYPE == "BACKEND" then
		canExecute = true
		ConsolePrint("CMix_RewardReplacement Installed")
	else
		ConsolePrint("CMix_RewardReplacement -- FAILED --")
	end
end



function _OnFrame()
	if not canExecute then
		goto done
	end
	
	if ReadByte(randoEnabledGummi) == 0 then
		default_reward_replacements()
	end
	keep_wooden_sword()
	
	::done::
end


function keep_wooden_sword()
	if ReadByte(hollowBastionStatus) >= 3 then
		WriteByte(0x2DE5EBE - offset, 1)
	end


end

-- NOTES --





-- Black hole is currently in dalmatians, maybe move


--Stun blitz in wonderland thunder flower 1
-- Hurricane blast in neverland
-- Mushu in deep jungle
-- Chain Attack in Tent
-- Sonic Blade moved to pegasus cup solo, Streak given by Cloud
-- Merlin Dream Rod is now sora instead of donald
-- Impulse is in green room
-- Onslaught is olympus blue trinity
-- Simba is pegasus cup time trial


function default_reward_replacements()



-- Custom Reward Additions
WriteShort(rewardTable+14, 0x1101) -- 07 Impulse (Sora) ; Olympus Gates
WriteShort(rewardTable+16, 0xB501) -- 08 Onslaught (Sora) ; TT Green Room
WriteShort(rewardTable+18, 0x3901) -- 09 Stun Blitz (Sora) ; Wonderland Thunder Flower
WriteShort(rewardTable+20, 0xC3F0) -- 0A Memory
WriteShort(rewardTable+22, 0xB201) -- 0B Chain Attack(Sora); Deep Jungle ; Tent
WriteShort(rewardTable+24, 0x3701) -- 0C Hurricane Blast (Sora); Neverland ; ?
WriteShort(rewardTable+26, 0xBB01) -- 0D Zantetsu Prime ; Rising Falls ; White Trinity
WriteShort(rewardTable+10, 0xAE01) -- 05 Overload(Sora) ; Agrabah ; Treasure Room

-- Modified Reward Table
WriteShort(rewardTable+0, 0x05F0) -- 00 Phoenix Down; Defeat Leon
WriteShort(rewardTable+2, 0x3801) -- 01 Ripple Slide (Sora) ; End of TT
WriteShort(rewardTable+4, 0x06F0) -- 02 Mega-Potion ; Aerith TT ; Missable



WriteShort(rewardTable+30, 0x03B1) -- 0F Glide ; Neverland ; Green Trinity
WriteShort(rewardTable+32, 0x35F0) -- 10 Holy Circlet ; Chernabog ; EotW ; HB1 ; HB2
WriteShort(rewardTable+34, 0x4AF0) -- 11 Dragon Fang ; Dragon Maleficent ; HB1
WriteShort(rewardTable+36, 0x1201) -- 12 Aerial Rush (Sora) ; Secret Waterway
WriteShort(rewardTable+38, 0x56F0) -- 13 Jungle King ; Deep Jungle ; Slides
WriteShort(rewardTable+40, 0x57F0) -- 14 Three Wishes ; Agrabah
WriteShort(rewardTable+42, 0x58F0) -- 15 Fairy Harp ; Neverland ; Green Trinity
WriteShort(rewardTable+44, 0x59F0) -- 16 Pumpkinhead ; Halloween Town ; Jack-In-The-Box
WriteShort(rewardTable+46, 0x5AF0) -- 17 Crabclaw ; Atlantica ; Mermaid Kick
WriteShort(rewardTable+48, 0x5BF0) -- 18 Divine Rose ; Belle in HB2 ; HB1 ; HB2
WriteShort(rewardTable+50, 0x5EF0) -- 19 Lionheart ; Leon & Cloud Hades Cup ; HB1 ; Entry Pass
WriteShort(rewardTable+52, 0x5FF0) -- 1A Metal Chocobo ; Cloud Hercules Cup ; Entry Pass
WriteShort(rewardTable+54, 0x60F0) -- 1B Oathkeeper ; Kairi TT4 ; HB1
WriteShort(rewardTable+56, 0x7FF0) -- 1C Genji Shield ; Yuffie Hades Cup ; Entry Pass
WriteShort(rewardTable+58, 0x80F0) -- 1D Herc's Shield ; Hercules Cup ; Entry Pass
WriteShort(rewardTable+60, 0xB601) -- 1E Streak (Sora) ; Olympus Coliseum ; Entry Pass
WriteShort(rewardTable+62, 0x36F0) -- 1F Raven's Claw ; Anti-Sora ; Green Trinity
WriteShort(rewardTable+64, 0x0D01) -- 20 Strike Raid ; Pegasus Cup ; Entry Pass
WriteShort(rewardTable+66, 0x0E01) -- 21 Ragnarok ; Riku 2 ; HB1
WriteShort(rewardTable+68, 0x0F01) -- 22 Trinity Limit ; Hades Cup ; HB1 ; Entry Pass
WriteShort(rewardTable+70, 0x0C01) -- 23 Ars Arcanum ; Capt. Hook ; Green Trinity
WriteShort(rewardTable+72, 0x1011) -- 24 Cheer (Donald) ; Maleficent ; HB1
WriteShort(rewardTable+74, 0x9301) -- 25 Critical Counter (Sora); Parasite Cage; High Jump OR Glide
WriteShort(rewardTable+76, 0x6FF0) -- 26 Lord Fortune ; Fairy Godmother ; All Summons ; Fire Magic
WriteShort(rewardTable+78, 0x01B1) -- 27 High Jump ; Chest ; -
WriteShort(rewardTable+80, 0xCEF0) -- 28 Watergleam ; Chest ; -
WriteShort(rewardTable+82, 0xFEF0) -- 29 Mythril ; Chest ; -
WriteShort(rewardTable+84, 0xCFF0) -- 2A Naturespark ; Hundred Acre Wood ; Page1
WriteShort(rewardTable+86, 0xFDF0) -- 2B Mythril Shard ; Hundred Acre Wood ; Page2
WriteShort(rewardTable+88, 0xFEF0) -- 2C Mythril ; Hundred Acre Wood ; Page4
WriteShort(rewardTable+90, 0x3AF0) -- 2D EXP Ring ; Hundred Acre Wood ; Page5
WriteShort(rewardTable+92, 0x05F0) -- 2E Phoenix Down; From Owl ; Page5
WriteShort(rewardTable+94, 0x53F0) -- 2F Dream Shield (SORA) ; Merlin ; Arts ; All Spells
WriteShort(rewardTable+96, 0x5DF0) -- 30 Olympia ; Olympus Coliseum ; Entry Pass
WriteShort(rewardTable+98, 0x61F0) -- 31 Oblivion ; Chest ; -
WriteShort(rewardTable+100, 0xFEF0) -- 32 Mythril ; Chest ; -
WriteShort(rewardTable+102, 0x63F0) -- 33 Wishing Star ; Chest ; -
WriteShort(rewardTable+104, 0x3A01) -- 34 Gravity Break(Sora) ; Dalmatians' House ; 42 Puppies
WriteShort(rewardTable+106, 0x05F0) -- 35 Phoenix Down; Dalmatians' House ; 60 Puppies
WriteShort(rewardTable+108, 0xFFF0) -- 36 Orichalcum ; Dalmatians' House ; 72 Puppies
WriteShort(rewardTable+110, 0x37F0) -- 37 Omega Arts; Dalmatians' House ; 90 Puppies
WriteShort(rewardTable+112, 0x30F0) -- 38 Brave Warrior ; Guard Armor
WriteShort(rewardTable+114, 0x62F0) -- 39 Lady Luck ; Trickmaster ; Evidence
WriteShort(rewardTable+116, 0x32F0) -- 3A Triple Bite ; Cerberus ; Entry Pass
WriteShort(rewardTable+118, 0x33F0) -- 3B White Fang ; Sabor 2 ; Slides
WriteShort(rewardTable+120, 0x0801) -- 3C Critical Plus (Sora) ; Pot Centipede
WriteShort(rewardTable+122, 0x9401) -- 3D Cleave (Sora) ; Oogie Boogie ; Jack-In-The-Box
WriteShort(rewardTable+124, 0x37F0) -- 3E Omega Arts ; Behemoth ; HB1 ; HB2
WriteShort(rewardTable+126, 0x04F0) -- 3F Elixir ; Chest ; -
WriteShort(rewardTable+128, 0x04F0) -- 40 Elixir ; Chest ; -
WriteShort(rewardTable+130, 0xFEF0) -- 41 Mythril ; Chest ; -
WriteShort(rewardTable+132, 0xFFF0) -- 42 Orichalcum ; Chest ; -
WriteShort(rewardTable+134, 0x8FF0) -- 43 Camping Set ; Chest ; -
WriteShort(rewardTable+136, 0x06F0) -- 44 Mega-Potion ; Chest ; -
WriteShort(rewardTable+138, 0x08F0) -- 45 Phoenix Down; Chest ; -
WriteShort(rewardTable+140, 0xFDF0) -- 46 Mythril Shard ; Chest ; -
WriteShort(rewardTable+142, 0xFFF0) -- 47 Orichalcum ; Chest ; -
WriteShort(rewardTable+144, 0x62F0) -- 48 Lady Luck ; Chest ; -
WriteShort(rewardTable+146, 0x06F0) -- 49 Mega-Potion ; Chest ; -
WriteShort(rewardTable+148, 0x11F0) -- 4A Protect Chain ; Chest ; -
WriteShort(rewardTable+150, 0xFFF0) -- 4B Orichalcum ; Chest ; -
WriteShort(rewardTable+152, 0xFDF0) -- 4C Mythril Shard ; Chest ; -
WriteShort(rewardTable+154, 0xFEF0) -- 4D Mythril ; Chest ; -
WriteShort(rewardTable+156, 0x90F0) -- 4E Cottage ; Chest ; -
WriteShort(rewardTable+158, 0x14F0) -- 4F Fire Ring ; Chest ; -
WriteShort(rewardTable+160, 0xFEF0) -- 50 Mythril ; Chest ; -
WriteShort(rewardTable+162, 0x9AF0) -- 51 Cottage ; Chest ; -
WriteShort(rewardTable+164, 0x04F0) -- 52 Elixir ; Chest ; -
WriteShort(rewardTable+166, 0x06F0) -- 53 Mega-Potion ; Chest ; -
WriteShort(rewardTable+168, 0x12F0) -- 54 Protera Chain ; Chest ; -
WriteShort(rewardTable+170, 0xFDF0) -- 55 Mythril Shard ; Chest ; -
WriteShort(rewardTable+172, 0x70F0) -- 56 Violetta ; Chest ; -
WriteShort(rewardTable+174, 0xFDF0) -- 57 Mythril Shard ; Chest ; -
WriteShort(rewardTable+176, 0x04F0) -- 58 Elixir ; Chest ; -
WriteShort(rewardTable+178, 0xFFF0) -- 59 Orichalcum ; Chest ; -
WriteShort(rewardTable+180, 0x1BF0) -- 5A Thundara Ring ; Chest ; -
WriteShort(rewardTable+182, 0x08F0) -- 5B Megalixir ; Chest ; -
WriteShort(rewardTable+184, 0x5CF0) -- 5C Spellbinder ; Merlin ; All Spells
WriteShort(rewardTable+186, 0x54F0) -- 5D Dream Rod (SORA) ; Merlin ; Max Spells
WriteShort(rewardTable+188, 0x0601) -- 5E Combo Plus (Sora); Phil Cup Solo ; Entry Pass
WriteShort(rewardTable+190, 0x0B01) -- 5F Sonic Blade (Sora) ; Pegasus Cup Solo ; Entry Pass
WriteShort(rewardTable+192, 0x0801) -- 60 Critical Plus (Sora) ; Hercules Cup Solo ; Entry Pass
WriteShort(rewardTable+194, 0x72F0) -- 61 Save the Queen ; Hades Cup Solo ; HB1 ; Entry Pass
WriteShort(rewardTable+196, 0x8521) -- 62 Treasure Magnet(Goofy); Phil Cup Time Trial ; Entry Pass
WriteShort(rewardTable+198, 0xD1F0) -- 63 Earthshine ; Pegasus Cup Time Trial ; Entry Pass
WriteShort(rewardTable+200, 0x49F0) -- 64 Olympus Medal
WriteShort(rewardTable+202, 0x82F0) -- 65 Save the King ; Hades Cup Time Trial ; HB1 ; Entry Pass
WriteShort(rewardTable+204, 0x11F0) -- 66 Protect Chain ; Chest ; -
WriteShort(rewardTable+206, 0x04F0) -- 67 Elixir ; Postcard 1 ; Postcard 1
WriteShort(rewardTable+208, 0xC3F0) -- 68 Memory ; Postcard 2 ; Postcard 2
WriteShort(rewardTable+210, 0x14F0) -- 69 Fire Ring ; Postcard 3 ; Postcard 3
WriteShort(rewardTable+212, 0x34F0) -- 6A Ray of Light ; Postcard 4 ; Postcard 4
WriteShort(rewardTable+214, 0xF2F0) -- 6B Mythril ; Postcard 5 ; Postcard 5
WriteShort(rewardTable+216, 0x08F0) -- 6C Megalixir ; Postcard 6 ; Postcard 6
WriteShort(rewardTable+218, 0x05F0) -- 6D Phoenix Down; Postcard 7 ; Postcard 7
WriteShort(rewardTable+220, 0xFFF0) -- 6E Orichalcum ; Postcard 8 ; Postcard 8
WriteShort(rewardTable+222, 0x05F0) -- 6F Phoenix Down ; Postcard 9 ; Postcard 9
WriteShort(rewardTable+224, 0x9CF0) -- 70 Dark Matter ; Postcard 10 ; Postcard 10
WriteShort(rewardTable+226, 0xFEF0) -- 71 Mythril ; Dalmatians' House ; 51 Puppies
WriteShort(rewardTable+228, 0x06F0) -- 72 Mega-Potion ; Chest ; -
WriteShort(rewardTable+230, 0xFDF0) -- 73 Mythril Shard ; Chest ; -
WriteShort(rewardTable+232, 0x04F0) -- 74 Elixir ; Chest ; -
WriteShort(rewardTable+234, 0xFEF0) -- 75 Mythril ; Chest ; -
WriteShort(rewardTable+236, 0x12F0) -- 76 Protera Chain ; Chest ; -
WriteShort(rewardTable+238, 0x1AF0) -- 77 Thunder Ring ; Chest ; -
WriteShort(rewardTable+240, 0x12F0) -- 78 Protera Chain ; Chest ; -
WriteShort(rewardTable+242, 0x18F0) -- 79 Blizzara Ring ; Chest ; -
WriteShort(rewardTable+244, 0x15F0) -- 7A Fira Ring ; Chest ; -
WriteShort(rewardTable+246, 0xFDF0) -- 7B Mythril Shard ; Chest ; -
WriteShort(rewardTable+248, 0x4EF0) -- 7C Paopu Fruit ; Final Dimension ; EotW
WriteShort(rewardTable+250, 0x06F0) -- 7D Mega-Potion ; Final Dimension ; EotW
WriteShort(rewardTable+252, 0xFEF0) -- 7E Mythril ; Final Dimension ; EotW


WriteShort(rewardTable+258, 0xFFF0) -- 81 Orichalcum ; Final Dimension ; EotW

WriteShort(rewardTable+262, 0xFCF0) -- 83 Gale ; Final Dimension ; EotW
WriteShort(rewardTable+264, 0x05F0) -- 84 Phoenix Down ; Final Dimension ; EotW


WriteShort(rewardTable+270, 0xEDF0) -- 87 Spirit Gem ; Chest ; -
WriteShort(rewardTable+272, 0xF6F0) -- 88 Thunder Gem ; Chest ; -
WriteShort(rewardTable+274, 0xF4F0) -- 89 Frost Gem ; Chest ; -
WriteShort(rewardTable+276, 0xF9F0) -- 8A Bright Gem ; Chest ; -
WriteShort(rewardTable+278, 0xF2F0) -- 8B Blaze Gem ; Chest ; -
WriteShort(rewardTable+280, 0xEAF0) -- 8C Lucid Gem ; Chest ; -
WriteShort(rewardTable+282, 0x84F0) -- 8D Mighty Shield ; Chest ; -
WriteShort(rewardTable+284, 0x04F0) -- 8E Elixir ; Chest ; -
WriteShort(rewardTable+286, 0x04F0) -- 8F Elixir ; Jungle Slider ; Slides
WriteShort(rewardTable+288, 0xFBF0) -- 90 Mystery Goo; Jungle Slider ; Slides
WriteShort(rewardTable+290, 0x9CF0) -- 91 Dark Matter ; Jungle Slider ; Slides
WriteShort(rewardTable+292, 0x0EF0) -- 92 Lightning Stone ; Jungle Slider ; Slides
WriteShort(rewardTable+294, 0xA6F0) -- 93 Matsutake ; Jungle Slider ; Slides
WriteShort(rewardTable+296, 0x65F0) -- 94 Diamond Dust ; Ice Titan ; Entry Pass
WriteShort(rewardTable+298, 0x66F0) -- 95 One-Winged Angel ; Sephiroth ; HB1 ; HB2 ; EotW ; Entry Pass
WriteShort(rewardTable+300, 0x48F0) -- 96 Ancient Ring; Kurt Zisa ; HB1 ; HB2 ; EotW
WriteShort(rewardTable+302, 0x3CF0) -- 97 EXP Necklace ; Unknown ; HB1 ; HB2 ; EotW

WriteShort(rewardTable+306, 0x9CF0) -- 99 Dark Matter ; Chest ; -
WriteShort(rewardTable+308, 0x41F0) -- 9A Shiva Belt ; Chest ; -
WriteShort(rewardTable+310, 0x9CF0) -- 9B Dark Matter ; Chest ; -
WriteShort(rewardTable+312, 0x9CF0) -- 9C Dark Matter ; Chest ; -
WriteShort(rewardTable+314, 0x40F0) -- 9D Ifrit Belt ; Chest ; -
WriteShort(rewardTable+316, 0x9CF0) -- 9E Dark Matter ; Chest ; -
WriteShort(rewardTable+318, 0xFFF0) -- 9F Orichalcum ; Chest ; -
WriteShort(rewardTable+320, 0x9CF0) -- A0 Dark Matter ; Chest ; -
WriteShort(rewardTable+322, 0x9CF0) -- A1 Dark Matter ; Chest ; -
WriteShort(rewardTable+324, 0xFFF0) -- A2 Orichalcum ; Chest ; -
WriteShort(rewardTable+326, 0x42F0) -- A3 Ramuh Belt ; Chest ; -
WriteShort(rewardTable+328, 0x45F0) -- A4 Royal Crown ; Chest ; -
WriteShort(rewardTable+330, 0x9CF0) -- A5 Dark Matter ; Chest ; -
WriteShort(rewardTable+332, 0x9CF0) -- A6 Dark Matter ; Chest ; -
WriteShort(rewardTable+334, 0x9CF0) -- A7 Dark Matter ; Chest ; -
WriteShort(rewardTable+336, 0x74F0) -- A8 Meteor Strike ; Chest ; -
end