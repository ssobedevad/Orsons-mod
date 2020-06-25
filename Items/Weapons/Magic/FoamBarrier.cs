
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

using Microsoft.Xna.Framework;

namespace OrsonsMod.Items.Weapons.Magic
{
    public class FoamBarrier : ModItem
    {
        public override void SetStaticDefaults()
        {
            Tooltip.SetDefault("Conjure up a foamy ball that will surround you and disease foes");
        }

        public override void SetDefaults()
        {
            item.damage = 18;
            item.noMelee = true;
            item.magic = true;
            item.knockBack = 3f;
            item.rare = ItemRarityID.Orange;
            item.width = 58;
            item.height = 26;
            item.useTime = 18;
            item.UseSound = SoundID.Item24;
            item.useStyle = ItemUseStyleID.HoldingOut;
            item.shootSpeed = 9f;
            item.useAnimation = 18;
            item.shoot = mod.ProjectileType("FoamyBall");
            item.mana = 14;
            item.value = 10000;
            item.crit = 1;
        }
        public override bool CanUseItem(Player player)
        {
            return !(player.GetModPlayer<OrsonsPlayer>().FoamBalls >= 6);
        }
        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {


                player.GetModPlayer<OrsonsPlayer>().FoamBalls += 1;
                Projectile.NewProjectile(position.X, position.Y, speedX, speedY, type, damage, knockBack, player.whoAmI);
            

            return false;
        }

    }
}
