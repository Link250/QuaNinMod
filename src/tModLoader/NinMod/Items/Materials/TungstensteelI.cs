using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace NinMod.Items.Materials
{
	public class Tungstensteel : ModItem
	{
		public override void SetDefaults()
		{
			item.name = "Tungstensteel";
			item.width = 20;
			item.height = 20;
			item.maxStack = 999;
			AddTooltip("Used in strong tools");
			item.value = 900;
			item.rare = 1;
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(704, 1);
			recipe.AddIngredient(21, 1);
			recipe.SetResult(this, 2);
			recipe.AddTile(18);
			recipe.AddRecipe();
			ModRecipe recipe1 = new ModRecipe(mod);
			recipe1.AddIngredient(705, 1);
			recipe1.AddIngredient(22, 1);
			recipe1.SetResult(this, 2);
			recipe1.AddTile(18);
			recipe1.AddRecipe();
		}

		
	}
}