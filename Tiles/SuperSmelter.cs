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
    public class SuperSmelter : ModTile
    {
        public override void SetDefaults()
        {
            Main.tileSolid[Type] = false;
            Main.tileMergeDirt[Type] = false;
            Main.tileLighted[Type] = true;
            Main.tileBlockLight[Type] = true;
            Main.tileFrameImportant[Type] = true;
            adjTiles = new int[] { TileID.Furnaces,TileID.Hellforge };
            TileObjectData.newTile.CopyFrom(TileObjectData.Style3x2);
            TileObjectData.addTile(Type);

        }
        public override void KillMultiTile(int i, int j, int frameX, int frameY)
        { Item.NewItem(i * 16, j * 16, 48, 48, mod.ItemType("SuperSmelter")); }
       

    }
}

