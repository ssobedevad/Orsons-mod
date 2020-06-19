
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

using Microsoft.Xna.Framework;

namespace OrsonsMod.Items.Weapons.Repeaters
{
    public class RabidRepeater : ModItem
    {
        public override void SetStaticDefaults()
        {
            Tooltip.SetDefault("Turns wooden arrows into foamy arrows");
        }

        public override void SetDefaults()
        {
            item.damage = 23;
            item.noMelee = true;
            item.ranged = true;
            item.autoReuse = true;
            item.rare = ItemRarityID.Orange;
            item.width = 58;
            item.height = 26;
            item.useTime = 18;
            item.UseSound = SoundID.Item5;
            item.useStyle = ItemUseStyleID.HoldingOut;
            item.shootSpeed = 9f;
            item.useAnimation = 18;
            item.shoot = mod.ProjectileType("FoamyArrow");
            item.useAmmo = AmmoID.Arrow;
            item.value = 10000;
        }

        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {

            if (type == ProjectileID.WoodenArrowFriendly)
            {
                Projectile.NewProjectile(position.X, position.Y, speedX, speedY, mod.ProjectileType("FoamyArrow"), damage, knockBack, player.whoAmI);
            }
            else
            {
                Projectile.NewProjectile(position.X, position.Y, speedX, speedY, type, damage, knockBack, player.whoAmI);
            }

            return false;
        }

    }
}
