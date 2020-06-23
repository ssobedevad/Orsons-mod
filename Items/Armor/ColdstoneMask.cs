
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;



namespace OrsonsMod.Items.Armor
{
    [AutoloadEquip(EquipType.Head)]
    public class ColdstoneMask : ModItem
    {
       
        public override void SetStaticDefaults()
        {
            base.SetStaticDefaults();
            DisplayName.SetDefault("Coldstone Mask");
            
        }

        public override void SetDefaults()
        {
            item.width = 20;
            item.height = 22;
            item.value = 10000;
            item.rare = ItemRarityID.Orange;
            item.defense = 7;

        }
        public override bool IsArmorSet(Item head, Item body, Item legs)
        {
            bool armorSet = (body.type == mod.ItemType("ColdstoneChestplate") && legs.type == mod.ItemType("ColdstoneLeggings"));
            return armorSet;
        }

        public override void UpdateArmorSet(Player player)
        {
            player.setBonus = "You are immune to cold debuffs"+"\n+15% ranged damage";
            player.buffImmune[BuffID.Chilled] = true;
            player.buffImmune[BuffID.Frozen] = true;
            player.buffImmune[BuffID.Frostburn] = true;
            player.rangedDamage *= 1.15f;

        }
        

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);

            recipe.AddIngredient(mod.ItemType("ColdstoneBar"), 20);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }

    }
}
