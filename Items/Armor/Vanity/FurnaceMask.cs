
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.GameContent;
using Terraria.DataStructures;

namespace OrsonsMod.Items.Armor.Vanity
{
    [AutoloadEquip(EquipType.Head)]

    public class FurnaceMask : ModItem
    {
        static Texture2D texture = ModContent.GetTexture("OrsonsMod/Items/Armor/Vanity/FurnaceMask_Glowmask");
        public override void SetDefaults()
        {
            item.width = 30;
            item.height = 20;
            item.value = 2500;
            item.rare = ItemRarityID.Blue;
            
               


        }
        public override void SetStaticDefaults()
        {
            OrsonsModGlowmask.AddGlowMask(item.type, "OrsonsMod/Items/Armor/Vanity/FurnaceMask_Glowmask");
        }
        public override void DrawArmorColor(Player drawPlayer, float shadow, ref Color color, ref int glowMask, ref Color glowMaskColor)
        {
            glowMaskColor = Color.White;
        }










    }
}
