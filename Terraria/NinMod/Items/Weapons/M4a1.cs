using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace NinMod.Items.Weapons
{
	public class M4a1 : ModItem
	{
		public override void SetDefaults()
		{
			item.name = "M4a1 suppressed";
			item.damage = 25;
			item.crit = 4;
			item.ranged = true;
			item.width = 90;
			item.height = 20;
			item.toolTip = "There's no stoffinus!";
			item.useTime = 6;
			item.useAnimation = 6;
			item.useStyle = 5;
			item.noMelee = true; //so the item's animation doesn't do damage
			item.knockBack = 0;
			item.value = Item.sellPrice(0, 1, 11, 0);
			item.rare = 5;
			item.useSound = 5;
			item.autoReuse = true;
			item.shoot = 11; //idk why but all the guns in the vanilla source have this
			item.shootSpeed = 21f;
			item.useAmmo = ProjectileID.Bullet;
		}
		public override bool Shoot(Player player, ref Microsoft.Xna.Framework.Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
		{
			float spread = 45f * 0.00157f;//45 degrees converted to radians
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