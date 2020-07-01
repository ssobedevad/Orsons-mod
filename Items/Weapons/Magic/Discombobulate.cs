
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

using Microsoft.Xna.Framework;

namespace OrsonsMod.Items.Weapons.Magic
{
    public class Discombobulate : ModItem
    {



        public override void SetDefaults()
        {
            item.damage = 23;
            item.noMelee = true;
            item.magic = true;
            item.knockBack = 2f;
            item.rare = ItemRarityID.Orange;
            item.channel = true;
            item.useTime = 26;
            item.UseSound = SoundID.Item24;
            item.useStyle = ItemUseStyleID.HoldingOut;
            item.shootSpeed = 8f;
            item.useAnimation = 26;
            item.shoot = mod.ProjectileType("Blood");
            item.mana = 15;
            item.value = 20000;

        }




    }
}
