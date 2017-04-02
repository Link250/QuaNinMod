using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using System.Collections.Generic;
using Terraria.GameContent;
using Terraria.GameContent.Achievements;
using Terraria.Graphics.Shaders;

namespace NinMod.Items.Weapons
{

    public class UnoDosTresCuatro : ModItem
    {
        public override bool Shoot(Player player, ref Microsoft.Xna.Framework.Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
            float baseSpeed = (float)Math.Sqrt(speedX * speedX + speedY * speedY);
            double baseAngle = Math.Atan2(speedX, speedY);
            position.X += 40 * (float)Math.Sin(baseAngle);
            position.Y += 40 * (float)Math.Cos(baseAngle);

            for (int i = 0; i < 1; ++i)
            {
                double randomAngle = baseAngle + (Main.rand.NextFloat() - 0.5f) * 0.17;
                speedX = baseSpeed * (float)Math.Sin(randomAngle) * ((Main.rand.NextFloat() * 0.8f + 0.9f));
                speedY = baseSpeed * (float)Math.Cos(randomAngle) * ((Main.rand.NextFloat() * 0.8f) + 0.9f);

                Terraria.Projectile.NewProjectile(position.X, position.Y, speedX, speedY, mod.ProjectileType("uno"), damage, 20f, Main.myPlayer);
            }
            for (int i = 0; i < 1; ++i)
            {
                double randomAngle = baseAngle + (Main.rand.NextFloat() - 0.5f) * 0.17;
                speedX = baseSpeed * (float)Math.Sin(randomAngle) * ((Main.rand.NextFloat() * 0.8f + 0.9f));
                speedY = baseSpeed * (float)Math.Cos(randomAngle) * ((Main.rand.NextFloat() * 0.8f) + 0.9f);

                Terraria.Projectile.NewProjectile(position.X, position.Y, speedX, speedY, mod.ProjectileType("dos"), damage, 20f, Main.myPlayer);
            }
            for (int i = 0; i < 1; ++i)
            {
                double randomAngle = baseAngle + (Main.rand.NextFloat() - 0.5f) * 0.17;
                speedX = baseSpeed * (float)Math.Sin(randomAngle) * ((Main.rand.NextFloat() * 0.8f + 0.9f));
                speedY = baseSpeed * (float)Math.Cos(randomAngle) * ((Main.rand.NextFloat() * 0.8f) + 0.9f);

                Terraria.Projectile.NewProjectile(position.X, position.Y, speedX, speedY, mod.ProjectileType("tres"), damage, 20f, Main.myPlayer);
            }
            for (int i = 0; i < 1; ++i)
            {
                double randomAngle = baseAngle + (Main.rand.NextFloat() - 0.5f) * 0.17;
                speedX = baseSpeed * (float)Math.Sin(randomAngle) * ((Main.rand.NextFloat() * 0.8f + 0.9f));
                speedY = baseSpeed * (float)Math.Cos(randomAngle) * ((Main.rand.NextFloat() * 0.8f) + 0.9f);

                Terraria.Projectile.NewProjectile(position.X, position.Y, speedX, speedY, mod.ProjectileType("cuatro"), damage, 20f, Main.myPlayer);
            }
            return false;
        }


        public override void SetDefaults()
        {
            item.name = "Uno Dos Tres Cuatro";
            item.damage = 96;
            item.melee = true;
            item.width = 40;
            item.height = 40;
            item.toolTip = "UnoDosTresCuatroUnoDosTresCuatro";
            item.useTime = 5;
            item.useAnimation = 40;
            item.useStyle = 5;
            item.knockBack = 7f;
            item.value = 00200000;
            item.rare = 7;
            item.crit = 10;
            item.shoot = mod.ProjectileType("uno");
            item.shootSpeed = 18f;
            item.UseSound = SoundID.Item1;
            item.autoReuse = true;
            item.channel = true;
            item.noMelee = true;
            item.scale = 1.1F;
            item.noUseGraphic = true;
        }


        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddTile(18);
            recipe.SetResult(this);
            recipe.AddIngredient(389);
			recipe.AddIngredient(1259);
			recipe.AddIngredient(163);
			recipe.AddIngredient(220);
			recipe.AddIngredient(1552, 10);
            recipe.AddRecipe();
        }


        public override void OnHitNPC(Player player, NPC target, int damage, float knockback, bool crit)
        {

            target.AddBuff(189, 300);

        }


    }
}