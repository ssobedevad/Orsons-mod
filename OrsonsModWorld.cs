using System;
using Terraria.ModLoader;
using Terraria;
using Terraria.ID;
using System.Linq;

namespace OrsonsMod
{

    public class OrsonsModWorld : ModWorld
    {
        public override void PostWorldGen()
        {
            
            foreach (Chest chest in Main.chest.Where(c => c != null))

            {
                var tile = Main.tile[chest.x, chest.y]; // the chest tile
                if (tile.type == TileID.Containers && tile.frameX >70 && tile.frameX < 107)
                {
                    // fixed: ice chest replacing
                    if (Main.rand.Next(0, 4) == 1)
                    {
                        chest.item[0].SetDefaults(mod.ItemType("MuraMini"));
                    }

                    
                }
            }
        }


    }


}