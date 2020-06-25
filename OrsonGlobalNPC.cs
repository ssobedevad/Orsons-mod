using System.IO;
using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ModLoader.IO;
using Terraria.World.Generation;
using Microsoft.Xna.Framework;
using Terraria.GameContent.Generation;
using System.Linq;
using Terraria.DataStructures;
using Terraria.Localization;
using System;
using OrsonsMod.Items.Weapons.Summon.Whips;
using OrsonsMod.Items.Weapons.Flails;
using OrsonsMod.Items.Weapons.Spears;

namespace OrsonsMod
{

    class DFMGlobalNPC : GlobalNPC
    {
        


        public override void NPCLoot(NPC npc)
        {
            // We check several things that filter out bosses and critters, as well as the depth that the npc died at. 
            if ( npc.Center.Y > Main.rockLayer && Main.rand.Next(0, 15) == 0 && Main.hardMode)
            {
                Player ClosestPlayer = Main.player[Player.FindClosest(npc.position, npc.width, npc.height)];
                if(ClosestPlayer.ZoneRockLayerHeight)
                { 
                if (ClosestPlayer.ZoneCrimson)
                {
                    NPC.NewNPC((int)npc.Center.X, (int)npc.Center.Y, mod.NPCType("IchorEssence"));
                }
                    if (ClosestPlayer.ZoneCorrupt)
                    {
                        NPC.NewNPC((int)npc.Center.X, (int)npc.Center.Y, mod.NPCType("CursedEssence"));
                    }
                }
            }
            if(npc.type == NPCID.KingSlime) { if (Main.rand.Next(0, 4) == 1) { Item.NewItem(npc.Hitbox, ModContent.ItemType<StickySlimeHand>()); } }
            if (npc.type == NPCID.SkeletronHead) { if (Main.rand.Next(0, 4) == 1) { Item.NewItem(npc.Hitbox, ModContent.ItemType<BoneSmack>()); } }
            if (npc.type == NPCID.EyeofCthulhu) { if (Main.rand.Next(0, 4) == 1) { Item.NewItem(npc.Hitbox, ModContent.ItemType<EyeSore>()); } }
            if (npc.type == NPCID.EaterofWorldsHead && !NPC.AnyNPCs(NPCID.EaterofWorldsTail)) { if (Main.rand.Next(0, 4) == 1) { Item.NewItem(npc.Hitbox, ModContent.ItemType<ScourgeFork>()); } }


        }
    }
}