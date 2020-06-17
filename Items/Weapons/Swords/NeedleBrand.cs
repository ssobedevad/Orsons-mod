using Microsoft.Xna.Framework;
using OrsonsMod.Buffs.Debuffs;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace OrsonsMod.Items.Weapons.Swords
{
	public class NeedleBrand : ModItem
	{
		public override void SetStaticDefaults()
		{

			Tooltip.SetDefault("Right click to stab and inflict diseased");
		}

		public override void SetDefaults()
		{
			item.damage = 30;
			item.melee = true;
			item.width = 64;
			item.height = 64;
			item.useTime = 20;
			item.useTurn = true;
			item.useAnimation = 20;
			item.useStyle = ItemUseStyleID.SwingThrow;
			item.knockBack = 5;
			item.value = 10000;
			item.rare = ItemRarityID.Orange;
			
			item.UseSound = SoundID.Item1;
			item.autoReuse = false;
		}
        public override bool AltFunctionUse(Player player)
        {
			return true;
        }
   
		public override bool CanUseItem(Player player)
		{
			if (player.altFunctionUse == 2)
			{
				item.useStyle = ItemUseStyleID.Stabbing;
				item.useTime = 26;
				item.useAnimation = 26;
				item.damage = 50;
				
			}
			else
			{
				item.useStyle = ItemUseStyleID.SwingThrow;
				item.useTime = 20;
				item.useAnimation = 20;
				item.damage = 30;
				item.noMelee = false;
				
			}
			return true;
		}
		public override void OnHitNPC(Player player, NPC target, int damage, float knockBack, bool crit)
		{
			if (player.altFunctionUse == 2)
			{
				target.AddBuff(ModContent.BuffType<Diseased>(), 240);
			}
			
		}


	}
}