
using Microsoft.Xna.Framework;
using OrsonsMod.Items.Tools;
using OrsonsMod.Items.Weapons.Bows;
using OrsonsMod.Items.Weapons.Flails;
using OrsonsMod.Items.Weapons.Magic;
using OrsonsMod.Items.Weapons.Spears;
using OrsonsMod.Items.Weapons.Summon;
using OrsonsMod.Items.Weapons.Summon.Whips;
using OrsonsMod.Items.Weapons.Swords;
using OrsonsMod.Items.Weapons.Thrown;
using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace OrsonsMod
{

    public class OrsonsGlobalItem : GlobalItem
    {
        public int grabbedBySlimeWhip = -1;
        public override bool InstancePerEntity => true;
        public override bool CloneNewInstances => true;
        public override void Update(Item item, ref float gravity, ref float maxFallSpeed)
        {
            if (grabbedBySlimeWhip >= 0)
            {
                Vector2 diff = (Main.player[grabbedBySlimeWhip].Center - item.Center);
                float Mag = (float)Math.Sqrt(diff.X * diff.X + diff.Y * diff.Y);
                if (Mag < 18f) { grabbedBySlimeWhip = -1; }
                Mag = 18f / Mag;
                item.position += diff * Mag;
                item.noGrabDelay = 0;


            }
        }

        public override void UpdateInventory(Item item, Player player)
        {
            grabbedBySlimeWhip = -1;
        }
        public override void SetDefaults(Item item)
        {
            if (item.type == ItemID.Shuriken)
            { item.ammo = 1000; }
        }
        public override void OpenVanillaBag(string context, Player player, int arg)
        {


            if (context == "bossBag")
            {
                int rand = Main.rand.Next(1, 5);
                if (arg == ItemID.KingSlimeBossBag)
                {
                    if (rand == 1) 
                    { player.QuickSpawnItem(ModContent.ItemType<StickySlimeHand>()); } 
                    else if (rand == 2) { player.QuickSpawnItem(ModContent.ItemType<SlimedNinjasThrowingGlove>()); } 
                    else if (rand == 3) { player.QuickSpawnItem(ModContent.ItemType<SlimeShield>()); } 
                    else if (rand == 4) { player.QuickSpawnItem(ModContent.ItemType<SlimeSlammer>()); }
                }
                else if (arg == ItemID.EyeOfCthulhuBossBag)
                {
                    if (rand == 1)
                    { player.QuickSpawnItem(ModContent.ItemType<EyeSore>()); }
                    else if (rand == 2) { player.QuickSpawnItem(ModContent.ItemType<EyeChaser>()); }
                    else if (rand == 3) { player.QuickSpawnItem(ModContent.ItemType<EyeServantGuardStaff>()); }
                    //else if (rand == 4) { player.QuickSpawnItem(ModContent.ItemType<SlimeSlammer>()); }
                }
                else if (arg == ItemID.EaterOfWorldsBossBag) 
                {
                    if (rand == 1)
                    { player.QuickSpawnItem(ModContent.ItemType<ScourgeFork>()); }
                    //else if (rand == 2) { player.QuickSpawnItem(ModContent.ItemType<SlimedNinjasThrowingGlove>()); }
                    //else if (rand == 3) { player.QuickSpawnItem(ModContent.ItemType<SlimeShield>()); }
                    //else if (rand == 4) { player.QuickSpawnItem(ModContent.ItemType<SlimeSlammer>()); }
                }
                else if (arg == ItemID.BrainOfCthulhuBossBag) 
                {
                    if (rand == 1)
                    { player.QuickSpawnItem(ModContent.ItemType<CraniumBlade>()); }
                    else if (rand == 2) { player.QuickSpawnItem(ModContent.ItemType<CerrebellumBow>()); }
                    else if (rand == 3) { player.QuickSpawnItem(ModContent.ItemType<CreeperGuardStaff>()); }
                    //else if (rand == 4) { player.QuickSpawnItem(ModContent.ItemType<SlimeSlammer>()); }
                }
                else if (arg == ItemID.SkeletronBossBag) 
                {
                    if (rand == 1)
                    { player.QuickSpawnItem(ModContent.ItemType<BoneSmack>()); }
                    //else if (rand == 2) { player.QuickSpawnItem(ModContent.ItemType<SlimedNinjasThrowingGlove>()); }
                    //else if (rand == 3) { player.QuickSpawnItem(ModContent.ItemType<SlimeShield>()); }
                    //else if (rand == 4) { player.QuickSpawnItem(ModContent.ItemType<SlimeSlammer>()); }
                }
            }
        }
    }
}
