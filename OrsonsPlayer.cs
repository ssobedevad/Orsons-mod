using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using Terraria;
using Terraria.DataStructures;
using Terraria.Enums;
using Terraria.GameContent.Achievements;
using Terraria.ID;
using Terraria.ModLoader;

namespace OrsonsMod
{
    public class OrsonsPlayer : ModPlayer
    {


        public int tileRangeBoost;
        public float miningSpeed;
        public Item sItem;
        public Item sItemClone;

        public override void PreUpdate()
        {
             sItem = player.HeldItem;
             sItemClone = sItem.Clone();
            sItemClone.SetDefaults(sItem.type);
        }
        public override void ResetEffects()
        {

            tileRangeBoost = 0;
            miningSpeed = 1f;
            if (player.armor[0].type == mod.ItemType("NeonVisor") && player.armor[1].type == mod.ItemType("NeonBreastplate") && player.armor[2].type == mod.ItemType("NeonLeggings"))
            {
                tileRangeBoost += 2;

            }
            







        }
        public override void PostUpdateEquips()
        {
            
            if (player.HeldItem.pick > 0)
            {
                player.HeldItem.tileBoost = sItemClone.tileBoost;
                player.HeldItem.tileBoost += tileRangeBoost;
                player.meleeSpeed *= miningSpeed;
                

            }
        }

        public override bool PreItemCheck()
        {
            if (sItem.useStyle == ItemUseStyleID.Stabbing)
            { sItem.noMelee = true; }
                return true;
        }
        public override void PostItemCheck()
        {


            
            
            
            if (sItem.useStyle == ItemUseStyleID.Stabbing)
            {
                sItem.noMelee = false;
                Rectangle itemRectangle = new Rectangle((int)player.itemLocation.X, (int)player.itemLocation.Y, 32, 32);
                if (!Main.dedServ)
                {
                    itemRectangle = new Rectangle((int)player.itemLocation.X, (int)player.itemLocation.Y, player.HeldItem.width, player.HeldItem.height);
                }
                itemRectangle.Width = (int)((float)itemRectangle.Width *sItem.scale);
                itemRectangle.Height = (int)((float)itemRectangle.Height *sItem.scale);
                if (player.direction == -1)
                {
                    itemRectangle.X -= itemRectangle.Width;
                }
                if (player.gravDir == 1f)
                {
                    itemRectangle.Y -= itemRectangle.Height;
                }
                if ((double)player.itemAnimation > (double)player.itemAnimationMax * 0.666)
                {

                }
                else
                {
                    if (player.direction == -1)
                    {
                        itemRectangle.X -= (int)((double)itemRectangle.Width * 1.4 - (double)itemRectangle.Width);
                    }
                    itemRectangle.Width = (int)((double)itemRectangle.Width * 1.4);
                    itemRectangle.Y += (int)((double)itemRectangle.Height * 0.6);
                    itemRectangle.Height = (int)((double)itemRectangle.Height * 0.6);
                   
                }
                    float mouseDirection = (float)(Main.MouseWorld - player.Center).ToRotation();
                Vector2 norm = Vector2.Normalize(Main.MouseWorld - player.Center);
               sItem.useTurn = true;
                if ((double)player.itemAnimation > (double)player.itemAnimationMax * 0.666)
                {
                    player.itemLocation.X = -1000f;
                    player.itemLocation.Y = -1000f;
                    player.itemRotation = -1.3f * (float)player.direction;
                }
                else
                {
                    player.itemLocation.X = player.position.X + (float)player.width * 0.5f + ((float)sItem.width * 0.5f - 4f) * (float)((Main.MouseWorld.X > player.Center.X)? 1 : -1);
                    
                    player.itemLocation.Y = player.MountedCenter.Y;
                    Vector2 offSet = norm * sItem.width * sItem.scale * ((float)player.itemAnimation / (float)(player.itemAnimationMax));
                    player.itemLocation -= offSet;

                    if ((double)player.itemAnimation > 0)
                    {
                        if (Main.MouseWorld.X > player.Center.X) { player.direction = 1; }
                        else { player.direction = -1; }
                    }
                    if (player.direction == -1)
                    {
                        player.itemRotation = mouseDirection + 2.25f;
                    }
                    else
                    {
                        player.itemRotation = mouseDirection + 0.75f;
                    }
                    
                }
                if (player.gravDir == -1f)
                {
                    player.itemRotation = 0f - player.itemRotation;
                    player.itemLocation.Y = player.position.Y + (float)player.height + (player.position.Y - player.itemLocation.Y);
                }
                

                
                if ((double)player.itemAnimation > (double)player.itemAnimationMax * 0.666)
                {
                    

                    itemRectangle.X = (int)(player.Center.X + (norm.X * itemRectangle.Width));
                    itemRectangle.Y = (int)(player.Center.Y-5 + (norm.Y * itemRectangle.Height));
                    Rectangle itemRectangle2 = new Rectangle();
                    itemRectangle2.X = (int)(player.Center.X + (norm.X * (itemRectangle.Width / 2)));
                    itemRectangle2.Y = (int)(player.Center.Y - 5 + (norm.Y * (itemRectangle.Height / 2)));
                    itemRectangle.Width = 10;
                    itemRectangle.Height = 10;
                    
                    itemRectangle2.Width = 10;
                    itemRectangle2.Height = 10;
                    ItemCheck_MeleeHitNPCs(sItem, itemRectangle,(int)( player.HeldItem.damage * (player.allDamage + player.meleeDamage - 1)), sItem.knockBack);
                    ItemCheck_MeleeHitNPCs(sItem, itemRectangle2, (int)(player.HeldItem.damage * (player.allDamage + player.meleeDamage - 1)), sItem.knockBack);
                }


            }
        }
        private void ApplyNPCOnHitEffects(Item sItem, Rectangle itemRectangle, int damage, float knockBack, int npcIndex, int dmgRandomized, int dmgDone)
        {
            bool fontDeathText = !Main.npc[npcIndex].immortal;
            
            if (player.beetleOffense && fontDeathText)
            {
                player.beetleCounter += dmgDone;
                player.beetleCountdown = 0;
            }
            
            if (player.meleeEnchant == 7)
            {
                Projectile.NewProjectile(Main.npc[npcIndex].Center.X, Main.npc[npcIndex].Center.Y, Main.npc[npcIndex].velocity.X, Main.npc[npcIndex].velocity.Y, ProjectileID.ConfettiMelee, 0, 0f, player.whoAmI);
            }
            
            
            if (Main.npc[npcIndex].value > 0f && player.coins && Main.rand.Next(5) == 0)
            {
                int type = 71;
                if (Main.rand.Next(10) == 0)
                {
                    type = 72;
                }
                if (Main.rand.Next(100) == 0)
                {
                    type = 73;
                }
                int Coin = Item.NewItem((int)Main.npc[npcIndex].position.X, (int)Main.npc[npcIndex].position.Y, Main.npc[npcIndex].width, Main.npc[npcIndex].height, type);
                Main.item[Coin].stack = Main.rand.Next(1, 11);
                Main.item[Coin].velocity.Y = (float)Main.rand.Next(-20, 1) * 0.2f;
                Main.item[Coin].velocity.X = (float)Main.rand.Next(10, 31) * 0.2f * (float)player.direction;
                if (Main.netMode == NetmodeID.MultiplayerClient)
                {
                    NetMessage.SendData(MessageID.SyncItem, -1, -1, null, Coin);
                }
            }
        }

        private void ItemCheck_MeleeHitNPCs(Item sItem, Rectangle itemRectangle, int originalDamage, float knockBack)
        {
            for (int HitNPC = 0; HitNPC < 200; HitNPC++)
            {
                if (!Main.npc[HitNPC].active || Main.npc[HitNPC].immune[player.whoAmI] != 0 || player.attackCD != 0)
                {
                    continue;
                }

                if (!Main.npc[HitNPC].dontTakeDamage && Main.npc[HitNPC].immune[player.whoAmI] == 0)
                {
                    if (!Main.npc[HitNPC].friendly || (Main.npc[HitNPC].type == NPCID.Guide && player.killGuide) || (Main.npc[HitNPC].type == NPCID.Clothier && player.killClothier))
                    {
                        Rectangle vector = new Rectangle((int)Main.npc[HitNPC].position.X, (int)Main.npc[HitNPC].position.Y, Main.npc[HitNPC].width, Main.npc[HitNPC].height);
                        if (itemRectangle.Intersects(vector) && (Main.npc[HitNPC].noTileCollide || player.CanHit(Main.npc[HitNPC])))
                        {
                            int num = Main.DamageVar(originalDamage); ;
                            bool Crit = false;
                            int weaponCrit = sItem.crit;
                            if (Main.rand.Next(1, 101) <= weaponCrit)
                            {
                                Crit = true;
                            }
                            int NPCtype = Item.NPCtoBanner(Main.npc[HitNPC].BannerID());
                            if (NPCtype > 0 && player.NPCBannerBuff[NPCtype] == true)
                            {
                                num = ((!Main.expertMode) ? ((int)((float)num * ItemID.Sets.BannerStrength[Item.BannerToItem(NPCtype)].NormalDamageDealt)) : ((int)((float)num * ItemID.Sets.BannerStrength[Item.BannerToItem(NPCtype)].ExpertDamageDealt)));
                            }



                            int RealDamage = Main.DamageVar(num);

                            if (Main.npc[HitNPC].life > 5)
                            {
                                player.OnHit(Main.npc[HitNPC].Center.X, Main.npc[HitNPC].Center.Y, Main.npc[HitNPC]);
                            }
                            if (player.armorPenetration > 0)
                            {
                                RealDamage += Main.npc[HitNPC].checkArmorPenetration(player.armorPenetration);
                            }
                            int dmgDone = (int)Main.npc[HitNPC].StrikeNPC(RealDamage, knockBack, player.direction, Crit);
                            if (sItem.modItem != null)
                            {



                                sItem.modItem.OnHitNPC(player, Main.npc[HitNPC], RealDamage, knockBack, Crit);
                            }
                            OnHitNPC(sItem, Main.npc[HitNPC], RealDamage, knockBack, Crit);
                            ApplyNPCOnHitEffects(sItem, itemRectangle, num, knockBack, HitNPC, RealDamage, dmgDone);
                            int num5 = Item.NPCtoBanner(Main.npc[HitNPC].BannerID());
                            if (num5 >= 0)
                            {
                                player.lastCreatureHit = num5;
                            }
                            if (Main.netMode != NetmodeID.SinglePlayer)
                            {
                                if (Crit)
                                {
                                    NetMessage.SendData(MessageID.StrikeNPC, -1, -1, null, HitNPC, RealDamage, knockBack, player.direction, 1);
                                }
                                else
                                {
                                    NetMessage.SendData(MessageID.StrikeNPC, -1, -1, null, HitNPC, RealDamage, knockBack, player.direction);
                                }
                            }
                            if (player.accDreamCatcher)
                            {
                                player.addDPS(RealDamage);
                            }
                            Main.npc[HitNPC].immune[player.whoAmI] = player.itemAnimation;
                            player.attackCD = Math.Max(1, (int)((double)player.itemAnimationMax * 0.33));
                        }
                    }
                }
                else if (Main.npc[HitNPC].type == NPCID.BlueJellyfish || Main.npc[HitNPC].type == NPCID.PinkJellyfish || Main.npc[HitNPC].type == NPCID.GreenJellyfish || Main.npc[HitNPC].type == NPCID.BloodJelly)
                {
                    Rectangle value = new Rectangle((int)Main.npc[HitNPC].position.X, (int)Main.npc[HitNPC].position.Y, Main.npc[HitNPC].width, Main.npc[HitNPC].height);
                    if (itemRectangle.Intersects(value) && (Main.npc[HitNPC].noTileCollide || player.CanHit(Main.npc[HitNPC])))
                    {
                        player.Hurt(PlayerDeathReason.LegacyDefault(), (int)((double)Main.npc[HitNPC].damage * 1.3), -player.direction);
                        Main.npc[HitNPC].immune[player.whoAmI] = player.itemAnimation;
                        player.attackCD = (int)((double)player.itemAnimationMax * 0.33);
                    }
                }


            }
        }
            
    
    }

}