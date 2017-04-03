using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace NinMod.TestItems
{
	public class TestShotty : ModItem
	{

		public override bool Shoot(Player player, ref Microsoft.Xna.Framework.Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
		{
			//float spread = 45f * 0.0174f;//45 degrees converted to radians
			float baseSpeed = (float)Math.Sqrt(speedX * speedX + speedY * speedY);
			double baseAngle = Math.Atan2(speedX, speedY);
			position.X += 70 * (float)Math.Sin(baseAngle);
			position.Y += 70 * (float)Math.Cos(baseAngle);

			 
            for (int i = 0; i < 5; ++i)
            {
//				double randomAngle = baseAngle+(Main.rand.NextFloat()-0.5f)*3;
				double randomAngle = baseAngle;
				speedX = baseSpeed*(float)Math.Sin(randomAngle)* ((Main.rand.NextFloat()*0.2f+0.9f));
				speedY = baseSpeed*(float)Math.Cos(randomAngle)* ((Main.rand.NextFloat() * 0.2f)+0.9f);
				
                Terraria.Projectile.NewProjectile(position.X, position.Y, speedX, speedY, 651, 1, 15f, Main.myPlayer);
            }
			return false;
		}

		public override void SetDefaults()
		{

			item.crit = 2;
			item.knockBack = 5.75f;
			item.useStyle = 5;
			item.useAnimation = 40;
			item.useTime = 40;
			item.name = "shotty";
			item.width = 50;
			item.height = 14;
			
			item.useAmmo = ProjectileID.Bullet;
			item.UseSound = SoundID.Item36;
			item.damage = 14;
			item.shootSpeed = 3.35f;
			item.noMelee = true;
			item.value = Item.sellPrice(0, 2, 0, 0);
			item.rare = 2;
			item.ranged = true;
			item.shoot = 14;
			item.toolTip = "fillme!";
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddTile(18);
			recipe.SetResult(this);
			recipe.AddIngredient(1041, 93);
			recipe.AddRecipe();
		}
	}
}