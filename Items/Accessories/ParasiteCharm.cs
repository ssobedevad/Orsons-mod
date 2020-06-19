using System.Threading.Tasks;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Microsoft.Xna.Framework;

namespace OrsonsMod.Items.Accessories
{
    
    public class ParasiteCharm : ModItem
    {


        public override void SetStaticDefaults()
        {
            
            Tooltip.SetDefault("Whenever you have a debuff you have a slight chance to inflict it upon others when you attack them");
        }

        public override void SetDefaults()
        {
            item.width = 28;
            item.height = 24;
            item.value = 30000;
            item.expert = true;
            item.accessory = true;

        }

        public override void UpdateEquip(Player player)
        {
            player.GetModPlayer<OrsonsPlayer>().Contagion = true;
        }
    }
}