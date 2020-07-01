
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

using Microsoft.Xna.Framework;

namespace OrsonsMod.Items.Weapons.Repeaters
{
    public class EaterRepeater : ModItem
    {
        public override void SetStaticDefaults()
        {
            Tooltip.SetDefault("Turns wooden arrows into unholy arrows");
        }

        public override void SetDefaults()
        {
            item.damage = 15;
            item.noMelee = true;
            item.ranged = true;
            item.autoReuse = true;
            item.rare = ItemRarityID.Orange;
            
            item.useTime = 18;
            item.UseSound = SoundID.Item5;
            item.useStyle = ItemUseStyleID.HoldingOut;
            item.shootSpeed = 9f;
            item.useAnimation = 18;
            item.shoot = ProjectileID.UnholyArrow;
            item.useAmmo = AmmoID.Arrow;
            item.value = 20000;
        }

        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {

            if (type == ProjectileID.WoodenArrowFriendly)
            {
                Projectile.NewProjectile(position.X, position.Y, speedX, speedY, item.shoot, damage, knockBack, player.whoAmI);
            }
            else
            {
                Projectile.NewProjectile(position.X, position.Y, speedX, speedY, type, damage, knockBack, player.whoAmI);
            }

            return false;
        }

    }
}
