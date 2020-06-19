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
    public class Contagious : ModBuff
    {
        public override void SetDefaults()
        {
            DisplayName.SetDefault("Contagious");
            Description.SetDefault("Has a Chance to inflict a debuff you have on an enemy that you attack");
            Main.buffNoSave[Type] = true;
            Main.buffNoTimeDisplay[Type] = true;
        }

        






    }
}
