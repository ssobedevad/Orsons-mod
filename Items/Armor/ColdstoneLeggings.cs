
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;


namespace OrsonsMod.Items.Armor
{
    [AutoloadEquip(EquipType.Legs)]
    public class ColdstoneLeggings : ModItem
    {
        public override void SetStaticDefaults()
        {
            base.SetStaticDefaults();
            DisplayName.SetDefault("Coldstone Leggings");
            
        }

        public override void SetDefaults()
        {
            item.width = 22;
            item.height = 18;
            item.value = 10000;
            item.rare = ItemRarityID.Orange;
            item.defense = 7;

        }
       

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);

            recipe.AddIngredient(mod.ItemType("ColdstoneBar"), 23);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }

    }
}
