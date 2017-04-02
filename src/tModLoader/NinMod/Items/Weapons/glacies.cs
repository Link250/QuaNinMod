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
	public class glacies : ModItem
	{
		public override void SetDefaults()
		{
			
			item.name = "Glacies";
			item.damage = 17;
			item.melee = true;
			item.width = 42;
			item.height = 42;
			item.toolTip = "Just frozen fish scales added to be honest";
			item.useTime = 25;
			item.useAnimation = 25;
			item.useStyle = 1;
			item.knockBack = 2;
			item.value = 000020;
			item.rare = 2;
			item.crit = 3;
			item.UseSound = SoundID.Item1;
			item.autoReuse = true;

			
		}
	
		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddTile(18);
			recipe.SetResult(this);
			recipe.AddIngredient(883, 20);
			recipe.AddIngredient(1304);
			recipe.AddIngredient(1116);
			recipe.AddRecipe();
		}
		
		public override void OnHitNPC(Player player, NPC target, int damage, float knockback, bool crit)
		{
			int[] randBuff = {44,30,30};
			
			target.AddBuff(randBuff[(int)(Main.rand.NextFloat()*3)], 240);

		}
	}
}