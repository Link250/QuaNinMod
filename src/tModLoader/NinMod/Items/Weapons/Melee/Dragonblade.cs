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
            item.damage = 160;
            item.melee = true;
            item.width = 40;
            item.height = 40;
            item.toolTip = "Ryujin no ken wo kurae!";
            item.useTime = 12;
            item.useAnimation = 12;
            item.useStyle = 1;
            item.knockBack = 28;
            item.value = 00200000;
            item.rare = 7;
            item.crit = 25;
            item.UseSound = SoundID.Item1;
            item.autoReuse = false;




        }

        public override bool AltFunctionUse(Player player)
        {
            if (item.useTime == 12)
            {
                item.useTime = 24;
                item.useAnimation = 24;
                item.damage = 300;
            }
            else
            {
                item.useTime = 12;
                item.useAnimation = 12;
                item.damage = 160;
            }

            return true;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddTile(18);
            recipe.SetResult(this);
            recipe.AddIngredient(1346, 8);
			recipe.AddIngredient(2862, 1);
			recipe.AddIngredient(1006, 16);
			recipe.AddIngredient(1508, 1);
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