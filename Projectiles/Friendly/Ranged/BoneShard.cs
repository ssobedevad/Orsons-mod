using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Microsoft.Xna.Framework;
using OrsonsMod.Buffs.Debuffs;

namespace OrsonsMod.Projectiles.Friendly.Ranged
{
    public class BoneShard : ModProjectile
    {
        public override void SetDefaults()
        {

            projectile.width = 6;
            projectile.height = 6;
            projectile.aiStyle = 1;
            projectile.friendly = true;
            projectile.ranged = true;
            projectile.penetrate = 5;

        }
       




    }
}
