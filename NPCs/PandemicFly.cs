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
            npc.DeathSound = SoundID.NPCDeath1;
            Main.npcFrameCount[npc.type] = 4;
            npc.noGravity = true;
            animationType = NPCID.Bee;
            npc.noTileCollide = true;
            

        }
        public override void ScaleExpertStats(int numPlayers, float bossLifeScale)
        {
            npc.lifeMax = 14;
            npc.defense = 0;
            npc.damage = 10;
        }

        public override void AI()
        {
            npc.TargetClosest(true);
            Vector2 ThisCenter = new Vector2(npc.Center.X, npc.Center.Y);
            float Xdiff = Main.player[npc.target].Center.X - ThisCenter.X + Main.rand.Next(-100, 100);
            float YDiff = Main.player[npc.target].Center.Y - ThisCenter.Y - Main.rand.Next(-100, 100);
            float Magnitude = (float)Math.Sqrt((double)(Xdiff * Xdiff + YDiff * YDiff));
            float Speed = 16f;
            Magnitude = Speed / Magnitude;
            Xdiff *= Magnitude;
            YDiff *= Magnitude;
            npc.velocity.X = (npc.velocity.X * 80f + Xdiff) / 81f;
            npc.velocity.Y = (npc.velocity.Y * 80f + YDiff) / 81f;
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