using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace NinMod.Items.Weapons
{
	public class TerrarianiedNinvolver : ModItem
	{
	
		public override bool Shoot(Player player, ref Microsoft.Xna.Framework.Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
		{
			float spread = 45f * 0.00100f;//45 degrees converted to radians
			float baseSpeed = (float)Math.Sqrt(speedX * speedX + speedY * speedY);
			double baseAngle = Math.Atan2(speedX, speedY);
			double randomAngle = baseAngle+(Main.rand.NextFloat()-0.5f)*spread;
			speedX = baseSpeed*(float)Math.Sin(randomAngle);
			speedY = baseSpeed*(float)Math.Cos(randomAngle);
			Terraria.Projectile.NewProjectile(position.X, position.Y, speedX, speedY, 645, damage, 10f, Main.myPlayer);
			return false;
		}
	
		public override void SetDefaults()
		{
			item.name = "Ninvolver";
			item.damage = 375;
			item.crit = 8;
			item.expertOnly = true;
			item.expert = true;
			item.ranged = true;
			item.newAndShiny = true;
			item.width = 40;
			item.height = 20;
			item.toolTip = "A swirling force empowered with Solar Flux! ";
			item.toolTip2 = "Nin-Sama's Gun of choice!";
			item.useTime = 1;
			item.useAnimation = 30;
			item.useStyle = 5;
			item.healLife = 30;
			item.lifeRegen = 30;
			item.noMelee = false;
			item.knockBack = 22;
			item.value = Item.sellPrice(0, 4, 20, 0);
			item.rare = 10;
			item.useSound = 36;
			item.autoReuse = true;
			item.shoot = 645; 
			item.shootSpeed = 100f;
//			item.useAmmo = ProjectileID.Bullet;
		}
		


		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddTile(18);
			recipe.SetResult(this);
			recipe.AddIngredient(ItemID.DirtBlock, 1);
			recipe.AddRecipe();
		}
	}
}