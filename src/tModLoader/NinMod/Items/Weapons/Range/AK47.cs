using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace NinMod.Items.Weapons
{
	public class AK47 : ModItem
	{

		public override void SetDefaults()
		{

			item.name = "AK47";
			item.damage = 31;
			item.crit = 2;
			item.ranged = true;
			item.width = 40;
			item.height = 20;
			item.toolTip = "We must drive them from our lands!";
			item.useTime = 8;
			item.useAnimation = 8;
			item.useStyle = 5;
			item.noMelee = true; 
			item.knockBack = 4f;
			item.value = Item.sellPrice(0, 1, 11, 0);
			item.rare = 5;
			item.UseSound = SoundID.Item11;
			item.autoReuse = true;
			item.shoot = 11; 
			item.shootSpeed = 25f;
			item.useAmmo = AmmoID.Bullet;
			
		}
		
		public override bool Shoot(Player player, ref Microsoft.Xna.Framework.Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
		{
			float spread = 45f * 0.00278f;
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
			recipe.AddIngredient(549, 6);
			recipe.AddIngredient(324);
			recipe.AddIngredient(391, 8);
			recipe.AddRecipe();
		}
	}
}