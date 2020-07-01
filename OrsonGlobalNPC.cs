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
using OrsonsMod.Items.Weapons.Summon;
using OrsonsMod.Items.Weapons.Thrown;
using OrsonsMod.Items.Weapons.Blowpipes;
using OrsonsMod.Items.Weapons.Magic;
using OrsonsMod.Items.Weapons.Bows;
using OrsonsMod.Items.Weapons.Swords;
using OrsonsMod.Items.Tools;


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
            if (!Main.expertMode)
            {
                int rand = Main.rand.Next(1, 5);
                if (npc.type == NPCID.KingSlime) { if (rand == 1) { Item.NewItem(npc.Hitbox, ModContent.ItemType<StickySlimeHand>()); }else if (rand == 2) { Item.NewItem(npc.Hitbox, ModContent.ItemType<SlimedNinjasThrowingGlove>()); } else if (rand == 3) { Item.NewItem(npc.Hitbox, ModContent.ItemType<SlimeSlammer>()); } else if (rand == 2) { Item.NewItem(npc.Hitbox, ModContent.ItemType<SlimeShield>()); } }
                if (npc.type == NPCID.SkeletronHead) { if (rand == 1) { Item.NewItem(npc.Hitbox, ModContent.ItemType<BoneSmack>()); } }
                if (npc.type == NPCID.EyeofCthulhu) { if (rand == 1) { Item.NewItem(npc.Hitbox, ModContent.ItemType<EyeSore>()); } else if (rand == 2) { Item.NewItem(npc.Hitbox, ModContent.ItemType<EyeServantGuardStaff>()); } else if (rand == 3) { Item.NewItem(npc.Hitbox, ModContent.ItemType<Macula>()); } else if (rand == 4) { Item.NewItem(npc.Hitbox, ModContent.ItemType<EyeChaser>()); } }
                if (npc.type == NPCID.EaterofWorldsHead && !NPC.AnyNPCs(NPCID.EaterofWorldsTail)) { if (rand == 1) { Item.NewItem(npc.Hitbox, ModContent.ItemType<ScourgeFork>()); } }
                if (npc.type == NPCID.BrainofCthulhu) { if (rand == 1) { Item.NewItem(npc.Hitbox, ModContent.ItemType<CreeperGuardStaff>()); } else if (rand == 2) { Item.NewItem(npc.Hitbox, ModContent.ItemType<CerrebellumBow>()); } else if (rand == 3) { Item.NewItem(npc.Hitbox, ModContent.ItemType<CraniumBlade>()); } }
            }


        }
    }
}