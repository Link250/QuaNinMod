using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace NinMod.Items.Weapons.Range
    {
	public class PhaRocket : ModItem
	{

		public override bool Shoot(Player player, ref Microsoft.Xna.Framework.Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
		{
			float baseSpeed = (float)Math.Sqrt(speedX * speedX + speedY * speedY);
			double baseAngle = Math.Atan2(speedX, speedY);
			position.X += 70 * (float)Math.Sin(baseAngle);
			position.Y += 70 * (float)Math.Cos(baseAngle);

			 
            for (int i = 0; i < 1; ++i)
            {
				double randomAngle = baseAngle+(Main.rand.NextFloat()-0.5f)*0.33;
				speedX = baseSpeed*(float)Math.Sin(randomAngle)* ((Main.rand.NextFloat()*0.5f+1.5f));
				speedY = baseSpeed*(float)Math.Cos(randomAngle)* ((Main.rand.NextFloat() * 0.5f)+1.5f);
				
				Terraria.Projectile.NewProjectile(position.X, position.Y, speedX, speedY, /*616*/140, damage, 10f, Main.myPlayer);
				
            }
			return false;
		}

		public override void SetDefaults()
		{

			item.crit = 0;
			item.knockBack = 4.25f;
			item.useStyle = 5;
			item.useAnimation = 22;
			item.useTime = 22;
			item.name = "Phara's Rocket Launcher";
			item.width = 50;
			item.height = 14;
			item.reuseDelay = 32;
			item.useAmmo = AmmoID.Rocket;
			item.UseSound = SoundID.Item36;
			item.damage = 112;
			item.shootSpeed = 2.35f;
			item.noMelee = true;
			item.value = Item.sellPrice(0, 8, 0, 0);
			item.rare = 9;
			item.ranged = true;
			item.shoot = ProjectileID.RocketIII;
			item.toolTip = "Justice Rains From Above!";
			item.autoReuse = true;
		}
        int timero;

        public override bool UseItem(Player player)
        {
            item.useAnimation = 22;
            item.useTime = 22;
            item.damage = 112;

            return true;
        }

        public override bool AltFunctionUse(Player player)
        {
            item.useAnimation = 120;
            item.useTime = 3;
            item.damage = 112;

            timero = (int)Main.time;
            return true;
        }

        public override bool CanRightClick()
        {
            return Math.Abs(Main.time - timero) >= 7200;
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