
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;



namespace OrsonsMod.Items.Armor
{
    [AutoloadEquip(EquipType.Body)]
    public class HazmatBody : ModItem
    {
        public override void SetStaticDefaults()
        {
            base.SetStaticDefaults();
            DisplayName.SetDefault("Hasmat body");
            Tooltip.SetDefault("COVID-19 free");
        }

        public override void SetDefaults()
        {
            item.width = 30;
            item.height = 20;
            item.value = 2500;
            item.rare = ItemRarityID.Blue;


        }







    }
}
