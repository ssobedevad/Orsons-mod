using Microsoft.Xna.Framework;
using OrsonsMod.Buffs.Debuffs;
using System;
using System.Security.Cryptography.X509Certificates;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace OrsonsMod.Projectiles.Friendly.Magic
{
    public class VileSpit : ModProjectile
    {

        private int target;
        private Vector2 targetPos;
        private int targetMag;





        public override void SetDefaults()
        {

            projectile.friendly = true;

            projectile.height = 32;
            projectile.width = 32;
            projectile.aiStyle = -1;


            projectile.penetrate = 2;
            projectile.tileCollide = false;

        }

        public override void AI()
        {
            int Dustid = Dust.NewDust(new Vector2(projectile.position.X, projectile.position.Y), projectile.width, projectile.height, DustID.ToxicBubble, projectile.velocity.X * 0.2f, projectile.velocity.Y * 0.2f, 120, default(Color), 2f);
            Main.dust[Dustid].noGravity = true;
            Player player = Main.player[projectile.owner];
            if (!player.dead || player.active)
            {


                projectile.timeLeft = 2;
            }

            Target();

            if (target == -1)
            {
                targetPos = Main.player[Main.myPlayer].Center;
                CircleAroundPlayer(player);
            }
            


            projectile.spriteDirection = -projectile.direction;
        }



        private void Target()
        {
            targetMag = 100;
            target = -1;

            for (int whichNpc = 0; whichNpc < 200; whichNpc++)
            {


                if (Main.npc[whichNpc].CanBeChasedBy(this, false))
                {
                    float whichNpcXpos = Main.npc[whichNpc].Center.X;
                    float whichNpcYpos = Main.npc[whichNpc].Center.Y;
                    float DistanceProjtoNpc = Math.Abs(this.projectile.position.X + (float)(this.projectile.width / 2) - whichNpcXpos) + Math.Abs(this.projectile.position.Y + (float)(this.projectile.height / 2) - whichNpcYpos);
                    if (DistanceProjtoNpc < targetMag)
                    {
                        targetMag = (int)DistanceProjtoNpc;
                        target = whichNpc;

                    }
                }
            }


        }
       
        private void CircleAroundPlayer(Player player)
        {
            projectile.rotation += 0.15f;
            projectile.position.X = player.Center.X - 25 + (float)Math.Cos(projectile.rotation) * 100f;
            projectile.position.Y = player.Center.Y - 25 + (float)Math.Sin(projectile.rotation) * 100f;
        }

    }
}