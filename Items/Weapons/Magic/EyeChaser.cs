
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

using Microsoft.Xna.Framework;

namespace OrsonsMod.Items.Weapons.Magic
{
    public class EyeChaser : ModItem
    {
        


        public override void SetDefaults()
        {
            item.damage = 15;
            item.noMelee = true;
            item.magic = true;
            item.knockBack = 2f;
            item.rare = ItemRarityID.Green;
            
            item.useTime = 24;
            item.UseSound = SoundID.Item24;
            item.useStyle = ItemUseStyleID.HoldingOut;
            item.shootSpeed = 8f;
            item.useAnimation = 24;
            item.shoot = mod.ProjectileType("EyeChaser");
            item.mana = 15;
            item.value = 5000;

        }
        



    }
}
