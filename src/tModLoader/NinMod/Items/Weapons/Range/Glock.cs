using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace NinMod.Items.Weapons.Range
    {
	public class Glock : ModItem
	{
		public override void SetDefaults()
		{
			item.name = "Glock 18";
			item.damage = 5;
			item.crit = 3;
			item.ranged = true;
			item.width = 40;
			item.height = 20;
			item.toolTip = "Burst fire not included!";
			item.useTime = 13;
			item.useAnimation = 13;
			item.useStyle = 5;
			item.noMelee = true; //so the item's animation doesn't do damage
			item.knockBack = 2f;
			item.value = Item.sellPrice(0, 1, 11, 0);
			item.rare = 2;
			item.UseSound = SoundID.Item11;
			item.autoReuse = false;
			item.shoot = 11; //idk why but all the guns in the vanilla source have this
			item.shootSpeed = 15f;
			item.useAmmo = AmmoID.Bullet;
			
		}
		public override bool Shoot(Player player, ref Microsoft.Xna.Framework.Vector2 position, ref float speedX, ref float speedY, ref int type , ref int damage, ref float knockBack)
		{
			float spread = 45f * 0.00175f;//45 degrees converted to radians
			float baseSpeed = (float)Math.Sqrt(speedX * speedX + speedY * speedY);
			double baseAngle = Math.Atan2(speedX, speedY);
			double randomAngle = baseAngle+(Main.rand.NextFloat()-0.5f)*spread;
			speedX = baseSpeed*(float)Math.Sin(randomAngle);
			speedY = baseSpeed*(float)Math.Cos(randomAngle);
			return true;
			

		}
		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddTile(18);
			recipe.SetResult(this);
			recipe.AddIngredient(95);
			recipe.AddIngredient(21, 6);
			recipe.AddIngredient(57, 6);
			recipe.AddRecipe();
		}
	}
}