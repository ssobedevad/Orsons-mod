using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Localization;
using Microsoft.Xna.Framework;
using System;
using Terraria.DataStructures;
using Terraria.Enums;

namespace OrsonsMod.NPCs
{
    public class CarnageCrimera : ModNPC
    {
        public float speed;
        public int shootCD;
        public override void SetDefaults()
        {
			Main.npcFrameCount[npc.type] = 3;
			npc.CloneDefaults(NPCID.Corruptor);
            animationType = NPCID.Corruptor;
			npc.aiStyle = -1;
            banner = npc.type;
            bannerItem = mod.ItemType("CarnageCrimeraBanner");
            
        }
        public override void AI()
        {
            npc.TargetClosest(true);
            if (shootCD > 0) { shootCD -= 1; }
            float Xdiff = Main.player[npc.target].Center.X - npc.Center.X;
            float YDiff = Main.player[npc.target].Center.Y - npc.Center.Y;
            Vector2 difference = new Vector2(Xdiff, YDiff);
            float Magnitude = Mag(difference);
            if (Main.tile[(int)npc.Bottom.X / 16, (int)npc.Bottom.Y / 16].type == 19)
            { npc.noTileCollide = true; }
            
            speed = 3f;
            if (Magnitude > 30) { speed = 6f; }
            else if (Magnitude > 100) { speed = 8f; }
            else if (Magnitude > 450) { speed = 12f; }
            else if (Magnitude > 650) { speed = 18f; }
            else if (Magnitude > 950) { speed = 25f; }

            Magnitude = speed / Magnitude;
            Xdiff *= Magnitude;
            YDiff *= Magnitude;

            npc.velocity.X = (npc.velocity.X * 100f + Xdiff) / 101f;
            npc.velocity.Y = (npc.velocity.Y * 100f + YDiff) / 101f;
            if (shootCD == 0) { NPC.NewNPC((int)npc.Center.X, (int)npc.Center.Y,ModContent.NPCType<Blood>()); shootCD = 120;npc.noTileCollide = false; }

            npc.rotation = (float)Math.Atan2((double)YDiff, (double)Xdiff) - 1.57f;

            if (((npc.velocity.X > 0f && npc.oldVelocity.X < 0f) || (npc.velocity.X < 0f && npc.oldVelocity.X > 0f) || (npc.velocity.Y > 0f && npc.oldVelocity.Y < 0f) || (npc.velocity.Y < 0f && npc.oldVelocity.Y > 0f)) && !npc.justHit)
			{
				npc.netUpdate = true;
			}
		}
		private Vector2 AimAtPlayer(float projSpeed)
		{
			Player player = Main.player[npc.target];
			Vector2 playerDiff = player.Center - npc.Center;
			float Magnitude = Mag(playerDiff);
			Magnitude = projSpeed / Magnitude;
			return playerDiff *= Magnitude;
		}
		private float Mag(Vector2 mag)
		{
			return (float)Math.Sqrt(mag.X * mag.X + mag.Y * mag.Y);
		}


		public override float SpawnChance(NPCSpawnInfo spawnInfo)
        {

            return (Main.hardMode && spawnInfo.player.ZoneCrimson )? 0.4f : 0f;



        }
        public override void NPCLoot()
        {
            if (Main.rand.Next(3) == 2)
            {
                Item.NewItem(npc.getRect(), ItemID.Vertebrae);
            }
        }
    }
}