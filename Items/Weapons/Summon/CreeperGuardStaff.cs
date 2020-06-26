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
    public class CreeperGuardStaff : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Creeper Guard Staff");
            Tooltip.SetDefault("Summons a swarm of creepers to protect you");
        }
        public override void SetDefaults()
        {
            item.damage = 18;
            item.summon = true;
            item.knockBack = 12f;
            item.useTime = 25;
            item.useAnimation = 25;
            item.buffType = mod.BuffType("CreeperBodyGuard");
            item.shoot = mod.ProjectileType("CreeperGuard");
            item.useStyle = ItemUseStyleID.SwingThrow;
            item.noMelee = true;
            item.rare = ItemRarityID.Orange;
            item.value = 20000;
            item.mana = 10;

        }
        public override bool CanUseItem(Player player)
        {
            if (player.ownedProjectileCounts[mod.ProjectileType("CreeperGuard")] > 0)
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
            for (int i = 0; i < 5; i++)
            {
                Projectile.NewProjectile(position.X + Main.rand.Next(-25,25), position.Y + Main.rand.Next(-25, 25), 0, 0, type, damage, knockBack, player.whoAmI, number);
                number += 1;
            }
            return false;
        }
       

    }
}
