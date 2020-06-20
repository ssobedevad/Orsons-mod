using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Microsoft.Xna.Framework;
using OrsonsMod.Buffs.Debuffs;
using OrsonsMod.Projectiles.Friendly.Summon;

namespace OrsonsMod.Projectiles.Friendly.Summon
{
    public class SpikeySlapper : WhipClass
    {
        public override void SafeSetDefaults()
        {
            rangeMult = 1f;
            summonTagDamage = 100;
            summonTagCrit = 100;
        }





    }
}
