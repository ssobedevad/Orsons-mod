using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using Terraria;
using Terraria.DataStructures;
using Terraria.Enums;
using Terraria.GameContent.Achievements;
using Terraria.ID;
using Terraria.ModLoader;

namespace OrsonsMod.Projectiles.Hostile
{ 

    public class RabidSpit : ModProjectile
    {
        public override void SetDefaults()
        {
            projectile.height = 16;
            projectile.width = 16;
            projectile.aiStyle = -1;
            projectile.hostile = true;
            projectile.penetrate = 1;
            projectile.scale = 1.5f;


        }
        public override void AI()
        {
            projectile.rotation = projectile.velocity.ToRotation();
            int DustId = Dust.NewDust(new Vector2(projectile.Center.X, projectile.Center.Y), projectile.width + 1, projectile.height + 1, DustID.Marble, projectile.velocity.X * 0.2f, projectile.velocity.Y * 0.2f, 120, default(Color), 1f);
            Main.dust[DustId].noGravity = true;
        }
        public override void OnHitPlayer(Player target, int damage, bool crit)
        {
            target.AddBuff(mod.BuffType("Diseased"), 60);

        }



    }
}



