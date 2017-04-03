using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using System.Collections.Generic;
using Terraria.GameContent;
using Terraria.GameContent.Achievements;
using Terraria.Graphics.Shaders;

namespace NinMod.TestItems
{
	public class TestSword : ModItem
	{
		public override void SetDefaults()
		{
			
			item.name = "sosos";
			item.damage = 132;
			item.melee = true;
			item.width = 40;
			item.height = 40;
			item.toolTip = "This saas";
			item.useTime = 20;
			item.useAnimation = 20;
			item.useStyle = 1;
			item.knockBack = 18;
			item.value = 10000;
			item.rare = 2;
			item.UseSound = SoundID.Item1;
			item.autoReuse = true;
			item.shoot = 14;
			item.shootSpeed = 25;
			
		}
	
		public override bool Shoot(Player player, ref Microsoft.Xna.Framework.Vector2 position, ref float speedX, ref float speedY, ref int type , ref int damage, ref float knockBack)
		{
			float fireCount = Main.rand.NextFloat()*3+4;
			float spread = Main.rand.NextFloat()*10+25;
			for (float i = 0; i < fireCount; ++i)
            {
				Vector2 speedZ = ModHelper.rotateByDegree(new Vector2(speedX, speedY), (i/fireCount-0.5f)*spread);//
                Terraria.Projectile.NewProjectile(position.X, position.Y, speedZ.X, speedZ.Y, 651, 1, 15f, Main.myPlayer);
            }
			for (float i = 0; i < 1; ++i)
            {
                Terraria.Projectile.NewProjectile(position.X, position.Y, speedX, speedY, 651, 80, 145f, Main.myPlayer);
            }
			return false;
		}
	
		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddTile(18);
			recipe.SetResult(this);
			recipe.AddIngredient(1041, 93);
			recipe.AddRecipe();
		}
		
		public override void OnHitNPC(Player player, NPC target, int damage, float knockback, bool crit)
		{
			target.AddBuff(24, 600);
			target.AddBuff(39, 600);
			target.AddBuff(44, 600);
			target.AddBuff(153, 600);
		}
	}
}