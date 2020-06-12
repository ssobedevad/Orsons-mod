
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;


namespace OrsonsMod.Items.Armor
{
    [AutoloadEquip(EquipType.Legs)]
    public class NeonLeggings : ModItem
    {
        public override void SetStaticDefaults()
        {
            base.SetStaticDefaults();
            DisplayName.SetDefault("Neon leggings");
            Tooltip.SetDefault("7% increased mining speed");
        }

        public override void SetDefaults()
        {
            item.width = 22;
            item.height = 18;
            item.value = 7500;
            item.rare = ItemRarityID.Orange;
            item.defense = 5;

        }
        public override void UpdateEquip(Player player)
        {


            player.GetModPlayer<OrsonsPlayer>().miningSpeed += 0.07f;


        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            
            recipe.AddIngredient(mod.ItemType("NeonBar"), 25);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }

    }
}
