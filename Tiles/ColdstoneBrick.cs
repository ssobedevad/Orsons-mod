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
    public class ColdstoneBrick : ModTile
    {
        public override void SetDefaults()
        {

            Main.tileSolid[Type] = true;
            Main.tileMergeDirt[Type] = true;

            Main.tileLighted[Type] = true;
            Main.tileBlockLight[Type] = true;
            drop = mod.ItemType("ColdstoneBrick");
            AddMapEntry(new Color(0, 50, 255));

        }
       

    }
}


