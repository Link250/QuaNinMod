using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace NinMod.Items.Alchemy
{
	public class Basepotion : ModItem
	{
		public override void SetDefaults()
		{
			item.name = "Basic brew";
			item.width = 20;
			item.height = 20;
			item.maxStack = 999;
			AddTooltip("The first step into the alchemical wonderland!");
			item.value = 200;
			item.rare = 2;
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(31, 1);
			recipe.AddIngredient(23, 1);
			recipe.SetResult(this);
			recipe.AddTile(13);
			recipe.AddTile(355);
			recipe.AddRecipe();

		}
	}
}