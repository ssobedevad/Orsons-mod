
using OrsonsMod.Items.Armor.Vanity;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace OrsonsMod.Items.TreasureBags
{
    public class DrPandemicBag : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Treasure Bag");
            Tooltip.SetDefault("{$CommonItemTooltip.RightClickToOpen}");
        }

        public override void SetDefaults()
        {
            item.maxStack = 999;
            item.consumable = true;
            item.width = 24;
            item.height = 24;
            
            item.expert = true;
        }

        public override bool CanRightClick()
        {
            return true;
        }

        public override void OpenBossBag(Player player)
        {

            int choice = Main.rand.Next(0,4);

            if (choice == 0)
            {
                player.QuickSpawnItem(mod.ItemType("NeedleBrand"));
                player.QuickSpawnItem(ItemType<HazmatBody>());
                player.QuickSpawnItem(ItemType<HazmatHelmet>());
            }
            else if (choice == 1)
            {
                player.QuickSpawnItem(mod.ItemType("RabidRepeater"));
                player.QuickSpawnItem(ItemType<HazmatBody>());
                player.QuickSpawnItem(ItemType<HazmatBoots>());
            }
            else if (choice == 2)
            {
                player.QuickSpawnItem(mod.ItemType("FoamBarrier"));
                player.QuickSpawnItem(ItemType<HazmatBoots>());
                player.QuickSpawnItem(ItemType<HazmatHelmet>());
            }
            else if (choice == 3)
            {
                player.QuickSpawnItem(mod.ItemType("SwarmFlyStaff"));
                player.QuickSpawnItem(ItemType<HazmatBoots>());
                player.QuickSpawnItem(ItemType<HazmatHelmet>());
            }
            if(Main.rand.NextFloat() < 0.1429f)
            { player.QuickSpawnItem(mod.ItemType("DrPandemicMask")); }
            player.QuickSpawnItem(mod.ItemType("ParasiteCharm"));
            
        }

        public override int BossBagNPC => mod.NPCType("DrPandemic");
    }
}