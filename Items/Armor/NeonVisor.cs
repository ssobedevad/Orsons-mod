
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;



namespace OrsonsMod.Items.Armor
{
    [AutoloadEquip(EquipType.Head)]
    public class NeonVisor : ModItem
    { 
        private bool armorSet;
        public override void SetStaticDefaults()
        {
            base.SetStaticDefaults();
            DisplayName.SetDefault("Neon visor");
            Tooltip.SetDefault("5% increased mining speed");
        }

        public override void SetDefaults()
        {
            item.width = 20;
            item.height = 22;
            item.value = 7500;
            item.rare = ItemRarityID.Orange;
            item.defense = 5;

        }
        public override bool IsArmorSet(Item head, Item body, Item legs)
        {
            armorSet = (body.type == mod.ItemType("NeonBreastplate") && legs.type == mod.ItemType("NeonLeggings"));
            return armorSet;
        }

        public override void UpdateArmorSet(Player player)
        {
            player.setBonus = "You emit light and have +2 increased mining range";
            
            Lighting.AddLight((int)((player.Center.X + (float)(player.width / 2)) / 16f), (int)((player.Center.Y + (float)(player.height / 2)) / 16f), 1f, 1f, 1f);

        }
        public override void UpdateEquip(Player player)
        {


            player.toolTime =(int)(player.toolTime * 0.95) ;


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
