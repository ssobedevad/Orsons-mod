﻿using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Localization;
using Microsoft.Xna.Framework;
using System;

namespace OrsonsMod.NPCs
{
    public class FoamyZombie : ModNPC
    {

        public override void SetDefaults()
        {

            npc.width = 34;
            npc.height = 46;
            npc.damage = 17;
            npc.defense = 8;
            npc.value = 200;
            npc.lifeMax = 60;
            npc.aiStyle = 3;
            npc.knockBackResist = 0.55f;
            npc.HitSound = SoundID.NPCHit1;
            npc.DeathSound = SoundID.NPCDeath2;
            Main.npcFrameCount[npc.type] = 3;
            
            animationType = NPCID.Zombie;
            banner = npc.type;
            bannerItem = mod.ItemType("FoamyZombieBanner");

        }
        public override float SpawnChance(NPCSpawnInfo spawnInfo)
        {

            return (!Main.dayTime) ? 0.05f : 0f;



        }
        public override void OnHitPlayer(Player target, int damage, bool crit)
        {
            target.AddBuff(mod.BuffType("Diseased"), 600);

        }
        public override void NPCLoot()
        {
            Gore.NewGore(npc.Center, npc.velocity + new Vector2(Main.rand.Next(-1, 1), Main.rand.Next(-1, 1)), mod.GetGoreSlot("Gores/FoamyZombieHead"), 1f);
            Gore.NewGore(npc.Center, npc.velocity + new Vector2(Main.rand.Next(-1, 1), Main.rand.Next(-1, 1)), mod.GetGoreSlot("Gores/FoamyZombieArm"), 1f);
            Gore.NewGore(npc.Center, npc.velocity + new Vector2(Main.rand.Next(-1, 1), Main.rand.Next(-1, 1)), mod.GetGoreSlot("Gores/FoamyZombieLeg"), 1f);
            if (Main.rand.Next(2) == 1)
            {
                Item.NewItem(npc.getRect(), mod.ItemType("RabidFoam"), 1);
            }
        }
    }
}