using Microsoft.Xna.Framework;
using OrsonsMod.Items.Weapons.PressureWeapons;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace OrsonsMod
{
    public class OrsonsGlobalProjectile : GlobalProjectile
    {
        public override void OnHitNPC(Projectile projectile, NPC target, int damage, float knockback, bool crit)
        {
            ModItem mi = Main.player[projectile.owner].HeldItem.modItem;
           
            if (mi != null)
            {
                PressureWeapon pw = mi as PressureWeapon;
                if (pw != null && pw.pressure < 30 &&( projectile.type != mod.ProjectileType("SmokeSpray") || projectile.ai[0] != -1))
                {
                    if (pw.pressure == 29)
                    { pw.pressure = 30; }
                    else
                    {
                        pw.pressure += 2;
                    }

                }
            }
        }




    }
}
