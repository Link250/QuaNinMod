using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace NinMod.Items.Weapons
{
    public class Magmapeak : ModItem
    {
		public override bool Shoot(Player player, ref Microsoft.Xna.Framework.Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
		{
			float baseSpeed = (float)Math.Sqrt(speedX * speedX + speedY * speedY);
			double baseAngle = Math.Atan2(speedX, speedY);
			position.X += 5 * (float)Math.Sin(baseAngle);
			position.Y += 5 * (float)Math.Cos(baseAngle);
		
					for (int i = 0; i < 1; ++i)
					{
						double randomAngle = baseAngle+(Main.rand.NextFloat()-0.5f)*0.00001;
						speedX = baseSpeed*(float)Math.Sin(randomAngle)* ((Main.rand.NextFloat()*0.2f+0.4f));
						speedY = baseSpeed*(float)Math.Cos(randomAngle)* ((Main.rand.NextFloat() * 0.2f)+0.4f);
						
						Terraria.Projectile.NewProjectile(position.X, position.Y, speedX, speedY, 85, damage, 20f, Main.myPlayer);	
					}
					return false;
					}
					
        public override void SetDefaults()
        {
            item.name = "Magmapeak";
            item.damage = 1;// macht 41 schaden
			item.crit = 3;
            item.melee = true;
            item.width = 6;
            item.height = 6;
            item.scale = 1.1f;
            item.maxStack = 1;
            item.useTime = 30;
			item.autoReuse = true;
            item.useAnimation = 30;
            item.knockBack = 0.1f;
            item.UseSound = SoundID.Item1;
            item.noMelee = true;
            item.noUseGraphic = true;
            item.useTurn = true;
            item.useStyle = 5;
            item.value = 000030;
            item.rare = 2;
            item.shoot = mod.ProjectileType("Magmapeakproj");  
            item.shootSpeed = 4.0f;
        }
        public override void AddRecipes()  
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.DirtBlock, 999);   
            recipe.AddTile(TileID.WorkBenches);  
            recipe.SetResult(this);
            recipe.AddRecipe();
        }      
    }
}