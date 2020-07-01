
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

using Microsoft.Xna.Framework;

namespace OrsonsMod.Items.Weapons.Bows
{
    public class CerrebellumBow : ModItem
    {


        public override void SetDefaults()
        {
            item.damage = 22;
            item.noMelee = true;
            item.ranged = true;
            item.autoReuse = false;
            item.rare = ItemRarityID.Orange;
            
            item.useTime = 28;
            item.UseSound = SoundID.Item5;
            item.useStyle = ItemUseStyleID.HoldingOut;
            item.shootSpeed = 10f;
            item.useAnimation = 28;
            item.shoot = ProjectileID.WoodenArrowFriendly;
            item.useAmmo = AmmoID.Arrow;
            item.value = 20000;
            item.crit = 4;
        }


        
    }
}
