using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace NinMod.TestItems
{
	public class dd : ModItem
	{

		public override void SetDefaults()
		{

			item.name = "dd";
			item.damage = 56;
			item.crit = 6;
			item.ranged = true;
			item.width = 40;
			item.height = 20;
			item.toolTip = "dd";
			item.useTime = 18;
			item.useAnimation = 18;
			item.useStyle = 5;
			item.noMelee = true; 
			item.knockBack = 4f;
			item.value = Item.sellPrice(0, 1, 11, 0);
			item.rare = 5;
			item.UseSound = SoundID.Item11;
			item.autoReuse = true;
			item.shoot = 304; //378
			item.shootSpeed = 22f; //22
			item.useAmmo = ItemID.Gel;
			
		}
		
		public override bool Shoot(Player player, ref Microsoft.Xna.Framework.Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
		{
			float spread = 45f * 0.00048f;
			float baseSpeed = (float)Math.Sqrt(speedX * speedX + speedY * speedY);
			double baseAngle = Math.Atan2(speedX, speedY);
			double randomAngle = baseAngle+(Main.rand.NextFloat()-0.5f)*spread;
			speedX = baseSpeed*(float)Math.Sin(randomAngle);
			speedY = baseSpeed*(float)Math.Cos(randomAngle);
			return true;
		}
	}
}