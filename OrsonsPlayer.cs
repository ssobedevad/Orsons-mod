using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
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
            Item HeldItem = new Item();
            HeldItem = player.HeldItem.Clone();
            HeldItem.SetDefaults(HeldItem.type, false);
            if (player.HeldItem.pick > 0)
            {
                player.HeldItem.tileBoost = HeldItem.tileBoost;
                player.HeldItem.tileBoost += tileRangeBoost;
                player.meleeSpeed *= miningSpeed;


            }
        }


        public override void PostItemCheck()
        {


            Item sItem = player.HeldItem;
            Item sItemClone = sItem.Clone();
            sItemClone.SetDefaults(sItem.type);
            
            if (sItem.useStyle == ItemUseStyleID.Stabbing)
            {
                Rectangle itemRectangle = new Rectangle((int)player.itemLocation.X, (int)player.itemLocation.Y, 32, 32);
                if (!Main.dedServ)
                {
                    itemRectangle = new Rectangle((int)player.itemLocation.X, (int)player.itemLocation.Y, player.HeldItem.width, player.HeldItem.height);
                }
                itemRectangle.Width = (int)((float)itemRectangle.Width * sItem.scale);
                itemRectangle.Height = (int)((float)itemRectangle.Height * sItem.scale);
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
                    if (sItem.type == 946 || sItem.type == 4707)
                    {
                        itemRectangle.Height += 14;
                        itemRectangle.Width -= 10;
                        if (player.direction == -1)
                        {
                            itemRectangle.X += 10;
                        }
                    }
                }
                    float mouseDirection = (float)(Main.MouseWorld - player.Center).ToRotation();
                sItem.useTurn = true;
                if ((double)player.itemAnimation > (double)player.itemAnimationMax * 0.666)
                {
                    player.itemLocation.X = -1000f;
                    player.itemLocation.Y = -1000f;
                    player.itemRotation = -1.3f * (float)player.direction;
                }
                else
                {
                    player.itemLocation.X = player.position.X + (float)player.width * 0.5f + ((float)sItem.width * 0.5f - 4f) * (float)player.direction;
                    player.itemLocation.Y = player.MountedCenter.Y;
                    float XoffSet = (float)player.itemAnimation / (float)player.itemAnimationMax * (float)sItem.width * (float)player.direction * sItem.scale * 1.2f - (float)(10 * player.direction);
                    if (XoffSet > -4f && player.direction == -1)
                    {
                        XoffSet = -8f;
                    }
                    if (XoffSet < 4f && player.direction == 1)
                    {
                        XoffSet = 8f;
                    }
                    player.itemLocation.X -= XoffSet;

                    if (Main.MouseWorld.X > player.Center.X) { player.direction = 1; }
                    else { player.direction = -1; }


                    if (player.direction == -1)
                    {
                        player.itemRotation = mouseDirection + 2.25f;
                    }
                    else
                    {
                        player.itemRotation = mouseDirection + 0.75f;
                    }
                    if (sItem.type == ItemID.Umbrella)
                    {
                        player.itemLocation.X -= 6 * player.direction;
                    }
                }
                if (player.gravDir == -1f)
                {
                    player.itemRotation = 0f - player.itemRotation;
                    player.itemLocation.Y = player.position.Y + (float)player.height + (player.position.Y - player.itemLocation.Y);
                }
                Vector2 norm = Vector2.Normalize(Main.MouseWorld - player.Center);

                
                if (player.controlUseItem && (double)player.itemAnimation > (double)player.itemAnimationMax * 0.666)
                {
                    itemRectangle.X = (int)(player.Center.X-6 + (norm.X * itemRectangle.Width));
                    itemRectangle.Y = (int)(player.Center.Y-6 + (norm.Y * itemRectangle.Height));
                    itemRectangle.Width = 12;
                    itemRectangle.Height = 12;
                    
                    ItemCheck_MeleeHitNPCs(sItem, itemRectangle, sItem.damage, sItem.knockBack);
                
                }


            }
        }


        private void ItemCheck_MeleeHitNPCs(Item sItem, Rectangle itemRectangle, int originalDamage, float knockBack)
        {
            for (int fontMouseText = 0; fontMouseText < 200; fontMouseText++)
            {
                if (!Main.npc[fontMouseText].active || Main.npc[fontMouseText].immune[player.whoAmI] != 0 || player.attackCD != 0)
                {
                    continue;
                }

                if (!Main.npc[fontMouseText].dontTakeDamage && Main.npc[fontMouseText].immune[player.whoAmI] == 0)
                {
                    if (!Main.npc[fontMouseText].friendly || (Main.npc[fontMouseText].type == NPCID.Guide && player.killGuide) || (Main.npc[fontMouseText].type == NPCID.Clothier && player.killClothier))
                    {
                        Rectangle vector = new Rectangle((int)Main.npc[fontMouseText].position.X, (int)Main.npc[fontMouseText].position.Y, Main.npc[fontMouseText].width, Main.npc[fontMouseText].height);
                        if (itemRectangle.Intersects(vector) && (Main.npc[fontMouseText].noTileCollide || player.CanHit(Main.npc[fontMouseText])))
                        {
                            int num = Main.DamageVar(originalDamage); ;
                            bool Crit = false;
                            int weaponCrit = sItem.crit;
                            if (Main.rand.Next(1, 101) <= weaponCrit)
                            {
                                Crit = true;
                            }
                            int NPCtype = Item.NPCtoBanner(Main.npc[fontMouseText].BannerID());
                            if (NPCtype > 0 && player.NPCBannerBuff[NPCtype] == true)
                            {
                                num = ((!Main.expertMode) ? ((int)((float)num * ItemID.Sets.BannerStrength[Item.BannerToItem(NPCtype)].NormalDamageDealt)) : ((int)((float)num * ItemID.Sets.BannerStrength[Item.BannerToItem(NPCtype)].ExpertDamageDealt)));
                            }



                            int RealDamage = Main.DamageVar(num);

                            if (Main.npc[fontMouseText].life > 5)
                            {
                                player.OnHit(Main.npc[fontMouseText].Center.X, Main.npc[fontMouseText].Center.Y, Main.npc[fontMouseText]);
                            }
                            if (player.armorPenetration > 0)
                            {
                                RealDamage += Main.npc[fontMouseText].checkArmorPenetration(player.armorPenetration);
                            }
                            int dmgDone = (int)Main.npc[fontMouseText].StrikeNPC(RealDamage, knockBack, player.direction, Crit);
                            
                            int num5 = Item.NPCtoBanner(Main.npc[fontMouseText].BannerID());
                            if (num5 >= 0)
                            {
                                player.lastCreatureHit = num5;
                            }
                            if (Main.netMode != 0)
                            {
                                if (Crit)
                                {
                                    NetMessage.SendData(28, -1, -1, null, fontMouseText, RealDamage, knockBack, player.direction, 1);
                                }
                                else
                                {
                                    NetMessage.SendData(28, -1, -1, null, fontMouseText, RealDamage, knockBack, player.direction);
                                }
                            }
                            if (player.accDreamCatcher)
                            {
                                player.addDPS(RealDamage);
                            }
                            Main.npc[fontMouseText].immune[player.whoAmI] = player.itemAnimation;
                            player.attackCD = Math.Max(1, (int)((double)player.itemAnimationMax * 0.33));
                        }
                    }
                }
                else if (Main.npc[fontMouseText].type == 63 || Main.npc[fontMouseText].type == 64 || Main.npc[fontMouseText].type == 103 || Main.npc[fontMouseText].type == 242)
                {
                    Rectangle value = new Rectangle((int)Main.npc[fontMouseText].position.X, (int)Main.npc[fontMouseText].position.Y, Main.npc[fontMouseText].width, Main.npc[fontMouseText].height);
                    if (itemRectangle.Intersects(value) && (Main.npc[fontMouseText].noTileCollide || player.CanHit(Main.npc[fontMouseText])))
                    {
                        player.Hurt(PlayerDeathReason.LegacyDefault(), (int)((double)Main.npc[fontMouseText].damage * 1.3), -player.direction);
                        Main.npc[fontMouseText].immune[player.whoAmI] = player.itemAnimation;
                        player.attackCD = (int)((double)player.itemAnimationMax * 0.33);
                    }
                }

            }
        }
    }

}