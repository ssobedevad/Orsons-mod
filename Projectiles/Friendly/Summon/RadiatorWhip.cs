using Terraria.ModLoader;
using Terraria.ID;
using Microsoft.Xna.Framework;
using OrsonsMod.Buffs.Debuffs;
using OrsonsMod.Projectiles.Friendly.Summon;
using OrsonsMod.Buffs.Buffs;
using Terraria;
using System.Media;
using OrsonsMod.Items.Weapons.PressureWeapons;

namespace OrsonsMod.Projectiles.Friendly.Summon
{
    public class RadiatorWhip : WhipClass
    {
        
        private bool resetPressure = false;
        public override void SafeSetDefaults()
        {
            summonTagDamage = 7;
            rangeMult = 0.6f;


        }
        public override void AIEffects(Player player)
        {
            PressureWeapon pw = Main.player[projectile.owner].HeldItem.modItem as PressureWeapon;
            if (pw == null) { pw = Main.mouseItem.modItem as PressureWeapon; }
            if (pw != null)
            {
                if (pw.pressure >= 30)
                {
                    summonTagDamage = 10;


                    rangeMult = 0.8f;
                }
                else
                {
                    summonTagDamage = 7;


                    rangeMult = 0.6f;
                }
            }
        }
        public override void NpcEffects(NPC target, int damage, float knockback, bool crit)
        {
            Player player = Main.player[projectile.owner];
            PressureWeapon pw = Main.player[projectile.owner].HeldItem.modItem as PressureWeapon;
            if (pw == null) { pw = Main.mouseItem.modItem as PressureWeapon; }
            if(pw != null)
            {
                if (pw.pressure >= 30)
                { Projectile.NewProjectile(target.Center, Vector2.Zero, ProjectileID.DD2ExplosiveTrapT3Explosion, damage, knockback, player.whoAmI); resetPressure = true; }
            }

        }
        public override void Kill(int timeLeft)
        {
            PressureWeapon pw = Main.player[projectile.owner].HeldItem.modItem as PressureWeapon;
            if (pw == null) { pw = Main.mouseItem.modItem as PressureWeapon; }
            if (pw != null)
            {
                if (resetPressure)
                {

                    pw.pressure = 0;
                }
            }
        }




    }
}
