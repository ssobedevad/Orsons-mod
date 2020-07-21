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
    public class EaterNestStaff : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Eater Nest Staff");
            Tooltip.SetDefault("Summons an eater nest to spawn baby eaters");
        }
        public override void SetDefaults()
        {
            item.damage = 16;
            item.summon = true;
            item.sentry = true;
            
            item.useTime = 26;
            item.useAnimation = 26;
            item.buffType = mod.BuffType("EaterNest");
            item.shoot = mod.ProjectileType("EaterNest");
            item.useStyle = ItemUseStyleID.SwingThrow;
            item.noMelee = true;
            item.rare = ItemRarityID.Orange;
            item.value = 20000;
            item.mana = 10;

        }
        
        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
            player.AddBuff(item.buffType, 7200, true);
           
            position = Main.MouseWorld;

            int turretNum = 0;
            for (int i = 0; i < Main.projectile.Length;i++)
            {
                Projectile proji = Main.projectile[i];
                if(proji.active && proji.sentry)
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
