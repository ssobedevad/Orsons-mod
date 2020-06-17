using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Localization;
using Microsoft.Xna.Framework;
using System;

namespace OrsonsMod.NPCs
{
    public class PandemicFly : ModNPC
    {

        public override void SetDefaults()
        {

            npc.width = 12;
            npc.height = 12;
            npc.damage = 5;
            npc.defense = 0;
            
            npc.lifeMax = 7;
            npc.aiStyle = -1;
            npc.knockBackResist = 0f;
            npc.HitSound = SoundID.NPCHit1;
            Main.npcFrameCount[npc.type] = 4;
            npc.noGravity = true;
            animationType = NPCID.Bee;
            

        }
        public override void ScaleExpertStats(int numPlayers, float bossLifeScale)
        {
            npc.lifeMax *= 2;
            npc.damage *= 2;
        }
        public override void AI()
        {
            npc.TargetClosest(true);
            float speed = (Main.rand.Next(1,160)/10f);
            Vector2 moveTo = Main.player[npc.target].Center;
            Vector2 moveVel = (moveTo - npc.Center);
            float magnitude = Magnitude(moveVel);
            if (magnitude > speed)
            {
                moveVel *= speed / magnitude;

                npc.velocity = moveVel;
            }
        }
        public override void OnHitPlayer(Player target, int damage, bool crit)
        {
            if (Main.expertMode) { target.AddBuff(mod.BuffType("Diseased"), 120); }

        }
        private float Magnitude(Vector2 mag)// does funky pythagoras to find distance between two points
        {
            return (float)Math.Sqrt(mag.X * mag.X + mag.Y * mag.Y);
        }

    }
}