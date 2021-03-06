using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace NinMod.TestItems
{
	public class TestYoyo : ModItem
	{
		public override void SetDefaults()
		{
			
			item.name = "Yoyo";
			item.useStyle = 5;
			item.width = 24;
			item.height = 24;
			item.noUseGraphic = false;
			item.UseSound = SoundID.Item1;
			item.melee = true;
			item.channel = true;
			item.noMelee = true;
			item.shoot = 14;
			item.useAnimation = 25;
			item.useTime = 25;
			item.shootSpeed = 16f;
			
		}
	}
}