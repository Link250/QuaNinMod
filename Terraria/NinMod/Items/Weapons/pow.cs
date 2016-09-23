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
	public class pow : ModItem
	{
		public override void SetDefaults()
		{
			
			item.name = "Pow Hammer";
			item.damage = 23;
			item.melee = true;
			item.width = 40;
			item.height = 40;
			item.toolTip = "It's e me!";
			item.useTime = 30;
			item.useAnimation = 30;
			item.useStyle = 1;
			item.knockBack = 2;
			item.value = 002000;
			item.crit = 6;
			item.rare = 4;
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
			target.AddBuff(31, 60);

		}
	}
}