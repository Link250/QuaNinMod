using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace NinMod.Items.Weapons
{
	public class RainbowShotgun : ModItem
	{

		public override bool Shoot(Player player, ref Microsoft.Xna.Framework.Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
		{
			float baseSpeed = (float)Math.Sqrt(speedX * speedX + speedY * speedY);
			double baseAngle = Math.Atan2(speedX, speedY);
			position.X += 40 * (float)Math.Sin(baseAngle);
			position.Y += 40 * (float)Math.Cos(baseAngle);

			 
            for (int i = 0; i < 1; ++i)
            {
				double randomAngle = baseAngle+(Main.rand.NextFloat()-0.5f)*0.17;
				speedX = baseSpeed*(float)Math.Sin(randomAngle)* ((Main.rand.NextFloat()*0.2f+0.9f));
				speedY = baseSpeed*(float)Math.Cos(randomAngle)* ((Main.rand.NextFloat() * 0.2f)+0.9f);
				
				Terraria.Projectile.NewProjectile(position.X, position.Y, speedX, speedY, 283, damage, 20f, Main.myPlayer);	
            }
			
			for (int i = 0; i < 1; ++i)
            {
				double randomAngle = baseAngle+(Main.rand.NextFloat()-0.5f)*0.17;
				speedX = baseSpeed*(float)Math.Sin(randomAngle)* ((Main.rand.NextFloat()*0.2f+0.9f));
				speedY = baseSpeed*(float)Math.Cos(randomAngle)* ((Main.rand.NextFloat() * 0.2f)+0.9f);
				
				Terraria.Projectile.NewProjectile(position.X, position.Y, speedX, speedY, 284, damage, 20f, Main.myPlayer);	
            }
			
			for (int i = 0; i < 1; ++i)
            {
				double randomAngle = baseAngle+(Main.rand.NextFloat()-0.5f)*0.17;
				speedX = baseSpeed*(float)Math.Sin(randomAngle)* ((Main.rand.NextFloat()*0.2f+0.9f));
				speedY = baseSpeed*(float)Math.Cos(randomAngle)* ((Main.rand.NextFloat() * 0.2f)+0.9f);
				
				Terraria.Projectile.NewProjectile(position.X, position.Y, speedX, speedY, 285, damage, 20f, Main.myPlayer);	
            }
			
			for (int i = 0; i < 1; ++i)
            {
				double randomAngle = baseAngle+(Main.rand.NextFloat()-0.5f)*0.17;
				speedX = baseSpeed*(float)Math.Sin(randomAngle)* ((Main.rand.NextFloat()*0.2f+0.9f));
				speedY = baseSpeed*(float)Math.Cos(randomAngle)* ((Main.rand.NextFloat() * 0.2f)+0.9f);
				
				Terraria.Projectile.NewProjectile(position.X, position.Y, speedX, speedY, 286, damage, 20f, Main.myPlayer);	
            }
			
			for (int i = 0; i < 1; ++i)
            {
				double randomAngle = baseAngle+(Main.rand.NextFloat()-0.5f)*0.17;
				speedX = baseSpeed*(float)Math.Sin(randomAngle)* ((Main.rand.NextFloat()*0.2f+0.9f));
				speedY = baseSpeed*(float)Math.Cos(randomAngle)* ((Main.rand.NextFloat() * 0.2f)+0.9f);
				
				Terraria.Projectile.NewProjectile(position.X, position.Y, speedX, speedY, 287, damage, 20f, Main.myPlayer);	
            }
			
			return false;
		}

		public override void SetDefaults()
		{

			item.crit = 4;
			item.knockBack = 1.00f;
			item.useStyle = 5;
			item.useAnimation = 31;
			item.useTime = 31;
			item.name = "Rainbow Shotgun";
			item.width = 50;
			item.height = 14;
			
			item.useAmmo = ProjectileID.Bullet;;
			item.useSound = 36;
			item.damage = 38;
			item.shootSpeed = 9.65f;
			item.noMelee = true;
			item.value = Item.sellPrice(0, 2, 0, 0);
			item.rare = 2;
			item.ranged = true;
			item.shoot = 14;
			item.toolTip = "Taste the rainbow Mother*****r";
			item.autoReuse = true;




		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.DirtBlock, 1);
			recipe.SetResult(this);
			recipe.AddTile(18);
			recipe.AddRecipe();
		}
	}
}