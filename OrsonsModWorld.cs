using System;
using Terraria.ModLoader;
using Terraria;
using Terraria.ID;
using System.Linq;
using System.Collections.Generic;
using Terraria.GameContent.Generation;
using Terraria.World.Generation;

namespace OrsonsMod
{

    public class OrsonsModWorld : ModWorld
    {
        public override void PostWorldGen()
        {

            foreach (Chest chest in Main.chest.Where(c => c != null))

            {
                var tile = Main.tile[chest.x, chest.y]; // the chest tile
                if (tile.type == TileID.Containers && tile.frameX > 70 && tile.frameX < 107)
                {
                    // fixed: ice chest replacing
                    if (Main.rand.Next(0, 4) == 1)
                    {
                        chest.item[0].SetDefaults(mod.ItemType("MuraMini"));
                    }


                }
            }
        }
        public override void ModifyWorldGenTasks(List<GenPass> tasks, ref float totalWeight)
        {






            int genIndex2 = tasks.FindIndex(genpass => genpass.Name.Equals("Shinies"));
            if (genIndex2 == -1)
            {
                return;
            }
            tasks.Insert(genIndex2 + 1, new PassLegacy("Ores", delegate (GenerationProgress progress)
            {
                progress.Message = "Placing special ores";
                
                for (int k = 0; k < 750; k++)                     //750 is the ore spawn rate. the bigger is the number = more ore spawns
                {
                    int X = WorldGen.genRand.Next(300, Main.maxTilesX - 300);

                    int Y = WorldGen.genRand.Next((int)WorldGen.worldSurface + 400, Main.maxTilesY - 200);
                    if (Main.tile[X, Y].type == TileID.IceBlock)   //this is the tile where the ore will spawn
                    {

                        
                        WorldGen.TileRunner(X, Y, (double)WorldGen.genRand.Next(5, 10), WorldGen.genRand.Next(5, 10), mod.TileType("ColdstoneOre"), false, 0f, 0f, false, true);
                        k += 5;
                        
                    }
                    else { k -= 1; }
                    
                }

            }));
        }
    }


}