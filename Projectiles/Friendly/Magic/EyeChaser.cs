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
    public class EyeChaser : ModProjectile
    {


        private Vector2[] oldPos = new Vector2[9] { Vector2.Zero, Vector2.Zero, Vector2.Zero, Vector2.Zero, Vector2.Zero, Vector2.Zero, Vector2.Zero, Vector2.Zero, Vector2.Zero, };




        public override void SetDefaults()
        {

            projectile.friendly = true;

            projectile.height = 16;
            projectile.width = 16;
            projectile.aiStyle = -1;
            
            
            projectile.penetrate = 1;
            projectile.tileCollide = false;
            projectile.ai[0] = 0;
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
            projectile.rotation = projectile.velocity.ToRotation()- 1.57f;





            projectile.ai[0] += 1;
            if (projectile.ai[0] == 60)
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
        public override bool PreDraw(SpriteBatch spriteBatch, Color lightColor)
        {
            for (int i = 4; i >= 0; i--)
            {
                Vector2 oldV = oldPos[i];
                Vector2 vect = new Vector2(oldV.X - Main.screenPosition.X, oldV.Y - Main.screenPosition.Y);
                Rectangle rect = new Rectangle(0, 0, 18, 22);

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
            Rectangle rect2 = new Rectangle(0, 0, 18, 22);
            spriteBatch.Draw(
                    ModContent.GetTexture(Texture),
                     vect2, rect2, Color.White, projectile.rotation, new Vector2(projectile.width / 2, projectile.height / 2), 1f, SpriteEffects.None, 0f);
            return false;

        }

    }
}