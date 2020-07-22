using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Localization;
using Microsoft.Xna.Framework;
using System;
using Terraria.GameContent;
using Microsoft.Xna.Framework.Graphics;

namespace OrsonsMod.NPCs
{
    public class IchorVein : ModNPC
    {

        public override void SetDefaults()
        {

            npc.CloneDefaults(NPCID.Clinger);
			npc.aiStyle = -1;
			Main.npcFrameCount[npc.type] = 5;
			animationType = NPCID.Clinger;
			banner = npc.type;
			bannerItem = mod.ItemType("IchorVeinBanner");

		}
		public override void AI()
        {
			if(npc.ai[0] == 0) { int npcXTile = (int)(npc.Center.X / 16f)-5; int npcYTile = (int)(npc.Center.Y / 16f)-5; for (int i = 0; i < 10; i ++) { for (int j = 0; j < 10; j++) { if (Main.tile[npcXTile+i, npcYTile+j].active() && Main.tileSolid[Main.tile[npcXTile + i, npcYTile + j].type]) { npc.ai[0] = npcXTile + i; npc.ai[1] = npcYTile + j;break;  } } } }
			if (npc.ai[0] < 0f || npc.ai[0] >= (float)Main.maxTilesX || npc.ai[1] < 0f || npc.ai[1] >= (float)Main.maxTilesX)
			{
				return;
			}
			if (Main.tile[(int)npc.ai[0], (int)npc.ai[1]] == null)
			{
				Main.tile[(int)npc.ai[0], (int)npc.ai[1]] = new Tile();
			}
			if (!Main.tile[(int)npc.ai[0], (int)npc.ai[1]].active())
			{
				npc.life = -1;
				npc.HitEffect();
				npc.active = false;
				return;
			}
			FixExploitManEaters.ProtectSpot((int)npc.ai[0], (int)npc.ai[1]);
			npc.TargetClosest();
			float num191 = 0.035f;
			float num192 = 175f;
			
			npc.ai[2] += 1f;
			if (npc.ai[2] > 300f)
			{
				num192 = (int)((double)num192 * 1.3);
				if (npc.ai[2] > 450f)
				{
					npc.ai[2] = 0f;
				}
			}
			Vector2 vector22 = new Vector2(npc.ai[0] * 16f + 8f, npc.ai[1] * 16f + 8f);
			float num193 = Main.player[npc.target].position.X + (float)(Main.player[npc.target].width / 2) - (float)(npc.width / 2) - vector22.X;
			float num194 = Main.player[npc.target].position.Y + (float)(Main.player[npc.target].height / 2) - (float)(npc.height / 2) - vector22.Y;
			float num195 = (float)Math.Sqrt(num193 * num193 + num194 * num194);
			if (num195 > num192)
			{
				num195 = num192 / num195;
				num193 *= num195;
				num194 *= num195;
			}
			if (npc.position.X < npc.ai[0] * 16f + 8f + num193)
			{
				npc.velocity.X += num191;
				if (npc.velocity.X < 0f && num193 > 0f)
				{
					npc.velocity.X += num191 * 1.5f;
				}
			}
			else if (npc.position.X > npc.ai[0] * 16f + 8f + num193)
			{
				npc.velocity.X -= num191;
				if (npc.velocity.X > 0f && num193 < 0f)
				{
					npc.velocity.X -= num191 * 1.5f;
				}
			}
			if (npc.position.Y < npc.ai[1] * 16f + 8f + num194)
			{
				npc.velocity.Y += num191;
				if (npc.velocity.Y < 0f && num194 > 0f)
				{
					npc.velocity.Y += num191 * 1.5f;
				}
			}
			else if (npc.position.Y > npc.ai[1] * 16f + 8f + num194)
			{
				npc.velocity.Y -= num191;
				if (npc.velocity.Y > 0f && num194 < 0f)
				{
					npc.velocity.Y -= num191 * 1.5f;
				}
			}
			
				if (npc.velocity.X > 2f)
				{
					npc.velocity.X = 2f;
				}
				if (npc.velocity.X < -2f)
				{
					npc.velocity.X = -2f;
				}
				if (npc.velocity.Y > 2f)
				{
					npc.velocity.Y = 2f;
				}
				if (npc.velocity.Y < -2f)
				{
					npc.velocity.Y = -2f;
				}
			
			
			
				if (num193 > 0f)
				{
				npc.spriteDirection = 1;
				npc.rotation = (float)Math.Atan2(num194, num193);
				}
				if (num193 < 0f)
				{
				npc.spriteDirection = -1;
				npc.rotation = (float)Math.Atan2(num194, num193) + 3.14f;
				}
			
			if (npc.collideX)
			{
				npc.netUpdate = true;
				npc.velocity.X = npc.oldVelocity.X * -0.7f;
				if (npc.velocity.X > 0f && npc.velocity.X < 2f)
				{
					npc.velocity.X = 2f;
				}
				if (npc.velocity.X < 0f && npc.velocity.X > -2f)
				{
					npc.velocity.X = -2f;
				}
			}
			if (npc.collideY)
			{
				npc.netUpdate = true;
				npc.velocity.Y = npc.oldVelocity.Y * -0.7f;
				if (npc.velocity.Y > 0f && npc.velocity.Y < 2f)
				{
					npc.velocity.Y = 2f;
				}
				if (npc.velocity.Y < 0f && npc.velocity.Y > -2f)
				{
					npc.velocity.Y = -2f;
				}
			}
			if (Main.netMode == NetmodeID.MultiplayerClient)
			{
				return;
			}
			
				if (npc.justHit)
				{
				npc.localAI[0] = 0f;
				}
			npc.localAI[0] += 1f;
				if (npc.localAI[0] >= 120f)
				{
					if (!Collision.SolidCollision(npc.position, npc.width, npc.height) && Collision.CanHit(npc.position, npc.width, npc.height, Main.player[npc.target].position, Main.player[npc.target].width, Main.player[npc.target].height))
					{
						float num196 = 10f;
						vector22 = new Vector2(npc.position.X + (float)npc.width * 0.5f, npc.position.Y + (float)npc.height * 0.5f);
						num193 = Main.player[npc.target].position.X + (float)Main.player[npc.target].width * 0.5f - vector22.X + (float)Main.rand.Next(-10, 11);
						num194 = Main.player[npc.target].position.Y + (float)Main.player[npc.target].height * 0.5f - vector22.Y + (float)Main.rand.Next(-10, 11);
						num195 = (float)Math.Sqrt(num193 * num193 + num194 * num194);
						num195 = num196 / num195;
						num193 *= num195;
						num194 *= num195;
						int attackDamage_ForProjectiles2 = 30;
						int num197 = ProjectileID.GoldenShowerHostile;
						int num198 = Projectile.NewProjectile(vector22.X, vector22.Y, num193, num194, num197, attackDamage_ForProjectiles2, 0f, Main.myPlayer);
						Main.projectile[num198].timeLeft = 300;
					npc.localAI[0] = 0f;
					}
					else
					{
					npc.localAI[0] = 100f;
					}
				}
			
			
			
		}
		public override bool PreDraw(SpriteBatch spriteBatch, Color drawColor)
		{
			
			Vector2 vector = new Vector2(npc.position.X + (float)(npc.width / 2), npc.position.Y + (float)(npc.height / 2));
			float num = npc.ai[0] * 16f + 8f - vector.X;
			float num2 = npc.ai[1] * 16f + 8f - vector.Y;
			float rotation = (float)Math.Atan2(num2, num) - 1.57f;
			bool flag4 = true;
			while (flag4)
			{
				float num3 = 0.75f;
				int height = 28;
				float num4 = (float)Math.Sqrt(num * num + num2 * num2);
				if (num4 < 28f * num3)
				{
					height = (int)num4 - 40 + 28;
					flag4 = false;
				}
				num4 = 20f * num3 / num4;
				num *= num4;
				num2 *= num4;
				vector.X += num;
				vector.Y += num2;
				num = npc.ai[0] * 16f + 8f - vector.X;
				num2 = npc.ai[1] * 16f + 8f - vector.Y;
				Microsoft.Xna.Framework.Color color = Lighting.GetColor((int)vector.X / 16, (int)(vector.Y / 16f));
				
				
					
					spriteBatch.Draw(mod.GetTexture("NPCs/IchorVeinChain"),
                      new Vector2(vector.X - Main.screenPosition.X, vector.Y - Main.screenPosition.Y),
                      new Microsoft.Xna.Framework.Rectangle(0, 0, 34, 30), color, rotation,
                      new Vector2((float)34 * 0.5f, (float)30 * 0.5f), num3, SpriteEffects.None, 0f);
				
				
			}
			return true;
		}
        public override float SpawnChance(NPCSpawnInfo spawnInfo)
        {
			return (Main.hardMode && spawnInfo.player.ZoneCrimson && spawnInfo.player.ZoneRockLayerHeight) ? 0.4f : 0f;
		}
        public override void NPCLoot()
        {
			Gore.NewGore(npc.Center, npc.velocity + new Vector2(Main.rand.Next(-1, 1), Main.rand.Next(-1, 1)), mod.GetGoreSlot("Gores/VeinGoreEye"), 1f);
			Gore.NewGore(npc.Center, npc.velocity + new Vector2(Main.rand.Next(-1, 1), Main.rand.Next(-1, 1)), mod.GetGoreSlot("Gores/VeinGoreHead"), 1f);
			Gore.NewGore(npc.Center, npc.velocity + new Vector2(Main.rand.Next(-1, 1), Main.rand.Next(-1, 1)), mod.GetGoreSlot("Gores/VeinGoreJaw"), 1f);
			if (Main.rand.Next(2) == 1)
            {
                Item.NewItem(npc.getRect(),ItemID.Ichor, Main.rand.Next(2,6));
            }
        }
    }
}