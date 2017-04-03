using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using System.Collections.Generic;
using Terraria.GameContent;
using Terraria.GameContent.Achievements;
using Terraria.Graphics.Shaders;

namespace NinMod.Items.Weapons.Melee 
    {
    public class Rockcleaver : ModItem
	{
		public override void SetDefaults()
		{
			
			item.name = "Ignis glacies";
			item.damage = 36;
			item.melee = true;
			item.width = 40;
			item.height = 40;
			item.toolTip = "It totally is not fire ice in another language!";
			item.useTime = 27;
			item.useAnimation = 27;
			item.useStyle = 1;
			item.knockBack = 5;
			item.value = 000050;
			item.rare = 2;
			item.crit = 4;
			item.UseSound = SoundID.Item1;
			item.autoReuse = true;

			
		}
	
		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddTile(18);
			recipe.SetResult(this);
			recipe.AddIngredient(ModLoader.GetMod("NinMod").GetItem("Ignis"));
			recipe.AddIngredient(ModLoader.GetMod("NinMod").GetItem("glacies"));
			recipe.AddRecipe();
		}
		
		public override void OnHitNPC(Player player, NPC target, int damage, float knockback, bool crit)
		{
			int[] randBuff = {24,44,30,30,30};
			
			target.AddBuff(randBuff[(int)(Main.rand.NextFloat()*5)], 120);

		}
	}
}