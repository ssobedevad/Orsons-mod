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
    public class BeeHive : ModBuff
    {
        public override void SetDefaults()
        {
            DisplayName.SetDefault("BeeHive");
            Description.SetDefault("A Beehive is generating you friendly bees");
            Main.buffNoSave[Type] = true;
            Main.buffNoTimeDisplay[Type] = true;
        }

        public override void Update(Player player, ref int buffIndex)
        {
            if (player.ownedProjectileCounts[mod.ProjectileType("BeeHive")] == 0)
            { player.buffTime[buffIndex] = 0; }
        }







    }
}
