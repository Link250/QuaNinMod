using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace NinMod.Items.Weapons
{
	public class Bizon : ModItem
	{
		public override void SetDefaults()
		{
			item.name = "PP Bizon";
			item.damage = 2;
			item.ranged = true;
			item.width = 40;
			item.height = 20;
			item.toolTip = "Actually needs Air";
			item.useTime = 7;
			item.useAnimation = 7;
			item.useStyle = 5;
			item.noMelee = true; //so the item's animation doesn't do damage
			item.knockBack = 1f;
			item.value = Item.sellPrice(0, 1, 11, 0);
			item.rare = 2;
			item.useSound = 11;
			item.autoReuse = true;
			item.shoot = 11; //idk why but all the guns in the vanilla source have this
			item.shootSpeed = 11f;
			item.useAmmo = ProjectileID.Bullet;
		}
		public override bool Shoot(Player player, ref Microsoft.Xna.Framework.Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
		{
			float spread = 45f * 0.00196f;//45 degrees converted to radians
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