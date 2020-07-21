using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Microsoft.Xna.Framework;
using OrsonsMod.Projectiles.Friendly.Summon;

namespace OrsonsMod.Items.Weapons.Summon.Whips
{
    public class SpikeySlapper : ModItem
    {
        public override void SetStaticDefaults()
        {
            
            Tooltip.SetDefault("The giant spikey ball in a smaller more contained version" + "\n100 summon tag damage"+"\n100% summon tag crit" + "\nYour summons will focus struck enemies");
        }
        public override void SetDefaults()
        {

            item.useStyle = ItemUseStyleID.SwingThrow;
            item.useAnimation = 30;
            item.useTime = 30;
            item.width = 18;
            item.height = 18;
            item.shoot = mod.ProjectileType("SpikeySlapper");
            item.UseSound = SoundID.Item1;
            item.noMelee = true;
            item.summon = true;
            item.noUseGraphic = true;
            item.autoReuse = true;
            item.damage = 99999999;
            item.knockBack = 3;
            item.shootSpeed = 8;
            item.rare = ItemRarityID.Purple;
            item.value = 99999999;

        }



    }
}
