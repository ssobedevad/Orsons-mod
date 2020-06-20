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
    public class BoneSmack : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Bone Smack");
            Tooltip.SetDefault("Smack em' bois"+"\n5 summon tag damage"+"\nHitting enemies grants you the Necrotic Bastion buff"+ "\nYour summons will focus struck enemies");
        }
        public override void SetDefaults()
        {
            
            item.useStyle = ItemUseStyleID.SwingThrow;
            item.useAnimation = 30;
            item.useTime = 30;
            item.width = 18;
            item.height = 18;
            item.shoot = mod.ProjectileType("BoneSmack");
            item.UseSound = SoundID.Item1;
            item.noMelee = true;
            item.summon = true;
            item.noUseGraphic = true;
            item.autoReuse = true;
            item.damage = 18;
            item.knockBack = 2;
            item.shootSpeed = 8;
            item.rare = ItemRarityID.Orange;

        }

       

    }
}
