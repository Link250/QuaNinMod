using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using System.Collections.Generic;
using Terraria.GameContent;
using Terraria.GameContent.Achievements;
using Terraria.Graphics.Shaders;

namespace NinMod.Items.TestItems
{
	public class DevStaff : ModItem
	{
		public override void SetDefaults()
		{
			item.name = "effewfew";
			item.damage = 34;
			item.magic = true;
			item.crit = 25;
			item.mana = 7;
			item.width = 40;
			item.height = 40;
			item.toolTip = "MOO";
			item.useTime = 22;
			item.useAnimation = 22;
			item.useStyle = 5;
			Item.staff[item.type] = true;
			item.noMelee = true;
			item.knockBack = 6;
			item.value = 150000;
			item.rare = 5;
			item.useSound = 20;
			item.autoReuse = true;
			item.shoot = 14;
			item.shootSpeed = 2f;
		}
		
		public override bool Shoot(Player player, ref Microsoft.Xna.Framework.Vector2 position, ref float speedX, ref float speedY, ref int type , ref int damage, ref float knockBack)
		{
//			float fireCount = Main.rand.NextFloat()*3+4;
//			float spread = Main.rand.NextFloat()*10+25;
//			for (float i = 0; i < fireCount; ++i)
//            {
//				Vector2 speedZ = ModHelper.rotateByDegree(new Vector2(speedX, speedY), (i/fireCount-0.5f)*spread);//
//                Terraria.Projectile.NewProjectile(position.X, position.Y, speedZ.X, speedZ.Y, 651, 1, 15f, Main.myPlayer);
//            }
			for (float i = 0; i < 1; ++i)
            {
                Terraria.Projectile.NewProjectile(position.X, position.Y, speedX, speedY, 651, 1, 145f, Main.myPlayer);
            }
			return false;
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