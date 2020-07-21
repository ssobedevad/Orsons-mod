using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace OrsonsMod.Items.Weapons.PressureWeapons
{
	public class RadiatorWhip : PressureWeapon
	{
		public override void SetStaticDefaults()
		{

			Tooltip.SetDefault("Can Cause an explosion on impact when at full pressure" + "\n7/10 summon tag damage" + "\nYour summons will focus struck enemies");
		}

		public override void SetDefaults()
		{
			item.damage = 28;
			baseDamage = item.damage;
			pressureDamage = 34;
			item.summon = true;
			item.noMelee = true;
			item.noUseGraphic = true;
			item.useTime = 30;
			
			item.useAnimation = 30;
			item.useStyle = ItemUseStyleID.SwingThrow;
			item.knockBack = 1;
			baseKnockback = item.knockBack;
			pressureKnockback = 3;
			item.value = 40000;
			item.rare = ItemRarityID.LightRed;
			
			item.UseSound = SoundID.Item1;
			item.autoReuse = false;
			item.shootSpeed = 8;
			baseShootspeed = item.shootSpeed;
			pressureShootspeed = item.shootSpeed;
			item.shoot = mod.ProjectileType("RadiatorWhip");
			
		}
		
		public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
		{
			if (pressure < maxPressure)
			{
				pressure += 1;
			}
			
				return true;


			}

	}
}