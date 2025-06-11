LUAGUI_NAME = "CMix_ChestReplacement"
LUAGUI_AUTH = "Xendra"
LUAGUI_DESC = "Changes the contents of Treasure Chests"


local offset = 0x3A0606
local chestTable = 0x5259E0 - offset
local randoEnabledGummi = 0x2DF18DA - offset -- Unused Gummi 3


function _OnInit()
	if GAME_ID == 0xAF71841E and ENGINE_TYPE == "BACKEND" then
		canExecute = true
		ConsolePrint("CMix_ChestReplacement Installed")
	else
		ConsolePrint("CMix_ChestReplacement -- FAILED --")
	end
end



function _OnFrame()
	if not canExecute then
		goto done
	end
	
	if ReadByte(randoEnabledGummi) == 0 then
		default_chest_replacement()
	end
	
	::done::
end


-- oblivion moved to postcard blue trinity
-- that postcard moved to the 1000 munny chest


function default_chest_replacement()
	WriteShort(chestTable+040, 0x09F0) --Blizzard Arts -- 14 Reward 3f ; 1st District ; Blizzard Magic
	WriteShort(chestTable+042, 0x0D30) --Postcard -- 15 Postcard ; 1st District
	WriteShort(chestTable+044, 0x0D30) --Postcard -- 16 Postcard ; 2nd District
	WriteShort(chestTable+046, 0x0FD0) --Mythril Shard -- 17 Mythril Shard ; 2nd District
	WriteShort(chestTable+048, 0x00A0) --Power Stone -- 18 Mega-Potion ; 2nd District
	WriteShort(chestTable+050, 0x0FE0) --Mythril -- 19 Potion ; Alleyway
	WriteShort(chestTable+052, 0x0D30) --Postcard -- 1a Pretty Stone ; Alleyway
	WriteShort(chestTable+054, 0x009E) -- Stun Blitz -- 1b Potion ; Alleyway
	WriteShort(chestTable+058, 0x0FE0) -- -- 1d Mythril ; Green Room
	WriteShort(chestTable+060, 0x007E) --Sora: Impulse -- 1e Reward 40 ; Green Room
	WriteShort(chestTable+062, 0x09E0) --Fire Arts -- 1f Pretty Stone ; Red Room
	WriteShort(chestTable+064, 0x041E) -- -- 20 Reward 41 ; Mystical House ; Fire Magic ; High Jump OR Yellow Trinity
	WriteShort(chestTable+066, 0x0110) --Protect Ring -- 21 Mythril Shard ; Accessory Shop
	WriteShort(chestTable+068, 0x02F0) --Crystal Crown -- 22 Reward 42 ; Secret Waterway ; White Trinity
	WriteShort(chestTable+070, 0x033E) --Wishing Star -- 23 Reward 33 ; Gepetto's House ; High Jump OR Glide
	WriteShort(chestTable+080, 0x0610) --Oblivion -- 28 Postcard ; 1st District ; Blue Trinity OR Glide
	WriteShort(chestTable+176, 0x0014) --Dalmatians -- 58 Dalmatians 1 ; Mystical House ; Glide ; Fire Magic
	WriteShort(chestTable+178, 0x0024) --Dalmatians -- 59 Dalmatians 2 ; Alleyway ; Red Trinity
	WriteShort(chestTable+180, 0x0034) --Dalmatians -- 5a Dalmatians 3 ; Item Workshop ; Green Trinity
	WriteShort(chestTable+182, 0x0044) --Dalmatians -- 5b Dalmatians 4 ; Secret Waterway
	WriteShort(chestTable+184, 0x0050) --Phoenix Down -- 5c Reward 74 ; Rabbit hole ; Green Trinity
	WriteShort(chestTable+186, 0x043E) -- -- 5d Reward 43 ; Rabbit hole
	WriteShort(chestTable+188, 0x044E) -- -- 5e Reward 44 ; Rabbit hole
	WriteShort(chestTable+190, 0x045E) -- -- 5f Reward 45 ; Rabbit hole
	WriteShort(chestTable+192, 0x0090) --Fury Stone -- 60 Reward 46 ; Bizarre Room ; Green Trinity
	WriteShort(chestTable+200, 0x02A0) --Magic Armlet -- 64 Thundara-G ; Queen's Castle
	WriteShort(chestTable+202, 0x0054) --Dalmatians -- 65 Dalmatians 5 ; Queen's Castle ; Evidence OR High Jump OR Glide
	WriteShort(chestTable+204, 0x0F40) --Frost Gem -- 66 Meteor-G ; Queen's Castle
	WriteShort(chestTable+206, 0x0C30) -- Memory -- 67 Thundara-G ; Lotus Forest ; Thunder Magic ; Evidence
	WriteShort(chestTable+208, 0x0144) --Dalmatians -- 68 Dalmatians 20 ; Lotus Forest ; Thunder Magic
	WriteShort(chestTable+210, 0x047E) -- -- 69 Reward 47 ; Lotus Forest ; Glide OR High Jump
	WriteShort(chestTable+212, 0x0064) --Dalmatians -- 6a Dalmatians 6 ; Lotus Forest
	WriteShort(chestTable+214, 0x0FB0) --Mystery Goo -- 6b Scan-G ; Lotus Forest
	WriteShort(chestTable+216, 0x0FA6) --2500 Munny -- 6c Defense Up ; Bizarre Room
	WriteShort(chestTable+220, 0x0C30) --Memory -- 6e Flare-G ; Tea Party Garden ; Glide OR High Jump ; Evidence OR Glide
	WriteShort(chestTable+222, 0x0074) --Dalmatians -- 6f Dalmatians 7 ; Tea Party Garden ; Glide OR High Jump ; Evidence OR Glide
	WriteShort(chestTable+224, 0x099E) -- -- 70 Reward 99 ; Tea Party Garden ; Evidence OR Glide
	WriteShort(chestTable+226, 0x032E) -- -- 71 Reward 32 ; Tea Party Garden ; Glide OR High Jumpra ; Evidence OR Glide
	WriteShort(chestTable+228, 0x09C0) --Dark Matter -- 72 Reward 48 ; Lotus Forest ; White Trinity
	WriteShort(chestTable+244, 0x09B0) --Serenity Power -- 7a Reward 49 ; Tree House
	WriteShort(chestTable+246, 0x0D00) --Fireglow -- 7b Reward 4a ; Tree House
	WriteShort(chestTable+248, 0x0094) --Dalmatians -- 7c Dalmatians 9 ; Hippos' Lagoon
	WriteShort(chestTable+250, 0x0EF0) --Power Gem -- 7d Mega-Potion ; Hippos' Lagoon
	WriteShort(chestTable+252, 0x0C30) --Memory -- 7e Meteor-G ; Hippos' Lagoon
	WriteShort(chestTable+256, 0x0FE0) -- -- 80 Mythril ; Jungle: Vines
	WriteShort(chestTable+258, 0x00A4) --Dalmatians -- 81 Dalmatians 10 ; Jungle: Vines 2
	WriteShort(chestTable+260, 0x0F60) --Thunder Gem -- 82 Thundara-G ; Climbing Trees ; Blue Trinity
	WriteShort(chestTable+264, 0x04E0) --Paopu Fruit -- 84 Mega-Ether ; Jungle: Tunnel
	WriteShort(chestTable+266, 0x0450) --Royal Crown -- 85 Reward 4b ; Cavern of Hearts ; White Trinity ; Slides
	WriteShort(chestTable+268, 0x00C4) --Dalmatians -- 86 Dalmatians 12 ; Camp ; Blue Trinity
	WriteShort(chestTable+270, 0x00BE) --Chain Attack (Sora) -- 87 Mythril Shard ; Camp: Tent
	WriteShort(chestTable+272, 0x00E0) --Lightning Stone -- 88 Mythril Shard ; Waterfall Cavern ; Slides
	WriteShort(chestTable+274, 0x00B4) --Dalmatians -- 89 Dalmatians 11 ; Waterfall Cavern ; Slides
	WriteShort(chestTable+276, 0x0FE0) -- -- 8a Mythril ; Waterfall Cavern ; Slides
	WriteShort(chestTable+278, 0x0FF0) -- -- 8b Orichalcum ; Waterfall Cavern ; Slides
	WriteShort(chestTable+280, 0x0240) --Power Chain -- 8c Reward 72 ; Jungle: Cliff
	WriteShort(chestTable+282, 0x073E) -- -- 8d Reward 73 ; Jungle: Cliff
	WriteShort(chestTable+284, 0x075E) -- -- 8e Reward 75 ; Tree House
	WriteShort(chestTable+334, 0x0FD0) --Mythril Shard -- a7 Mythril Shard ; Hundred Acre Woods
	WriteShort(chestTable+336, 0x04CE) -- -- a8 Reward 4c ; Hundred Acre Woods ; Page3
	WriteShort(chestTable+338, 0x09BE) -- -- a9 Reward 9b ; Hundred Acre Woods ; Page3
	WriteShort(chestTable+340, 0x04DE) -- -- aa Reward 4d ; Hundred Acre Woods ; Page3
	WriteShort(chestTable+394, 0x0FD0) --Mythril Shard -- c5 Mega-Potion ; Agrabah: Plaza
	WriteShort(chestTable+396, 0x09D0) --Mythril Stone -- c6 Mega-Ether ; Agrabah: Plaza
	WriteShort(chestTable+398, 0x01B0) --Thundara Ring -- c7 Reward 4e ; Agrabah: Plaza
	WriteShort(chestTable+400, 0x0FD0) --Mythril Shard -- c8 Mega-Potion ; Agrabah: Alley
	WriteShort(chestTable+402, 0x0FD0) --Mythril Shard -- c9 Thundara-G ; Agrabah: Bazaar
	WriteShort(chestTable+404, 0x0150) --Fira Ring -- ca Reward 4f ; Agrabah: Bazaar
	WriteShort(chestTable+406, 0x0FD0) --Mythril Shard -- cb Mega-Ether ; Agrabah: Main Street
	WriteShort(chestTable+408, 0x09CE) -- -- cc Reward 9c ; Agrabah: Main Street
	WriteShort(chestTable+410, 0x050E) -- -- cd Reward 50 ; Agrabah: Main Street ; High Jump OR Glide
	WriteShort(chestTable+412, 0x076E) -- -- ce Reward 76 ; Palace Gates
	WriteShort(chestTable+414, 0x0124) --Dalmatians -- cf Dalmatians 18 ; Palace Gates ; High Jump OR Glide
	WriteShort(chestTable+416, 0x09D0) --Mythril Stone -- d0 Osmose-G ; Palace Gates ; Glide
	WriteShort(chestTable+418, 0x051E) -- -- d1 Reward 51 ; Agrabah: Storage ; Green Trinity
	WriteShort(chestTable+420, 0x0FA6) --2500 Munny -- d2 Mega-Potion ; Agrabah: Storage
	WriteShort(chestTable+422, 0x0FD0) --Mythril Shard -- d3 Mega-Ether ; Cave: Entrance
	WriteShort(chestTable+424, 0x0114) --Dalmatians -- d4 Dalmatians 17 ; Cave: Entrance ; High Jump OR Glide
	WriteShort(chestTable+426, 0x0FE0) --Mythril -- d5 Elixir ; Cave: Hall
	WriteShort(chestTable+428, 0x0FD0) --Mythril Shard -- d6 Mythril Shard ; Cave: Hall
	WriteShort(chestTable+430, 0x0FD0) --Mythril Shard -- d7 Cottage ; Bottomless Hall
	WriteShort(chestTable+432, 0x0FB0) --Mystery Goo -- d8 Reward 52 ; Bottomless Hall
	WriteShort(chestTable+434, 0x053E) -- -- d9 Reward 53 ; Bottomless Hall
	WriteShort(chestTable+436, 0x00D4) --Dalmatians -- da Dalmatians 13 ; Treasure Room
	WriteShort(chestTable+438, 0x04D0) --Gold Ring -- db Mythril Shard ; Treasure Room
	WriteShort(chestTable+440, 0x005E) --Overload (Sora) -- dc Thundara-G ; Treasure Room
	WriteShort(chestTable+442, 0x0FA6) --2500 Munny -- dd Defense Up ; Treasure Room
	WriteShort(chestTable+444, 0x0FE0) -- -- de Mythril ; Relic Chamber
	WriteShort(chestTable+446, 0x0C30) --Memory -- df Reward 77 ; Relic Chamber
	WriteShort(chestTable+448, 0x0390) --Drain Brace -- e0 Reward 54 ; Dark Chamber
	WriteShort(chestTable+450, 0x0F10) --Blaze Shard -- e1 Meteor-G ; Dark Chamber
	WriteShort(chestTable+452, 0x0D60) --Torn Page -- e2 Torn Page 3 ; Dark Chamber
	WriteShort(chestTable+454, 0x0F20) --Blaze Gem -- e3 Cottage ; Dark Chamber
	WriteShort(chestTable+456, 0x09C0) --Dark Matter -- e4 Thundara-G ; Silent Chamber ; Blue Trinity
	WriteShort(chestTable+458, 0x09C0) --Dark Matter -- e5 Haste2-G ; Hidden Room ; Yellow Trinity OR High Jump
	WriteShort(chestTable+460, 0x0104) --Dalmatians -- e6 Dalmatians 16 ; Hidden Room ; Yellow Trinity OR High Jump
	WriteShort(chestTable+462, 0x01E0) --Haste Ring -- e7 Scissors-G ; Aladdin's House
	WriteShort(chestTable+464, 0x0080) -- -- e8 Megalixir ; Aladdin's House
	WriteShort(chestTable+466, 0x09DE) --Ifrit Belt -- e9 Reward 9d ; Cave: Entrance ; White Trinity
	WriteShort(chestTable+484, 0x0080) -- -- f2 Megalixir ; Chamber 6 ; High Jump OR Glide
	WriteShort(chestTable+486, 0x0D50) --Torn Page -- f3 Torn Page 2 ; Chamber 6
	WriteShort(chestTable+488, 0x029E) -- -- f4 Reward 29 ; Chamber 6 ; High Jump OR Glide
	WriteShort(chestTable+490, 0x01A4) --Dalmatians -- f5 Dalmatians 26 ; Chamber 6
	WriteShort(chestTable+606, 0x0174) --Dalmatians -- 12f Dalmatians 23 ; Moonlight Hill ; White Trinity
	WriteShort(chestTable+608, 0x024E) --Goofy: Cheer -- 130 Fira-G ; Bridge ; Jack-In-The-Box
	WriteShort(chestTable+612, 0x0FA6) --2500 Munny -- 132 Defense Up ; Bridge ; High Jump OR Glide ; Jack-In-The-Box
	WriteShort(chestTable+614, 0x0A0E) -- -- 133 Reward a0 ; Cemetery ; Jack-In-The-Box
	WriteShort(chestTable+616, 0x0164) --Dalmatians -- 134 Dalmatians 22 ; Cemetery ; Jack-In-The-Box
	WriteShort(chestTable+618, 0x0230) --Aerogun Band -- 135 Gummi ; Cemetery ; Jack-In-The-Box
	WriteShort(chestTable+620, 0x09FE) -- -- 136 Reward 9f ; Oogie Manor ; Jack-In-The-Box
	WriteShort(chestTable+622, 0x00C0) --Blazing Stone -- 137 Mega-Ether ; Oogie Manor ; Jack-In-The-Box
	WriteShort(chestTable+624, 0x00E4) --Dalmatians -- 138 Dalmatians 14 ; Oogie Manor ; Jack-In-The-Box
	WriteShort(chestTable+626, 0x0FD0) --Mythril Shard -- 139 Mythril Shard ; Oogie Manor ; Red Trinity ; Jack-In-The-Box
	WriteShort(chestTable+628, 0x1906) --4000 Munny -- 13a Power Up ; Guillotine Square ; High Jump OR Glide
	WriteShort(chestTable+630, 0x0050) --Phoenix Down -- 13b Elixir ; Guillotine Square ; Glide
	WriteShort(chestTable+632, 0x0C30) --Memory -- 13c Ether ; Oogie Manor ; Jack-In-The-Box
	WriteShort(chestTable+634, 0x0F90) --Bright Gem -- 13d Ether ; Oogie Manor ; Jack-In-The-Box
	WriteShort(chestTable+656, 0x0250) --Golem Chain -- 148 Meteor-G ; Bridge ; Jack-In-The-Box
	WriteShort(chestTable+658, 0x00C0) --Blazing Stone -- 149 Holy-G ; Cemetery ; Jack-In-The-Box
	WriteShort(chestTable+660, 0x024E) --Donald: Cheer -- 14a Thundara-G ; Guillotine Square
	WriteShort(chestTable+662, 0x0184) --Dalmatians -- 14b Dalmatians 24 ; Guillotine Square ; Glide
	WriteShort(chestTable+666, 0x01A0) --Thunder Ring -- 14d Mega-Potion ; Coliseum Gates
	WriteShort(chestTable+668, 0x0084) --Dalmatians -- 14e Dalmatians 8 ; Coliseum Gates ; Blue Trinity
	WriteShort(chestTable+670, 0x008E) --Sora: Onslaught -- 14f Reward 55 ; Coliseum Gates ; Blue Trinity
	WriteShort(chestTable+672, 0x02C0) --Atlas Armlet -- 150 Reward 56 ; Coliseum Gates ; White Trinity
	WriteShort(chestTable+674, 0x0020) -- -- 151 Gummi ; Coliseum Gates ; Blizzara Magic
	WriteShort(chestTable+676, 0x09AE) -- -- 152 Reward 9a ; Coliseum Gates ; Blizzaga Magic
	WriteShort(chestTable+694, 0x027E) --HIGH JUMP -- 15b Reward 27 ; Monstro: Mouth
	WriteShort(chestTable+696, 0x0F60) --Thunder Gem -- 15c Cottage ; Monstro: Mouth ; High Jump OR Glide
	WriteShort(chestTable+698, 0x0194) --Dalmatians -- 15d Dalmatians 25 ; Monstro: Mouth ; High Jump OR Glide
	WriteShort(chestTable+700, 0x00D0) --Frost Stone -- 15e Scan-G ; Monstro: Mouth
	WriteShort(chestTable+702, 0x057E) -- -- 15f Reward 57 ; Monstro: Mouth ; High Jump OR Glide ; Green Trinity
	WriteShort(chestTable+710, 0x0380) --Nose Piece -- 163 Cottage ; Chamber 2
	WriteShort(chestTable+712, 0x0080) -- -- 164 Megalixir ; Chamber 2
	WriteShort(chestTable+724, 0x0FE0) -- -- 16a Mythril ; Chamber 5
	WriteShort(chestTable+726, 0x0C30) --Memory -- 16b Mega-Ether ; Chamber 3
	WriteShort(chestTable+728, 0x0134) --Dalmatians -- 16c Dalmatians 19 ; Chamber 3
	WriteShort(chestTable+730, 0x0180) --Blizzara Ring -- 16d Osmose-G ; Chamber 3
	WriteShort(chestTable+732, 0x0130) --Mighty  Chain -- 16e Flare-G ; Chamber 3
	WriteShort(chestTable+746, 0x028E) -- -- 175 Reward 28 ; Monstro: Mouth ; High Jump OR Glide
	WriteShort(chestTable+748, 0x01B4) --Dalmatians -- 176 Dalmatians 27 ; Chamber 5
	WriteShort(chestTable+750, 0x07C0) --Adamant Shield -- 177 Mega-Ether ; Chamber 5
	WriteShort(chestTable+752, 0x06B0) --Wisdom Staff -- 178 Thundaga-G ; Chamber 5
	WriteShort(chestTable+754, 0x00F4) -- -- 179 Dalmatians 15 ; Pirate Ship ; White Trinity ; Green Trinity ; Glide
	WriteShort(chestTable+756, 0x0A2E) -- -- 17a Reward a2 ; Pirate Ship ; Green Trinity ; Glide
	WriteShort(chestTable+758, 0x0FF0) -- -- 17b Orichalcum ; Ship: Hold ; Yellow Trinity
	WriteShort(chestTable+760, 0x0A1E) -- -- 17c Reward a1 ; Ship: Hold ; Yellow Trinity
	WriteShort(chestTable+762, 0x00CE) --Hurricane Blast (Sora) -- 17d Meteor-G ; Ship: Galley
	WriteShort(chestTable+764, 0x0C30) --Memory -- 17e Reward 78 ; Ship: Cabin ; Green Trinity
	WriteShort(chestTable+766, 0x01C4) --Dalmatians -- 17f Dalmatians 28 ; Ship: Hold ; Glide ; Green Trinity
	WriteShort(chestTable+806, 0x00F0) --Dazzling Stone -- 193 Flare-G ; Clock Tower ; Green Trinity
	WriteShort(chestTable+808, 0x0020) -- -- 194 Paper-G ; Ship: Hold ; Glide ; Green Trinity
	WriteShort(chestTable+810, 0x01D4) --Dalmatians -- 195 Dalmatians 29 ; Ship: Hold ; Yellow Trinity
	WriteShort(chestTable+812, 0x01E4) --Dalmatians -- 196 Dalmatians 30 ; Captain's Cabin ; Green Trinity
	WriteShort(chestTable+814, 0x0C30) --Memory -- 197 Life-G ; Rising Falls
	WriteShort(chestTable+816, 0x0020) -- -- 198 Meteor-G ; Rising Falls
	WriteShort(chestTable+818, 0x03E0) --Blizzagun Band -- 199 Reward 58 ; Rising Falls ; HB1 ; HB2
	WriteShort(chestTable+820, 0x01F4) --Dalmatians -- 19a Dalmatians 31 ; Rising Falls ; Blizzard Magic
	WriteShort(chestTable+822, 0x0190) --Blizzaga Ring -- 19b Reward 79 ; Rising Falls ; Blizzard Magic
	WriteShort(chestTable+824, 0x0080) -- -- 19c Megalixir ; Rising Falls
	WriteShort(chestTable+826, 0x0204) --Dalmatians -- 19d Dalmatians 32 ; Castle Gates ; Dumbo OR HB1 ; Gravity Magic
	WriteShort(chestTable+828, 0x059E) -- -- 19e Reward 59 ; Castle Gates ; Dumbo OR HB1
	WriteShort(chestTable+830, 0x0160) --Firaga Ring -- 19f Haste2-G ; Castle Gates ; Dumbo OR HB1
	WriteShort(chestTable+832, 0x0FF0) -- -- 1a0 Orichalcum ; Great Crest ; HB1
	WriteShort(chestTable+834, 0x0430) --Moogle Badge -- 1a1 Thundaga-G ; Great Crest ; HB1
	WriteShort(chestTable+836, 0x0EB0) --Lucid Crystal -- 1a2 Osmose-G ; High Tower ; HB1 ; Gravity Magic
	WriteShort(chestTable+838, 0x0260) --Titan Chain -- 1a3 Reward 5a ; High Tower ; HB1 ; Gravity Magic
	WriteShort(chestTable+840, 0x0080) -- -- 1a4 Megalixir ; High Tower ; HB1
	WriteShort(chestTable+842, 0x0210) --Trinity Sigil -- 1a5 Reward 5b ; Entrance Hall ; Dumbo
	WriteShort(chestTable+844, 0x00F0) --Power Crystal -- 1a6 Ultima-G ; Library ; Khama
	WriteShort(chestTable+854, 0x0A3E) -- -- 1ab Reward a3 ; Lift Stop ; HB1 ; Khama ; Gravity Magic
	WriteShort(chestTable+856, 0x03F0) --Thundagun Band -- 1ac Osmose-G ; Lift Stop ; Dumbo OR HB1 ; Khama ; Gravity Magic
	WriteShort(chestTable+858, 0x0A4E) -- -- 1ad Reward a4 ; Lift Stop ; HB1 ; Khama ; Gravity Magic
	WriteShort(chestTable+860, 0x0214) -- -- 1ae Dalmatians 33 ; Lift Stop ; Dumbo OR HB1 ; Khama ; Gravity Magic
	WriteShort(chestTable+862, 0x0FF0) -- -- 1af Orichalcum ; Lift Stop ; Dumbo OR HB1
	WriteShort(chestTable+864, 0x0FE0) -- -- 1b0 Mythril ; Base Level
	WriteShort(chestTable+866, 0x0EB0) --Lucid Crystal -- 1b1 Paper-G ; Base Level
	WriteShort(chestTable+868, 0x09C0) --Dark Matter -- 1b2 Thundara-G ; Base Level
	WriteShort(chestTable+870, 0x03D0) --Firagun Band -- 1b3 Reward 7a ; Waterway
	WriteShort(chestTable+872, 0x0A5E) -- -- 1b4 Reward a5 ; Waterway ; High Jump ; Blizzard Magic
	WriteShort(chestTable+874, 0x02EE) --Sora: Cheer -- 1b5 Thundaga-G ; Waterway
	WriteShort(chestTable+876, 0x0130) --Mighty Chain -- 1b6 Ultima-G ; Dungeon
	WriteShort(chestTable+878, 0x0100) --Stormy Stone -- 1b7 Thundaga-G ; Dungeon
	WriteShort(chestTable+894, 0x09C0) --Dark Matter -- 1bf Reward a6 ; Grand Hall ; HB1 ; HB2
	WriteShort(chestTable+896, 0x031E) --Heartseeker -- 1c0 Reward 31 ; Grand Hall ; HB1 ; HB2
	WriteShort(chestTable+898, 0x0154) --Dalmatians -- 1c1 Dalmatians 21 ; Grand Hall ; HB1 ; HB2
	WriteShort(chestTable+902, 0x00DE) --Sora: Zantetsu Prime -- 1c3 Thundaga-G ; Rising Falls ; White Trinity
	WriteShort(chestTable+904, 0x0C30) --Memory -- 1c4 Reward 7b ; Final Dimension ; EotW
	WriteShort(chestTable+908, 0x0FB0) --Mystery Goo -- EOTW
	WriteShort(chestTable+912, 0x0FC0) --Gale -- 1c8 Reward 7f ; Final Dimension ; EotW
	WriteShort(chestTable+914, 0x0100) --Stormy Stone -- 1c9 Reward 80 ; Final Dimension ; EotW
	WriteShort(chestTable+918, 0x09C0) --Dark Matter -- 1cb Reward 82 ; Final Dimension ; EotW
	WriteShort(chestTable+924, 0x02F0) --Crystal Crown -- 1ce Full-Life-G ; Giant Crevasse ; EotW ; Glide
	WriteShort(chestTable+926, 0x0A8E) -- -- 1cf Reward a8 ; Giant Crevasse ; EotW
	WriteShort(chestTable+928, 0x0080) --Megalixir -- 1d0 Drill-G ; Giant Crevasse ; EotW
	WriteShort(chestTable+930, 0x0A7E) -- -- 1d1 Reward a7 ; Giant Crevasse ; EotW ; Glide
	WriteShort(chestTable+932, 0x02D0) --Gravigun Band -- 1d2 Ultima-G ; Giant Crevasse ; EotW
	WriteShort(chestTable+934, 0x0300) --Brave Warrior -- 1d3 Reward 87 ; World Terminus ; EotW
	WriteShort(chestTable+936, 0x004E) --Donald: Treasure Magnet -- 1d4 Reward 88 ; World Terminus ; EotW
	WriteShort(chestTable+938, 0x0490) --Olympus Medal -- 1d5 Reward 89 ; World Terminus ; EotW
	WriteShort(chestTable+940, 0x0460) --Prime Cap -- 1d6 Reward 8a ; World Terminus ; EotW
	WriteShort(chestTable+942, 0x0400) --Ifrit Belt -- 1d7 Reward 8b ; World Terminus ; EotW
	WriteShort(chestTable+946, 0x0410) --Shiva Belt -- 1d9 Reward 8c ; World Terminus ; EotW
	WriteShort(chestTable+948, 0x08DE) -- -- 1da Reward 8d ; World Terminus ; EotW
	WriteShort(chestTable+950, 0x0050) --Phoenix Down -- 1db Megalixir ; World Terminus ; EotW
	WriteShort(chestTable+952, 0x0420) --Ramuh Belt -- 1dc Reward 8e ; World Terminus ; HB1 ; HB2 ; EotW
	WriteShort(chestTable+954, 0x0050) --Phoenix Down -- 1dd Megalixir ; Final Rest ; HB1 ; HB2 ; EotW
	WriteShort(chestTable+956, 0x09EE) -- -- 1fd Reward 9E ; Chamber 6 ; White Trinity
end