using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace NinMod.Items.Weapons.Magic
    {
	public class DiceNKnife : ModItem
	{

		public override bool Shoot(Player player, ref Microsoft.Xna.Framework.Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
		{
			
			int[] randProj = {497,304,93,184,661,599}; 
			//497 304 93 54 48 599
			
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
			return false;
		}

		public override void SetDefaults()
		{

			item.name = "Dice'n Knife";
			item.damage = 38;
			item.magic = true;
			item.crit = 4;
			item.mana = 7;
			item.width = 40;
			item.height = 40;
			item.toolTip = "Reroll!";
			item.useTime = 15;
			item.useAnimation = 15;
			item.useStyle = 1;
			Item.staff[item.type] = true;
			item.noMelee = true;
			item.knockBack = 6;
			item.value = 000010;
			item.rare = 5;
			item.UseSound = SoundID.Item20;
			item.autoReuse = true;
			item.shoot = 14;
			item.shootSpeed = 18.5f;



		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(381, 12);
			recipe.AddIngredient(501, 21);
			recipe.SetResult(this);
			recipe.AddTile(18);
			recipe.AddRecipe();
		}
	}
}