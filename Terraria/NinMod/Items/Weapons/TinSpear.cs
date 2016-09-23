using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace NinMod.Items.Weapons
{
    public class TinSpear : ModItem
    {
        public override void SetDefaults()
        {
            item.name = "Tin Spear";
            item.damage = 7;// 7 9 10 12 13 15 17
            item.toolTip = "it is the second most useless thing next to the shortsword";
            item.melee = true;
            item.width = 4;
            item.height = 4;
            item.scale = 1.1f;
            item.maxStack = 1;
            item.useTime = 30;
            item.useAnimation = 30;
            item.knockBack = 1.1f;
            item.useSound = 1;
            item.noMelee = true;
            item.noUseGraphic = true;
            item.useTurn = true;
            item.useStyle = 5;
            item.value = 000002;
            item.rare = 8;
            item.shoot = mod.ProjectileType("tinspearproj");  
            item.shootSpeed = 2.3f;
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