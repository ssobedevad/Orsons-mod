
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

using Microsoft.Xna.Framework;

namespace OrsonsMod.Items.Weapons.Blowpipes
{
    public class Macula : ModItem
    {


        public override void SetDefaults()
        {
            item.damage = 22;
            item.noMelee = true;
            item.ranged = true;
            item.autoReuse = false;
            item.rare = ItemRarityID.Green;

            item.useTime = 28;
            item.UseSound = SoundID.Item63;
            item.useStyle = ItemUseStyleID.HoldingOut;
            item.shootSpeed = 10f;
            item.useAnimation = 28;
            item.shoot = ProjectileID.Seed;
            item.useAmmo = AmmoID.Dart;
            item.value = 5000;
            
        }
        public override void UpdateInventory(Player player)
        {
            player.GetModPlayer<OrsonsPlayer>().SeedCollect = true;
        }



    }
}
