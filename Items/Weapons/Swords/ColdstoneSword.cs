using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace OrsonsMod.Items.Weapons.Swords
{
	public class ColdstoneSword : ModItem
	{
		public override void SetStaticDefaults()
		{

			Tooltip.SetDefault("Made of stone thats unusually cold");
		}

		public override void SetDefaults()
		{
			item.damage = 32;
			item.melee = true;
			item.width = 48;
			item.height = 48;
			item.useTime = 20;
			item.useTurn = true;
			item.useAnimation = 20;
			item.useStyle = ItemUseStyleID.SwingThrow;
			item.knockBack = 3;
			item.value = 10000;
			item.rare = ItemRarityID.Orange;
			item.crit = 1;
			item.UseSound = SoundID.Item1;
			item.autoReuse = false;
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(mod.ItemType("ColdstoneBar"), 18);

			recipe.AddTile(TileID.Anvils);
			recipe.SetResult(this);
			recipe.AddRecipe();


		}
		public override void MeleeEffects(Player player, Rectangle hitbox)
		{
			int dustid = Dust.NewDust(hitbox.BottomLeft(), hitbox.Width, hitbox.Height, DustID.Ice);
			Main.dust[dustid].noGravity = true;
		}
	}
}