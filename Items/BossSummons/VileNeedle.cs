using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using OrsonsMod.Items.Materials;
//using static DRGN.DRGNPlayer;

namespace OrsonsMod.Items.BossSummons
{
    public class VileNeedle : ModItem
    {
        public override void SetStaticDefaults()
        {
            
            Tooltip.SetDefault("Summons Dr Pandemic");
        }
        public override void SetDefaults()
        {
            item.height = 28;
            item.width = 28;
            item.useTime = 25;
            item.useAnimation = 25;
            item.consumable = true;
            item.useStyle = ItemUseStyleID.SwingThrow;
            item.rare = ItemRarityID.Green;
            item.maxStack = 999;
        }
        public override bool CanUseItem(Player player)
        {

            
            bool alreadySpawned = NPC.AnyNPCs(mod.NPCType("DrPandemic"));
            return (!alreadySpawned);
        }
        public override bool UseItem(Player player)

        {

            NPC.SpawnOnPlayer(player.whoAmI, mod.NPCType("DrPandemic")); // Spawn the boss within a range of the player. 
            Main.PlaySound(SoundID.Roar, player.Right, 0);
            return true;


        }
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<RabidFoam>(), 10);
            recipe.AddRecipeGroup("T3PHmB");
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(this);
            recipe.AddRecipe();
            
        }
    }
}
