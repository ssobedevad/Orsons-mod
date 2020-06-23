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
    public class ColdstoneOre : ModItem
    {

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Coldstone Ore");
            Tooltip.SetDefault("Like regular stone ore just colder");

        }
        public override void SetDefaults()
        {
            item.width = 12;
            item.height = 12;
            item.maxStack = 999;
            item.useTime = 10;
            item.useAnimation = 10;
            item.useStyle = ItemUseStyleID.SwingThrow;
            item.rare = ItemRarityID.Orange;
            item.consumable = true;
            item.createTile = mod.TileType("ColdstoneOre");
            item.autoReuse = true;

        }
    }
}
