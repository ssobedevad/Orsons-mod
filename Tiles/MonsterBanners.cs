﻿using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.DataStructures;
using Terraria.Enums;
using Terraria.ModLoader;
using Terraria.ObjectData;
using static Terraria.ModLoader.ModContent;

namespace OrsonsMod.Tiles
{
	public class MonsterBanners : ModTile
	{
		public override void SetDefaults()
		{
			Main.tileFrameImportant[Type] = true;
			Main.tileNoAttach[Type] = true;
			Main.tileLavaDeath[Type] = true;
			TileObjectData.newTile.CopyFrom(TileObjectData.Style1x2Top);
			TileObjectData.newTile.Height = 3;
			TileObjectData.newTile.CoordinateHeights = new[] { 16, 16, 16 };
			TileObjectData.newTile.StyleHorizontal = true;
			TileObjectData.newTile.AnchorTop = new AnchorData(AnchorType.SolidTile | AnchorType.SolidSide | AnchorType.SolidBottom, TileObjectData.newTile.Width, 0);
			TileObjectData.newTile.StyleWrapLimit = 111;
			TileObjectData.addTile(Type);
			dustType = -1;
			disableSmartCursor = true;
			ModTranslation name = CreateMapEntryName();
			name.SetDefault("Banner");
			AddMapEntry(new Color(13, 88, 130), name);
		}

		public override void KillMultiTile(int i, int j, int frameX, int frameY)
		{
			int style = frameX / 18;
			string item;
			switch (style)
			{
				case 0:
					item = "IchorEssenceBanner";
					break;
				case 1:
					item = "SpineShifterBanner";
					break;
				case 2:
					item = "ScourgeCrawlerBanner";
					break;
				case 3:
					item = "NeonProbeBanner";
					break;
				case 4:
					item = "RottedWandererBanner";
					break;
				case 5:
					item = "CursedEssenceBanner";
					break;
				case 6:
					item = "FoamyZombiebanner";
					break;
				case 7:
					item = "CarnageCrimeraBanner";
					break;
				case 8:
					item = "CursedPharaohBanner";
					break;
				default:
					return;
			}
			Item.NewItem(i * 16, j * 16, 16, 48, mod.ItemType(item));
		}

		public override void NearbyEffects(int i, int j, bool closer)
		{
			if (closer)
			{
				Player player = Main.LocalPlayer;
				int style = Main.tile[i, j].frameX / 18;
				string type;
				switch (style)
				{
					case 0:
						type = "IchorEssence";
						break;
					case 1:
						type = "SpineShifterHead";
						
						break;
					case 2:
						type = "ScourgeCrawler";
						
						break;
					case 3:
						type = "NeonProbe";
						break;
					case 4:
						type = "RottedWanderer";
						break;
					case 5:
						type = "CursedEssence";
						break;
					case 6:
						type = "FoamyZombie";
						break;
					case 7:
						type = "CarnageCrimera";
						break;
					case 8:
						type = "CursedPharaoh";
						break;
					default:
						return;
				}
				player.NPCBannerBuff[mod.NPCType(type)] = true;
				player.hasBanner = true;
			}
		}

		public override void SetSpriteEffects(int i, int j, ref SpriteEffects spriteEffects)
		{
			if (i % 2 == 1)
			{
				spriteEffects = SpriteEffects.FlipHorizontally;
			}
		}
	}
}