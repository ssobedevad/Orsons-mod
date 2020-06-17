using Microsoft.Xna.Framework;
using System;
using Terraria;
using Terraria.ModLoader;

namespace OrsonsMod.Projectiles.Friendly.Melee.Shortsword
{

    public class TerriBeam : ModProjectile
    {
        public override void SetDefaults()
        {
            projectile.height = 16;
            projectile.width = 16;
            projectile.aiStyle = -1;
            projectile.friendly = true;
            projectile.penetrate = 2;


        }
        public override void AI()
        {
            projectile.rotation = projectile.velocity.ToRotation();
            int DustId = Dust.NewDust(new Vector2(projectile.position.X, projectile.position.Y + 2f), projectile.width + 1, projectile.height + 1, 107, projectile.velocity.X * 0.2f, projectile.velocity.Y * 0.2f, 120, default(Color), 1f);
            Main.dust[DustId].noGravity = true;
        }



    }





}