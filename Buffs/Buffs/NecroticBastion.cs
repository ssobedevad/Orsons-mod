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
    public class NecroticBastion : ModBuff
    {
        public override void SetDefaults()
        {
            DisplayName.SetDefault("Necrotic Bastion");
            Description.SetDefault("Increases defense by 2 and increases damage reduction by 3%");
            Main.buffNoSave[Type] = true;
            Main.buffNoTimeDisplay[Type] = false;
        }
        public override void Update(Player player, ref int buffIndex)
        {
            player.statDefense += 2;
            player.GetModPlayer<OrsonsPlayer>().damagePercentageTaken -= 0.03f;
        }







    }
}
