
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

using Microsoft.Xna.Framework;

namespace OrsonsMod.Items.Weapons.Magic
{
    public class SlimeShield : ModItem
    {
        public override void SetStaticDefaults()
        {
            Tooltip.SetDefault("Conjures a slimy ball to surround you");
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
            item.shoot = mod.ProjectileType("SlimeShield");
            item.mana = 10;
            item.value = 3300;
            
        }
        public override bool CanUseItem(Player player)
        {
            return !(player.ownedProjectileCounts[mod.ProjectileType("SlimeShield")] >= 5);
        }
        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {


            
            Projectile.NewProjectile(position.X, position.Y, speedX, speedY, type, damage, knockBack, player.whoAmI);


            return false;
        }

    }
}
