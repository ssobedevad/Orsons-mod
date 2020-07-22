using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using OrsonsMod.Buffs.Debuffs;
using OrsonsMod.Items.Armor;
using OrsonsMod.Items.Armor.Vanity;
using OrsonsMod.Items.Placeables;
using OrsonsMod.Items.TreasureBags;
using OrsonsMod.Items.Weapons.Magic;
using OrsonsMod.Items.Weapons.PressureWeapons;
using OrsonsMod.Items.Weapons.Repeaters;
using OrsonsMod.Items.Weapons.Summon;
using OrsonsMod.Items.Weapons.Swords;
using OrsonsMod.Projectiles.Hostile;
using System;
using System.Security.Cryptography;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace OrsonsMod.NPCs.Boss
{
    [AutoloadBossHead]
    public class FuriousFurnace : ModNPC
    {

        private const int grenadeDamage = 20;
        
        private const int rocketDamage = 22;
        
        public override void SetDefaults()
        {

            npc.width = 160;               //this is where you put the npc sprite width.     important
            npc.height = 160;              //this is where you put the npc sprite height.   important
            npc.damage = 30;
            npc.defense = 15;
            npc.value = 60000;
            npc.lifeMax = 7500;
            npc.aiStyle = -1;
            npc.damage = 30;
            npc.knockBackResist = 0f;
            npc.HitSound = SoundID.NPCHit4;
            npc.DeathSound = SoundID.NPCDeath14;
            
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
            npc.lifeMax = 10000;
            
            npc.damage = 60;
        }
        public override void AI()
        {

            npc.TargetClosest(true);
            Player player = Main.player[npc.target];
            if(npc.ai[0] == 0)
            {
                if (npc.ai[1] == 0)
                {
                    Vector2 moveTo = new Vector2(-400, -400) + player.Center;
                    if (move(moveTo)) { npc.ai[1] = 1; }
                }
                if (npc.ai[1] >= 1)
                {
                    npc.velocity *= 0.9f;
                    if (npc.ai[1] < 160) { npc.ai[1] += 1; if (npc.ai[1] % 40 == 0) { Shoot(); } }
                    else { npc.ai[0] = 1; npc.ai[1] = 0; }
                }
            }
            else if (npc.ai[0] == 1)
            {
                if (npc.ai[1] == 0)
                {
                    Vector2 moveTo = new Vector2(-400, 400) + player.Center;
                    if (move(moveTo)) { npc.ai[1] = 1; }
                }
                if (npc.ai[1] >= 1)
                {
                    npc.velocity *= 0.9f;
                    if (npc.ai[1] < 160) { npc.ai[1] += 1; if (npc.ai[1] % 40 == 0) { Shoot(); } }
                    else { npc.ai[0] = 2; npc.ai[1] = 0; }
                }
            }
            else if (npc.ai[0] == 2)
            {
                if (npc.ai[1] == 0)
                {
                    Vector2 moveTo = new Vector2(400, 400) + player.Center;
                    if (move(moveTo)) { npc.ai[1] = 1; }
                }
                if (npc.ai[1] >= 1)
                {
                    npc.velocity *= 0.9f;
                    if (npc.ai[1] < 160) { npc.ai[1] += 1; if (npc.ai[1] % 40 == 0) { Shoot(); } }
                    else { npc.ai[0] = 3; npc.ai[1] = 0; }
                }
            }
            else if (npc.ai[0] == 3)
            {
                if (npc.ai[1] == 0)
                {
                    Vector2 moveTo = new Vector2(400, -400) + player.Center;
                    if (move(moveTo)) { npc.ai[1] = 1; }
                }
                if (npc.ai[1] >= 1)
                {
                    npc.velocity *= 0.9f;
                    if (npc.ai[1] < 160) { npc.ai[1] += 1; if (npc.ai[1] % 40 == 0) { Shoot(); } }
                    else { npc.ai[0] = 0; npc.ai[1] = 0; }
                }
            }



        }
        private void Shoot()
        {
            if (Main.netMode != 1)
            {
                int projid = Projectile.NewProjectile(npc.Center + new Vector2(-80, -70), new Vector2(-4, -8), mod.ProjectileType("FurnaceRocket"), rocketDamage, 0f);
                int projid2 = Projectile.NewProjectile(npc.Center + new Vector2(80, -70), new Vector2(4, -8), mod.ProjectileType("FurnaceRocket"), rocketDamage, 0f);
                int projid3 = Projectile.NewProjectile(npc.Center + new Vector2(-40, -40), new Vector2(-2, -2), ProjectileID.BombSkeletronPrime, grenadeDamage, 0f);
                int projid4 = Projectile.NewProjectile(npc.Center + new Vector2(40, -40), new Vector2(2, -2), ProjectileID.BombSkeletronPrime, grenadeDamage, 0f);
                Main.projectile[projid3].timeLeft = 60;
                Main.projectile[projid4].timeLeft = 60;
                if (Main.expertMode)
                {
                    int expertProj = Projectile.NewProjectile(npc.Center + new Vector2(-30, -70), new Vector2(-4, -8), mod.ProjectileType("FurnaceRocket"), rocketDamage, 0f);
                    int expertProj2 = Projectile.NewProjectile(npc.Center + new Vector2(30, -70), new Vector2(4, -8), mod.ProjectileType("FurnaceRocket"), rocketDamage, 0f);
                    NetMessage.SendData(MessageID.SyncProjectile, -1, -1, null, expertProj, expertProj2);
                }
                NetMessage.SendData(MessageID.SyncProjectile, -1, -1, null, projid, projid2, projid3, projid4);

            }


        }
        private bool move(Vector2 moveTo)
        {
            
            Vector2 diff = moveTo - npc.Center;
            
            float Magnitude = Vector2.Distance(npc.Center, moveTo);
            float Speed = 12f;
            if (Magnitude > Speed * 2)
            {
                Magnitude = Speed / Magnitude;
                diff *= Magnitude;
            }
            else { return true; }

            npc.velocity = (npc.velocity * 15f + diff) / 16f;
            return false;


        }
        public override void BossLoot(ref string name, ref int potionType)
        {
            potionType = ItemID.HealingPotion;
        }
        public override void NPCLoot()
        {
            if (Main.expertMode)
            { Item.NewItem(npc.getRect(), ModContent.ItemType<FuriousFurnaceBag>()); }
            else
            {
                switch (Main.rand.Next(4))
                {
                    case 0:
                        {
                            Item.NewItem(npc.getRect(), ModContent.ItemType<BoilerGun>());
                            
                            break;
                        }
                    case 1:
                        {
                            Item.NewItem(npc.getRect(), ModContent.ItemType<PressureCooker>());
                            
                            break;
                        }
                    case 2:
                        {
                            Item.NewItem(npc.getRect(), ModContent.ItemType<RadiatorWhip>());
                            
                            break;
                        }
                    case 3:
                        {
                            Item.NewItem(npc.getRect(), ModContent.ItemType<SmokeSprayer>());
                            
                            break;
                        }
                }

            }
            if (Main.rand.Next(7) == 1)
            {
                Item.NewItem(npc.getRect(), ModContent.ItemType<FuriousFurnaceTrophy>());
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
        public override void PostDraw(SpriteBatch spriteBatch, Color drawColor)
        {
        
            Texture2D texture = mod.GetTexture("NPCs/Boss/FuriousFurnace_Glowmask");
            spriteBatch.Draw
            (
                texture,
                new Vector2
                (
                    npc.position.X - Main.screenPosition.X + npc.width * 0.5f,
                    npc.position.Y - Main.screenPosition.Y + npc.height - texture.Height * 0.5f + 2f
                ),
                new Rectangle(0, 0, texture.Width, texture.Height),
                Color.White,
                npc.rotation,
                texture.Size() * 0.5f,
                npc.scale,
                SpriteEffects.None,
                0f
            );
        }



    }
}
