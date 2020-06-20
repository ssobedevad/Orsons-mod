using Microsoft.Xna.Framework;
using OrsonsMod.Buffs.Buffs;
using OrsonsMod.Buffs.Debuffs;
using System;
using System.Linq;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace OrsonsMod
{
    public class OrsonsPlayer : ModPlayer
    {


        public int tileRangeBoost;
        
        public Item sItem;
        public Item sItemClone;
        public int FoamBalls;
        public bool Contagion;
        public int ContagionBuffType;
        public int minionTargetNPC;
        public int summonTagDamage;
        public int summonTagCrit;
        public float damagePercentageTaken;
        public override void PreUpdate()
        {
            sItem = player.HeldItem;
            sItemClone = sItem.Clone();
            sItemClone.SetDefaults(sItem.type);
        }
        public override void ResetEffects()
        {
            Contagion = false;
            tileRangeBoost = 0;
            damagePercentageTaken = 1f;
            if (player.armor[0].type == mod.ItemType("NeonVisor") && player.armor[1].type == mod.ItemType("NeonBreastplate") && player.armor[2].type == mod.ItemType("NeonLeggings"))
            {
                tileRangeBoost += 2;

            }








        }
        public override void ModifyHitByNPC(NPC npc, ref int damage, ref bool crit)
        {
           if(damagePercentageTaken < 1f) { damage = (int)(damage*damagePercentageTaken); }
        }
        public override void ModifyHitByProjectile(Projectile proj, ref int damage, ref bool crit)
        {
            if (damagePercentageTaken < 1f) { damage = (int)(damage * damagePercentageTaken); }
        }
        public override void Hurt(bool pvp, bool quiet, double damage, int hitDirection, bool crit)
        {

            for (int i = 0; i < player.buffType.Length; i++)
            { if (IsReturnableDebuff(player.buffType[i])) { ContagionBuffType = player.buffType[i]; player.AddBuff(ModContent.BuffType<Contagious>(), 600); break; } }
        }
        public override void ModifyHitNPCWithProj(Projectile proj, NPC target, ref int damage, ref float knockback, ref bool crit, ref int hitDirection)
        {
            if (proj.minion && target.whoAmI == player.MinionAttackTargetNPC) { damage += summonTagDamage; if (summonTagCrit > 0) { if (Main.rand.Next(1, 101) < summonTagCrit) { crit = true;  } } }
        }
        public override void OnHitNPCWithProj(Projectile proj, NPC target, int damage, float knockback, bool crit)
        {
           
            if (player.HasBuff(ModContent.BuffType<Contagious>()) && ContagionBuffType != -1) { target.AddBuff(ContagionBuffType, 120); ContagionBuffType = -1; player.ClearBuff(ModContent.BuffType<Contagious>());}
        }
        public override void OnHitNPC(Item item, NPC target, int damage, float knockback, bool crit)
        {

            if (player.HasBuff(ModContent.BuffType<Contagious>()) && ContagionBuffType != -1) { target.AddBuff(ContagionBuffType, 120); ContagionBuffType = -1; player.ClearBuff(ModContent.BuffType<Contagious>()); }
        }
        private bool IsReturnableDebuff(int buffID)
        {
            int[] ReturnableVanillaBuffs = new int[16] { BuffID.Bleeding, BuffID.Poisoned, BuffID.OnFire, BuffID.Venom, BuffID.Confused, BuffID.CursedInferno, BuffID.Ichor, BuffID.Chilled, BuffID.Frozen, BuffID.Bleeding, BuffID.Electrified, BuffID.Suffocation, BuffID.Burning, BuffID.Frostburn, BuffID.Daybreak, BuffID.Oiled };
            int[] ReturnableModdedBuffs = new int[1] { ModContent.BuffType<Diseased>() };
            return (ReturnableVanillaBuffs.Contains(buffID) || ReturnableModdedBuffs.Contains(buffID));
                
        }
        public override void PostUpdateEquips()
        {

            if (player.HeldItem.pick > 0)
            {
                player.HeldItem.tileBoost = sItemClone.tileBoost;
                player.HeldItem.tileBoost += tileRangeBoost;
                


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
                int itemLength = (int)Math.Sqrt(player.HeldItem.width * player.HeldItem.width + player.HeldItem.height * player.HeldItem.height);


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
                    player.itemLocation.X = player.position.X + (float)player.width * 0.5f;

                    player.itemLocation.Y = player.MountedCenter.Y;
                    Vector2 offSet = (norm *35* ((float)player.itemAnimation / (float)(player.itemAnimationMax))) ;
                   
                    player.itemLocation -= offSet ;
                    player.itemLocation += (norm * 15);

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



                if ((double)player.itemAnimation > 0)
                {
                    for (int i = 0; i < itemLength ; i++)
                    {
                        itemRectangle.X = (int)(player.Center.X + (i * norm.X))-3;
                        itemRectangle.Y = (int)(player.Center.Y + (i * norm.Y))-3;
                        itemRectangle.Width = 6;
                        itemRectangle.Height = 6;
                        
                        ItemCheck_MeleeHitNPCs(sItem, itemRectangle, (int)(player.HeldItem.damage * (player.allDamage + player.meleeDamage - 1)), sItem.knockBack);
                        
                    }
                    
                }


            }
        }
        public void ApplyNPCOnHitEffects(Item sItem, Rectangle itemRectangle, int damage, float knockBack, int npcIndex, int dmgRandomized, int dmgDone)
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

        public void ItemCheck_MeleeHitNPCs(Item sItem, Rectangle itemRectangle, int originalDamage, float knockBack)
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