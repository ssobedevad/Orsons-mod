
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

using Microsoft.Xna.Framework;

namespace OrsonsMod.Items.Weapons.Bows
{
    public class ColdstoneBow : ModItem
    {
        public override void SetStaticDefaults()
        {
            Tooltip.SetDefault("Turns wooden Arrows into frostburn arrows");
        }

        public override void SetDefaults()
        {
            item.damage = 28;
            item.noMelee = true;
            item.ranged = true;
            item.autoReuse = false;
            item.rare = ItemRarityID.Orange;
            item.width = 18;
            item.height = 40;
            item.useTime = 21;
            item.UseSound = SoundID.Item5;
            item.useStyle = ItemUseStyleID.HoldingOut;
            item.shootSpeed = 9f;
            item.useAnimation = 21;
            item.shoot = ProjectileID.FrostburnArrow;
            item.useAmmo = AmmoID.Arrow;
            item.value = 10000;
        }

        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {

            if (type == ProjectileID.WoodenArrowFriendly)
            {
                Projectile.NewProjectile(position.X, position.Y, speedX, speedY, ProjectileID.FrostburnArrow, damage, knockBack, player.whoAmI);
            }
            else
            {
                Projectile.NewProjectile(position.X, position.Y, speedX, speedY, type, damage, knockBack, player.whoAmI);
            }

            return false;
        }
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);

            recipe.AddIngredient(mod.ItemType("ColdstoneBar"), 18);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }


    }
}
