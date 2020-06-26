
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

using Microsoft.Xna.Framework;

namespace OrsonsMod.Items.Weapons.Magic
{
    public class ColdstoneCane : ModItem
    {
        public override void SetStaticDefaults()
        {
           
            Item.staff[item.type] = true;
        }


        public override void SetDefaults()
        {
            item.damage = 29;
            item.noMelee = true;
            item.magic = true;
            item.knockBack = 3f;
            item.rare = ItemRarityID.Orange;
            item.width = 58;
            item.height = 26;
            item.useTime = 25;
            item.UseSound = SoundID.Item24;
            item.useStyle = ItemUseStyleID.HoldingOut;
            item.shootSpeed = 9f;
            item.useAnimation = 25;
            item.shoot =ProjectileID.IceBolt;
            item.mana = 15;
            item.value = 10000;
            
        }
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(mod.ItemType("ColdstoneBar"), 18);

            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(this);
            recipe.AddRecipe();


        }



    }
}
