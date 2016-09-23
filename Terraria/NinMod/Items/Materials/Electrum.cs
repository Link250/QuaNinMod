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
			recipe.AddIngredient(19, 1 /*Gold Bar*/);
			recipe.AddIngredient(21, 1 /*Silver Bar*/);
			recipe.SetResult(this, 2);
			recipe.AddTile(18);
			recipe.AddRecipe();
		}
	}
}