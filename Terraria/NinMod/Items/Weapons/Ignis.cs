using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using System.Collections.Generic;
using Terraria.GameContent;
using Terraria.GameContent.Achievements;
using Terraria.Graphics.Shaders;

namespace NinMod.Items.Weapons
{
	public class Ignis : ModItem
	{
		public override void SetDefaults()
		{
			
			item.name = "Ignis";
			item.damage = 24;
			item.melee = true;
			item.width = 40;
			item.height = 40;
			item.toolTip = "Just hot obsidian added to be honest";
			item.useTime = 32;
			item.useAnimation = 32;
			item.useStyle = 1;
			item.knockBack = 4;
			item.value = 000020;
			item.rare = 2;
			item.crit = 4;
			item.useSound = 1;
			item.autoReuse = true;

			
		}
	
		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddTile(18);
			recipe.SetResult(this);
			recipe.AddIngredient(ItemID.DirtBlock, 1);
			recipe.AddRecipe();
		}
		
		public override void OnHitNPC(Player player, NPC target, int damage, float knockback, bool crit)
		{
			int[] randBuff = {24,30,30};
			
			target.AddBuff(randBuff[(int)(Main.rand.NextFloat()*3)], 300);

		}
	}
}