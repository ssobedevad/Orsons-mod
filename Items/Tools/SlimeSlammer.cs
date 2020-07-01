using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace OrsonsMod.Items.Tools
{
    public class SlimeSlammer : ModItem
    {
        public override void SetStaticDefaults()
        {
            
            Tooltip.SetDefault("Use a living slime to cause havoc");
        }

        public override void SetDefaults()
        {
            item.damage = 16;

            item.melee = true;

            item.useTurn = true;
            item.rare = ItemRarityID.Blue;
            item.knockBack = 8f;
            item.useTime = 29;
            item.autoReuse = true;
            item.useStyle = ItemUseStyleID.SwingThrow;

            item.useAnimation = 29;
            
            item.hammer = 50;

            item.value = 5000;
        }
        



    }
}
