using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace NinMod.Items.blocks
{
	public class AlloySmelter : ModItem
	{
		public override void SetDefaults()
		{
			item.name = "AlloySmelter";
			item.width = 28;
			item.height = 14;
			item.maxStack = 99;
			AddTooltip("Smelt metals together");
			item.useTurn = true;
			item.autoReuse = true;
			item.useAnimation = 15;
			item.useTime = 10;
			item.useStyle = 1;
			item.consumable = true;
			item.value = 650;
			item.createTile = mod.TileType("AlloySmelter");
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(2119, 30);
			recipe.AddIngredient(205, 1);
			recipe.AddIngredient(3111, 5);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}