using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace OrsonsMod.Items.Weapons.Shortswords
{
    public class NightsTip : ModItem
    {
        public override void SetStaticDefaults()
        {

            Tooltip.SetDefault("No real reason to make this over any other weapon");
        }

        public override void SetDefaults()
        {
            item.damage = 38;
            item.melee = true;
            item.width = 36;
            item.height = 38;
            item.useTime = 24;
            item.useTurn = true;
            item.useAnimation = 24;
            item.useStyle = ItemUseStyleID.Stabbing;
            item.knockBack = 4;
            item.value = 38000;
            item.rare = ItemRarityID.Orange;
            //item.crit = 2;
            item.UseSound = SoundID.Item1;
            item.autoReuse = false;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(mod.ItemType("VoidedKnife"));
            recipe.AddIngredient(mod.ItemType("FieryLongDagger"));
            recipe.AddIngredient(mod.ItemType("ThreadOfGrass"));
            recipe.AddTile(TileID.DemonAltar);
            recipe.SetResult(this);
            recipe.AddRecipe();
            recipe = new ModRecipe(mod);
            recipe.AddIngredient(mod.ItemType("Puree"));
            recipe.AddIngredient(mod.ItemType("FieryLongDagger"));
            recipe.AddIngredient(mod.ItemType("ThreadOfGrass"));
            recipe.AddTile(TileID.DemonAltar);
            recipe.SetResult(this);
            recipe.AddRecipe();

        }


    }
}