using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace OrsonsMod.Items.Weapons.Shortswords
{
    public class CobaltShortsword : ModItem
    {
        

        public override void SetDefaults()
        {
            item.damage = 36;
            item.melee = true;
            item.width = 30;
            item.height = 32;
            item.useTime = 20;
            item.useTurn = true;
            item.useAnimation = 20;
            item.useStyle = ItemUseStyleID.Stabbing;
            item.knockBack = 3f;
            item.value = 12800;
            item.rare = ItemRarityID.LightRed;
            //item.crit = 2;
            item.UseSound = SoundID.Item1;
            item.autoReuse = false;
        }
        
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.CobaltBar, 8);

            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(this);
            recipe.AddRecipe();


        }


    }
}