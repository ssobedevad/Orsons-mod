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

            Tooltip.SetDefault("The worlds evils combined");
        }

        public override void SetDefaults()
        {
            item.damage = 38;
            item.melee = true;
            item.width = 40;
            item.height = 40;
            item.useTime = 22;
            item.useTurn = true;
            item.useAnimation = 22;
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
            recipe.AddIngredient(mod.ItemType("MuraMini"));
            recipe.AddTile(TileID.DemonAltar);
            recipe.SetResult(this);
            recipe.AddRecipe();
            recipe = new ModRecipe(mod);
            recipe.AddIngredient(mod.ItemType("Puree"));
            recipe.AddIngredient(mod.ItemType("FieryLongDagger"));
            recipe.AddIngredient(mod.ItemType("ThreadOfGrass"));
            recipe.AddIngredient(mod.ItemType("MuraMini"));
            recipe.AddTile(TileID.DemonAltar);
            recipe.SetResult(this);
            recipe.AddRecipe();

        }


    }
}