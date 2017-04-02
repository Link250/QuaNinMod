using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace NinMod.Items.Materials
{
	public class Electrum : ModItem
	{
		public override void SetDefaults()
		{
			item.name = "Electrum";
			item.width = 20;
			item.height = 20;
			item.maxStack = 999;
			AddTooltip("Used in special armors and sciency stuff");
			item.value = 1200;
			item.rare = 2;
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(19, 6 /*Gold Bar*/);
			recipe.AddIngredient(21, 6 /*Silver Bar*/);
			recipe.SetResult(this, 2);
			recipe.AddTile(null, "AlloySmelter");
			recipe.AddRecipe();
			ModRecipe recipe1 = new ModRecipe(mod);
			recipe1.AddIngredient(19, 6 /*Gold Bar*/);
			recipe1.AddIngredient(21, 6 /*Silver Bar*/);
			recipe1.SetResult(this, 2);
			recipe1.AddTile(18);
			recipe1.AddRecipe();
		}
	}
}