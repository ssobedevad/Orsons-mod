using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using OrsonsMod.Buffs.Debuffs;
using OrsonsMod.Items.Armor;
using OrsonsMod.Items.Armor.Vanity;
using OrsonsMod.Items.Placeables;
using OrsonsMod.Items.TreasureBags;
using OrsonsMod.Items.Weapons.Magic;
using OrsonsMod.Items.Weapons.Repeaters;
using OrsonsMod.Items.Weapons.Summon;
using OrsonsMod.Items.Weapons.Swords;
using OrsonsMod.Projectiles.Hostile;
using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace OrsonsMod.NPCs.Boss
{
    public class DrPandemic : ModNPC
    {

        private int dashDamage = Main.expertMode ? 60 : 40;
        private int contactDamage = Main.expertMode ? 30 : 15;
        private int spitDamage = Main.expertMode ? 25 : 12;
        private int phaseCounter = 0;
        public override void SetDefaults()
        {

            npc.width = 90;               //this is where you put the npc sprite width.     important
            npc.height = 90;              //this is where you put the npc sprite height.   important
            npc.damage = 15;
            npc.defense = 13;
            npc.value = 60000;
            npc.lifeMax = 5000;
            npc.aiStyle = -1;
            npc.knockBackResist = 0f;
            npc.HitSound = SoundID.NPCHit1;
            npc.DeathSound = SoundID.NPCDeath5;
            npc.behindTiles = true;
            npc.noTileCollide = true;
            npc.boss = true;
            npc.buffImmune[BuffID.Poisoned] = true;
            npc.buffImmune[BuffID.Venom] = true;
            npc.buffImmune[BuffID.Confused] = true;
            npc.buffImmune[ModContent.BuffType<Diseased>()] = true;
            npc.noGravity = true;
            npc.ai[0] = 0;
            npc.ai[1] = 0;
            npc.ai[2] = 0;
        }
        public override void ScaleExpertStats(int numPlayers, float bossLifeScale)
        {
            npc.lifeMax = 7000;
            npc.defense = 26;
        }
        public override void AI()
        {

            npc.TargetClosest(true);


            if (npc.ai[1] == 0)
            {
                FloatAbovePlayer();
                if (npc.ai[0] % 60 == 0) { Projectile.NewProjectile(npc.Center, ShootAtPlayer(16f, Main.player[npc.target]), ModContent.ProjectileType<RabidSpit>(), spitDamage, 0f, Main.myPlayer); }
                npc.ai[0] += 1;
                if (npc.ai[0] > 420) { npc.ai[1] = 1; npc.ai[0] = 0; }
                

            }
            else if (npc.ai[1] == 1)
            {
                
                npc.ai[0] += 1;
                if (npc.ai[0] < 120) { DashToLeftSideOfPlayer(); if (npc.ai[0] % 40 == 0) { Projectile.NewProjectile(npc.Center, ShootAtPlayer(16f, Main.player[npc.target]), ModContent.ProjectileType<RabidSpit>(), spitDamage, 0f, Main.myPlayer); } }
                else if (npc.ai[0] < 240) { FloatAbovePlayer(); if (npc.ai[0] % 40 == 0) { for (int i = 0; i < Main.rand.Next(2, 5); i++) { NPC.NewNPC((int)npc.Center.X + Main.rand.Next(-100, 100), (int)npc.Center.Y + Main.rand.Next(-100, 100), ModContent.NPCType<PandemicFly>()); } Projectile.NewProjectile(npc.Center, ShootAtPlayer(16f, Main.player[npc.target]), ModContent.ProjectileType<RabidSpit>(), spitDamage, 0f, Main.myPlayer); } }
                else if (npc.ai[0] < 360) { DashToRightSideOfPlayer(); if (npc.ai[0] % 40 == 0) { Projectile.NewProjectile(npc.Center, ShootAtPlayer(16f, Main.player[npc.target]), ModContent.ProjectileType<RabidSpit>(), spitDamage, 0f, Main.myPlayer); NPC.NewNPC((int)npc.Center.X + Main.rand.Next(-100, 100), (int)npc.Center.Y + Main.rand.Next(-100, 100), ModContent.NPCType<PandemicFly>());  } }
                else if (npc.ai[0] < 480) { FloatAbovePlayer(); if (npc.ai[0] % 40 == 0) { Projectile.NewProjectile(npc.Center, ShootAtPlayer(16f, Main.player[npc.target]), ModContent.ProjectileType<RabidSpit>(), spitDamage, 0f, Main.myPlayer); } }
                if (phaseCounter <= 3 && npc.ai[0] >= 480) { npc.ai[0] = 0; phaseCounter += 1; }
                if (phaseCounter >= 4) { npc.ai[0] = 0; phaseCounter = 0; npc.ai[1] = 0; for (int i = 0; i < Main.rand.Next(1, 3); i++) { NPC.NewNPC((int)npc.Center.X + Main.rand.Next(-100, 100), (int)npc.Center.Y + Main.rand.Next(-100, 100), ModContent.NPCType<PandemicFly>()); } }

            }




            npc.rotation = npc.velocity.X / 15f;
            int Dustid = Dust.NewDust(new Vector2(npc.position.X + (float)(npc.width / 2) - 15f - npc.velocity.X * 5f, npc.position.Y + (float)npc.height - 2f), 30, 10, DustID.Marble, -npc.velocity.X * 0.2f, 3f, 0, default(Color), 2f);
            Main.dust[Dustid].noGravity = true;
            Dust dust = Main.dust[Dustid];
            dust.velocity.X = dust.velocity.X * 1.3f;
            Dust dust2 = Main.dust[Dustid];
            dust2.velocity.X = dust2.velocity.X + npc.velocity.X * 0.4f;
            Dust dust3 = Main.dust[Dustid];
            dust3.velocity.Y = dust3.velocity.Y + (2f + npc.velocity.Y);


        }
        private void FloatAbovePlayer()
        {
            npc.damage = contactDamage;
            Vector2 ThisCenter = new Vector2(npc.Center.X, npc.Center.Y);
            float Xdiff = Main.player[npc.target].Center.X - ThisCenter.X + Main.rand.Next(-200, 200);
            float YDiff = Main.player[npc.target].Center.Y - ThisCenter.Y - Main.rand.Next(200, 400);
            float Magnitude = (float)Math.Sqrt((double)(Xdiff * Xdiff + YDiff * YDiff));
            float Speed = 12f;
            Magnitude = Speed / Magnitude;
            Xdiff *= Magnitude;
            YDiff *= Magnitude;
            npc.velocity.X = (npc.velocity.X * 100f + Xdiff) / 101f;
            npc.velocity.Y = (npc.velocity.Y * 100f + YDiff) / 101f;
        }
        private void DashToLeftSideOfPlayer()
        {
            npc.damage = dashDamage;
            Vector2 ThisCenter = new Vector2(npc.Center.X, npc.Center.Y);
            float Xdiff = Main.player[npc.target].Center.X - ThisCenter.X - 300;
            float YDiff = Main.player[npc.target].Center.Y - ThisCenter.Y - 300;
            float Magnitude = (float)Math.Sqrt((double)(Xdiff * Xdiff + YDiff * YDiff));
            float Speed = 40f;
            Magnitude = Speed / Magnitude;
            Xdiff *= Magnitude;
            YDiff *= Magnitude;
            npc.velocity.X = (npc.velocity.X * 100f + Xdiff) / 101f;
            npc.velocity.Y = (npc.velocity.Y * 100f + YDiff) / 101f;
        }
        private void DashToRightSideOfPlayer()
        {
            npc.damage = dashDamage;
            Vector2 ThisCenter = new Vector2(npc.Center.X, npc.Center.Y);
            float Xdiff = Main.player[npc.target].Center.X - ThisCenter.X + 300;
            float YDiff = Main.player[npc.target].Center.Y - ThisCenter.Y - 300;
            float Magnitude = (float)Math.Sqrt((double)(Xdiff * Xdiff + YDiff * YDiff));
            float Speed = 40f;
            Magnitude = Speed / Magnitude;
            Xdiff *= Magnitude;
            YDiff *= Magnitude;
            npc.velocity.X = (npc.velocity.X * 100f + Xdiff) / 101f;
            npc.velocity.Y = (npc.velocity.Y * 100f + YDiff) / 101f;
        }
        public override void BossLoot(ref string name, ref int potionType)
        {
            potionType = ItemID.HealingPotion;
        }
        public override void NPCLoot()
        {
            if (Main.expertMode)
            { Item.NewItem(npc.getRect(), ModContent.ItemType<DrPandemicBag>()); }
            else
            {
                switch (Main.rand.Next(4))
                {
                    case 0:
                        {
                            Item.NewItem(npc.getRect(), ModContent.ItemType<NeedleBrand>());
                            Item.NewItem(npc.getRect(), ModContent.ItemType<HazmatHelmet>());
                            break;
                        }
                    case 1:
                        {
                            Item.NewItem(npc.getRect(), ModContent.ItemType<SwarmFlyStaff>());
                            Item.NewItem(npc.getRect(), ModContent.ItemType<HazmatBoots>());
                            break;
                        }
                    case 2:
                        {
                            Item.NewItem(npc.getRect(), ModContent.ItemType<RabidRepeater>());
                            Item.NewItem(npc.getRect(), ModContent.ItemType<HazmatHelmet>());
                            break;
                        }
                    case 3:
                        {
                            Item.NewItem(npc.getRect(), ModContent.ItemType<FoamBarrier>());
                            Item.NewItem(npc.getRect(), ModContent.ItemType<HazmatBody>());
                            break;
                        }
                }
                
            }
            if (Main.rand.Next(7) == 1)
            {
                Item.NewItem(npc.getRect(), ModContent.ItemType<DrPandemicTrophy>());
            }



            }
        private Vector2 ShootAtPlayer(float moveSpeed, Player player)
        {
            // Sets the max speed of the npc.
            Vector2 moveTo2 = player.Top - npc.Bottom;
            float Magnitude = (float)Math.Sqrt((double)(moveTo2.X * moveTo2.X + moveTo2.Y * moveTo2.Y));

            moveTo2 *= moveSpeed / Magnitude;
            return moveTo2;



        }
        public override bool PreDraw(SpriteBatch spriteBatch, Color drawColor)
        {


            for (int i = 4; i >= 0; i--)
            {
                Vector2 oldV = npc.velocity * i;
                Vector2 vect = new Vector2(npc.position.X + npc.width / 2 - Main.screenPosition.X - oldV.X, npc.position.Y + npc.height / 2 - Main.screenPosition.Y - oldV.Y);
                Rectangle rect = npc.frame;

                Color alpha9 = npc.GetAlpha(Color.White);
                alpha9.R = (byte)(alpha9.R * (10 - (2 * i)) / 20);
                alpha9.G = (byte)(alpha9.G * (10 - (2 * i)) / 20);
                alpha9.B = (byte)(alpha9.B * (10 - (2 * i)) / 20);
                alpha9.A = (byte)(alpha9.A * (10 - (2 * i)) / 20);
                spriteBatch.Draw(
                    mod.GetTexture("NPCs/Boss/DrPandemic"),
                     vect, rect, alpha9, npc.rotation, new Vector2(npc.width / 2, npc.height / 2), 1f, SpriteEffects.None, 0f);



                //SpriteBatch.Draw(mod.GetTexture("NPCs/Boss/Triplet"),
                //new Vector2(npc.oldPos[i].X - Main.screenPosition.X + (float)(npc.width / 2) - (float)110 / 2f + npc.Center.X , npc.oldPos[i].Y - Main.screenPosition.Y + (float)npc.height - (float)162 / (float)Main.npcFrameCount[npc.type] + 4f + npc.Center.Y + 30f),
                //npc.frame, alpha9, npc.rotation, npc.Center, 1f, SpriteEffects.None, 0f);
            }
            Vector2 vect2 = new Vector2(npc.position.X + npc.width / 2 - Main.screenPosition.X, npc.position.Y + npc.height / 2 - Main.screenPosition.Y);
            Rectangle rect2 = npc.frame;
            spriteBatch.Draw(
                    mod.GetTexture("NPCs/Boss/DrPandemic"),
                     vect2, rect2, Color.White, npc.rotation, new Vector2(npc.width / 2, npc.height / 2), 1f, SpriteEffects.None, 0f);
            return false;

        }


    }
}
