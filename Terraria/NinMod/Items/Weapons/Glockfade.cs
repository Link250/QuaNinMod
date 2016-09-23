using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace NinMod.Items.Weapons
{
	public class Glockfade : ModItem
	{
		public override void SetDefaults()
		{
			item.name = "Glock 18 fade";
			item.damage = 12;
			item.crit = 3;
			item.ranged = true;
			item.width = 40;
			item.height = 20;
			item.toolTip = "This is still a good idea, right guys?";
			item.useTime = 11;
			item.useAnimation = 11;
			item.useStyle = 5;
			item.noMelee = true; //so the item's animation doesn't do damage
			item.knockBack = 3f;
			item.value = Item.sellPrice(0, 0, 80, 0);
			item.rare = 2;
			item.useSound = 11;
			item.autoReuse = false;
			item.shoot = 11; //idk why but all the guns in the vanilla source have this
			item.shootSpeed = 15f;
			item.useAmmo = ProjectileID.Bullet;	
			
		}
		public override bool Shoot(Player player, ref Microsoft.Xna.Framework.Vector2 position, ref float speedX, ref float speedY, ref int type , ref int damage, ref float knockBack)
		{
			float spread = 45f * 0.00075f;//45 degrees converted to radians
			float baseSpeed = (float)Math.Sqrt(speedX * speedX + speedY * speedY);
			double baseAngle = Math.Atan2(speedX, speedY);
			double randomAngle = baseAngle+(Main.rand.NextFloat()-0.5f)*spread;
			speedX = baseSpeed*(float)Math.Sin(randomAngle);
			speedY = baseSpeed*(float)Math.Cos(randomAngle);
			return true;
			

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