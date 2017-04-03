using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace NinMod.Items.Weapons.Range
    {
	public class SlimeAR: ModItem
	{
		public override void SetDefaults()
		{
			item.name = "Slimeurgatory!";
			item.damage = 106;
			item.crit = 2;
			item.ranged = true;
			item.width = 40;
			item.height = 20;
			item.toolTip = "What has Science done?!";
			item.useTime = 22;
			item.useAnimation = 22;
			item.useStyle = 5;
			item.noMelee = true; 
			item.knockBack = 10;
			item.value = Item.sellPrice(0, 3, 60, 0);
			item.rare = 8;
			item.UseSound = SoundID.Item11;
			item.autoReuse = true;
			item.shootSpeed = 23;
			item.useAmmo = ItemID.Gel;
			item.shoot =  ProjectileID.CursedFlameFriendly;
			
		}
		public override bool Shoot(Player player, ref Microsoft.Xna.Framework.Vector2 position, ref float speedX, ref float speedY, ref int type , ref int damage, ref float knockBack)
		{
			float spread = 45f * 0.00175f;//45 degrees converted to radians
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
			recipe.AddIngredient(1225, 6);
			recipe.AddIngredient(522, 20);
			recipe.AddIngredient(ModLoader.GetMod("NinMod").GetItem("Slimegun"));
			recipe.AddRecipe();
		}
	}
}