using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using System.Collections.Generic;
using Terraria.GameContent;
using Terraria.GameContent.Achievements;
using Terraria.Graphics.Shaders;

namespace NinMod.Items.Weapons.Magic
    {
	public class Manabomb : ModItem
	{
		public override void SetDefaults()
		{
			item.name = "Manabomb";
			item.damage = 25;
			item.magic = true;
			item.crit = 25;
			item.mana = 7;
			item.width = 40;
			item.height = 40;
			item.toolTip = "Creates a Magic mine that explodes after a second infront of you";
			item.useTime = 33;
			item.useAnimation = 33;
			item.useStyle = 5;
			Item.staff[item.type] = true;
			item.noMelee = true;
			item.knockBack = 7;
			item.value = 020000;
			item.rare = 5;
			item.UseSound = SoundID.Item20;
			item.autoReuse = true;
			item.shoot = 644;
			item.shootSpeed = 16f;
		}
		
		public override bool Shoot(Player player, ref Microsoft.Xna.Framework.Vector2 position, ref float speedX, ref float speedY, ref int type , ref int damage, ref float knockBack)
		{
			float spread = 45f * 0.000016f;
			float baseSpeed = (float)Math.Sqrt(speedX * speedX + speedY * speedY);
			double baseAngle = Math.Atan2(speedX, speedY);
			double randomAngle = baseAngle+(Main.rand.NextFloat()-0.5f)*spread;
			speedX = baseSpeed*(float)Math.Sin(randomAngle);
			speedY = baseSpeed*(float)Math.Cos(randomAngle);
			position.X += 170*(float)Math.Sin(baseAngle);
			position.Y += 170*(float)Math.Cos(baseAngle);
			return true;
			

		}
		
		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddTile(18);
			recipe.SetResult(this);
			recipe.AddIngredient(20, 12);
			recipe.AddIngredient(293);
			recipe.AddIngredient(170, 20);
			recipe.AddIngredient(2275);
			recipe.AddRecipe();
		}
	}
}