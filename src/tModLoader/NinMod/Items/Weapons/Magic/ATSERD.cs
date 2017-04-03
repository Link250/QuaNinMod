using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace NinMod.Items.Weapons
{
	public class ATSERD : ModItem
	{

		public override bool Shoot(Player player, ref Microsoft.Xna.Framework.Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
		{
			
			int[] randProj = {121,122,123,124,125,126}; 
			
			float baseSpeed = (float)Math.Sqrt(speedX * speedX + speedY * speedY);
			double baseAngle = Math.Atan2(speedX, speedY);
			position.X += 40 * (float)Math.Sin(baseAngle);
			position.Y += 40 * (float)Math.Cos(baseAngle);

			 
            for (int i = 0; i < 1; ++i)
            {
				double randomAngle = baseAngle+(Main.rand.NextFloat()-0.5f)*0.17;
				speedX = baseSpeed*(float)Math.Sin(randomAngle)* ((Main.rand.NextFloat()*0.2f+0.9f));
				speedY = baseSpeed*(float)Math.Cos(randomAngle)* ((Main.rand.NextFloat() * 0.2f)+0.9f);
				
				Terraria.Projectile.NewProjectile(position.X, position.Y, speedX, speedY, randProj[(int)(Main.rand.NextFloat()*6)], damage, 20f, Main.myPlayer);	
            }
			
			for (int i = 0; i < 1; ++i)
            {
				double randomAngle = baseAngle+(Main.rand.NextFloat()-0.5f)*0.17;
				speedX = baseSpeed*(float)Math.Sin(randomAngle)* ((Main.rand.NextFloat()*0.2f+0.9f));
				speedY = baseSpeed*(float)Math.Cos(randomAngle)* ((Main.rand.NextFloat() * 0.2f)+0.9f);
				
				Terraria.Projectile.NewProjectile(position.X, position.Y, speedX, speedY, randProj[(int)(Main.rand.NextFloat()*6)], damage, 20f, Main.myPlayer);
            }
			
			
			return false;
		}

		public override void SetDefaults()
		{

			item.name = "ATSERD";
			item.damage = 19;
			item.magic = true;
			item.crit = 4;
			item.mana = 9;
			item.width = 40;
			item.height = 40;
			item.toolTip = "And just enjoy yourself...";
			item.useTime = 28;
			item.useAnimation = 28;
			item.useStyle = 5;
			Item.staff[item.type] = true;
			item.noMelee = true;
			item.knockBack = 6;
			item.value = 010000;
			item.rare = 5;
			item.UseSound = SoundID.Item20;
			item.autoReuse = true;
			item.shoot = 14;
			item.shootSpeed = 9.5f;
		}
		//497 304 93 54 48 599
		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(739, 1); 
			recipe.AddIngredient(744, 1);
			recipe.AddIngredient(3377, 1);
			recipe.SetResult(this);
			recipe.AddTile(18);
			recipe.AddRecipe();
		}
	}
}