using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace NinMod.Items.Alchemy
{
	public class Basepotionplus : ModItem
	{
		public override void SetDefaults()
		{
			item.name = "Refined brew";
			item.width = 20;
			item.height = 20;
			item.maxStack = 999;
			AddTooltip("The most commonly used brew for a scholar alchemist");
			item.value = 800;
			item.rare = 4;
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModLoader.GetMod("NinMod").GetItem("Basepotion"));
            recipe.AddIngredient(318, 1);
            recipe.AddIngredient(183, 1);
            recipe.SetResult(this);
			recipe.AddTile(13);
			recipe.AddTile(355);
			recipe.AddRecipe();

		}
	}
}