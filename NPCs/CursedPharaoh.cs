using Microsoft.Xna.Framework;
using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace OrsonsMod.NPCs
{
    public class CursedPharaoh : ModNPC
    {
        
        public override void SetDefaults()
        {

            npc.CloneDefaults(NPCID.GoblinSorcerer);
            animationType = NPCID.GoblinSorcerer;
            npc.aiStyle = -1;
            npc.HitSound = SoundID.NPCHit1;
            npc.lifeMax = 70;
            npc.damage = 20;
            npc.defense = 3;
            npc.knockBackResist = 0.5f;
            npc.value = 56;
            banner = npc.type;
            bannerItem = mod.ItemType("CursedPharaohBanner");
            Main.npcFrameCount[npc.type] = 3;
        }
        public override void AI()
        {
            npc.TargetClosest(true);
            npc.velocity.X *= 0.93f;
            if ((double)npc.velocity.X > -0.1 && (double)npc.velocity.X < 0.1)
            {
                npc.velocity.X = 0f;
            }
            if (npc.ai[0] == 0f)
            {
                npc.ai[0] = 500f;
            }

            if (npc.ai[2] != 0f && npc.ai[3] != 0f)
            {
                npc.position += Vector2.Zero;

                Main.PlaySound(SoundID.Item8, npc.position);
                for (int num69 = 0; num69 < 50; num69++)
                {

                    int num70 = Dust.NewDust(new Vector2(npc.position.X, npc.position.Y), npc.width, npc.height, 27, 0f, 0f, 100, default(Color), Main.rand.Next(1, 3));
                    Dust dust = Main.dust[num70];
                    dust.velocity *= 3f;
                    if (Main.dust[num70].scale > 1f)
                    {
                        Main.dust[num70].noGravity = true;
                    }


                }
                npc.position -= Vector2.Zero;
                npc.position.X = npc.ai[2] * 16f - (float)(npc.width / 2) + 8f;
                npc.position.Y = npc.ai[3] * 16f - (float)npc.height;
                
                npc.velocity.X = 0f;
                npc.velocity.Y = 0f;
                npc.ai[2] = 0f;
                npc.ai[3] = 0f;
                Main.PlaySound(SoundID.Item8, npc.position);
                for (int num78 = 0; num78 < 50; num78++)
                {

                    int num79 = Dust.NewDust(new Vector2(npc.position.X, npc.position.Y), npc.width, npc.height, 27, 0f, 0f, 100, default(Color), Main.rand.Next(1, 3));
                    Dust dust = Main.dust[num79];
                    dust.velocity *= 3f;
                    if (Main.dust[num79].scale > 1f)
                    {
                        Main.dust[num79].noGravity = true;
                    }


                }
            }
            npc.ai[0] += 1f;

            if (npc.ai[0] == 100f || npc.ai[0] == 200f || npc.ai[0] == 300f)
            {
                npc.ai[1] = 30f;
                npc.netUpdate = true;
            }

            if (npc.ai[0] >= 650f && Main.netMode != 1)
            {
                npc.ai[0] = 1f;
                int num87 = (int)Main.player[npc.target].position.X / 16;
                int num88 = (int)Main.player[npc.target].position.Y / 16;
                int num89 = (int)npc.position.X / 16;
                int num90 = (int)npc.position.Y / 16;
                int num91 = 20;
                int num92 = 0;
                bool flag4 = false;
                if (Math.Abs(npc.position.X - Main.player[npc.target].position.X) + Math.Abs(npc.position.Y - Main.player[npc.target].position.Y) > 2000f)
                {
                    num92 = 100;
                    flag4 = true;
                }
                while (!flag4 && num92 < 100)
                {
                    num92++;
                    int num93 = Main.rand.Next(num87 - num91, num87 + num91);
                    int num94 = Main.rand.Next(num88 - num91, num88 + num91);
                    for (int num95 = num94; num95 < num88 + num91; num95++)
                    {
                        if ((num95 < num88 - 4 || num95 > num88 + 4 || num93 < num87 - 4 || num93 > num87 + 4) && (num95 < num90 - 1 || num95 > num90 + 1 || num93 < num89 - 1 || num93 > num89 + 1) && Main.tile[num93, num95].nactive())
                        {
                            bool flag5 = true;

                            if (Main.tile[num93, num95 - 1].lava())
                            {
                                flag5 = false;
                            }
                            if (flag5 && Main.tileSolid[Main.tile[num93, num95].type] && !Collision.SolidTiles(num93 - 1, num93 + 1, num95 - 4, num95 - 1))
                            {
                                npc.ai[1] = 20f;
                                npc.ai[2] = num93;
                                npc.ai[3] = num95;
                                flag4 = true;
                                break;
                            }
                        }
                    }
                }
                npc.netUpdate = true;
            }
            if (npc.ai[1] > 0f)
            {
                npc.ai[1] -= 1f;


                if (npc.ai[1] == 25f)
                {




                    if (Main.netMode != 1)
                    {

                        NPC.NewNPC((int)npc.position.X + npc.width / 2, (int)npc.position.Y + npc.height / 2, 30);



                    }

                }
            }
            npc.position += Vector2.Zero;

            if (Main.rand.Next(5) == 0)
            {
                int num117 = Dust.NewDust(new Vector2(npc.position.X, npc.position.Y + 2f), npc.width, npc.height, 27, npc.velocity.X * 0.2f, npc.velocity.Y * 0.2f, 100, default(Color), 1.5f);
                Main.dust[num117].noGravity = true;
                Main.dust[num117].velocity.X *= 0.5f;
                Main.dust[num117].velocity.Y = -2f;
            }


            npc.position -= Vector2.Zero;
        }

        public override float SpawnChance(NPCSpawnInfo spawnInfo)
        {
            return spawnInfo.player.ZoneUndergroundDesert ? 0.2f : 0;
        }
    }
}