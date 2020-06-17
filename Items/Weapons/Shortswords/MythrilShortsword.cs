using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace OrsonsMod.Items.Weapons.Shortswords
{
    public class MythrilShortsword : ModItem
    {


        public override void SetDefaults()
        {
            item.damage = 45;
            item.melee = true;
            item.width = 36;
            item.height = 36;
            item.useTime = 24;
            item.useTurn = true;
            item.useAnimation = 24;
            item.useStyle = ItemUseStyleID.Stabbing;
            item.knockBack = 5.2f;
            item.value = 26000;
            item.rare = ItemRarityID.LightRed;
            //item.crit = 2;
            item.UseSound = SoundID.Item1;
            item.autoReuse = false;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.MythrilBar, 8);

            recipe.AddTile(TileID.MythrilAnvil);
            recipe.SetResult(this);
            recipe.AddRecipe();


        }


    }
}