using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace OrsonsMod.Items.Weapons.Shortswords
{
    public class PalladiumShortsword : ModItem
    {


        public override void SetDefaults()
        {
            item.damage = 42;
            item.melee = true;
            item.width = 28;
            item.height = 32;
            item.useTime = 22;
            item.useTurn = true;
            item.useAnimation = 22;
            item.useStyle = ItemUseStyleID.Stabbing;
            item.knockBack = 4f;
            item.value = 12800;
            item.rare = ItemRarityID.LightRed;
            //item.crit = 2;
            item.UseSound = SoundID.Item1;
            item.autoReuse = false;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.PalladiumBar, 10);

            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(this);
            recipe.AddRecipe();


        }


    }
}