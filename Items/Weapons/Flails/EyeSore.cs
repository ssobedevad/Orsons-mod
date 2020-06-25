

using OrsonsMod.Projectiles;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace OrsonsMod.Items.Weapons.Flails
{
	public class EyeSore : ModItem
	{
		public override void SetDefaults()
		{
			item.width = 20;
			item.height = 20;
			item.value = 5000;
			item.rare = ItemRarityID.Green;
			item.noMelee = true;
			item.useStyle = ItemUseStyleID.HoldingOut;
			item.useAnimation = 22;
			item.useTime = 22;
			item.knockBack = 5f;
			item.damage = 14;
			item.noUseGraphic = true;
			item.shoot = mod.ProjectileType("EyeSore");
			item.shootSpeed = 16f;
			item.UseSound = SoundID.Item1;
			item.melee = true;
			
			item.channel = true;
		}

		
	}
}