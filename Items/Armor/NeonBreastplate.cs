
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;



namespace OrsonsMod.Items.Armor
{
    [AutoloadEquip(EquipType.Body)]
    public class NeonBreastplate : ModItem
    {
        public override void SetStaticDefaults()
        {
            base.SetStaticDefaults();
            DisplayName.SetDefault("Neon breastplate");
            Tooltip.SetDefault("10% increased mining speed");
        }

        public override void SetDefaults()
        {
            item.width = 30;
            item.height = 20;
            item.value = 9000;
            item.rare = ItemRarityID.Orange;
            item.defense = 6;

        }
       

        public override void UpdateEquip(Player player)
        {

            player.GetModPlayer<OrsonsPlayer>().miningSpeed += 0.1f;







        }


        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);

            recipe.AddIngredient(mod.ItemType("NeonBar"), 35);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }

    }
}
