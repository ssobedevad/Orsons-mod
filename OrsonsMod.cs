using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace OrsonsMod
{
	public class OrsonsMod : Mod
	{
        public override void AddRecipeGroups()
        {

            RecipeGroup group = new RecipeGroup(() => Language.GetTextValue("LegacyMisc.37") + " Tier 3 PreHardmode Bar", new int[]
            {
            ItemID.SilverBar,

            ItemID.TungstenBar,
            });
            RecipeGroup.RegisterGroup("T3PHmB", group);
        }
        }
}