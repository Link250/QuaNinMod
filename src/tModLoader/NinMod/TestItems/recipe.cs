using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace NinMod.TestItems
{
	public class recipe : ModItem
	{
        static Boolean enabled = false;
		public override void AddRecipes()
		{
			AddDirtyRecipe(ItemID.DirtBlock, 99);
			AddDirtyRecipe(ItemID.Gel, 995);
			AddDirtyRecipe(ItemID.MusketBall, 995);
			AddDirtyRecipe(3549, 1);
			AddDirtyRecipe(ItemID.FragmentNebula, 995);
			AddDirtyRecipe(ItemID.FragmentSolar, 995);
			AddDirtyRecipe(ItemID.FragmentStardust, 995);
			AddDirtyRecipe(ItemID.FragmentVortex, 995);
			AddDirtyRecipe(ItemID.LunarBar, 995);
			AddDirtyRecipe(ItemID.LifeCrystal, 95);
			AddDirtyRecipe(ItemID.ManaCrystal, 95);
			AddDirtyRecipe(ItemID.PlatinumCoin, 95);
			AddDirtyRecipe(ItemID.MechanicalSkull, 95);
			AddDirtyRecipe(ItemID.MechanicalEye, 95);
			AddDirtyRecipe(ItemID.MechanicalWorm, 95);
			AddDirtyRecipe(ItemID.ChlorophyteBullet, 995);
			AddDirtyRecipe(267, 995);
			AddDirtyRecipe(3202, 1);
			AddDirtyRecipe(3124, 1);
			AddDirtyRecipe(1613, 1);
			AddDirtyRecipe(2269, 1);
			AddDirtyRecipe(19, 1);
			AddDirtyRecipe(3000, 1);
            AddDirtyRecipe(ItemID.BirdStatue);
            AddDirtyRecipe(ItemID.Wire);
            AddDirtyRecipe(ItemID.MulticolorWrench);
            AddDirtyRecipe(ItemID.RedPressurePlate);
            AddDirtyRecipe(ItemID.EoCShield);
            AddDirtyRecipe(ItemID.FrostsparkBoots);
            AddDirtyRecipe(ItemID.MasterNinjaGear);
			
		
        }
		
		private void AddDirtyRecipe(int itemID, int stack = 1){
            if (enabled) {
                ModRecipe recipe = new ModRecipe(mod);
                recipe.AddTile(18);
                recipe.AddIngredient(ItemID.DirtBlock, 1);
                recipe.SetResult(itemID, stack);
                recipe.AddRecipe();
            }
		}
	}
}