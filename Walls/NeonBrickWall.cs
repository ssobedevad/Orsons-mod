

using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace OrsonsMod.Walls
{
    public class NeonBrickWall : ModWall
    {
        public override void SetDefaults()
        {
            Main.wallHouse[Type] = true;

            drop = mod.ItemType("NeonBrickwall");
            AddMapEntry(new Color(25, 25, 0));
        }
        public override void ModifyLight(int i, int j, ref float r, ref float g, ref float b)
        {
            Lighting.AddLight(new Vector2(i, j), new Vector3(1f, 1f, 1f));
        }



    }
}
