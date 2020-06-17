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
    public class SwarmFlyStaff : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Swarm Fly Staff");
            Tooltip.SetDefault("Summons a swarm of flies to fight for you");
        }
        public override void SetDefaults()
        {
            item.damage = 14;
            item.summon = true;
            item.height = 28;
            item.width = 27;
            item.useTime = 25;
            item.useAnimation = 25;
            item.buffType = mod.BuffType("SwarmFlyBuff");
            item.shoot = mod.ProjectileType("FlySwarm");
            item.useStyle = ItemUseStyleID.SwingThrow;
            item.noMelee = true;

        }
        
        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
            player.AddBuff(item.buffType, 2, true);
            position = Main.MouseWorld;
            return true;
        }

    }
}
