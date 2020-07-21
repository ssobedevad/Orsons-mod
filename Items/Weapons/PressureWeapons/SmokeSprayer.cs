using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace OrsonsMod.Items.Weapons.PressureWeapons
{
	public class SmokeSprayer : PressureWeapon
	{
		public override void SetStaticDefaults()
		{

			Tooltip.SetDefault("Lightly puffs out toxic smoke and can furiously spew out a stream of smoke when at full pressure");
		}

		public override void SetDefaults()
		{
			item.damage = 26;
			baseDamage = item.damage;
			pressureDamage = 33;
			item.magic = true;
			item.noMelee = true;
			item.useTime = 23;
			item.useTurn = true;
			item.useAnimation = 23;
			item.useStyle = ItemUseStyleID.HoldingOut;
			item.knockBack = 0;
			baseKnockback = item.knockBack;
			pressureKnockback = 1;
			item.value = 40000;
			item.rare = ItemRarityID.LightRed;
			baseCrit = item.crit;
			pressureCrit = 15;
			item.UseSound = SoundID.Item1;
			item.autoReuse = false;
			item.shootSpeed = 6;
			baseShootspeed = item.shootSpeed;
			pressureShootspeed = 8;
			item.shoot = mod.ProjectileType("SmokeSpray");
			item.mana = 15;
			baseManaCost = item.mana;
			pressureManaCost = 0;
			
		}
		public override void safeUpdateInv(Player player)
		{

			if (boilerGunProj[0] > 0 && Main.time % 10 == 0)
			{
				Projectile.NewProjectile(new Vector2(boilerGunProj[1] + Main.rand.NextFloat(-2f, 2f), boilerGunProj[2] + Main.rand.NextFloat(-2f, 2f)), new Vector2(boilerGunProj[3]+Main.rand.NextFloat(-2f,2f), boilerGunProj[4] + Main.rand.NextFloat(-2f, 2f)), (int)boilerGunProj[5], (int)boilerGunProj[6], boilerGunProj[7], player.whoAmI);
				boilerGunProj[0] -= 1;

			}
		}

		public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
		{
			if (pressure >= maxPressure)
			{ pressure = 0; boilerGunProj = new float[8] { 6, position.X, position.Y, speedX, speedY, type, damage, knockBack }; }
			else
			{
				pressure += 1;
			}


			return true;
		}

	}
}