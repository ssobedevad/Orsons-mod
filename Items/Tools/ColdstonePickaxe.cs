using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace OrsonsMod.Items.Tools
{
    public class ColdstonePickaxe : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Coldstone Pickaxe");
            Tooltip.SetDefault("What better to mine with than stone so cold it sticks to your hands?");
        }

        public override void SetDefaults()
        {
            item.damage = 9;

            item.melee = true;

            item.useTurn = true;
            item.rare = ItemRarityID.Blue;
            item.knockBack = 3f;
            item.useTime = 20;
            item.autoReuse = true;
            item.useStyle = ItemUseStyleID.SwingThrow;

            item.useAnimation = 20;
            item.pick = 85;
           
            item.value = 3600;
        }
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(mod.ItemType("ColdstoneBar"), 12);

            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }



    }
}
