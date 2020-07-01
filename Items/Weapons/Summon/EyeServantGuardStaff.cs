using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Microsoft.Xna.Framework;


namespace OrsonsMod.Items.Weapons.Summon
{
    public class EyeServantGuardStaff : ModItem
    {
        public override void SetStaticDefaults()
        {
            
            Tooltip.SetDefault("Summons servants of Cthulhu to protect you");
            
        }
        public override void SetDefaults()
        {
            item.damage = 14;
            item.summon = true;
            item.knockBack = 10f;
            item.useTime = 25;
            item.useAnimation = 25;
            item.buffType = mod.BuffType("CthuluServantBodyGuard");
            item.shoot = mod.ProjectileType("EyeServantGuard");
            item.useStyle = ItemUseStyleID.SwingThrow;
            item.noMelee = true;
            item.rare = ItemRarityID.Green;
            item.value = 20000;
            item.mana = 10;
            
        }
        public override bool CanUseItem(Player player)
        {
            if (player.ownedProjectileCounts[mod.ProjectileType("EyeServantGuard")] > 0 || player.GetModPlayer<OrsonsPlayer>().guardMinion == true)
            {
                return false;
            }
            return true;
        }

        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
            player.AddBuff(item.buffType, 2, true);
            position = Main.MouseWorld;
            int number = 1;
            for (int i = 0; i < 4; i++)
            {
                Projectile.NewProjectile(position.X + Main.rand.Next(-25, 25), position.Y + Main.rand.Next(-25, 25), 0, 0, type, damage, knockBack, player.whoAmI, number);
                number += 1;
            }
            return false;
        }


    }
}
