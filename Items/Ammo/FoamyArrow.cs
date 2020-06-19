using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using OrsonsMod.Items.Materials;

namespace OrsonsMod.Items.Ammo
{
    public class FoamyArrow : ModItem
    {
        public override void SetDefaults()
        {
            item.damage = 6;
            item.ranged = true;
            item.width = 7;
            item.height = 7;
            item.maxStack = 999;
            item.consumable = true;
            item.knockBack = 5;
            item.value = 75; 
            item.rare = ItemRarityID.Blue;
            item.shoot = mod.ProjectileType("FoamyArrow");
            item.ammo = AmmoID.Arrow;

        }
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.WoodenArrow,100);
            recipe.AddIngredient(ModContent.ItemType<RabidFoam>(),5);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(this, 100);
            recipe.AddRecipe();
        }
    }
}
