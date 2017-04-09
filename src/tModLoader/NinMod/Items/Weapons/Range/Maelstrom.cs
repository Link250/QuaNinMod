using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace NinMod.Items.Weapons.Range
    {
	public class Maelstrom : ModItem
	{

		public override bool Shoot(Player player, ref Microsoft.Xna.Framework.Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
		{
			float baseSpeed = (float)Math.Sqrt(speedX * speedX + speedY * speedY);
			double baseAngle = Math.Atan2(speedX, speedY);
			position.X += 70 * (float)Math.Sin(baseAngle);
			position.Y += 70 * (float)Math.Cos(baseAngle);

			 
            for (int i = 0; i < 10; ++i)
            {
				double randomAngle = baseAngle+(Main.rand.NextFloat()-0.5f)*0.33;
				speedX = baseSpeed*(float)Math.Sin(randomAngle)* ((Main.rand.NextFloat()*0.5f+1.5f));
				speedY = baseSpeed*(float)Math.Cos(randomAngle)* ((Main.rand.NextFloat() * 0.5f)+1.5f);
				
				Terraria.Projectile.NewProjectile(position.X, position.Y, speedX, speedY, type, damage, 10f, Main.myPlayer);
				
            }
			return false;
		}

		public override void SetDefaults()
		{

			item.crit = 0;
			item.knockBack = 4.25f;
			item.useStyle = 5;
			item.useAnimation = 24;
			item.useTime = 12;
			item.name = "Maelstrom";
			item.width = 50;
			item.height = 14;
			item.reuseDelay = 36;
			
			item.useAmmo = AmmoID.Bullet;
			item.UseSound = SoundID.Item36;
			item.damage = 40;
			item.shootSpeed = 4.35f;
			item.noMelee = true;
			item.value = Item.sellPrice(0, 8, 0, 0);
			item.rare = 9;
			item.ranged = true;
			item.shoot = ProjectileID.Bullet;
			item.toolTip = "33% chance not to mistake it for the ammo consume chance!";
			item.autoReuse = true;




		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(3456, 18);
			recipe.SetResult(this);
			recipe.AddTile(18);
			recipe.AddRecipe();
		}
	}
}