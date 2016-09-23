using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace NinMod.Items.TestItems
{
	public class TestItem : ModItem
	{
		public override void SetDefaults()
		{
			item.name = "Test Item";
			item.width = 20;
			item.height = 20;
			item.maxStack = 420;
			AddTooltip("lala");
			item.value = 1000;
			item.rare = 5;
			item.ammo = 342;
			item.consumable = true;
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.DirtBlock, 1);
			recipe.AddTile(18);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}