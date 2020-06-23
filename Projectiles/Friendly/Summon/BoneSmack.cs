﻿using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Microsoft.Xna.Framework;
using OrsonsMod.Buffs.Debuffs;
using OrsonsMod.Projectiles.Friendly.Summon;
using OrsonsMod.Buffs.Buffs;

namespace OrsonsMod.Projectiles.Friendly.Summon
{
    public class BoneSmack : WhipClass
    {

        public override void SafeSetDefaults()
        {
            summonTagDamage = 5;
            buffGivenToPlayer = ModContent.BuffType<NecroticBastion>();
            buffTime = 120;
            rangeMult = 0.5f;
            
        }





    }
}
