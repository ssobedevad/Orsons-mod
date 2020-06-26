using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using Terraria;
using Terraria.Enums;
using Terraria.ModLoader;

namespace OrsonsMod.Projectiles
{
    // The following laser shows a channeled ability, after charging up the laser will be fired
    // Using custom drawing, dust effects, and custom collision checks for tiles
    public abstract class LaserClass : ModProjectile
    {
        // Use a different style for constant so it is very clear in code when a constant is used

        // The maximum charge value

        //The distance charge particle from the player center
        public float PlayerOffset = 30f;
        public float MaxDist = 1200f;
        public int SpecialEffectType = -1;
        public Vector2 headDimensions;
        public Vector2 bodyDimensions;
        public Vector2 heldDimensions;
        public float realScale;

        // The actual distance is stored in the ai0 field
        // By making a property to handle this it makes our life easier, and the accessibility more readable
        public float Distance
        {

            get { return projectile.ai[0]; }
            set { projectile.ai[0] = value; }
        }

        // The actual charge value is stored in the localAI0 field



        // Are we at max charge? With c#6 you can simply use => which indicates this is a get only property
        public virtual void SafeSetDefaults()
        { }

        public override void SetDefaults()
        {
            projectile.width = 10;
            projectile.height = 10;
            projectile.friendly = true;
            projectile.penetrate = -1;
            projectile.tileCollide = false;
            projectile.magic = true;
            projectile.hide = true;
            SafeSetDefaults();

        }

        public override bool PreDraw(SpriteBatch spriteBatch, Color lightColor)
        {
           
                DrawLaser(spriteBatch, Main.projectileTexture[projectile.type], Main.player[projectile.owner].Center,
                projectile.velocity, 2, projectile.damage, -1.57f, 1f, 1000f, Color.White, (int)PlayerOffset);
            


            return false;


        }

        // The core function of drawing a laser
        public void DrawLaser(SpriteBatch spriteBatch, Texture2D texture, Vector2 start, Vector2 unit, float step, int damage, float rotation = 0f, float scale = 1f, float maxDist = 2000f, Color color = default(Color), int transDist = 50)
        {
            float r = unit.ToRotation() + rotation;
            realScale = 1f;
            // Draws the laser 'body'
            for (float i = transDist; i <= Distance; i += step)
            {
                Color c = projectile.GetAlpha(Color.White);
                c.R = (byte)(c.R * (1) / 20);
                c.G = (byte)(c.G * (1) / 20);
                c.B = (byte)(c.B * (1) / 20);
                c.A = (byte)(c.A * (1) / 20);
                var origin = start + i * unit;
                spriteBatch.Draw(texture, origin - Main.screenPosition,
                    new Rectangle(0, (int)heldDimensions.Y + 2, (int)bodyDimensions.X, (int)bodyDimensions.Y), i < transDist ? Color.Transparent : c, r,
                    new Vector2((int)(bodyDimensions.X/2), (int)(bodyDimensions.Y / 2)), realScale, 0, 0);
                if (SpecialEffectType == 1)
                {
                    realScale += 0.05f;
                    Lighting.AddLight((start + i * unit) / 16f, new Vector3(1.5f, 1.5f, 1.5f));
                }
            }
            if (SpecialEffectType != 1)
            {
                // Draws the laser 'tail'
                spriteBatch.Draw(texture, start + unit * (transDist - step) - Main.screenPosition,
                    new Rectangle(0, 0, (int)heldDimensions.X, (int)heldDimensions.Y), Color.White, r, new Vector2((int)(heldDimensions.X / 2), (int)(heldDimensions.Y / 2)), scale, 0, 0);

                // Draws the laser 'head'
                spriteBatch.Draw(texture, start + (Distance + step) * unit - Main.screenPosition,
                    new Rectangle(0, (int)heldDimensions.Y + 4 + (int)bodyDimensions.Y, (int)headDimensions.X, (int)headDimensions.Y), Color.White, r, new Vector2((int)(headDimensions.X / 2), (int)(headDimensions.Y / 2)), realScale, 0, 0);
            }
           }

        // Change the way of collision check of the projectile
        public override bool? Colliding(Rectangle projHitbox, Rectangle targetHitbox)
        {
            // We can only collide if we are at max charge, which is when the laser is actually fired
            int width = 1;

            Player player = Main.player[projectile.owner];
            Vector2 unit = projectile.velocity;
            
            bool collision = false;
            for (int i = 0; i < 200; i++)
            {
                if (Collision.CheckAABBvAABBCollision(player.Center + (unit * 5 * i), new Vector2((width * realScale), (width * realScale)), targetHitbox.TopLeft(), new Vector2(targetHitbox.Width, targetHitbox.Height)))
                { collision = true; return collision; }
            }
           
            return collision;

        }

        // Set custom immunity time on hitting an NPC
        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
        {
            target.immune[projectile.owner] = 4;
        }

        // The AI of the projectile
        public override void AI()
        {
            Player player = Main.player[projectile.owner];
            projectile.position = player.Center + projectile.velocity * PlayerOffset;


            // By separating large AI into methods it becomes very easy to see the flow of the AI in a broader sense
            // First we update player variables that are needed to channel the laser
            // Then we run our charging laser logic
            // If we are fully charged, we proceed to update the laser's position
            // Finally we spawn some effects like dusts and light

            UpdatePlayer(player);
            ChargeLaser(player);

            // If laser is not charged yet, stop the AI here.


            SetLaserPosition(player);
            if (SpecialEffectType == 1)
            {
                if (projectile.timeLeft > 4) { projectile.timeLeft = 4; }
            }
            
        }



        /*
         * Sets the end of the laser position based on where it collides with something
         */
        private void SetLaserPosition(Player player)
        {
            Distance = MaxDist;
        }

        private void ChargeLaser(Player player)
        {
            // Kill the projectile if the player stops channeling
            if (!player.channel)
            {
                projectile.Kill();
            }
            else
            {
                // Do we still have enough mana? If not, we kill the projectile because we cannot use it anymore
                if (Main.time % 10 < 1 && !player.CheckMana(player.inventory[player.selectedItem].mana, true))
                {
                    projectile.Kill();
                }
                Vector2 offset = projectile.velocity;
                offset *= PlayerOffset - 20;
                Vector2 pos = player.Center + offset - new Vector2(10, 10);

            }
            
        }

        private void UpdatePlayer(Player player)
        {
            // Multiplayer support here, only run this code if the client running it is the owner of the projectile
            if (projectile.owner == Main.myPlayer)
            {
                Vector2 diff = Main.MouseWorld - player.Center;
                diff.Normalize();
                projectile.velocity = diff;
                projectile.direction = Main.MouseWorld.X > player.position.X ? 1 : -1;
                projectile.netUpdate = true;
            }
            int dir = projectile.direction;
            player.ChangeDir(dir); // Set player direction to where we are shooting
            player.heldProj = projectile.whoAmI; // Update player's held projectile
            player.itemTime = 2; // Set item time to 2 frames while we are used
            player.itemAnimation = 2; // Set item animation time to 2 frames while we are used
            player.itemRotation = (float)Math.Atan2(projectile.velocity.Y * dir, projectile.velocity.X * dir); // Set the item rotation to where we are shooting
        }

       

        public override bool ShouldUpdatePosition() => false;

        /*
         * Update CutTiles so the laser will cut tiles (like grass)
         */
        public override void CutTiles()
        {
            DelegateMethods.tilecut_0 = TileCuttingContext.AttackProjectile;
            Vector2 unit = projectile.velocity;
            Utils.PlotTileLine(projectile.Center, projectile.Center + unit * Distance, (projectile.width + 16) * projectile.scale, DelegateMethods.CutTiles);
        }
    }
}