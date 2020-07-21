
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

using Microsoft.Xna.Framework;
using OrsonsMod.Projectiles.Friendly.Ranged;

namespace OrsonsMod.Items.Weapons.Repeaters
{
    public class RibcageSpitter : ModItem
    {
        public override void SetStaticDefaults()
        {
            Tooltip.SetDefault("Turns bones into bone shards");
        }

        public override void SetDefaults()
        {
            item.damage = 10;
            item.noMelee = true;
            item.ranged = true;
            item.autoReuse = true;
            item.rare = ItemRarityID.Orange;

            item.useTime = 10;
            item.UseSound = SoundID.Item11;
            item.useStyle = ItemUseStyleID.HoldingOut;
            item.shootSpeed = 10f;
            item.useAnimation = 10;
            item.shoot = ProjectileID.UnholyArrow;
            item.useAmmo = ItemID.Bone;
            item.value = 20000;
        }

        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {

           
            
                Projectile.NewProjectile(position.X, position.Y, speedX, speedY, ModContent.ProjectileType<BoneShard>(), damage, knockBack, player.whoAmI);
            

            return false;
        }

    }
}
