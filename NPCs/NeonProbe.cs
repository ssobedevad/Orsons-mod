using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Localization;
using Microsoft.Xna.Framework;
using System;
using Steamworks;

namespace OrsonsMod.NPCs
{
    public class NeonProbe : ModNPC
    {
        public float speed;
        public int shootCD;
        public override void SetDefaults()
        {

            npc.width = 32;               //this is where you put the npc sprite width.     important
            npc.height = 32;              //this is where you put the npc sprite height.   important
            npc.damage = 25;
            npc.defense = 12;
            npc.value = 100;
            npc.lifeMax = 50;
            npc.aiStyle = -1;
            npc.knockBackResist = 0.4f;
            npc.HitSound = SoundID.NPCHit4;
            npc.DeathSound = SoundID.NPCDeath14;
            npc.noTileCollide = true;


            npc.noGravity = true;
            banner = npc.type;
            bannerItem = mod.ItemType("NeonProbeBanner");

        }
        public override void AI()
        {
            npc.TargetClosest(true);
            if (shootCD > 0) { shootCD -= 1; }
            float Xdiff = Main.player[npc.target].Center.X - npc.Center.X;
            float YDiff = Main.player[npc.target].Center.Y - npc.Center.Y;
            Vector2 difference = new Vector2(Xdiff, YDiff);
            float Magnitude = Mag(difference);
            
            speed = 1f;
            if (Magnitude > 100) { speed = 3f; }
            else if (Magnitude > 220) { speed = 8f; }
            else if (Magnitude > 450) { speed = 12f; }
            else if (Magnitude > 650) { speed = 18f; }
            else if (Magnitude > 950) { speed = 25f; }

            Magnitude = speed / Magnitude;
            Xdiff *= Magnitude;
            YDiff *= Magnitude;

            npc.velocity.X = (npc.velocity.X * 100f + Xdiff) / 101f;
            npc.velocity.Y = (npc.velocity.Y * 100f + YDiff) / 101f;
            if (shootCD == 0) {  Projectile.NewProjectile(npc.Center, AimAtPlayer(10f), ProjectileID.DeathLaser, npc.damage / 3, 0); shootCD = 120; }

            npc.rotation = (float)Math.Atan2((double)YDiff, (double)Xdiff) - 1.57f;

            Lighting.AddLight((int)((npc.Center.X + (float)(npc.width / 2)) / 16f), (int)((npc.Center.Y + (float)(npc.height / 2)) / 16f), 1.5f, 1.5f, 1.5f);
        }

        public override void NPCLoot()
        {
            Item.NewItem(npc.getRect(), mod.ItemType("NeonScrap"), Main.rand.Next(1, 3));
        }
        public override float SpawnChance(NPCSpawnInfo spawnInfo)
        {

            return spawnInfo.player.ZoneSkyHeight? 0.8f : 0f;



        }
        private Vector2 AimAtPlayer(float projSpeed)
        {
            Player player = Main.player[npc.target];
            Vector2 playerDiff = player.Center - npc.Center;
            float Magnitude = Mag(playerDiff);
            Magnitude = projSpeed / Magnitude;
            return playerDiff *= Magnitude;
        }
        private float Mag(Vector2 mag)
        {
            return (float)Math.Sqrt(mag.X * mag.X + mag.Y * mag.Y);
        }



    }
}
