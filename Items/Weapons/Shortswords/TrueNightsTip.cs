using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace OrsonsMod.Items.Weapons.Shortswords
{
    public class TrueNightsTip : ModItem
    {
        public override void SetStaticDefaults()
        {

            Tooltip.SetDefault("Truly evil");
        }

        public override void SetDefaults()
        {
            item.damage = 100;
            item.melee = true;
            item.width = 38;
            item.height = 46;
            item.useTime = 24;
            item.useTurn = true;
            item.useAnimation = 24;
            item.useStyle = ItemUseStyleID.Stabbing;
            item.knockBack = 4.5f;
            item.value = 100000;
            item.rare = ItemRarityID.Yellow;
            //item.crit = 2;
            item.UseSound = SoundID.Item1;
            item.autoReuse = false;
            item.shoot = mod.ProjectileType("NightsBeam");
            item.shootSpeed = 10f;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.BrokenHeroSword);
            recipe.AddIngredient(mod.ItemType("NightsTip"));

            recipe.AddTile(TileID.MythrilAnvil);
            recipe.SetResult(this);
            recipe.AddRecipe();


        }


    }
}