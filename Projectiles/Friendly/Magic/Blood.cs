using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using OrsonsMod.Buffs.Debuffs;
using System;
using System.Media;
using System.Security.Cryptography.X509Certificates;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace OrsonsMod.Projectiles.Friendly.Magic
{
    public class Blood : ModProjectile
    {


        




        public override void SetDefaults()
        {

            projectile.friendly = true;

            projectile.height = 16;
            projectile.width = 16;
            projectile.aiStyle = -1;


            projectile.penetrate = 3;
            projectile.tileCollide = true;
            
        }

        public override void AI()
        {
            
            
            projectile.rotation += 0.3f;
            int dustid = Dust.NewDust(projectile.position, projectile.height, projectile.width, DustID.Blood);
            Main.dust[dustid].noGravity = true;





            if (Main.player[projectile.owner].channel)
            {
                DashToMouse();
            }
            







        }




        private void DashToMouse()
        {

            float speed = 20f;
            Vector2 moveTo = Main.MouseWorld;
            Vector2 moveVel = moveTo - projectile.Center;
            float magnitude = Magnitude(moveVel);
            if (magnitude > speed)
            {
                moveVel *= speed / magnitude;
            }

            projectile.velocity = moveVel;


        }
        private float Magnitude(Vector2 mag)
        {
            return (float)Math.Sqrt(mag.X * mag.X + mag.Y * mag.Y);
        }
      
    }
}