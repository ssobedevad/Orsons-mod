using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace OrsonsMod.Items.Tools
{
    public class NeonPickaxe : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Neon pickaxe");
            Tooltip.SetDefault("Mines quick and glows");
        }

        public override void SetDefaults()
        {
            item.damage = 9;

            item.melee = true;

            item.useTurn = true;
            item.rare = ItemRarityID.Blue;
            item.width = 36;
            item.height = 36;
            item.useTime = 18;
            item.autoReuse = true;
            item.useStyle = ItemUseStyleID.SwingThrow;
            item.shootSpeed = 14f;
            item.useAnimation = 18;
            item.pick = 59;
            
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
