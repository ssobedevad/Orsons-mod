

using Microsoft.Xna.Framework;
using System.IO;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace OrsonsMod.NPCs
{


	public class SpineShifterHead : SpineShifter
	{


		public override void SetDefaults()
		{

			npc.CloneDefaults(NPCID.DiggerHead);
			npc.aiStyle = -1;
			npc.lifeMax = 125;
			npc.width = 30;
			npc.height = 30;
			npc.damage = 40;    
			npc.defense = 3;
		}

		public override void Init()
		{
			base.Init();
			head = true;
		}

		private int attackCounter;
		public override void SendExtraAI(BinaryWriter writer)
		{
			writer.Write(attackCounter);
		}

		public override void ReceiveExtraAI(BinaryReader reader)
		{
			attackCounter = reader.ReadInt32();
		}

		public override void CustomBehavior()
		{
			if (Main.netMode != NetmodeID.MultiplayerClient)
			{
				if (attackCounter > 0)
				{
					attackCounter--;
				}

				Player target = Main.player[npc.target];
				if (attackCounter <= 0 && Vector2.Distance(npc.Center, target.Center) < 200 && Collision.CanHit(npc.Center, 1, 1, target.Center, 1, 1))
				{
					//Vector2 direction = (target.Center - npc.Center).SafeNormalize(Vector2.UnitX);
					//direction = direction.RotatedByRandom(MathHelper.ToRadians(10));


					attackCounter = 500;
					npc.netUpdate = true;
				}
			}
		}
		public override void NPCLoot()
		{
			Gore.NewGore(npc.Center, npc.velocity + new Vector2(Main.rand.Next(-1, 1), Main.rand.Next(-1, 1)), mod.GetGoreSlot("Gores/SpineShifterHead"), 1f);

		}
	}

	public class SpineShifterBody : SpineShifter
	{


		public override void SetDefaults()
		{
			npc.CloneDefaults(NPCID.DiggerBody);
			npc.aiStyle = -1;
			npc.lifeMax = 125;
			npc.width = 26;
			npc.height = 26;
			npc.damage = 20;
			npc.defense = 7;

		}
		public override void NPCLoot()
		{
			Gore.NewGore(npc.Center, npc.velocity + new Vector2(Main.rand.Next(-1, 1), Main.rand.Next(-1, 1)), mod.GetGoreSlot("Gores/SpineShifterBody"), 1f);

		}
	}

	public class SpineShifterTail : SpineShifter
	{

		public override void SetDefaults()
		{
			npc.CloneDefaults(NPCID.DiggerBody);
			npc.aiStyle = -1;
			npc.lifeMax = 125;
			npc.width = 34;
			npc.height = 34;
			npc.damage = 15;
			npc.defense = 10;

		}

		public override void Init()
		{
			base.Init();
			tail = true;
		}
		public override void NPCLoot()
		{
			Gore.NewGore(npc.Center, npc.velocity + new Vector2(Main.rand.Next(-1, 1), Main.rand.Next(-1, 1)), mod.GetGoreSlot("Gores/SpineShifterTail"), 1f);
			
		}
	}

	// I made this 2nd base class to limit code repetition.
	public abstract class SpineShifter : Worm
	{

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Spine Shifter");
		}

		public override void Init()
		{
			minLength = 10;
			maxLength = 15;
			tailType = NPCType<SpineShifterTail>();
			bodyType = NPCType<SpineShifterBody>();
			headType = NPCType<SpineShifterHead>();
			speed = 10f;
			turnSpeed = 0.08f;
			flies = true;
		}
		public override float SpawnChance(NPCSpawnInfo spawnInfo)
		{

			return Main.tile[(spawnInfo.spawnTileX), (spawnInfo.spawnTileY)].type == TileID.Crimstone ? 0.4f : 0f;



		}
		public override void NPCLoot()
		{

			Item.NewItem(npc.getRect(), ItemID.WormTooth, Main.rand.Next(4, 10));
			if (Main.rand.Next(0, 3) == 1)
			{
				Item.NewItem(npc.getRect(), ItemID.Vertebrae, Main.rand.Next(1, 2));
			}


		}
	}
}