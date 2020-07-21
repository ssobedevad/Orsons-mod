using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Microsoft.Xna.Framework;
using OrsonsMod.Projectiles.Friendly.Summon.Minions;

namespace OrsonsMod.Items.Weapons.Summon
{
    public class BeeHiveStaff : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Bee Hive Staff");
            Tooltip.SetDefault("Summons a bee hive to spawn in friendly bees");
        }
        public override void SetDefaults()
        {
            item.damage = 20;
            item.summon = true;
            item.sentry = true;

            item.useTime = 26;
            item.useAnimation = 26;
            item.buffType = mod.BuffType("BeeHive");
            item.shoot = mod.ProjectileType("BeeHive");
            item.useStyle = ItemUseStyleID.SwingThrow;
            item.noMelee = true;
            item.rare = ItemRarityID.Green;
            item.value = 20000;
            item.mana = 10;

        }
        

        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
            player.AddBuff(item.buffType, 7200, true);
            player.FindSentryRestingSpot(item.shoot, out int worldX, out int worldY, out int pushYUp);
            position = new Vector2(worldX,worldY-pushYUp);
            int turretNum = 0;
            for (int i = 0; i < Main.projectile.Length; i++)
            {
                Projectile proji = Main.projectile[i];
                if (proji.active && proji.sentry)
                { turretNum++; }


            }

            if (turretNum >= player.maxTurrets)
            {
                player.WipeOldestTurret();
            }
            return true;
        }


    }
}
