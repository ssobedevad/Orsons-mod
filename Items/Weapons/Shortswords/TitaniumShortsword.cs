using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace OrsonsMod.Items.Weapons.Shortswords
{
    public class TitaniumShortsword : ModItem
    {


        public override void SetDefaults()
        {
            item.damage = 54;
            item.melee = true;
            item.width = 40;
            item.height = 40;
            item.useTime = 22;
            item.useTurn = true;
            item.useAnimation = 22;
            item.useStyle = ItemUseStyleID.Stabbing;
            item.knockBack = 5.2f;
            item.value = 31200;
            item.rare = ItemRarityID.LightRed;
            //item.crit = 2;
            item.UseSound = SoundID.Item1;
            item.autoReuse = false;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.TitaniumBar, 10);

            recipe.AddTile(TileID.MythrilAnvil);
            recipe.SetResult(this);
            recipe.AddRecipe();


        }


    }
}