using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace OrsonsMod.Items.Placeables
{
    public class NeonBrickWall : ModItem
    {

        public override void SetStaticDefaults()
        {

            Tooltip.SetDefault("Glows a bit");

        }
        public override void SetDefaults()
        {

            item.maxStack = 999;
            item.useTime = 10;
            item.useAnimation = 10;
            item.useStyle = ItemUseStyleID.SwingThrow;
            item.rare = ItemRarityID.Orange;
            item.consumable = true;
            item.createWall = mod.WallType("NeonBrickWall");
            item.autoReuse = true;

        }
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(mod.ItemType("NeonBrick"));

            recipe.AddTile(TileID.Furnaces);
            recipe.SetResult(this, 4);
            recipe.AddRecipe();
        }
    }
}
