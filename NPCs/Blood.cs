using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Localization;
using Microsoft.Xna.Framework;
using System;
using Steamworks;

namespace OrsonsMod.NPCs
{
	public class Blood : ModNPC
	{

		public override void SetDefaults()
		{

			npc.CloneDefaults(NPCID.VileSpit);
			npc.aiStyle = -1;	
			

		}
		public override void AI()
		{
			if (npc.target == 255)
			{
				npc.TargetClosest();
				float num126 = 7f;


				Vector2 vector14 = new Vector2(npc.position.X + (float)npc.width * 0.5f, npc.position.Y + (float)npc.height * 0.5f);
				float num127 = Main.player[npc.target].position.X + (float)(Main.player[npc.target].width / 2) - vector14.X;
				float num128 = Main.player[npc.target].position.Y + (float)(Main.player[npc.target].height / 2) - vector14.Y;
				float num129 = (float)Math.Sqrt(num127 * num127 + num128 * num128);
				num129 = num126 / num129;
				npc.velocity.X = num127 * num129;
				npc.velocity.Y = num128 * num129;
			}
			npc.damage = npc.defDamage;
			if (npc.ai[1] == 1f)
			{
				npc.damage = 65;
			}
			npc.ai[0] += 1f;
			if (npc.ai[0] > 3f)
			{
				npc.ai[0] = 3f;
			}
			if (npc.ai[0] == 2f)
			{
				npc.position += npc.velocity;
				Main.PlaySound(4, (int)npc.position.X, (int)npc.position.Y, 9);
				for (int num130 = 0; num130 < 20; num130++)
				{
					int num131 = Dust.NewDust(new Vector2(npc.position.X, npc.position.Y + 2f) + Vector2.Zero, npc.width, npc.height, DustID.Blood, 0f, 0f, 100, default(Color), 1.8f);
					Dust dust = Main.dust[num131];
					dust.velocity *= 1.3f;
					dust = Main.dust[num131];
					dust.velocity += npc.velocity;
					Main.dust[num131].noGravity = true;
				}
			}

			if (Collision.SolidCollision(npc.position, npc.width, npc.height))
			{
				_ = Main.netMode;
				_ = 1;
				npc.StrikeNPCNoInteraction(9999, 0f, 0);
			}


			npc.position += Vector2.Zero;
			for (int i = 0; i < 2; i++)
			{

				int num144 = Dust.NewDust(new Vector2(npc.position.X, npc.position.Y + 2f), npc.width, npc.height, DustID.Blood, npc.velocity.X * 0.1f, npc.velocity.Y * 0.1f, 80, default(Color), 1.3f);
				Dust dust = Main.dust[num144];
				dust.velocity *= 0.3f;
				Main.dust[num144].noGravity = true;


			}
			npc.rotation += 0.4f * (float)npc.direction;
			npc.position -= Vector2.Zero;
		}
		public override void NPCLoot()
		{
			for (int i = 0; i < 8; i++)
			{

				int num144 = Dust.NewDust(new Vector2(npc.position.X, npc.position.Y), npc.width, npc.height, DustID.Blood, npc.velocity.X * 0.1f, npc.velocity.Y * 0.1f, 80, default(Color), 1.8f);
				Dust dust = Main.dust[num144];
				dust.velocity *= 0.3f;
				Main.dust[num144].noGravity = true;


			}
		}
	}
}
