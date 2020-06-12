using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace OrsonsMod.Items.Weapons.Shortswords
{
    public class ThreadOfGrass : ModItem
    {
        public override void SetStaticDefaults()
        {

            Tooltip.SetDefault("Has a chance to poison enemies");
        }

        public override void SetDefaults()
        {
            item.damage = 25;
            item.melee = true;
            item.width = 38;
            item.height = 38;
            item.useTime = 25;
            item.useTurn = true;
            item.useAnimation = 25;
            item.useStyle = ItemUseStyleID.Stabbing;
            item.knockBack = 3;
            item.value = 2000;
            item.rare = ItemRarityID.Orange;
            //item.crit = 2;
            item.UseSound = SoundID.Item1;
            item.autoReuse = false;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.Stinger, 8);
            recipe.AddIngredient(ItemID.JungleSpores, 10);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(this);
            recipe.AddRecipe();


        }
        public override void OnHitNPC(Player player, NPC target, int damage, float knockBack, bool crit)
        {
            if (Main.rand.Next(0, 4) == 1)
            {
                target.AddBuff(BuffID.Poisoned, 540);
            }
        }
        public override void MeleeEffects(Player player, Rectangle hitbox)
        {
            if (player.direction == -1)
            {
                int Dustid1 = Dust.NewDust(player.Center - new Vector2(hitbox.Width, 0), hitbox.Width, hitbox.Height, DustID.GrassBlades);
                Main.dust[Dustid1].noGravity = true;
            }
            else
            {
                int Dustid = Dust.NewDust(player.Center, hitbox.Width, hitbox.Height, DustID.GrassBlades);
                Main.dust[Dustid].noGravity = true;
            }


        }


    }
}