using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace OrsonsMod.Items.Weapons.PressureWeapons
{
	public class PressureCooker : PressureWeapon
	{
		public override void SetStaticDefaults()
		{

			Tooltip.SetDefault("Attacking Enemies Builds Pressure, and causes an explosion when you attack at max pressure");
		}

		public override void SetDefaults()
		{
			item.damage = 34;
			baseDamage = item.damage;
			pressureDamage = 69;
			item.melee = true;
			
			item.useTime = 22;
			item.useTurn = true;
			item.useAnimation = 22;
			item.useStyle = ItemUseStyleID.SwingThrow;
			item.knockBack = 4;
			baseKnockback = item.knockBack;
			pressureKnockback = 8;
			item.value = 40000;
			item.rare = ItemRarityID.LightRed;
			baseCrit = item.crit;
			pressureCrit = 11;
			item.UseSound = SoundID.Item1;
			item.autoReuse = false;

		}


		public override bool UseItem(Player player)
		{


			if (pressure < maxPressure)
			{
				pressure += 1;
			}

			return true;
		}
		public override void OnHitNPC(Player player, NPC target, int damage, float knockBack, bool crit)
		{
			if (pressure >= maxPressure)
			{ pressure = 0; Projectile.NewProjectile(player.Center, Vector2.Zero, ProjectileID.DD2ExplosiveTrapT3Explosion, player.HeldItem.damage, player.HeldItem.knockBack, player.whoAmI); }
			else { pressure += 2; }
		}
	}
}