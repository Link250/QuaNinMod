using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace NinMod.Items.Weapons
{
	public class Jewolver : ModItem
	{
		public override bool Shoot(Player player, ref Microsoft.Xna.Framework.Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
		{
			float baseSpeed = (float)Math.Sqrt(speedX * speedX + speedY * speedY);
			double baseAngle = Math.Atan2(speedX, speedY);
			position.X += 40 * (float)Math.Sin(baseAngle);
			position.Y += 40 * (float)Math.Cos(baseAngle);
		
					for (int i = 0; i < 1; ++i)
					{
						double randomAngle = baseAngle+(Main.rand.NextFloat()-0.5f)*0.00001;
						speedX = baseSpeed*(float)Math.Sin(randomAngle)* ((Main.rand.NextFloat()*0.2f+0.9f));
						speedY = baseSpeed*(float)Math.Cos(randomAngle)* ((Main.rand.NextFloat() * 0.2f)+0.9f);
						
						Terraria.Projectile.NewProjectile(position.X, position.Y, speedX, speedY, 287, damage, 32f, Main.myPlayer);	
					}
					return false;
					}
					
				public override void SetDefaults()
				{

			item.name = "Jewolver";
			item.damage = 21;
			item.crit = 12;
			item.ranged = true;
			item.width = 40;
			item.height = 20;
			item.toolTip = "*jewing intensifies*";
			item.useTime = 21;
			item.useAnimation = 21;
			item.useStyle = 5;
			item.noMelee = true; 
			item.knockBack = 4f;
			item.value = Item.sellPrice(0, 1, 0, 0);
			item.rare = 5;
			item.UseSound = SoundID.Item41;
			item.autoReuse = false;
			item.shoot = 287; //660 
			item.shootSpeed = 26f;
			item.useAmmo = AmmoID.Bullet;
			
		}
		
		

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddTile(18);
			recipe.SetResult(this);
			recipe.AddIngredient(19, 16);
			recipe.AddIngredient(2269);
			recipe.AddRecipe();
		}
	}
}