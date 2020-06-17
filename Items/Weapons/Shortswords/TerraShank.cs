using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace OrsonsMod.Items.Weapons.Shortswords
{
    public class TerraShank : ModItem
    {
        public override void SetStaticDefaults()
        {

            Tooltip.SetDefault("Fires a mean green beam");
        }

        public override void SetDefaults()
        {
            item.damage = 91;
            item.melee = true;
            item.width = 30;
            item.height = 26;
            item.useTime = 14;
            item.useTurn = true;
            item.useAnimation = 14;
            item.useStyle = ItemUseStyleID.Stabbing;
            item.knockBack = 6;
            item.value = 200000;
            item.rare = ItemRarityID.Yellow;
            //item.crit = 2;
            item.UseSound = SoundID.Item1;
            item.autoReuse = true;
            item.shoot = mod.ProjectileType("TerriBeam");
            item.shootSpeed = 12f;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(mod.ItemType("TrueNightsTip"));
            recipe.AddIngredient(mod.ItemType("TrueLightsVale"));

            recipe.AddTile(TileID.MythrilAnvil);
            recipe.SetResult(this);
            recipe.AddRecipe();



        }


    }
}