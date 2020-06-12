using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace OrsonsMod.Items.Weapons.Shortswords
{
    public class Puree : ModItem
    {
        public override void SetStaticDefaults()
        {

            Tooltip.SetDefault("No real reason to make this over any other weapon");
        }

        public override void SetDefaults()
        {
            item.damage = 21;
            item.melee = true;
            item.width = 42;
            item.height = 40;
            item.useTime = 16;
            item.useTurn = true;
            item.useAnimation = 16;
            item.useStyle = ItemUseStyleID.Stabbing;
            item.knockBack = 7;
            item.value = 2000;
            item.rare = ItemRarityID.Blue;
            //item.crit = 2;
            item.UseSound = SoundID.Item1;
            item.autoReuse = false;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.CrimtaneBar, 8);

            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(this);
            recipe.AddRecipe();


        }
        public override void MeleeEffects(Player player, Rectangle hitbox)
        {
            if (player.direction == -1)
            {
                int Dustid1 = Dust.NewDust(player.Center - new Vector2(hitbox.Width, 0), hitbox.Width, hitbox.Height, DustID.t_Flesh);
                Main.dust[Dustid1].noGravity = true;
            }
            else
            {
                int Dustid = Dust.NewDust(player.Center, hitbox.Width, hitbox.Height, DustID.t_Flesh);
                Main.dust[Dustid].noGravity = true;
            }


        }
    }
}