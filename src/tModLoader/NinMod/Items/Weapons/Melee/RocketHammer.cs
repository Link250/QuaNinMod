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
    public class RocketHammer : ModItem
    {
        public override void SetDefaults()
        {
            item.name = "Rocket Hammer";
            item.damage = 300;
            item.melee = true;
            item.width = 40;
            item.height = 40;
            item.toolTip = "Hammer... DOWN!!";
            item.useTime = 40;
            item.useAnimation = 40;
            item.useStyle = 1;
            item.knockBack = 28;
            item.value = 00200000;
            item.rare = 7;
            item.crit = 10;
            item.shoot = mod.ProjectileType("Testiproji");
            item.shootSpeed = 18f;
            item.UseSound = SoundID.Item1;
            item.autoReuse = true;

        }

        public override bool AltFunctionUse(Player player)
        {
            if (item.useTime == 40)
            {
                item.useTime = 160;
                item.useAnimation = 160;
                item.shoot = mod.ProjectileType("Testiproji");
                item.shootSpeed = 18f;
            }
            else
            {
                item.useTime = 20;
                item.useAnimation = 20;
                item.shoot = 0;
                item.shootSpeed = 0;
            }

            return true;
        }



        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddTile(412);
            recipe.SetResult(this);
            recipe.AddIngredient(3458, 18);
            recipe.AddRecipe();
        }


        public override void OnHitNPC(Player player, NPC target, int damage, float knockback, bool crit)
        {

            target.AddBuff(189, 300);

        }


    }
}