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

namespace DeadFESHsMod
{

    class DFMGlobalNPC : GlobalNPC
    {
        


        public override void NPCLoot(NPC npc)
        {
            // We check several things that filter out bosses and critters, as well as the depth that the npc died at. 
            if ( npc.Center.Y > Main.rockLayer * 16 && Main.rand.Next(0, 15) == 0)
            {
                if (Main.player[Player.FindClosest(npc.position, npc.width, npc.height)].ZoneCrimson)
                {
                    NPC.NewNPC((int)npc.Center.X, (int)npc.Center.Y, mod.NPCType("IchorEssence"));
                }
            }
            

        }
    }
}