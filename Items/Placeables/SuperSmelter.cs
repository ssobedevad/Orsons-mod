using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace OrsonsMod.Items.Placeables
{
    public class SuperSmelter : ModItem
    {

        public override void SetStaticDefaults()
        {
            
            Tooltip.SetDefault("Works like a normal furnace, but has a 10% chance to not consume the materials used");

        }
        public override void SetDefaults()
        {
            
            item.maxStack = 99;
            item.useTime = 20;
            item.useAnimation = 20;
            item.useStyle = ItemUseStyleID.SwingThrow;
            item.expert = true;
            item.value = 20000;
            item.consumable = true;
            item.createTile = mod.TileType("SuperSmelter");
            item.autoReuse = true;

        }
       
    }
}
