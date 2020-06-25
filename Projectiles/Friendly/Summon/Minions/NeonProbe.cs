﻿using System;
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
    public class NeonProbe : ModProjectile
    {
        public float speed;
        public int shootCD;
        public int target;
        public int targetMag;
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
            

            projectile.aiStyle = -1;
            projectile.friendly = true;
            projectile.penetrate = -1;
            projectile.tileCollide = false;
            projectile.minion = true;
            projectile.minionSlots = 1f;




        }
        public override bool MinionContactDamage()
        {
            return true;
        }
        public override void AI()
        {
            Player player = Main.player[projectile.owner];
            if (player.dead || !player.active)
            {
                player.ClearBuff(mod.BuffType("SwarmFlyBuff"));
            }
            if (player.HasBuff(mod.BuffType("SwarmFlyBuff")))
            {
                projectile.timeLeft = 2;
            }
            if (shootCD > 0) { shootCD -= 1; }
            Target();
            float Xdiff = Main.player[projectile.owner].Center.X - projectile.Center.X + Main.rand.Next(-10, 10);
            float YDiff = Main.player[projectile.owner].Center.Y - projectile.Center.Y + Main.rand.Next(-10, 10);
            if (target != -1)
            {
                Xdiff = Main.npc[target].Center.X - projectile.Center.X + Main.rand.Next(-10,10);
                YDiff = Main.npc[target].Center.Y - projectile.Center.Y + Main.rand.Next(-10, 10);
            }


            Vector2 difference = new Vector2(Xdiff, YDiff);
            float Magnitude = Mag(difference);

            speed = 1f;
            if (Magnitude > 100) { speed = 3f; }
            else if (Magnitude > 220) { speed = 18f; }
            else if (Magnitude > 350) { speed = 30f; }
            else if (Magnitude > 450) { speed = 48f; }
            else if (Magnitude > 550) { speed = 200f; }

            Magnitude = speed / Magnitude;
            Xdiff *= Magnitude;
            YDiff *= Magnitude;

            projectile.velocity.X = (projectile.velocity.X * 100f + Xdiff + Main.rand.Next(-10, 10)) / 101f;
            projectile.velocity.Y = (projectile.velocity.Y * 100f + YDiff + Main.rand.Next(-10, 10)) / 101f;
            if (shootCD == 0 && target != -1) { int projid = Projectile.NewProjectile(projectile.Center, AimAtNPC(10f), ProjectileID.DeathLaser, 35, 0, projectile.owner); shootCD = 120; Main.projectile[projid].hostile = false; Main.projectile[projid].friendly = true; }

            projectile.rotation = (float)Math.Atan2((double)YDiff, (double)Xdiff) - 1.57f;

            Lighting.AddLight((int)((projectile.Center.X + (float)(projectile.width / 2)) / 16f), (int)((projectile.Center.Y + (float)(projectile.height / 2)) / 16f), 1.5f, 1.5f, 1.5f);
        }
        private void Target()
        {
            target = -1;
            targetMag = 600;
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

        private Vector2 AimAtNPC(float projSpeed)
        {
            NPC npc = Main.npc[target];
            Vector2 playerDiff = npc.Center - projectile.Center;
            float Magnitude = Mag(playerDiff);
            Magnitude = projSpeed / Magnitude;
            return playerDiff *= Magnitude;
        }
        private float Mag(Vector2 mag)
        {
            return (float)Math.Sqrt(mag.X * mag.X + mag.Y * mag.Y);
        }
        public override bool PreDraw(SpriteBatch spriteBatch, Color lightColor)
        {
            for (int i = 4; i >= 0; i--)
            {
                Vector2 oldV = projectile.velocity * i;
                Vector2 vect = new Vector2(projectile.position.X + projectile.width / 2 - Main.screenPosition.X - oldV.X, projectile.position.Y + projectile.height / 2 - Main.screenPosition.Y - oldV.Y);
                Rectangle rect = new Rectangle(0, 0, projectile.width, projectile.height);

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
            Rectangle rect2 = new Rectangle(0, 0, projectile.width, projectile.height);
            spriteBatch.Draw(
                    ModContent.GetTexture(Texture),
                     vect2, rect2, Color.White, projectile.rotation, new Vector2(projectile.width / 2, projectile.height / 2), 1f, SpriteEffects.None, 0f);
            return false;

        }



    }
}
