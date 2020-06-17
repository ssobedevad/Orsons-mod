using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace OrsonsMod.Items.Weapons.Shortswords
{
    public class TrueLightsVale : ModItem
    {
        public override void SetStaticDefaults()
        {

            Tooltip.SetDefault("Truly heavenly");
        }

        public override void SetDefaults()
        {
            item.damage = 63;
            item.melee = true;
            item.width = 36;
            item.height = 40;
            item.useTime = 14;
            item.useTurn = true;
            item.useAnimation = 14;
            item.useStyle = ItemUseStyleID.Stabbing;
            item.knockBack = 4;
            item.value = 100000;
            item.rare = ItemRarityID.Yellow;
            //item.crit = 2;
            item.UseSound = SoundID.Item1;
            item.autoReuse = false;
            item.shoot = mod.ProjectileType("LightsValeBeam");
            item.shootSpeed = 11f;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.BrokenHeroSword);
            recipe.AddIngredient(mod.ItemType("LightsVale"));

            recipe.AddTile(TileID.MythrilAnvil);
            recipe.SetResult(this);
            recipe.AddRecipe();


        }


    }
}