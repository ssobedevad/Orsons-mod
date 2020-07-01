using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using OrsonsMod.Buffs.Debuffs;
using System;
using System.Media;
using System.Security.Cryptography.X509Certificates;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace OrsonsMod.Projectiles.Friendly.Summon.Minions
{
    public class BabyEater : ModProjectile
    {


        




        public override void SetDefaults()
        {

            projectile.friendly = true;

            projectile.height = 16;
            projectile.width = 16;
            projectile.aiStyle = -1;


            projectile.penetrate = 1;
            projectile.tileCollide = true;
            
        }

        public override void AI()
        {
           
           
            projectile.rotation = projectile.velocity.ToRotation() + 1.57f;
              DashToMouse();
        }




        private void DashToMouse()
        {
            int target = Target();
            if (target != -1)
            {
                float speed = 20f;
                Vector2 moveTo = Main.npc[target].Center ;
                Vector2 moveVel = moveTo - projectile.Center;
                float magnitude = Magnitude(moveVel);
                if (magnitude > speed)
                {
                    moveVel *= speed / magnitude;
                }

                projectile.velocity = (projectile.velocity * 20f + moveVel) / 21f;
            }


        }
        private float Magnitude(Vector2 mag)
        {
            return (float)Math.Sqrt(mag.X * mag.X + mag.Y * mag.Y);
        }
        private int Target()
        {
            int target = -1;
            int targetMag = 600;
            for (int whichNpc = 0; whichNpc < 200; whichNpc++)
            {
                if (Main.npc[whichNpc].CanBeChasedBy(this, false))
                {
                    float DistanceProjtoNpc = Vector2.Distance(projectile.Center, Main.npc[whichNpc].Center);
                    if (DistanceProjtoNpc < targetMag)
                    {
                        targetMag = (int)DistanceProjtoNpc;
                        target = whichNpc;

                    }
                }
            }
            return target;


        }


    }
}