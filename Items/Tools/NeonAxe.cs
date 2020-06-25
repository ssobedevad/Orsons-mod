using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace OrsonsMod.Items.Tools
{
    public class NeonAxe : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Neon axe");
            Tooltip.SetDefault("Chops quick and glows");
        }

        public override void SetDefaults()
        {
            item.damage = 9;

            item.melee = true;

            item.useTurn = true;
            item.rare = ItemRarityID.Green;
            item.knockBack = 3f;
            item.useTime = 25;
            item.autoReuse = true;
            item.useStyle = ItemUseStyleID.SwingThrow;
           
            item.useAnimation = 25;
            item.axe = 18;

            item.value = 1800;
        }
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(mod.ItemType("NeonBar"), 13);

            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
        public override void MeleeEffects(Player player, Rectangle hitbox)
        {
            Lighting.AddLight((int)((player.Center.X + (float)(hitbox.Width / 2)) / 16f), (int)((player.Center.Y + (float)(hitbox.Height / 2)) / 16f), 1.5f, 1.5f, 1.5f);
        }
        public override void UpdateInventory(Player player)
        {
            if (player.HeldItem == this.item || Main.mouseItem == this.item) { player.pickSpeed -= 2; }
        }

    }
}
