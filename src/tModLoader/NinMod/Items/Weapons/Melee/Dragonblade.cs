using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using System.Collections.Generic;
using Terraria.GameContent;
using Terraria.GameContent.Achievements;
using Terraria.Graphics.Shaders;

namespace NinMod.Items.Weapons.Melee
    {
    public class Dragonblade : ModItem
    {
        public override void SetDefaults()
        {

            item.name = "Dragonblade";
            item.damage = 74;
            item.melee = false;
            item.ranged = true;
            item.width = 40;
            item.height = 40;
            item.toolTip = "Melee Sword and ranged Shuriken";
            item.toolTip2 = "Ryujin no ken wo kurae!";
            item.useTime = 12;
            item.useAnimation = 12;
            item.useStyle = 1;
            item.knockBack = 1;
            item.value = 00200000;
            item.rare = 7;
            item.crit = 25;
            item.UseSound = SoundID.Item1;
            item.autoReuse = true;
            item.shoot = mod.ProjectileType("GenjiShuriken");
            item.shootSpeed = 7f;
            item.noUseGraphic = true;

        }

        public override bool AltFunctionUse(Player player)
        {
            if (item.useTime == 12)
            {
                item.useTime = 20;
                item.useAnimation = 20;
                item.damage = 477;
                item.noUseGraphic = false;
                item.shoot = 0;
                item.melee = true;
                item.ranged = false;
                item.knockBack = 23;
            }
            else
            {
                item.useTime = 12;
                item.useAnimation = 12;
                item.damage = 89;
                item.noUseGraphic = true;
                item.shoot = mod.ProjectileType("GenjiShuriken");
                item.melee = false;
                item.ranged = true;
                item.knockBack = 1;
            }

            return true;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddTile(18);
            recipe.SetResult(this);
            recipe.AddIngredient(1346, 8);
			recipe.AddIngredient(3456, 6);
			recipe.AddIngredient(1006, 16);
			recipe.AddIngredient(1508, 1);
            recipe.AddIngredient(2880, 1); 
            recipe.AddRecipe();
        }


        public override void OnHitNPC(Player player, NPC target, int damage, float knockback, bool crit)
        {
            int[] randstyle = { 1, 3, 2 };

            item.useStyle = (randstyle[(int)(Main.rand.NextFloat() * 3)]);

            target.AddBuff(39, 1200);

        }
    }
}