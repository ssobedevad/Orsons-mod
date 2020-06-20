using Terraria.ModLoader;
using Terraria.ID;
using Microsoft.Xna.Framework;
using OrsonsMod.Buffs.Debuffs;
using OrsonsMod.Projectiles.Friendly.Summon;
using OrsonsMod.Buffs.Buffs;
using Terraria;

namespace OrsonsMod.Projectiles.Friendly.Summon
{
    public class StickySlimeHand : WhipClass
    {

        public override void SafeSetDefaults()
        {
            summonTagDamage = 3;
            canPickUpItems = true;
        }
        
        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
        {
            target.AddBuff(BuffID.Slimed, 600);
        }




    }
}
