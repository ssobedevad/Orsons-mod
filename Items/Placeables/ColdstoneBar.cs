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
    public class ColdstoneBar : ModItem
    {

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Coldstone Bar");
            Tooltip.SetDefault("Like regular stone bars just colder");

        }
        public override void SetDefaults()
        {
            item.width = 30;
            item.height = 24;
            item.maxStack = 99;
            item.rare = ItemRarityID.Orange;
            item.value = 10000;
            item.useStyle = ItemUseStyleID.SwingThrow;
            item.useTurn = true;
            item.useAnimation = 15;
            item.useTime = 10;
            item.autoReuse = true;
            item.consumable = true;
            item.createTile = mod.TileType("BarPile");
            item.placeStyle = 1;

        }
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(mod.ItemType("ColdstoneOre"), 3);
            
            recipe.AddTile(TileID.Furnaces);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }

    }
}
