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
    public class EaterNest : ModProjectile
    {
        public float speed;

        public int shootCD;

        public override void SetStaticDefaults()
        { // Denotes that this projectile is a pet or minion
            //Main.projPet[projectile.type] = true;

            ProjectileID.Sets.MinionSacrificable[projectile.type] = true;
            // Don't mistake this with "if this is true, then it will automatically home". It is just for damage reduction for certain NPCs
            ProjectileID.Sets.Homing[projectile.type] = true;
        }

        public override void SetDefaults()
        {

            


            projectile.aiStyle = -1;
            projectile.friendly = true;
            projectile.penetrate = -1;
            projectile.tileCollide = true;
            projectile.sentry = true;
            
            projectile.height = 64;
            projectile.width = 64;




        }
        public override bool OnTileCollide(Vector2 oldVelocity)
        {
            
            return false;
        }
        public override void AI()
        {
            
            Player player = Main.player[projectile.owner];
            
            if (player.dead || !player.active)
            {
                player.ClearBuff(mod.BuffType("EaterNest"));
                
            }
            if (!player.HasBuff(mod.BuffType("EaterNest")))
            {
                projectile.active = false;
                
            }
            if (shootCD > 0) { shootCD -= 1; }
            int target = Target();
            if (target != -1 && shootCD <= 0)
            { Projectile.NewProjectile(projectile.Center, Vector2.Zero, mod.ProjectileType("BabyEater"), projectile.damage, projectile.knockBack, projectile.owner); shootCD = 40; }

            



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
