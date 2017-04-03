using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace NinMod.Items.Weapons.Range
    {

	public class Gasthrower : ModItem
	{
	
		public override void SetDefaults()
		{
			item.name = "Gasthrower";
			item.damage = 68;
			item.crit = 8;
			item.ranged = true;
			item.width = 40;
			item.height = 20;
			item.toolTip = "Made in Germany!";
			item.useTime = 3;
			item.useAnimation = 3;
			item.useStyle = 5;
			item.noMelee = true; 
			item.knockBack = 0f;
			item.value = Item.sellPrice(0, 5, 34, 0);
			item.rare = 7;
			item.UseSound = SoundID.Item34;
			item.autoReuse = true;
			item.shoot =  512 ;
			item.shootSpeed = 13f;
			item.useAmmo = ItemID.Gel;
			
			
		}
		
		public override bool Shoot(Player player, ref Microsoft.Xna.Framework.Vector2 position, ref float speedX, ref float speedY, ref int type , ref int damage, ref float knockBack)
		{
			float spread = 45f * 0.004116f;
			float baseSpeed = (float)Math.Sqrt(speedX * speedX + speedY * speedY);
			double baseAngle = Math.Atan2(speedX, speedY);
			double randomAngle = baseAngle+(Main.rand.NextFloat()-0.5f)*spread;
			speedX = baseSpeed*(float)Math.Sin(randomAngle);
			speedY = baseSpeed*(float)Math.Cos(randomAngle);
			position.X += 70*(float)Math.Sin(baseAngle);
			position.Y += 70*(float)Math.Cos(baseAngle);
			return true;
			

		}
		
		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddTile(18);
			recipe.SetResult(this);
			recipe.AddIngredient(3105, 1);
			recipe.AddIngredient(1552, 14);
			recipe.AddRecipe();
		}
		
	}
}