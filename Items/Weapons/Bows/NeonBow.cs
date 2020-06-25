
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

using Microsoft.Xna.Framework;

namespace OrsonsMod.Items.Weapons.Bows
{
    public class NeonBow : ModItem
    {


        public override void SetDefaults()
        {
            item.damage = 18;
            item.noMelee = true;
            item.ranged = true;
            item.autoReuse = false;
            item.rare = ItemRarityID.Green;
            item.width = 18;
            item.height = 40;
            item.useTime = 26;
            item.UseSound = SoundID.Item5;
            item.useStyle = ItemUseStyleID.HoldingOut;
            item.shootSpeed = 10f;
            item.useAnimation = 26;
            item.shoot = ProjectileID.WoodenArrowFriendly;
            item.useAmmo = AmmoID.Arrow;
            item.value = 10000;
        }


        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(mod.ItemType("NeonBar"), 15);

            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(this);
            recipe.AddRecipe();



        }
    }
}
