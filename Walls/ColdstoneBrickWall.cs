

using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace OrsonsMod.Walls
{
    public class ColdstoneBrickWall : ModWall
    {
        public override void SetDefaults()
        {
            Main.wallHouse[Type] = true;
            drop = mod.ItemType("ColdstoneBrickwall");

            AddMapEntry(new Color(0, 2, 25));
        }



    }
}
