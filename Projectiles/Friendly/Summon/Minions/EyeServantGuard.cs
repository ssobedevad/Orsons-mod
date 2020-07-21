using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ModLoader;
using Terraria.Modules;
using Terraria.ID;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace OrsonsMod.Projectiles.Friendly.Summon.Minions
{
    public class EyeServantGuard : ModProjectile
    {
        public float speed;

        public int target;
        public int targetMag;
        private Vector2[] oldPos = new Vector2[9] { Vector2.Zero, Vector2.Zero, Vector2.Zero, Vector2.Zero, Vector2.Zero, Vector2.Zero, Vector2.Zero, Vector2.Zero, Vector2.Zero, };
        public override void SetStaticDefaults()
        { // Denotes that this projectile is a pet or minion
            Main.projPet[projectile.type] = true;

            ProjectileID.Sets.MinionSacrificable[projectile.type] = true;
            // Don't mistake this with "if this is true, then it will automatically home". It is just for damage reduction for certain NPCs
            ProjectileID.Sets.Homing[projectile.type] = true;
        }
        public override void SetDefaults()
        {

            projectile.width = 22;               //this is where you put the npc sprite width.     important
            projectile.height = 22;              //this is where you put the npc sprite height.   important

            Main.projFrames[projectile.type] = 3;
            projectile.aiStyle = -1;
            projectile.friendly = true;
            projectile.penetrate = -1;
            projectile.tileCollide = false;
            projectile.minion = true;
            projectile.minionSlots = 0f;




        }
        public override bool MinionContactDamage()
        {
            return true;
        }
        public override void AI()
        {
            for (int i = 8; i > -1; i--)
            {
                if (i == 0) { oldPos[i] = projectile.Center; }
                else
                {
                    oldPos[i] = oldPos[i - 1];

                }



                if (oldPos[i] == Vector2.Zero) { oldPos[i] = projectile.Center; }

            }
            Player player = Main.player[projectile.owner];
            if (player.dead || !player.active)
            {
                player.ClearBuff(mod.BuffType("CthuluServantBodyGuard"));
                player.GetModPlayer<OrsonsPlayer>().guardMinion = false;
            }
            if (player.HasBuff(mod.BuffType("CthuluServantBodyGuard")))
            {
                projectile.timeLeft = 2;
                player.GetModPlayer<OrsonsPlayer>().guardMinion = true;
            }

            Target(player);
            projectile.rotation = projectile.velocity.ToRotation() + 3.14f;
            if (++projectile.frameCounter % 5 == 0)
            {
                projectile.frame += 1;
                if (projectile.frame >= Main.projFrames[projectile.type]) { projectile.frame = 1; }
            }
                if (target != -1)
                {
                    CircleAroundPlayer(player);
                }
                else
                {
                    float Xdiff = player.Center.X - projectile.Center.X + Main.rand.Next(-10, 10);
                    float YDiff = player.Center.Y - projectile.Center.Y + Main.rand.Next(-10, 10);
                    projectile.ai[1] = projectile.ai[0] * 1.5f;
                    Vector2 difference = new Vector2(Xdiff, YDiff);
                    float Magnitude = Mag(difference);

                    speed = 8f;
                    if (Magnitude > 100) { speed = 18f; }
                    else if (Magnitude > 220) { speed = 30f; }
                    else if (Magnitude > 350) { speed = 50f; }



                    Magnitude = speed / Magnitude;
                    Xdiff *= Magnitude;
                    YDiff *= Magnitude;

                    projectile.velocity.X = (projectile.velocity.X * 100f + Xdiff + Main.rand.Next(-10, 10)) / 101f;
                    projectile.velocity.Y = (projectile.velocity.Y * 100f + YDiff + Main.rand.Next(-10, 10)) / 101f;
                }



            
        }
        public override void Kill(int timeLeft)
        {
            Player player = Main.player[projectile.owner];
            player.GetModPlayer<OrsonsPlayer>().guardMinion = false;
        }

        private void Target(Player player)
        {
            target = -1;
            targetMag = 240;
            for (int whichNpc = 0; whichNpc < 200; whichNpc++)
            {
                if (Main.npc[whichNpc].CanBeChasedBy(this, false))
                {
                    float DistanceProjtoNpc = Vector2.Distance(player.Center, Main.npc[whichNpc].Center);
                    if (DistanceProjtoNpc < targetMag)
                    {
                        targetMag = (int)DistanceProjtoNpc;
                        target = whichNpc;

                    }
                }
            }


        }


        private float Mag(Vector2 mag)
        {
            return (float)Math.Sqrt(mag.X * mag.X + mag.Y * mag.Y);
        }
        public override bool PreDraw(SpriteBatch spriteBatch, Color lightColor)
        {
            for (int i = 4; i >= 0; i--)
            {
                Vector2 oldV = oldPos[i];
                Vector2 vect = new Vector2(oldV.X - Main.screenPosition.X, oldV.Y - Main.screenPosition.Y);
                Rectangle rect = new Rectangle(0, 23 * projectile.frame, 38, 22);

                Color alpha9 = projectile.GetAlpha(Color.White);
                alpha9.R = (byte)(alpha9.R * (10 - (2 * i)) / 20);
                alpha9.G = (byte)(alpha9.G * (10 - (2 * i)) / 20);
                alpha9.B = (byte)(alpha9.B * (10 - (2 * i)) / 20);
                alpha9.A = (byte)(alpha9.A * (10 - (2 * i)) / 20);
                spriteBatch.Draw(
                    ModContent.GetTexture(Texture),
                     vect, rect, alpha9, projectile.rotation, new Vector2(projectile.width / 2, projectile.height / 2), 1f, SpriteEffects.None, 0f);




            }
            Vector2 vect2 = new Vector2(projectile.position.X + projectile.width / 2 - Main.screenPosition.X, projectile.position.Y + projectile.height / 2 - Main.screenPosition.Y);
            Rectangle rect2 = new Rectangle(0, 23 * projectile.frame, 38, 22);
            spriteBatch.Draw(
                    ModContent.GetTexture(Texture),
                     vect2, rect2, Color.White, projectile.rotation, new Vector2(projectile.width / 2, projectile.height / 2), 1f, SpriteEffects.None, 0f);
            return false;

        }
        private void CircleAroundPlayer(Player player)
        {
            projectile.ai[1] += 0.1f;

            Vector2 moveTo = new Vector2(player.Center.X + (float)Math.Cos(projectile.ai[1]) * 50f, player.Center.Y + (float)Math.Sin(projectile.ai[1]) * 50f);
            moveTo = moveTo - projectile.Center;
            float Mag = (float)Math.Sqrt((moveTo.X * moveTo.X + moveTo.Y * moveTo.Y));
            moveTo *= (20 / Mag);
            projectile.velocity.X = (projectile.velocity.X * 40f + moveTo.X) / 41f;
            projectile.velocity.Y = (projectile.velocity.Y * 40f + moveTo.Y) / 41f;
        }



    }
}
