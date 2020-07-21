using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Microsoft.Xna.Framework;

namespace OrsonsMod.Buffs.Buffs
{
    public class EaterNest : ModBuff
    {
        public override void SetDefaults()
        {
            DisplayName.SetDefault("Eater Nest");
            Description.SetDefault("A nest is spawning eaters to fight for you");
            Main.buffNoSave[Type] = true;
            Main.buffNoTimeDisplay[Type] = true;
        }
        public override void Update(Player player, ref int buffIndex)
        {
            if(player.ownedProjectileCounts[mod.ProjectileType("EaterNest")] == 0)
            { player.buffTime[buffIndex] = 0; }
        }








    }
}
