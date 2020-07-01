
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

using Microsoft.Xna.Framework;

namespace OrsonsMod.Items.Weapons.Magic
{
    public class VileSpitBarrier : ModItem
    {
        public override void SetStaticDefaults()
        {
            Tooltip.SetDefault("Conjures up balls of vile spit that surround you");
        }

        public override void SetDefaults()
        {
            item.damage = 14;
            item.noMelee = true;
            item.magic = true;
            item.knockBack = 3f;
            item.rare = ItemRarityID.Blue;
            item.width = 58;
            item.height = 26;
            item.useTime = 20;
            item.UseSound = SoundID.Item24;
            item.useStyle = ItemUseStyleID.HoldingOut;
            item.shootSpeed = 9f;
            item.autoReuse = true;
            item.useAnimation = 20;
            item.shoot = mod.ProjectileType("VileSpit");
            item.mana = 10;
            item.value = 3300;

        }
        public override bool CanUseItem(Player player)
        {
            return !(player.ownedProjectileCounts[mod.ProjectileType("VileSpit")] >= 5);
        }
        

    }
}
