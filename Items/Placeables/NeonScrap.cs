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
    public class NeonScrap : ModItem
    {

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Neon scrap");
            Tooltip.SetDefault("Glows faintly");

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
            item.createTile = mod.TileType("NeonScrap");
            item.autoReuse = true;

        }
    }
}
