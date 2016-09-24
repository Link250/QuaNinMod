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
            item.useSound = 1;
            item.autoReuse = false;




        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddTile(18);
            recipe.SetResult(this);
            recipe.AddIngredient(ItemID.DirtBlock, 1);
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