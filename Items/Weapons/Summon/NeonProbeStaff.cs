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
    public class NeonProbeStaff : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Neon Probe Staff");
            Tooltip.SetDefault("Summons a neon probe to fight for you");
        }
        public override void SetDefaults()
        {
            item.damage = 15;
            item.summon = true;
           
            item.useTime = 25;
            item.useAnimation = 25;
            item.buffType = mod.BuffType("NeonProbeMinion");
            item.shoot = mod.ProjectileType("NeonProbe");
            item.useStyle = ItemUseStyleID.SwingThrow;
            item.noMelee = true;
            item.rare = ItemRarityID.Green;
            item.value = 10000;
            item.mana = 10;

        }

        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
            player.AddBuff(item.buffType, 2, true);
            position = Main.MouseWorld;
            return true;
        }
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(mod.ItemType("NeonBar"), 15);

            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(this);
            recipe.AddRecipe();



        }

    }
}
