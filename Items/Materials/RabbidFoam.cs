using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace OrsonsMod.Items.Materials
{
    public class RabbidFoam : ModItem
    {

        public override void SetStaticDefaults()
        {
            
            Tooltip.SetDefault("It bubbles with an ancient disease");

        }
        public override void SetDefaults()
        {
            item.width = 10;
            item.height = 16;
            item.maxStack = 999;
            item.rare = ItemRarityID.Blue;
            item.value = 100;

        }

    }
}
