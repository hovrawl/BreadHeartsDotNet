LUAGUI_NAME = "Customize Accessory Stats"
LUAGUI_AUTH = "Xendra"
LUAGUI_DESC = "Customize the stats of Accessories"

local offset = 0x3A0606

local accessoryStart = 0x2D22218 - offset

-- Accessory Digits

-- 11  Protect Chain   
-- 12  Protera Chain   
-- 13  Protega Chain   
-- 14  Fire Ring       
-- 15  Fira Ring       
-- 16  Firaga Ring     
-- 17  Blizzard Ring   
-- 18  Blizzara Ring   
-- 19  Blizzaga Ring   
-- 1A  Thunder Ring    
-- 1B  Thundara Ring   
-- 1C  Thundaga Ring   
-- 1D  Ability Stud    
-- 1E  Guard Earring   
-- 1F  Master Earring  
-- 20  Chaos Ring      
-- 21  Dark Ring       
-- 22  Element Ring    
-- 23  Three Stars     
-- 24  Power Chain     
-- 25  Golem Chain     
-- 26  Titan Chain     
-- 27  Energy Bangle   
-- 28  Angel Bangle    
-- 29  Gaia Bangle     
-- 2A  Magic Armlet    
-- 2B  Rune Armlet     
-- 2C  Atlas Armlet    
-- 2D  Heartguard      
-- 2E  Ribbon          
-- 2F  Crystal Crown   
-- 30  Brave Warrior   
-- 31  Ifrit's Horn    
-- 32  Inferno Band    
-- 33  White Fang      
-- 34  Ray of Light    
-- 35  Holy Circlet    
-- 36  Raven's Claw    
-- 37  Omega Arts      
-- 38  EXP Earring     
-- 39  A41             
-- 3A  EXP Ring        
-- 3B  EXP Bracelet    
-- 3C  EXP Necklace    
-- 3D  Firagun Band    
-- 3E  Blizzagun Band  
-- 3F  Thundagun Band  
-- 40  Ifrit Belt      
-- 41  Shiva Belt      
-- 42  Ramuh Belt      
-- 43  Moogle Badge    
-- 44  Cosmic Arts     
-- 45  Royal Crown     
-- 46  Prime Cap       
-- 47  Obsidian Ring   
-- 48  A56             
-- 49  A57             
-- 4A  A58             
-- 4B  A59             
-- 4C  A60             
-- 4D  A61             
-- 4E  A62             
-- 4F  A63             
-- 50  A64             


acc_11_health_value = 0
acc_11_mp_value = 0
acc_11_str_value = 0
acc_11_def_value = 0
acc_11_ap_value = 0

acc_12_health_value = 0
acc_12_mp_value = 0
acc_12_str_value = 0
acc_12_def_value = 0
acc_12_ap_value = 0

acc_13_health_value = 0
acc_13_mp_value = 0
acc_13_str_value = 0
acc_13_def_value = 0
acc_13_ap_value = 0

acc_14_health_value = 0
acc_14_mp_value = 0
acc_14_str_value = 0
acc_14_def_value = 0
acc_14_ap_value = 0

acc_15_health_value = 0
acc_15_mp_value = 1
acc_15_str_value = 0
acc_15_def_value = 0
acc_15_ap_value = 0

acc_16_health_value = 0
acc_16_mp_value = 1
acc_16_str_value = 0
acc_16_def_value = 0
acc_16_ap_value = 0

acc_17_health_value = 0
acc_17_mp_value = 0
acc_17_str_value = 0
acc_17_def_value = 0
acc_17_ap_value = 0

acc_18_health_value = 0
acc_18_mp_value = 1
acc_18_str_value = 0
acc_18_def_value = 0
acc_18_ap_value = 0

acc_19_health_value = 0
acc_19_mp_value = 1
acc_19_str_value = 0
acc_19_def_value = 0
acc_19_ap_value = 0

acc_1A_health_value = 0
acc_1A_mp_value = 0
acc_1A_str_value = 0
acc_1A_def_value = 0
acc_1A_ap_value = 0

acc_1B_health_value = 0
acc_1B_mp_value = 1
acc_1B_str_value = 0
acc_1B_def_value = 0
acc_1B_ap_value = 0

acc_1C_health_value = 0
acc_1C_mp_value = 1
acc_1C_str_value = 0
acc_1C_def_value = 0
acc_1C_ap_value = 0

acc_1D_health_value = 0
acc_1D_mp_value = 0
acc_1D_str_value = 1
acc_1D_def_value = 0
acc_1D_ap_value = 0

acc_1E_health_value = 0
acc_1E_mp_value = 0
acc_1E_str_value = 0
acc_1E_def_value = 0
acc_1E_ap_value = 0

acc_1F_health_value = 0
acc_1F_mp_value = 0
acc_1F_str_value = 0
acc_1F_def_value = 0
acc_1F_ap_value = 0

acc_20_health_value = 0
acc_20_mp_value = 0
acc_20_str_value = 0
acc_20_def_value = 0
acc_20_ap_value = 0

acc_21_health_value = 0
acc_21_mp_value = 1
acc_21_str_value = 1
acc_21_def_value = 0
acc_21_ap_value = 0

acc_22_health_value = 0
acc_22_mp_value = 0
acc_22_str_value = 0
acc_22_def_value = 0
acc_22_ap_value = 0

acc_23_health_value = 0
acc_23_mp_value = 2
acc_23_str_value = 0
acc_23_def_value = 0
acc_23_ap_value = 0

acc_24_health_value = 0
acc_24_mp_value = 0
acc_24_str_value = 2
acc_24_def_value = 0
acc_24_ap_value = 0

acc_25_health_value = 0
acc_25_mp_value = 0
acc_25_str_value = 3
acc_25_def_value = 0
acc_25_ap_value = 0

acc_26_health_value = 0
acc_26_mp_value = 0
acc_26_str_value = 4
acc_26_def_value = 0
acc_26_ap_value = 0

acc_27_health_value = 0
acc_27_mp_value = 0
acc_27_str_value = 0
acc_27_def_value = 0
acc_27_ap_value = 0

acc_28_health_value = 7
acc_28_mp_value = 0
acc_28_str_value = 0
acc_28_def_value = 0
acc_28_ap_value = 0

acc_29_health_value = 7
acc_29_mp_value = 0
acc_29_str_value = 0
acc_29_def_value = 0
acc_29_ap_value = 0

acc_2A_health_value = 0
acc_2A_mp_value = 0
acc_2A_str_value = 0
acc_2A_def_value = 0
acc_2A_ap_value = 0

acc_2B_health_value = 0
acc_2B_mp_value = 1
acc_2B_str_value = 0
acc_2B_def_value = 0
acc_2B_ap_value = 0

acc_2C_health_value = 0
acc_2C_mp_value = 2
acc_2C_str_value = 0
acc_2C_def_value = 0
acc_2C_ap_value = 0

acc_2D_health_value = 0
acc_2D_mp_value = 2
acc_2D_str_value = 0
acc_2D_def_value = 0
acc_2D_ap_value = 0

acc_2E_health_value = 20
acc_2E_mp_value = 0
acc_2E_str_value = 0
acc_2E_def_value = 0
acc_2E_ap_value = 0

acc_2F_health_value = 7
acc_2F_mp_value = 1
acc_2F_str_value = 3
acc_2F_def_value = 0
acc_2F_ap_value = 0

acc_30_health_value = 4
acc_30_mp_value = 0
acc_30_str_value = 1
acc_30_def_value = 0
acc_30_ap_value = 0

acc_31_health_value = 0
acc_31_mp_value = 2
acc_31_str_value = 0
acc_31_def_value = 0
acc_31_ap_value = 0

acc_32_health_value = 0
acc_32_mp_value = 0
acc_32_str_value = 2
acc_32_def_value = 0
acc_32_ap_value = 0

acc_33_health_value = 0
acc_33_mp_value = 1
acc_33_str_value = 1
acc_33_def_value = 0
acc_33_ap_value = 0

acc_34_health_value = 5
acc_34_mp_value = 1
acc_34_str_value = 0
acc_34_def_value = 0
acc_34_ap_value = 0

acc_35_health_value = 0
acc_35_mp_value = 0
acc_35_str_value = 0
acc_35_def_value = 0
acc_35_ap_value = 0

acc_36_health_value = 0
acc_36_mp_value = 0
acc_36_str_value = 5
acc_36_def_value = 0
acc_36_ap_value = 0

acc_37_health_value = 4
acc_37_mp_value = 0
acc_37_str_value = 4
acc_37_def_value = 0
acc_37_ap_value = 0

acc_38_health_value = 0
acc_38_mp_value = 0
acc_38_str_value = 0
acc_38_def_value = 0
acc_38_ap_value = 0

acc_39_health_value = 7
acc_39_mp_value = 0
acc_39_str_value = 0
acc_39_def_value = 0
acc_39_ap_value = 0

acc_3A_health_value = 0
acc_3A_mp_value = 2
acc_3A_str_value = 0
acc_3A_def_value = 0
acc_3A_ap_value = 0

acc_3B_health_value = 0
acc_3B_mp_value = 0
acc_3B_str_value = 0
acc_3B_def_value = 0
acc_3B_ap_value = 0

acc_3C_health_value = 0
acc_3C_mp_value = 1
acc_3C_str_value = 4
acc_3C_def_value = 0
acc_3C_ap_value = 0

acc_3D_health_value = 0
acc_3D_mp_value = 2
acc_3D_str_value = 0
acc_3D_def_value = 0
acc_3D_ap_value = 0

acc_3E_health_value = 0
acc_3E_mp_value = 2
acc_3E_str_value = 0
acc_3E_def_value = 0
acc_3E_ap_value = 0

acc_3F_health_value = 0
acc_3F_mp_value = 2
acc_3F_str_value = 0
acc_3F_def_value = 0
acc_3F_ap_value = 0

acc_40_health_value = 0
acc_40_mp_value = 0
acc_40_str_value = 5
acc_40_def_value = 0
acc_40_ap_value = 0

acc_41_health_value = 0
acc_41_mp_value = 2
acc_41_str_value = 0
acc_41_def_value = 0
acc_41_ap_value = 0

acc_42_health_value = 0
acc_42_mp_value = 0
acc_42_str_value = 0
acc_42_def_value = 0
acc_42_ap_value = 0

acc_43_health_value = 7
acc_43_mp_value = 2
acc_43_str_value = 0
acc_43_def_value = 0
acc_43_ap_value = 0

acc_44_health_value = 0
acc_44_mp_value = 1
acc_44_str_value = 3
acc_44_def_value = 0
acc_44_ap_value = 0

acc_45_health_value = 0
acc_45_mp_value = 3
acc_45_str_value = -3
acc_45_def_value = 0
acc_45_ap_value = 0

acc_46_health_value = 0
acc_46_mp_value = 0
acc_46_str_value = -5
acc_46_def_value = 0
acc_46_ap_value = 0

acc_47_health_value = -6
acc_47_mp_value = 0
acc_47_str_value = 2
acc_47_def_value = 0
acc_47_ap_value = 0

acc_48_health_value = 0
acc_48_mp_value = 0
acc_48_str_value = 4
acc_48_def_value = 0
acc_48_ap_value = 0

acc_49_health_value = 0
acc_49_mp_value = 0
acc_49_str_value = 3
acc_49_def_value = 0
acc_49_ap_value = 0

acc_4A_health_value = 0
acc_4A_mp_value = 0
acc_4A_str_value = 4
acc_4A_def_value = 0
acc_4A_ap_value = 0

acc_4B_health_value = 0
acc_4B_mp_value = 3
acc_4B_str_value = 0
acc_4B_def_value = 0
acc_4B_ap_value = 0

acc_4C_health_value = 0
acc_4C_mp_value = 0
acc_4C_str_value = 0
acc_4C_def_value = 0
acc_4C_ap_value = 0

acc_4D_health_value = 0
acc_4D_mp_value = 0
acc_4D_str_value = 0
acc_4D_def_value = 0
acc_4D_ap_value = 0

acc_4E_health_value = 0
acc_4E_mp_value = 0
acc_4E_str_value = 0
acc_4E_def_value = 0
acc_4E_ap_value = 0

acc_4F_health_value = 0
acc_4F_mp_value = 0
acc_4F_str_value = 0
acc_4F_def_value = 0
acc_4F_ap_value = 0

acc_50_health_value = 0
acc_50_mp_value = 0
acc_50_str_value = 0
acc_50_def_value = 0
acc_50_ap_value = 0



-- Accessory Addresses

acc_11_health = accessoryStart+0x0
acc_11_mp = accessoryStart+0x1
acc_11_str = accessoryStart+0x2
acc_11_def = accessoryStart+0x3
acc_11_ap = accessoryStart+0x4

acc_12_health = accessoryStart+0x16
acc_12_mp = accessoryStart+0x17
acc_12_str = accessoryStart+0x18
acc_12_def = accessoryStart+0x19
acc_12_ap = accessoryStart+0x1A

acc_13_health = accessoryStart+0x2C
acc_13_mp = accessoryStart+0x2D
acc_13_str = accessoryStart+0x2E
acc_13_def = accessoryStart+0x2F
acc_13_ap = accessoryStart+0x30

acc_14_health = accessoryStart+0x42
acc_14_mp = accessoryStart+0x43
acc_14_str = accessoryStart+0x44
acc_14_def = accessoryStart+0x45
acc_14_ap = accessoryStart+0x46

acc_15_health = accessoryStart+0x58
acc_15_mp = accessoryStart+0x59
acc_15_str = accessoryStart+0x5A
acc_15_def = accessoryStart+0x5B
acc_15_ap = accessoryStart+0x5C

acc_16_health = accessoryStart+0x6E
acc_16_mp = accessoryStart+0x6F
acc_16_str = accessoryStart+0x70
acc_16_def = accessoryStart+0x71
acc_16_ap = accessoryStart+0x72

acc_17_health = accessoryStart+0x84
acc_17_mp = accessoryStart+0x85
acc_17_str = accessoryStart+0x86
acc_17_def = accessoryStart+0x87
acc_17_ap = accessoryStart+0x88

acc_18_health = accessoryStart+0x9A
acc_18_mp = accessoryStart+0x9B
acc_18_str = accessoryStart+0x9C
acc_18_def = accessoryStart+0x9D
acc_18_ap = accessoryStart+0x9E

acc_19_health = accessoryStart+0xB0
acc_19_mp = accessoryStart+0xB1
acc_19_str = accessoryStart+0xB2
acc_19_def = accessoryStart+0xB3
acc_19_ap = accessoryStart+0xB4

acc_1A_health = accessoryStart+0xC6
acc_1A_mp = accessoryStart+0xC7
acc_1A_str = accessoryStart+0xC8
acc_1A_def = accessoryStart+0xC9
acc_1A_ap = accessoryStart+0xCA

acc_1B_health = accessoryStart+0xDC
acc_1B_mp = accessoryStart+0xDD
acc_1B_str = accessoryStart+0xDE
acc_1B_def = accessoryStart+0xDF
acc_1B_ap = accessoryStart+0xE0

acc_1C_health = accessoryStart+0xF2
acc_1C_mp = accessoryStart+0xF3
acc_1C_str = accessoryStart+0xF4
acc_1C_def = accessoryStart+0xF5
acc_1C_ap = accessoryStart+0xF6

acc_1D_health = accessoryStart+0x0108
acc_1D_mp = accessoryStart+0x0109
acc_1D_str = accessoryStart+0x010A
acc_1D_def = accessoryStart+0x010B
acc_1D_ap = accessoryStart+0x010C

acc_1E_health = accessoryStart+0x011E
acc_1E_mp = accessoryStart+0x011F
acc_1E_str = accessoryStart+0x0120
acc_1E_def = accessoryStart+0x0121
acc_1E_ap = accessoryStart+0x0122

acc_1F_health = accessoryStart+0x0134
acc_1F_mp = accessoryStart+0x0135
acc_1F_str = accessoryStart+0x0136
acc_1F_def = accessoryStart+0x0137
acc_1F_ap = accessoryStart+0x0138

acc_20_health = accessoryStart+0x014A
acc_20_mp = accessoryStart+0x014B
acc_20_str = accessoryStart+0x014C
acc_20_def = accessoryStart+0x014D
acc_20_ap = accessoryStart+0x014E

acc_21_health = accessoryStart+0x0160
acc_21_mp = accessoryStart+0x0161
acc_21_str = accessoryStart+0x0162
acc_21_def = accessoryStart+0x0163
acc_21_ap = accessoryStart+0x0164

acc_22_health = accessoryStart+0x0176
acc_22_mp = accessoryStart+0x0177
acc_22_str = accessoryStart+0x0178
acc_22_def = accessoryStart+0x0179
acc_22_ap = accessoryStart+0x017A

acc_23_health = accessoryStart+0x018C
acc_23_mp = accessoryStart+0x018D
acc_23_str = accessoryStart+0x018E
acc_23_def = accessoryStart+0x018F
acc_23_ap = accessoryStart+0x0190

acc_24_health = accessoryStart+0x01A2
acc_24_mp = accessoryStart+0x01A3
acc_24_str = accessoryStart+0x01A4
acc_24_def = accessoryStart+0x01A5
acc_24_ap = accessoryStart+0x01A6

acc_25_health = accessoryStart+0x01B8
acc_25_mp = accessoryStart+0x01B9
acc_25_str = accessoryStart+0x01BA
acc_25_def = accessoryStart+0x01BB
acc_25_ap = accessoryStart+0x01BC

acc_26_health = accessoryStart+0x01CE
acc_26_mp = accessoryStart+0x01CF
acc_26_str = accessoryStart+0x01D0
acc_26_def = accessoryStart+0x01D1
acc_26_ap = accessoryStart+0x01D2

acc_27_health = accessoryStart+0x01E4
acc_27_mp = accessoryStart+0x01E5
acc_27_str = accessoryStart+0x01E6
acc_27_def = accessoryStart+0x01E7
acc_27_ap = accessoryStart+0x01E8

acc_28_health = accessoryStart+0x01FA
acc_28_mp = accessoryStart+0x01FB
acc_28_str = accessoryStart+0x01FC
acc_28_def = accessoryStart+0x01FD
acc_28_ap = accessoryStart+0x01FE

acc_29_health = accessoryStart+0x0210
acc_29_mp = accessoryStart+0x0211
acc_29_str = accessoryStart+0x0212
acc_29_def = accessoryStart+0x0213
acc_29_ap = accessoryStart+0x0214

acc_2A_health = accessoryStart+0x0226
acc_2A_mp = accessoryStart+0x0227
acc_2A_str = accessoryStart+0x0228
acc_2A_def = accessoryStart+0x0229
acc_2A_ap = accessoryStart+0x022A

acc_2B_health = accessoryStart+0x023C
acc_2B_mp = accessoryStart+0x023D
acc_2B_str = accessoryStart+0x023E
acc_2B_def = accessoryStart+0x023F
acc_2B_ap = accessoryStart+0x0240

acc_2C_health = accessoryStart+0x0252
acc_2C_mp = accessoryStart+0x0253
acc_2C_str = accessoryStart+0x0254
acc_2C_def = accessoryStart+0x0255
acc_2C_ap = accessoryStart+0x0256

acc_2D_health = accessoryStart+0x0268
acc_2D_mp = accessoryStart+0x0269
acc_2D_str = accessoryStart+0x026A
acc_2D_def = accessoryStart+0x026B
acc_2D_ap = accessoryStart+0x026C

acc_2E_health = accessoryStart+0x027E
acc_2E_mp = accessoryStart+0x027F
acc_2E_str = accessoryStart+0x0280
acc_2E_def = accessoryStart+0x0281
acc_2E_ap = accessoryStart+0x0282

acc_2F_health = accessoryStart+0x0294
acc_2F_mp = accessoryStart+0x0295
acc_2F_str = accessoryStart+0x0296
acc_2F_def = accessoryStart+0x0297
acc_2F_ap = accessoryStart+0x0298

acc_30_health = accessoryStart+0x02AA
acc_30_mp = accessoryStart+0x02AB
acc_30_str = accessoryStart+0x02AC
acc_30_def = accessoryStart+0x02AD
acc_30_ap = accessoryStart+0x02AE

acc_31_health = accessoryStart+0x02C0
acc_31_mp = accessoryStart+0x02C1
acc_31_str = accessoryStart+0x02C2
acc_31_def = accessoryStart+0x02C3
acc_31_ap = accessoryStart+0x02C4

acc_32_health = accessoryStart+0x02D6
acc_32_mp = accessoryStart+0x02D7
acc_32_str = accessoryStart+0x02D8
acc_32_def = accessoryStart+0x02D9
acc_32_ap = accessoryStart+0x02DA

acc_33_health = accessoryStart+0x02EC
acc_33_mp = accessoryStart+0x02ED
acc_33_str = accessoryStart+0x02EE
acc_33_def = accessoryStart+0x02EF
acc_33_ap = accessoryStart+0x02F0

acc_34_health = accessoryStart+0x0302
acc_34_mp = accessoryStart+0x0303
acc_34_str = accessoryStart+0x0304
acc_34_def = accessoryStart+0x0305
acc_34_ap = accessoryStart+0x0306

acc_35_health = accessoryStart+0x0318
acc_35_mp = accessoryStart+0x0319
acc_35_str = accessoryStart+0x031A
acc_35_def = accessoryStart+0x031B
acc_35_ap = accessoryStart+0x031C

acc_36_health = accessoryStart+0x032E
acc_36_mp = accessoryStart+0x032F
acc_36_str = accessoryStart+0x0330
acc_36_def = accessoryStart+0x0331
acc_36_ap = accessoryStart+0x0332

acc_37_health = accessoryStart+0x0344
acc_37_mp = accessoryStart+0x0345
acc_37_str = accessoryStart+0x0346
acc_37_def = accessoryStart+0x0347
acc_37_ap = accessoryStart+0x0348

acc_38_health = accessoryStart+0x035A
acc_38_mp = accessoryStart+0x035B
acc_38_str = accessoryStart+0x035C
acc_38_def = accessoryStart+0x035D
acc_38_ap = accessoryStart+0x035E

acc_39_health = accessoryStart+0x0370
acc_39_mp = accessoryStart+0x0371
acc_39_str = accessoryStart+0x0372
acc_39_def = accessoryStart+0x0373
acc_39_ap = accessoryStart+0x0374

acc_3A_health = accessoryStart+0x0386
acc_3A_mp = accessoryStart+0x0387
acc_3A_str = accessoryStart+0x0388
acc_3A_def = accessoryStart+0x0389
acc_3A_ap = accessoryStart+0x038A

acc_3B_health = accessoryStart+0x039C
acc_3B_mp = accessoryStart+0x039D
acc_3B_str = accessoryStart+0x039E
acc_3B_def = accessoryStart+0x039F
acc_3B_ap = accessoryStart+0x03A0

acc_3C_health = accessoryStart+0x03B2
acc_3C_mp = accessoryStart+0x03B3
acc_3C_str = accessoryStart+0x03B4
acc_3C_def = accessoryStart+0x03B5
acc_3C_ap = accessoryStart+0x03B6

acc_3D_health = accessoryStart+0x03C8
acc_3D_mp = accessoryStart+0x03C9
acc_3D_str = accessoryStart+0x03CA
acc_3D_def = accessoryStart+0x03CB
acc_3D_ap = accessoryStart+0x03CC

acc_3E_health = accessoryStart+0x03DE
acc_3E_mp = accessoryStart+0x03DF
acc_3E_str = accessoryStart+0x03E0
acc_3E_def = accessoryStart+0x03E1
acc_3E_ap = accessoryStart+0x03E2

acc_3F_health = accessoryStart+0x03F4
acc_3F_mp = accessoryStart+0x03F5
acc_3F_str = accessoryStart+0x03F6
acc_3F_def = accessoryStart+0x03F7
acc_3F_ap = accessoryStart+0x03F8

acc_40_health = accessoryStart+0x040A
acc_40_mp = accessoryStart+0x040B
acc_40_str = accessoryStart+0x040C
acc_40_def = accessoryStart+0x040D
acc_40_ap = accessoryStart+0x040E

acc_41_health = accessoryStart+0x0420
acc_41_mp = accessoryStart+0x0421
acc_41_str = accessoryStart+0x0422
acc_41_def = accessoryStart+0x0423
acc_41_ap = accessoryStart+0x0424

acc_42_health = accessoryStart+0x0436
acc_42_mp = accessoryStart+0x0437
acc_42_str = accessoryStart+0x0438
acc_42_def = accessoryStart+0x0439
acc_42_ap = accessoryStart+0x043A

acc_43_health = accessoryStart+0x044C
acc_43_mp = accessoryStart+0x044D
acc_43_str = accessoryStart+0x044E
acc_43_def = accessoryStart+0x044F
acc_43_ap = accessoryStart+0x0450

acc_44_health = accessoryStart+0x0462
acc_44_mp = accessoryStart+0x0463
acc_44_str = accessoryStart+0x0464
acc_44_def = accessoryStart+0x0465
acc_44_ap = accessoryStart+0x0466

acc_45_health = accessoryStart+0x0478
acc_45_mp = accessoryStart+0x0479
acc_45_str = accessoryStart+0x047A
acc_45_def = accessoryStart+0x047B
acc_45_ap = accessoryStart+0x047C

acc_46_health = accessoryStart+0x048E
acc_46_mp = accessoryStart+0x048F
acc_46_str = accessoryStart+0x0490
acc_46_def = accessoryStart+0x0491
acc_46_ap = accessoryStart+0x0492

acc_47_health = accessoryStart+0x04A4
acc_47_mp = accessoryStart+0x04A5
acc_47_str = accessoryStart+0x04A6
acc_47_def = accessoryStart+0x04A7
acc_47_ap = accessoryStart+0x04A8

acc_48_health = accessoryStart+0x04BA
acc_48_mp = accessoryStart+0x04BB
acc_48_str = accessoryStart+0x04BC
acc_48_def = accessoryStart+0x04BD
acc_48_ap = accessoryStart+0x04BE

acc_49_health = accessoryStart+0x04D0
acc_49_mp = accessoryStart+0x04D1
acc_49_str = accessoryStart+0x04D2
acc_49_def = accessoryStart+0x04D3
acc_49_ap = accessoryStart+0x04D4

acc_4A_health = accessoryStart+0x04E6
acc_4A_mp = accessoryStart+0x04E7
acc_4A_str = accessoryStart+0x04E8
acc_4A_def = accessoryStart+0x04E9
acc_4A_ap = accessoryStart+0x04EA

acc_4B_health = accessoryStart+0x04FC
acc_4B_mp = accessoryStart+0x04FD
acc_4B_str = accessoryStart+0x04FE
acc_4B_def = accessoryStart+0x04FF
acc_4B_ap = accessoryStart+0x0500

acc_4C_health = accessoryStart+0x0512
acc_4C_mp = accessoryStart+0x0513
acc_4C_str = accessoryStart+0x0514
acc_4C_def = accessoryStart+0x0515
acc_4C_ap = accessoryStart+0x0516

acc_4D_health = accessoryStart+0x0528
acc_4D_mp = accessoryStart+0x0529
acc_4D_str = accessoryStart+0x052A
acc_4D_def = accessoryStart+0x052B
acc_4D_ap = accessoryStart+0x052C

acc_4E_health = accessoryStart+0x053E
acc_4E_mp = accessoryStart+0x053F
acc_4E_str = accessoryStart+0x0540
acc_4E_def = accessoryStart+0x0541
acc_4E_ap = accessoryStart+0x0542

acc_4F_health = accessoryStart+0x0554
acc_4F_mp = accessoryStart+0x0555
acc_4F_str = accessoryStart+0x0556
acc_4F_def = accessoryStart+0x0557
acc_4F_ap = accessoryStart+0x0558

acc_50_health = accessoryStart+0x056A
acc_50_mp = accessoryStart+0x056B
acc_50_str = accessoryStart+0x056C
acc_50_def = accessoryStart+0x056D
acc_50_ap = accessoryStart+0x056E



function _OnInit()
	if GAME_ID == 0xAF71841E and ENGINE_TYPE == "BACKEND" then
		ConsolePrint("Customize Accessory Stats Installed")
		canExecute = true
	end
end


function _OnFrame()
	if canExecute == true then
		update_accessory_stats()
	end
end





function update_accessory_stats()
	WriteByte(acc_11_health, acc_11_health_value)
	WriteByte(acc_11_mp, acc_11_mp_value)
	WriteByte(acc_11_str, acc_11_str_value)
	WriteByte(acc_11_def, acc_11_def_value)
	WriteByte(acc_11_ap, acc_11_ap_value)

	WriteByte(acc_12_health, acc_12_health_value)
	WriteByte(acc_12_mp, acc_12_mp_value)
	WriteByte(acc_12_str, acc_12_str_value)
	WriteByte(acc_12_def, acc_12_def_value)
	WriteByte(acc_12_ap, acc_12_ap_value)

	WriteByte(acc_13_health, acc_13_health_value)
	WriteByte(acc_13_mp, acc_13_mp_value)
	WriteByte(acc_13_str, acc_13_str_value)
	WriteByte(acc_13_def, acc_13_def_value)
	WriteByte(acc_13_ap, acc_13_ap_value)

	WriteByte(acc_14_health, acc_14_health_value)
	WriteByte(acc_14_mp, acc_14_mp_value)
	WriteByte(acc_14_str, acc_14_str_value)
	WriteByte(acc_14_def, acc_14_def_value)
	WriteByte(acc_14_ap, acc_14_ap_value)

	WriteByte(acc_15_health, acc_15_health_value)
	WriteByte(acc_15_mp, acc_15_mp_value)
	WriteByte(acc_15_str, acc_15_str_value)
	WriteByte(acc_15_def, acc_15_def_value)
	WriteByte(acc_15_ap, acc_15_ap_value)

	WriteByte(acc_16_health, acc_16_health_value)
	WriteByte(acc_16_mp, acc_16_mp_value)
	WriteByte(acc_16_str, acc_16_str_value)
	WriteByte(acc_16_def, acc_16_def_value)
	WriteByte(acc_16_ap, acc_16_ap_value)

	WriteByte(acc_17_health, acc_17_health_value)
	WriteByte(acc_17_mp, acc_17_mp_value)
	WriteByte(acc_17_str, acc_17_str_value)
	WriteByte(acc_17_def, acc_17_def_value)
	WriteByte(acc_17_ap, acc_17_ap_value)

	WriteByte(acc_18_health, acc_18_health_value)
	WriteByte(acc_18_mp, acc_18_mp_value)
	WriteByte(acc_18_str, acc_18_str_value)
	WriteByte(acc_18_def, acc_18_def_value)
	WriteByte(acc_18_ap, acc_18_ap_value)

	WriteByte(acc_19_health, acc_19_health_value)
	WriteByte(acc_19_mp, acc_19_mp_value)
	WriteByte(acc_19_str, acc_19_str_value)
	WriteByte(acc_19_def, acc_19_def_value)
	WriteByte(acc_19_ap, acc_19_ap_value)

	WriteByte(acc_1A_health, acc_1A_health_value)
	WriteByte(acc_1A_mp, acc_1A_mp_value)
	WriteByte(acc_1A_str, acc_1A_str_value)
	WriteByte(acc_1A_def, acc_1A_def_value)
	WriteByte(acc_1A_ap, acc_1A_ap_value)

	WriteByte(acc_1B_health, acc_1B_health_value)
	WriteByte(acc_1B_mp, acc_1B_mp_value)
	WriteByte(acc_1B_str, acc_1B_str_value)
	WriteByte(acc_1B_def, acc_1B_def_value)
	WriteByte(acc_1B_ap, acc_1B_ap_value)

	WriteByte(acc_1C_health, acc_1C_health_value)
	WriteByte(acc_1C_mp, acc_1C_mp_value)
	WriteByte(acc_1C_str, acc_1C_str_value)
	WriteByte(acc_1C_def, acc_1C_def_value)
	WriteByte(acc_1C_ap, acc_1C_ap_value)

	WriteByte(acc_1D_health, acc_1D_health_value)
	WriteByte(acc_1D_mp, acc_1D_mp_value)
	WriteByte(acc_1D_str, acc_1D_str_value)
	WriteByte(acc_1D_def, acc_1D_def_value)
	WriteByte(acc_1D_ap, acc_1D_ap_value)

	WriteByte(acc_1E_health, acc_1E_health_value)
	WriteByte(acc_1E_mp, acc_1E_mp_value)
	WriteByte(acc_1E_str, acc_1E_str_value)
	WriteByte(acc_1E_def, acc_1E_def_value)
	WriteByte(acc_1E_ap, acc_1E_ap_value)

	WriteByte(acc_1F_health, acc_1F_health_value)
	WriteByte(acc_1F_mp, acc_1F_mp_value)
	WriteByte(acc_1F_str, acc_1F_str_value)
	WriteByte(acc_1F_def, acc_1F_def_value)
	WriteByte(acc_1F_ap, acc_1F_ap_value)

	WriteByte(acc_20_health, acc_20_health_value)
	WriteByte(acc_20_mp, acc_20_mp_value)
	WriteByte(acc_20_str, acc_20_str_value)
	WriteByte(acc_20_def, acc_20_def_value)
	WriteByte(acc_20_ap, acc_20_ap_value)

	WriteByte(acc_21_health, acc_21_health_value)
	WriteByte(acc_21_mp, acc_21_mp_value)
	WriteByte(acc_21_str, acc_21_str_value)
	WriteByte(acc_21_def, acc_21_def_value)
	WriteByte(acc_21_ap, acc_21_ap_value)

	WriteByte(acc_22_health, acc_22_health_value)
	WriteByte(acc_22_mp, acc_22_mp_value)
	WriteByte(acc_22_str, acc_22_str_value)
	WriteByte(acc_22_def, acc_22_def_value)
	WriteByte(acc_22_ap, acc_22_ap_value)

	WriteByte(acc_23_health, acc_23_health_value)
	WriteByte(acc_23_mp, acc_23_mp_value)
	WriteByte(acc_23_str, acc_23_str_value)
	WriteByte(acc_23_def, acc_23_def_value)
	WriteByte(acc_23_ap, acc_23_ap_value)

	WriteByte(acc_24_health, acc_24_health_value)
	WriteByte(acc_24_mp, acc_24_mp_value)
	WriteByte(acc_24_str, acc_24_str_value)
	WriteByte(acc_24_def, acc_24_def_value)
	WriteByte(acc_24_ap, acc_24_ap_value)

	WriteByte(acc_25_health, acc_25_health_value)
	WriteByte(acc_25_mp, acc_25_mp_value)
	WriteByte(acc_25_str, acc_25_str_value)
	WriteByte(acc_25_def, acc_25_def_value)
	WriteByte(acc_25_ap, acc_25_ap_value)

	WriteByte(acc_26_health, acc_26_health_value)
	WriteByte(acc_26_mp, acc_26_mp_value)
	WriteByte(acc_26_str, acc_26_str_value)
	WriteByte(acc_26_def, acc_26_def_value)
	WriteByte(acc_26_ap, acc_26_ap_value)

	WriteByte(acc_27_health, acc_27_health_value)
	WriteByte(acc_27_mp, acc_27_mp_value)
	WriteByte(acc_27_str, acc_27_str_value)
	WriteByte(acc_27_def, acc_27_def_value)
	WriteByte(acc_27_ap, acc_27_ap_value)

	WriteByte(acc_28_health, acc_28_health_value)
	WriteByte(acc_28_mp, acc_28_mp_value)
	WriteByte(acc_28_str, acc_28_str_value)
	WriteByte(acc_28_def, acc_28_def_value)
	WriteByte(acc_28_ap, acc_28_ap_value)

	WriteByte(acc_29_health, acc_29_health_value)
	WriteByte(acc_29_mp, acc_29_mp_value)
	WriteByte(acc_29_str, acc_29_str_value)
	WriteByte(acc_29_def, acc_29_def_value)
	WriteByte(acc_29_ap, acc_29_ap_value)

	WriteByte(acc_2A_health, acc_2A_health_value)
	WriteByte(acc_2A_mp, acc_2A_mp_value)
	WriteByte(acc_2A_str, acc_2A_str_value)
	WriteByte(acc_2A_def, acc_2A_def_value)
	WriteByte(acc_2A_ap, acc_2A_ap_value)

	WriteByte(acc_2B_health, acc_2B_health_value)
	WriteByte(acc_2B_mp, acc_2B_mp_value)
	WriteByte(acc_2B_str, acc_2B_str_value)
	WriteByte(acc_2B_def, acc_2B_def_value)
	WriteByte(acc_2B_ap, acc_2B_ap_value)

	WriteByte(acc_2C_health, acc_2C_health_value)
	WriteByte(acc_2C_mp, acc_2C_mp_value)
	WriteByte(acc_2C_str, acc_2C_str_value)
	WriteByte(acc_2C_def, acc_2C_def_value)
	WriteByte(acc_2C_ap, acc_2C_ap_value)

	WriteByte(acc_2D_health, acc_2D_health_value)
	WriteByte(acc_2D_mp, acc_2D_mp_value)
	WriteByte(acc_2D_str, acc_2D_str_value)
	WriteByte(acc_2D_def, acc_2D_def_value)
	WriteByte(acc_2D_ap, acc_2D_ap_value)

	WriteByte(acc_2E_health, acc_2E_health_value)
	WriteByte(acc_2E_mp, acc_2E_mp_value)
	WriteByte(acc_2E_str, acc_2E_str_value)
	WriteByte(acc_2E_def, acc_2E_def_value)
	WriteByte(acc_2E_ap, acc_2E_ap_value)

	WriteByte(acc_2F_health, acc_2F_health_value)
	WriteByte(acc_2F_mp, acc_2F_mp_value)
	WriteByte(acc_2F_str, acc_2F_str_value)
	WriteByte(acc_2F_def, acc_2F_def_value)
	WriteByte(acc_2F_ap, acc_2F_ap_value)

	WriteByte(acc_30_health, acc_30_health_value)
	WriteByte(acc_30_mp, acc_30_mp_value)
	WriteByte(acc_30_str, acc_30_str_value)
	WriteByte(acc_30_def, acc_30_def_value)
	WriteByte(acc_30_ap, acc_30_ap_value)

	WriteByte(acc_31_health, acc_31_health_value)
	WriteByte(acc_31_mp, acc_31_mp_value)
	WriteByte(acc_31_str, acc_31_str_value)
	WriteByte(acc_31_def, acc_31_def_value)
	WriteByte(acc_31_ap, acc_31_ap_value)

	WriteByte(acc_32_health, acc_32_health_value)
	WriteByte(acc_32_mp, acc_32_mp_value)
	WriteByte(acc_32_str, acc_32_str_value)
	WriteByte(acc_32_def, acc_32_def_value)
	WriteByte(acc_32_ap, acc_32_ap_value)

	WriteByte(acc_33_health, acc_33_health_value)
	WriteByte(acc_33_mp, acc_33_mp_value)
	WriteByte(acc_33_str, acc_33_str_value)
	WriteByte(acc_33_def, acc_33_def_value)
	WriteByte(acc_33_ap, acc_33_ap_value)

	WriteByte(acc_34_health, acc_34_health_value)
	WriteByte(acc_34_mp, acc_34_mp_value)
	WriteByte(acc_34_str, acc_34_str_value)
	WriteByte(acc_34_def, acc_34_def_value)
	WriteByte(acc_34_ap, acc_34_ap_value)

	WriteByte(acc_35_health, acc_35_health_value)
	WriteByte(acc_35_mp, acc_35_mp_value)
	WriteByte(acc_35_str, acc_35_str_value)
	WriteByte(acc_35_def, acc_35_def_value)
	WriteByte(acc_35_ap, acc_35_ap_value)

	WriteByte(acc_36_health, acc_36_health_value)
	WriteByte(acc_36_mp, acc_36_mp_value)
	WriteByte(acc_36_str, acc_36_str_value)
	WriteByte(acc_36_def, acc_36_def_value)
	WriteByte(acc_36_ap, acc_36_ap_value)

	WriteByte(acc_37_health, acc_37_health_value)
	WriteByte(acc_37_mp, acc_37_mp_value)
	WriteByte(acc_37_str, acc_37_str_value)
	WriteByte(acc_37_def, acc_37_def_value)
	WriteByte(acc_37_ap, acc_37_ap_value)

	WriteByte(acc_38_health, acc_38_health_value)
	WriteByte(acc_38_mp, acc_38_mp_value)
	WriteByte(acc_38_str, acc_38_str_value)
	WriteByte(acc_38_def, acc_38_def_value)
	WriteByte(acc_38_ap, acc_38_ap_value)

	WriteByte(acc_39_health, acc_39_health_value)
	WriteByte(acc_39_mp, acc_39_mp_value)
	WriteByte(acc_39_str, acc_39_str_value)
	WriteByte(acc_39_def, acc_39_def_value)
	WriteByte(acc_39_ap, acc_39_ap_value)

	WriteByte(acc_3A_health, acc_3A_health_value)
	WriteByte(acc_3A_mp, acc_3A_mp_value)
	WriteByte(acc_3A_str, acc_3A_str_value)
	WriteByte(acc_3A_def, acc_3A_def_value)
	WriteByte(acc_3A_ap, acc_3A_ap_value)

	WriteByte(acc_3B_health, acc_3B_health_value)
	WriteByte(acc_3B_mp, acc_3B_mp_value)
	WriteByte(acc_3B_str, acc_3B_str_value)
	WriteByte(acc_3B_def, acc_3B_def_value)
	WriteByte(acc_3B_ap, acc_3B_ap_value)

	WriteByte(acc_3C_health, acc_3C_health_value)
	WriteByte(acc_3C_mp, acc_3C_mp_value)
	WriteByte(acc_3C_str, acc_3C_str_value)
	WriteByte(acc_3C_def, acc_3C_def_value)
	WriteByte(acc_3C_ap, acc_3C_ap_value)

	WriteByte(acc_3D_health, acc_3D_health_value)
	WriteByte(acc_3D_mp, acc_3D_mp_value)
	WriteByte(acc_3D_str, acc_3D_str_value)
	WriteByte(acc_3D_def, acc_3D_def_value)
	WriteByte(acc_3D_ap, acc_3D_ap_value)

	WriteByte(acc_3E_health, acc_3E_health_value)
	WriteByte(acc_3E_mp, acc_3E_mp_value)
	WriteByte(acc_3E_str, acc_3E_str_value)
	WriteByte(acc_3E_def, acc_3E_def_value)
	WriteByte(acc_3E_ap, acc_3E_ap_value)

	WriteByte(acc_3F_health, acc_3F_health_value)
	WriteByte(acc_3F_mp, acc_3F_mp_value)
	WriteByte(acc_3F_str, acc_3F_str_value)
	WriteByte(acc_3F_def, acc_3F_def_value)
	WriteByte(acc_3F_ap, acc_3F_ap_value)

	WriteByte(acc_40_health, acc_40_health_value)
	WriteByte(acc_40_mp, acc_40_mp_value)
	WriteByte(acc_40_str, acc_40_str_value)
	WriteByte(acc_40_def, acc_40_def_value)
	WriteByte(acc_40_ap, acc_40_ap_value)

	WriteByte(acc_41_health, acc_41_health_value)
	WriteByte(acc_41_mp, acc_41_mp_value)
	WriteByte(acc_41_str, acc_41_str_value)
	WriteByte(acc_41_def, acc_41_def_value)
	WriteByte(acc_41_ap, acc_41_ap_value)

	WriteByte(acc_42_health, acc_42_health_value)
	WriteByte(acc_42_mp, acc_42_mp_value)
	WriteByte(acc_42_str, acc_42_str_value)
	WriteByte(acc_42_def, acc_42_def_value)
	WriteByte(acc_42_ap, acc_42_ap_value)

	WriteByte(acc_43_health, acc_43_health_value)
	WriteByte(acc_43_mp, acc_43_mp_value)
	WriteByte(acc_43_str, acc_43_str_value)
	WriteByte(acc_43_def, acc_43_def_value)
	WriteByte(acc_43_ap, acc_43_ap_value)

	WriteByte(acc_44_health, acc_44_health_value)
	WriteByte(acc_44_mp, acc_44_mp_value)
	WriteByte(acc_44_str, acc_44_str_value)
	WriteByte(acc_44_def, acc_44_def_value)
	WriteByte(acc_44_ap, acc_44_ap_value)

	WriteByte(acc_45_health, acc_45_health_value)
	WriteByte(acc_45_mp, acc_45_mp_value)
	WriteByte(acc_45_str, acc_45_str_value)
	WriteByte(acc_45_def, acc_45_def_value)
	WriteByte(acc_45_ap, acc_45_ap_value)

	WriteByte(acc_46_health, acc_46_health_value)
	WriteByte(acc_46_mp, acc_46_mp_value)
	WriteByte(acc_46_str, acc_46_str_value)
	WriteByte(acc_46_def, acc_46_def_value)
	WriteByte(acc_46_ap, acc_46_ap_value)

	WriteByte(acc_47_health, acc_47_health_value)
	WriteByte(acc_47_mp, acc_47_mp_value)
	WriteByte(acc_47_str, acc_47_str_value)
	WriteByte(acc_47_def, acc_47_def_value)
	WriteByte(acc_47_ap, acc_47_ap_value)

	WriteByte(acc_48_health, acc_48_health_value)
	WriteByte(acc_48_mp, acc_48_mp_value)
	WriteByte(acc_48_str, acc_48_str_value)
	WriteByte(acc_48_def, acc_48_def_value)
	WriteByte(acc_48_ap, acc_48_ap_value)

	WriteByte(acc_49_health, acc_49_health_value)
	WriteByte(acc_49_mp, acc_49_mp_value)
	WriteByte(acc_49_str, acc_49_str_value)
	WriteByte(acc_49_def, acc_49_def_value)
	WriteByte(acc_49_ap, acc_49_ap_value)

	WriteByte(acc_4A_health, acc_4A_health_value)
	WriteByte(acc_4A_mp, acc_4A_mp_value)
	WriteByte(acc_4A_str, acc_4A_str_value)
	WriteByte(acc_4A_def, acc_4A_def_value)
	WriteByte(acc_4A_ap, acc_4A_ap_value)

	WriteByte(acc_4B_health, acc_4B_health_value)
	WriteByte(acc_4B_mp, acc_4B_mp_value)
	WriteByte(acc_4B_str, acc_4B_str_value)
	WriteByte(acc_4B_def, acc_4B_def_value)
	WriteByte(acc_4B_ap, acc_4B_ap_value)

	WriteByte(acc_4C_health, acc_4C_health_value)
	WriteByte(acc_4C_mp, acc_4C_mp_value)
	WriteByte(acc_4C_str, acc_4C_str_value)
	WriteByte(acc_4C_def, acc_4C_def_value)
	WriteByte(acc_4C_ap, acc_4C_ap_value)

	WriteByte(acc_4D_health, acc_4D_health_value)
	WriteByte(acc_4D_mp, acc_4D_mp_value)
	WriteByte(acc_4D_str, acc_4D_str_value)
	WriteByte(acc_4D_def, acc_4D_def_value)
	WriteByte(acc_4D_ap, acc_4D_ap_value)

	WriteByte(acc_4E_health, acc_4E_health_value)
	WriteByte(acc_4E_mp, acc_4E_mp_value)
	WriteByte(acc_4E_str, acc_4E_str_value)
	WriteByte(acc_4E_def, acc_4E_def_value)
	WriteByte(acc_4E_ap, acc_4E_ap_value)

	WriteByte(acc_4F_health, acc_4F_health_value)
	WriteByte(acc_4F_mp, acc_4F_mp_value)
	WriteByte(acc_4F_str, acc_4F_str_value)
	WriteByte(acc_4F_def, acc_4F_def_value)
	WriteByte(acc_4F_ap, acc_4F_ap_value)

	WriteByte(acc_50_health, acc_50_health_value)
	WriteByte(acc_50_mp, acc_50_mp_value)
	WriteByte(acc_50_str, acc_50_str_value)
	WriteByte(acc_50_def, acc_50_def_value)
	WriteByte(acc_50_ap, acc_50_ap_value)
end
