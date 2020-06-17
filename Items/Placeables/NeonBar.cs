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
    public class NeonBar : ModItem
    {

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Neon Bar");
            Tooltip.SetDefault("It radiates a warm glow of light");

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
            item.createTile = mod.TileType("NeonBar");
            item.placeStyle = 0;
            
        }
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(mod.ItemType("NeonScrap"), 2);
            recipe.AddIngredient(ItemID.MeteoriteBar);
            recipe.AddTile(TileID.Furnaces);
            recipe.SetResult(this,2);
            recipe.AddRecipe();
        }
        
    }
}
