using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria.ObjectData;
namespace OrsonsMod.Tiles
{
    public class ColdstoneOre : ModTile
    {
        public override void SetDefaults()
        {
            TileID.Sets.Ore[Type] = true;
            Main.tileSolid[Type] = true;
            Main.tileMerge[Type][TileID.SnowBlock] = true;
            Main.tileMerge[TileID.SnowBlock][Type] = true;
            Main.tileMergeDirt[Type] = false;
            Main.tileSpelunker[Type] = true;
            Main.tileLighted[Type] = false;
            Main.tileBlockLight[Type] = true;
            drop = mod.ItemType("ColdstoneOre");
            AddMapEntry(new Color(0, 20, 255));
            minPick = 65;
        }

    }
}


