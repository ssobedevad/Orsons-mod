using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using OrsonsMod.Buffs.Debuffs;
using OrsonsMod.Items.Weapons.PressureWeapons;
using System;
using System.Media;
using System.Security.Cryptography.X509Certificates;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace OrsonsMod.Projectiles.Friendly.Magic
{
    public class SmokeSpray : ModProjectile
    {






        public override void SetDefaults()
        {
            
            projectile.friendly = true;

            projectile.height = 8;
            projectile.width = 8;
            projectile.aiStyle = -1;

            projectile.timeLeft = 120;
            projectile.penetrate = -1;
            projectile.tileCollide = true;
            projectile.scale = 1.8f;

        }

        public override void AI()
        {
           
           
           
            int dustid = Dust.NewDust(projectile.position, projectile.height, projectile.width, DustID.Smoke,projectile.velocity.X*0.2f, projectile.velocity.Y *0.2f, 240 - (projectile.timeLeft * 2),Lighting.GetColor((int)projectile.Center.X, (int)projectile.Center.Y),projectile.scale);
            Main.dust[dustid].noGravity = true;





          








        }




        

    }
}