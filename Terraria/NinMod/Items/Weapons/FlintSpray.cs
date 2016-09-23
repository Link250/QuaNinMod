using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace NinMod.Items.Weapons
{
	public class FlintSpray : ModItem
	{

		public override bool Shoot(Player player, ref Microsoft.Xna.Framework.Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
		{
			float baseSpeed = (float)Math.Sqrt(speedX * speedX + speedY * speedY);
			double baseAngle = Math.Atan2(speedX, speedY);
			position.X += 40 * (float)Math.Sin(baseAngle);
			position.Y += 40 * (float)Math.Cos(baseAngle);

			 
            for (int i = 0; i < 3; ++i)
            {
                Terraria.Projectile.NewProjectile(position.X, position.Y, speedX, speedY, type, damage, 10f, Main.myPlayer);
				
				double randomAngle = baseAngle+(Main.rand.NextFloat()-0.5f)*0.47;
				speedX = baseSpeed*(float)Math.Sin(randomAngle)* ((Main.rand.NextFloat()*0.2f+0.9f));
				speedY = baseSpeed*(float)Math.Cos(randomAngle)* ((Main.rand.NextFloat() * 0.2f)+0.9f);
				
            }
			return false;
		}

		public override void SetDefaults()
		{

			item.crit = 2;
			item.knockBack = 5.75f;
			item.useStyle = 5;
			item.useAnimation = 47;
			item.useTime = 47;
			item.name = "FlintSpray";
			item.width = 50;
			item.height = 14;
			
			item.useAmmo = ProjectileID.Bullet;;
			item.useSound = 36;
			item.damage = 7;
			item.shootSpeed = 1.35f;
			item.noMelee = true;
			item.value = Item.sellPrice(0, 2, 0, 0);
			item.rare = 2;
			item.ranged = true;
			item.shoot = 14;
			item.toolTip = "You could just throw a few bullets...";




		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(95, 1);
			recipe.AddIngredient(239, 10);
			recipe.AddIngredient(323, 2);
			recipe.SetResult(this);
			recipe.AddTile(18);
			recipe.AddRecipe();
		}
	}
}