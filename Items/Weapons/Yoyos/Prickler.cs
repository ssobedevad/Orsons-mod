
using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace OrsonsMod.Items.Weapons.Yoyos
{
	public class Prickler : ModItem
	{
		public override void SetStaticDefaults()
		{
			Tooltip.SetDefault("A cactus on a string"+"\n2 Armor Penetration");

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
			item.knockBack = 2.5f;
			item.damage = 12;
			item.rare = ItemRarityID.White;

			item.melee = true;
			item.channel = true;
			item.noMelee = true;
			item.noUseGraphic = true;

			item.UseSound = SoundID.Item1;
			item.value = 1000;
			item.shoot = mod.ProjectileType("Prickler");
		}

		// Make sure that your item can even receive these prefixes (check the vanilla wiki on prefixes)
		// These are the ones that reduce damage of a melee weapon
		

		

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			
			recipe.AddIngredient(ItemID.Cactus,25);
			recipe.AddIngredient(ItemID.Cobweb,30);
			recipe.AddTile(TileID.WorkBenches);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}