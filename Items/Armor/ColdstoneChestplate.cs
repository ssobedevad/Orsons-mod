
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;



namespace OrsonsMod.Items.Armor
{
    [AutoloadEquip(EquipType.Body)]
    public class ColdstoneChestplate : ModItem
    {
        public override void SetStaticDefaults()
        {
            base.SetStaticDefaults();
            DisplayName.SetDefault("Coldstone Chestplate");
            
        }

        public override void SetDefaults()
        {
            item.width = 30;
            item.height = 20;
            item.value = 10000;
            item.rare = ItemRarityID.Orange;
            item.defense = 8;

        }


        


        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);

            recipe.AddIngredient(mod.ItemType("ColdstoneBar"), 25);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }

    }
}
