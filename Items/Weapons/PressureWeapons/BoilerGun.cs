using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace OrsonsMod.Items.Weapons.PressureWeapons
{
	public class BoilerGun : PressureWeapon
	{
		public override void SetStaticDefaults()
		{

			Tooltip.SetDefault("Shoot to increase pressure and unload 5 bullets for one when at max pressure");
		}

		public override void SetDefaults()
		{
			item.damage = 25;
			baseDamage = item.damage;
			pressureDamage = 30;
			item.ranged = true;
			item.noMelee = true;
			item.useTime = 29;
			item.useTurn = true;
			item.useAnimation = 29;
			item.useStyle = ItemUseStyleID.HoldingOut;
			item.knockBack = 4;
			baseKnockback = item.knockBack;
			pressureKnockback = 8;
			item.value = 40000;
			item.rare = ItemRarityID.LightRed;
			baseCrit = item.crit;
			pressureCrit = 11;
			item.UseSound = SoundID.Item11;
			item.autoReuse = false;
			item.shootSpeed = 8;
			baseShootspeed = item.shootSpeed;
			pressureShootspeed = 11;
			item.shoot = ProjectileID.Bullet;
			item.useAmmo = AmmoID.Bullet;
		}
        public override void safeUpdateInv(Player player)
        {
          
			if ( boilerGunProj[0] > 0 && Main.time % 10 == 0)
			{
				Projectile.NewProjectile(new Vector2(boilerGunProj[1], boilerGunProj[2]), new Vector2(boilerGunProj[3], boilerGunProj[4]), (int)boilerGunProj[5], (int)boilerGunProj[6], boilerGunProj[7], player.whoAmI);
				boilerGunProj[0] -= 1;

			}
		}

        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
		{
			if (pressure >= maxPressure)
			{ pressure = 0; boilerGunProj = new float[8] { 4, position.X, position.Y, speedX, speedY, type, damage, knockBack }; } 
			else
			{
				pressure += 1;
			}


			return true;
		}

	}
}