
using OrsonsMod.Items.Armor.Vanity;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace OrsonsMod.Items.TreasureBags
{
    public class FuriousFurnaceBag : ModItem
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

            int choice = Main.rand.Next(0, 4);

            if (choice == 0)
            {
                player.QuickSpawnItem(mod.ItemType("PressureCooker"));
               
            }
            else if (choice == 1)
            {
                player.QuickSpawnItem(mod.ItemType("SmokeSprayer"));
               
            }
            else if (choice == 2)
            {
                player.QuickSpawnItem(mod.ItemType("RadiatorWhip"));
              
            }
            else if (choice == 3)
            {
                player.QuickSpawnItem(mod.ItemType("BoilerGun"));
                
            }
            if (Main.rand.NextFloat() < 0.1429f)
            { player.QuickSpawnItem(mod.ItemType("FurnaceMask")); }
            player.QuickSpawnItem(mod.ItemType("SuperSmelter"));

        }

        public override int BossBagNPC => mod.NPCType("FuriousFurnace");
    }
}