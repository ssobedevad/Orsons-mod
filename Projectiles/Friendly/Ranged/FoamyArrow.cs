using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Microsoft.Xna.Framework;
using OrsonsMod.Buffs.Debuffs;

namespace OrsonsMod.Projectiles.Friendly.Ranged
{
    public class FoamyArrow : ModProjectile
    {
        public override void SetDefaults()
        {

            projectile.width = 14;
            projectile.height = 14;
            projectile.aiStyle = 1;
            projectile.friendly = true;
            projectile.ranged = true;
            projectile.penetrate = 1;

        }
        public override void OnHitNPC(NPC target, int damage, float knockBack, bool crit)
        {
            if (Main.rand.NextBool())
            {
                target.AddBuff(ModContent.BuffType<Diseased>(), 60);
            }
            

        }




    }
}
