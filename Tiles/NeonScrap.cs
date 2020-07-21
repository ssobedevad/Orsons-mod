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
    public class NeonScrap : ModTile
    {
        public override void SetDefaults()
        {
            TileID.Sets.Ore[Type] = true;
            Main.tileSolid[Type] = true;
            Main.tileMergeDirt[Type] = true;
            Main.tileSpelunker[Type] = true;
            Main.tileLighted[Type] = true;
            Main.tileBlockLight[Type] = true;
            drop = mod.ItemType("NeonScrap");
            AddMapEntry(new Color(255, 105, 0));
            minPick = 50;
        }
        public override void ModifyLight(int i, int j, ref float r, ref float g, ref float b)
        {
            Lighting.AddLight(new Vector2(i, j), new Vector3(1f, 1f, 1f));
        }

    }
}


