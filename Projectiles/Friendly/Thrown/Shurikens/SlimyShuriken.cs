using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Microsoft.Xna.Framework;

namespace OrsonsMod.Projectiles.Friendly.Thrown.Shurikens
{
    public class SlimyShuriken : ModProjectile
    {

        private NPC hitEnemy = null;
        public override void SetDefaults()
        {

            projectile.height = 32;
            projectile.width = 32;
            projectile.aiStyle = -1;
            projectile.friendly = true;
            projectile.ranged = true;

            projectile.penetrate = 6;


        }

        public override void AI()
        {
            
            if (hitEnemy != null) { if (hitEnemy.active) { projectile.Center = hitEnemy.Center - projectile.velocity; } else { projectile.active = false; } }
            else { projectile.rotation += 0.3f; projectile.velocity.Y += 0.1f;if(projectile.velocity.Y > 16f) { projectile.velocity.Y = 16f; } }


        }
        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
        {
            if (hitEnemy == null)
            {
                projectile.timeLeft = 120;
                hitEnemy = target;
                projectile.knockBack = 0f;
            }

        }


    }

}

