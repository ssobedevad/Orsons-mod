using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace OrsonsMod.Items.Weapons.Shortswords
{
    public class LightsVale : ModItem
    {
        public override void SetStaticDefaults()
        {

            Tooltip.SetDefault("Heavenly");
        }

        public override void SetDefaults()
        {
            item.damage = 60;
            item.melee = true;
            item.width = 32;
            item.height = 32;
            item.useTime = 15;
            item.useTurn = true;
            item.useAnimation = 15;
            item.useStyle = ItemUseStyleID.Stabbing;
            item.knockBack = 4.5f;
            item.value = 4300;
            item.rare = ItemRarityID.Pink;
            item.crit = 2;
            item.UseSound = SoundID.Item1;
            item.autoReuse = false;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.HallowedBar, 10);

            recipe.AddTile(TileID.MythrilAnvil);
            recipe.SetResult(this);
            recipe.AddRecipe();


        }


    }
}