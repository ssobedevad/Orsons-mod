
using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace OrsonsMod.Items.Weapons.Yoyos
{
	public class BoneDaddy : ModItem
	{
		public override void SetStaticDefaults()
		{
			Tooltip.SetDefault("A Big Boney Boi on a string" + "\n3 Armor Penetration");

			// These are all related to gamepad controls and don't seem to affect anything else
			ItemID.Sets.Yoyo[item.type] = true;

		}

		public override void SetDefaults()
		{
			item.useStyle = ItemUseStyleID.HoldingOut;
			item.width = 38;
			item.height = 34;
			item.useAnimation = 25;
			item.useTime = 25;
			item.shootSpeed = 16f;
			item.knockBack = 4f;
			item.damage = 20;
			item.rare = ItemRarityID.Orange;

			item.melee = true;
			item.channel = true;
			item.noMelee = true;
			item.noUseGraphic = true;

			item.UseSound = SoundID.Item1;
			item.value = 1000;
			item.shoot = mod.ProjectileType("BoneDaddy");
		}

		// Make sure that your item can even receive these prefixes (check the vanilla wiki on prefixes)
		// These are the ones that reduce damage of a melee weapon




		
	}
}