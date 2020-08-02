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
    public class NeonBrick : ModTile
    {
        public override void SetDefaults()
        {
            
            Main.tileSolid[Type] = true;
            Main.tileMergeDirt[Type] = true;
           
            Main.tileLighted[Type] = true;
            Main.tileBlockLight[Type] = true;
            drop = mod.ItemType("NeonBrick");
            AddMapEntry(new Color(255, 125, 0));
           
        }
        public override void ModifyLight(int i, int j, ref float r, ref float g, ref float b)
        {
            Lighting.AddLight(new Vector2(i*16, j*16), new Vector3(1f, 1f, 1f));
        }

    }
}


