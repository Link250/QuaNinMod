using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace NinMod.Items.Weapons
{
    public class TungstenSpear : ModItem
    {
        public override void SetDefaults()
        {
            item.name = "Tungsten Spear";
            item.damage = 13;// 7 9 10 12 13 15 17
			item.crit = 3;
            item.melee = true;
            item.width = 6;
            item.height = 6;
            item.scale = 1.1f;
            item.maxStack = 1;
            item.useTime = 30;
            item.useAnimation = 30;
            item.knockBack = 2.5f;
            item.UseSound = SoundID.Item1;
            item.noMelee = true;
            item.noUseGraphic = true;
            item.useTurn = true;
            item.useStyle = 5;
            item.value = 000030;
            item.rare = 2;
            item.shoot = mod.ProjectileType("tungstenspearproj");  
            item.shootSpeed = 3.0f;
        }
        public override void AddRecipes()  
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(705, 9);   
            recipe.AddTile(TileID.WorkBenches);  
            recipe.SetResult(this);
            recipe.AddRecipe();
        }      
    }
}