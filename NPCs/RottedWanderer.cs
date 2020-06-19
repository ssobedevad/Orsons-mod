using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Localization;
using Microsoft.Xna.Framework;
using System;

namespace OrsonsMod.NPCs
{
    public class RottedWanderer : ModNPC
    {
       
        public override void SetDefaults()
        {

            npc.width = 34;               
            npc.height = 64;              
            npc.damage = 20;
            npc.defense = 8;
            npc.value = 200;
            npc.lifeMax = 85;
            npc.aiStyle = 3;
            npc.knockBackResist = 0.45f;
            npc.HitSound = SoundID.NPCHit13;
            npc.DeathSound = SoundID.NPCDeath5;
            Main.npcFrameCount[npc.type] = 16;
            npc.buffImmune[BuffID.Poisoned] = true;
            npc.buffImmune[BuffID.Venom] = true;
            animationType = NPCID.FaceMonster;
            banner = npc.type;
            bannerItem = mod.ItemType("RottedWandererBanner");

        }
        public override float SpawnChance(NPCSpawnInfo spawnInfo)
        {

            return spawnInfo.player.ZoneCorrupt ? 0.4f : 0f;



        }
        public override void NPCLoot()
        {
            if (Main.rand.Next(3) == 2)
            {
                Item.NewItem(npc.getRect(), ItemID.RottenChunk, 1);
            }
        }
    }
}