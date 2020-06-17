using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace OrsonsMod.Items.Weapons.Shortswords
{
    public class FieryLongDagger : ModItem
    {
        public override void SetStaticDefaults()
        {

            Tooltip.SetDefault("This is also made out of Fire!");
        }

        public override void SetDefaults()
        {
            item.damage = 33;
            item.melee = true;
            item.width = 42;
            item.height = 42;
            item.useTime = 28;
            item.useTurn = true;
            item.useAnimation = 28;
            item.useStyle = ItemUseStyleID.Stabbing;
            item.knockBack = 3.4f;
            item.value = 5000;
            item.rare = ItemRarityID.Blue;
            //item.crit = 2;
            item.UseSound = SoundID.Item1;
            item.autoReuse = false;
        }
        public override void OnHitNPC(Player player, NPC target, int damage, float knockBack, bool crit)
        {
            if (Main.rand.Next(0, 2) == 1)
            {
                target.AddBuff(BuffID.OnFire, 240);
            }
        }
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.HellstoneBar, 12);

            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(this);
            recipe.AddRecipe();


        }


    }
}