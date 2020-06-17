using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace OrsonsMod.Items.Weapons.Shortswords
{
    public class AdamantiteShortsword : ModItem
    {


        public override void SetDefaults()
        {
            item.damage = 52;
            item.melee = true;
            item.width = 38;
            item.height = 38;
            item.useTime = 23;
            item.useTurn = true;
            item.useAnimation = 23;
            item.useStyle = ItemUseStyleID.Stabbing;
            item.knockBack = 5.2f;
            item.value = 26600;
            item.rare = ItemRarityID.LightRed;
            //item.crit = 2;
            item.UseSound = SoundID.Item1;
            item.autoReuse = false;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.AdamantiteBar, 8);

            recipe.AddTile(TileID.MythrilAnvil);
            recipe.SetResult(this);
            recipe.AddRecipe();


        }


    }
}