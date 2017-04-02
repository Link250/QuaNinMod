using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace NinMod.Items.Weapons
{
	public class Slimegun : ModItem
	{
		public override void SetDefaults()
		{
			item.name = "Slimecinerator";
			item.damage = 58;
			item.crit = 0;
			item.ranged = true;
			item.width = 40;
			item.height = 20;
			item.toolTip = "Bouncy & Hot";
			item.useTime = 28;
			item.useAnimation = 28;
			item.useStyle = 5;
			item.noMelee = true; 
			item.knockBack = 8f;
			item.value = Item.sellPrice(0, 1, 11, 0);
			item.rare = 3;
			item.UseSound = SoundID.Item11;
			item.autoReuse = false;
			item.shootSpeed = 20;
			item.useAmmo = ItemID.Gel;
			item.shoot =  ProjectileID.BallofFire;
			
		}
		public override bool Shoot(Player player, ref Microsoft.Xna.Framework.Vector2 position, ref float speedX, ref float speedY, ref int type , ref int damage, ref float knockBack)
		{
			float spread = 45f * 0.00155f;
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
			recipe.AddIngredient(175, 4);
			recipe.AddIngredient(120);
			recipe.AddIngredient(2610);
			recipe.AddRecipe();
		}
	}
}