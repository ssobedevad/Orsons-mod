using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace OrsonsMod.Items.Tools
{
    public class ColdstoneHamaxe : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Coldstone Hamaxe");
            Tooltip.SetDefault("What better to chop down trees with than stone so cold it sticks to your hands?");
        }

        public override void SetDefaults()
        {
            item.damage = 20;

            item.melee = true;

            item.useTurn = true;
            item.rare = ItemRarityID.Blue;
            item.knockBack = 7f;
            item.useTime = 30;
            item.autoReuse = true;
            item.useStyle = ItemUseStyleID.SwingThrow;

            item.useAnimation = 30;
            item.axe = 20;
            item.hammer = 60;

            item.value = 3000;
        }
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(mod.ItemType("ColdstoneBar"), 20);

            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
        
        

    }
}
