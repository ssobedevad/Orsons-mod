
using Microsoft.Xna.Framework;
using OrsonsMod.Projectiles.Friendly.Magic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace OrsonsMod.Items.Weapons.Magic
{
    public class NeonFlasher : ModItem
    {
        public override void SetStaticDefaults()
        {
            Tooltip.SetDefault("Casts a beam of light that damages anything caught in it");
        }

        public override void SetDefaults()
        {
            item.damage = 18;
            item.noMelee = true;
            item.magic = true;
            item.channel = true; //Channel so that you can held the weapon [Important]
            item.mana = 17;
            item.rare = ItemRarityID.Green;
            
            item.useTime = 30;
            item.UseSound = SoundID.Item13;
            item.useStyle = ItemUseStyleID.HoldingOut;
            item.shootSpeed = 14f;
            item.useAnimation = 30;
            item.shoot = ModContent.ProjectileType<NeonFlash>();
            item.value = 2500;
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
