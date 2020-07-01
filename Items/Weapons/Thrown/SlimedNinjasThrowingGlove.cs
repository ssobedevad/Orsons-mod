
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

using Microsoft.Xna.Framework;

namespace OrsonsMod.Items.Weapons.Thrown
{
    public class SlimedNinjasThrowingGlove : ModItem
    {


        public override void SetDefaults()
        {
            item.damage = 4;
            item.noMelee = true;
            item.ranged = true;
            item.autoReuse = false;
            item.rare = ItemRarityID.Blue;

            item.useTime = 28;
            item.UseSound = SoundID.Item5;
            item.useStyle = ItemUseStyleID.SwingThrow;
            item.shootSpeed = 10f;
            item.useAnimation = 28;
            item.shoot = mod.ProjectileType("SlimyShuriken");
            item.useAmmo = 1000;
            item.value = 20000;
            item.crit = 4;
        }


        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {

            
            
                Projectile.NewProjectile(position.X, position.Y, speedX, speedY, mod.ProjectileType("SlimyShuriken"), damage, knockBack, player.whoAmI);
            

            return false;
        }



    }
}
