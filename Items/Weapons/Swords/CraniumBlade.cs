using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace OrsonsMod.Items.Weapons.Swords
{
	public class CraniumBlade : ModItem
	{
		
		public override void SetDefaults()
		{
			item.damage = 28;
			item.melee = true;
			
			item.useTime = 22;
			item.useTurn = true;
			item.useAnimation = 22;
			item.useStyle = ItemUseStyleID.SwingThrow;
			item.knockBack = 4;
			item.value = 20000;
			item.rare = ItemRarityID.Orange;
			item.crit = 4;
			item.UseSound = SoundID.Item1;
			item.autoReuse = false;
		}

		
	}
}