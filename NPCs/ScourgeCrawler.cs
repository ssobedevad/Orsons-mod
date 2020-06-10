using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Localization;
using Microsoft.Xna.Framework;
using System;

namespace DeadFESHsMod.NPCs
{
    public class ScourgeCrawler : ModNPC
    {
        public override void SetStaticDefaults()
        {
            Main.npcFrameCount[npc.type] = 4;
        }

        public override void SetDefaults()
        {

            npc.width = 58;               //this is where you put the npc sprite width.     important
            npc.height = 32;              //this is where you put the npc sprite height.   important
            npc.damage = 25;
            npc.defense = 10;
            npc.value = 125;
            npc.lifeMax = 55;
            npc.aiStyle = 3;
            npc.knockBackResist = 0.4f;
            npc.buffImmune[BuffID.Confused] = true;
            npc.buffImmune[BuffID.Venom] = true;


            banner = npc.type;
            bannerItem = mod.ItemType("ScourgeCrawlerBanner");

        }
        public override void AI()
        {
            //vanilla code
            npc.TargetClosest(true);
            Player player = Main.player[npc.target];
            if ((double)player.position.X > (double)npc.position.X)
                npc.spriteDirection = 1;
            else if ((double)player.position.X < (double)npc.position.X)
                npc.spriteDirection = -1;
            int num1 = (int)npc.Center.X / 16;
            int num2 = (int)npc.Center.Y / 16;
            int numWalls = 0;
            for (int index1 = num1 - 2; index1 <= num1 + 2; ++index1)
            {
                for (int index2 = num2 - 2; index2 <= num2 + 2; ++index2)
                {
                    if (Main.tile[index1, index2] == null)
                        return;
                    if ((int)Main.tile[index1, index2].wall > 0)
                        numWalls +=1;
                }
            }
            if (numWalls <= 10)
                return;
            npc.Transform(mod.NPCType("ScourgeCrawlerWall"));
        }



       
        public override void NPCLoot()
        {
            if (Main.rand.Next(3) == 2)
            {
                Item.NewItem(npc.getRect(), ItemID.RottenChunk, 1);
            }
        }
        public override void FindFrame(int frameHeight)
        {
            
            if (npc.velocity.Y != 0f)
            {
                npc.frameCounter = 0.0;
                //if (npc.velocity.Y < 0f)
                //{
                //    npc.frame.Y = frameHeight * 4;
                //}
                //else
                //{
                    npc.frame.Y = 0;
                //}
                
            }
            npc.spriteDirection = npc.direction;
            npc.frameCounter += Math.Abs(npc.velocity.X) * 1.1f;
            if (npc.frameCounter < 6.0)
            {
                npc.frame.Y = frameHeight;
            }
            else if (npc.frameCounter < 12.0)
            {
                npc.frame.Y = frameHeight * 2;
            }
            else if (npc.frameCounter < 18.0)
            {
                npc.frame.Y = frameHeight * 3;
            }
            else
            {
                npc.frameCounter = 0.0;
            }
            
        }
        public override float SpawnChance(NPCSpawnInfo spawnInfo)
        {

            return Main.tile[(spawnInfo.spawnTileX), (spawnInfo.spawnTileY)].type == TileID.Ebonstone ? 0.4f : 0f;



        }



    }
}
