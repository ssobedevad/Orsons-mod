
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;



namespace OrsonsMod.Items.Armor.Vanity
{
    [AutoloadEquip(EquipType.Head)]
    public class DrPandemicMask : ModItem
    {
        
        public override void SetDefaults()
        {
            item.width = 30;
            item.height = 20;
            item.value = 2500;
            item.rare = ItemRarityID.Blue;


        }







    }
}
