using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace OrsonsMod.Items.Weapons.Shortswords
{
    public class OrichalcumShortsword : ModItem
    {


        public override void SetDefaults()
        {
            item.damage = 46;
            item.melee = true;
            item.width = 32;
            item.height = 32;
            item.useTime = 22;
            item.useTurn = true;
            item.useAnimation = 22;
            item.useStyle = ItemUseStyleID.Stabbing;
            item.knockBack = 5.2f;
            item.value = 24300;
            item.rare = ItemRarityID.LightRed;
            //item.crit = 2;
            item.UseSound = SoundID.Item1;
            item.autoReuse = false;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.OrichalcumBar, 10);

            recipe.AddTile(TileID.MythrilAnvil);
            recipe.SetResult(this);
            recipe.AddRecipe();


        }


    }
}