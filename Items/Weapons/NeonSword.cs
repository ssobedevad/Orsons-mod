using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace DeadFESHsMod.Items.Weapons
{
	public class NeonSword : ModItem
	{
		public override void SetStaticDefaults()
		{
			
			Tooltip.SetDefault("Emits light");
		}

		public override void SetDefaults()
		{
			item.damage = 22;
			item.melee = true;
			item.width = 40;
			item.height = 40;
			item.useTime = 21;
			item.useTurn = true;
			item.useAnimation = 21;
			item.useStyle = ItemUseStyleID.SwingThrow;
			item.knockBack = 5;
			item.value = 2500;
			item.rare = ItemRarityID.Orange;
			item.crit = 2;
			item.UseSound = SoundID.Item1;
			item.autoReuse = false;
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(mod.ItemType("NeonBar"),15);
			
			recipe.AddTile(TileID.Anvils);
			recipe.SetResult(this);
			recipe.AddRecipe();

			
		}
        public override void MeleeEffects(Player player, Rectangle hitbox)
        {
			Lighting.AddLight((int)((player.Center.X + (float)(hitbox.Width / 2)) / 16f), (int)((player.Center.Y + (float)(hitbox.Height / 2)) / 16f),131 ,91,41 );
		}
    }
}