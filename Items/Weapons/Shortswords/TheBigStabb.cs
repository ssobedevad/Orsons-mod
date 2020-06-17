using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace OrsonsMod.Items.Weapons.Shortswords
{
    public class TheBigStabb : ModItem
    {
        public override void SetStaticDefaults()
        {

            Tooltip.SetDefault("Absolutely huge");
        }

        public override void SetDefaults()
        {
            item.damage = 39;
            item.melee = true;
            item.width =42;
            item.height = 42;
            item.useTime = 32;
            item.useTurn = true;
            item.useAnimation = 32;
            item.useStyle = ItemUseStyleID.Stabbing;
            item.knockBack = 10;
            item.value = 30000;
            item.rare = ItemRarityID.LightRed;
            item.crit = 2;
            item.UseSound = SoundID.Item1;
            item.autoReuse = false;
        }

        


    }
}