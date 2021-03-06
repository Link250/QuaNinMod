using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace NinMod.Items.Weapons.Melee 
    {
    public class PlatinumSpear : ModItem
    {
        public override void SetDefaults()
        {
            item.name = "Platinum Spear";
            item.damage = 17;// 7 9 10 12 13 15 17
            item.crit = 4;
            item.melee = true;
            item.width = 7;
            item.height = 7;
            item.scale = 1.1f;
            item.maxStack = 1;
            item.useTime = 30;
            item.useAnimation = 30;
            item.knockBack = 3.1f;
            item.UseSound = SoundID.Item1;
            item.noMelee = true;
            item.noUseGraphic = true;
            item.useTurn = true;
            item.useStyle = 5;
            item.value = 000090;
            item.rare = 8;
            item.shoot = mod.ProjectileType("platinumspearproj");  
            item.shootSpeed = 3.5f;
        }
        public override void AddRecipes()  
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(706, 9);   
            recipe.AddTile(TileID.WorkBenches);  
            recipe.SetResult(this);
            recipe.AddRecipe();
        }      
    }
}