using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace NinMod.Items.TestItems
{
	public class DevGun : ModItem
	{
		public override void SetDefaults()
		{
			item.name = "wawawawawa";
			item.damage = 7;
			item.crit = 320;
			item.ranged = true;
			item.width = 70;
			item.height = 22;
			item.toolTip = "BOWBOWBOW";
			item.useTime = 7;
			item.useAnimation = 7;
			item.useStyle = 5;
			item.noMelee = true; 
			item.knockBack = 2f;
			item.value = Item.sellPrice(0, 1, 11, 0);
			item.rare = 7;
			item.useSound = 11;
			item.autoReuse = true;
			item.shoot =  645 ;
			item.shootSpeed = 15f;
			
			item.useAmmo = ItemID.Gel;
			
			
		}
		public override bool Shoot(Player player, ref Microsoft.Xna.Framework.Vector2 position, ref float speedX, ref float speedY, ref int type , ref int damage, ref float knockBack)
		{
			float spread = 45f * 0.00050f;
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