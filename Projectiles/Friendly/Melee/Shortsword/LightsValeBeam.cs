using Microsoft.Xna.Framework;
using System;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
namespace OrsonsMod.Projectiles.Friendly.Melee.Shortsword
{

    public class LightsValeBeam : ModProjectile
    {
        public override void SetDefaults()
        {
            projectile.height = 16;
            projectile.width = 16;
            projectile.aiStyle = -1;
            projectile.friendly = true;       
            projectile.penetrate = 1;
            
            
        }
    public override void AI()
    {
            projectile.rotation = projectile.velocity.ToRotation();
        int DustId = Dust.NewDust(new Vector2(projectile.position.X, projectile.position.Y + 2f), projectile.width + 1, projectile.height + 1, DustID.PinkFlame, projectile.velocity.X * 0.2f, projectile.velocity.Y * 0.2f, 120, default(Color), 1f);
        Main.dust[DustId].noGravity = true;
    }



}





}