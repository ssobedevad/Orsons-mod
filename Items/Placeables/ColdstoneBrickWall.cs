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
    public class ColdstoneBrickWall : ModItem
    {

        public override void SetStaticDefaults()
        {

            Tooltip.SetDefault("Like regular stone brick wall just colder");

        }
        public override void SetDefaults()
        {

            item.maxStack = 999;
            item.useTime = 10;
            item.useAnimation = 10;
            item.useStyle = ItemUseStyleID.SwingThrow;
            item.rare = ItemRarityID.Orange;
            item.consumable = true;
            item.createWall = mod.WallType("ColdstoneBrickWall");
            item.autoReuse = true;

        }
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(mod.ItemType("ColdstoneBrick"));
            
            recipe.AddTile(TileID.Furnaces);
            recipe.SetResult(this, 4);
            recipe.AddRecipe();
        }
    }
}
