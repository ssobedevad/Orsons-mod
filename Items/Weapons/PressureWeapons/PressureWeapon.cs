using System.Collections.Generic;
using System.Linq;
using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;

namespace OrsonsMod.Items.Weapons.PressureWeapons
{
   
    public abstract class PressureWeapon : ModItem
    {
        public override bool CloneNewInstances => true;
        public int pressure;
        public const int maxPressure = 30;
        public int baseDamage;
        public int pressureDamage;
        public float baseKnockback;
        public float pressureKnockback;
        public int baseCrit;
        public int pressureCrit;
        public float baseShootspeed = 0;
        public float pressureShootspeed = 0;
        public float[] boilerGunProj = new float[8];
        private int maxPressureText = -1;
        public int baseManaCost = 0;
        public int pressureManaCost = 0;
        public virtual void safeUpdateInv(Player player)
        { }
        public override void UpdateInventory(Player player)
        {
           
            item.damage = baseDamage;
            item.knockBack = baseKnockback;
            item.crit = baseCrit;
            item.shootSpeed = baseShootspeed;
            item.mana = baseManaCost;
            if( pressure >= maxPressure)
            {
                item.damage = pressureDamage;
                item.knockBack = pressureKnockback;
                item.crit = pressureCrit;
                item.shootSpeed = pressureShootspeed;
                item.mana = pressureManaCost;

                if (maxPressureText == -1)
                {
                    maxPressureText = CombatText.NewText(player.getRect(), Color.White, "Max Pressure");
                }
            }
            else { maxPressureText = -1; }
            safeUpdateInv(player);

        }

        





       




    }
}
