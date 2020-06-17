using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace OrsonsMod.Items.Weapons.Shortswords
{
    public class MuraMini : ModItem
    {
        public override void SetStaticDefaults()
        {

            Tooltip.SetDefault("What tiny ninjas use");
        }

        public override void SetDefaults()
        {
            item.damage = 19;
            item.melee = true;
            item.width = 36;
            item.height = 36;
            item.useTime = 17;
            item.useTurn = true;
            item.useAnimation = 17;
            item.useStyle = ItemUseStyleID.Stabbing;
            item.knockBack = 2.5f;
            item.value = 15000;
            item.rare = ItemRarityID.Green;
            item.crit = 1;
            item.UseSound = SoundID.Item1;
            item.autoReuse = true;
        }

        


    }
}