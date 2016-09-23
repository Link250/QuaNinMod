using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace NinMod.Items.Weapons
{
    public class IronSpear : ModItem
    {
        public override void SetDefaults()
        {
            item.name = "iron Spear";
            item.damage = 9;// 7 9 10 12 13 15 17
            item.crit = 2;
            item.melee = true;
            item.width = 4;
            item.height = 4;
            item.scale = 1.1f;
            item.maxStack = 1;
            item.useTime = 30;
            item.useAnimation = 30;
            item.knockBack = 1.3f;
            item.useSound = 1;
            item.noMelee = true;
            item.noUseGraphic = true;
            item.useTurn = true;
            item.useStyle = 5;
            item.value = 000008;
            item.rare = 8;
            item.shoot = mod.ProjectileType("ironspearproj");  
            item.shootSpeed = 2.5f;
        }
        public override void AddRecipes()  
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.DirtBlock, 1);   
            recipe.AddTile(TileID.WorkBenches);  
            recipe.SetResult(this);
            recipe.AddRecipe();
        }      
    }
}