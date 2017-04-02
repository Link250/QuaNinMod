using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace NinMod.Items.Weapons
{
	public class LaserShotgun : ModItem
	{

		public override bool Shoot(Player player, ref Microsoft.Xna.Framework.Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
		{
			float baseSpeed = (float)Math.Sqrt(speedX * speedX + speedY * speedY);
			double baseAngle = Math.Atan2(speedX, speedY);
			position.X += 40 * (float)Math.Sin(baseAngle);
			position.Y += 40 * (float)Math.Cos(baseAngle);

			 
            for (int i = 0; i < 4; ++i)
            {
				double randomAngle = baseAngle+(Main.rand.NextFloat()-0.5f)*0.17;
				speedX = baseSpeed*(float)Math.Sin(randomAngle)* ((Main.rand.NextFloat()*0.2f+0.9f));
				speedY = baseSpeed*(float)Math.Cos(randomAngle)* ((Main.rand.NextFloat() * 0.2f)+0.9f);
				
				Terraria.Projectile.NewProjectile(position.X, position.Y, speedX, speedY, 440, damage, 20f, Main.myPlayer);
				
            }
			return false;
		}

		public override void SetDefaults()
		{

			item.crit = 4;
			item.knockBack = 1.00f;
			item.useStyle = 5;
			item.useAnimation = 34;
			item.useTime = 34;
			item.name = "Laser Shotgun";
			item.width = 50;
			item.height = 14;
			
			item.useAmmo = AmmoID.Bullet;
			item.UseSound = SoundID.Item12;
			item.damage = 24;
			item.shootSpeed = 9.65f;
			item.noMelee = true;
			item.value = Item.sellPrice(0, 2, 0, 0);
			item.rare = 2;
			item.ranged = true;
			item.shoot = 14;
			item.toolTip = "Laser Shotgun! Laser Shotgun!";
			item.autoReuse = true;




		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(534);
			recipe.AddIngredient(514);
			recipe.AddIngredient(391, 8);
			recipe.SetResult(this);
			recipe.AddTile(18);
			recipe.AddRecipe();
		}
	}
}