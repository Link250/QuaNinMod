using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace NinMod.Items.Weapons
{
    public class CopperSpear : ModItem
    {
        public override void SetDefaults()
        {
            item.name = "Copper Spear";
            item.damage = 6;// 7 9 10 12 13 15 17
            item.toolTip = "it is the most useless thing next to the shortsword";
            item.melee = true;
            item.width = 3;
            item.height = 3;
            item.scale = 1.1f;
            item.maxStack = 1;
            item.useTime = 30;
            item.useAnimation = 30;
            item.knockBack = 1f;
            item.UseSound = SoundID.Item1;
            item.noMelee = true;
            item.noUseGraphic = true;
            item.useTurn = true;
            item.useStyle = 5;
            item.value = 000001;
            item.rare = 8;
            item.shoot = mod.ProjectileType("copperspearproj");  
            item.shootSpeed = 2.2f;
        }
        public override void AddRecipes()  
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(20, 9);   
            recipe.AddTile(TileID.WorkBenches);  
            recipe.SetResult(this);
            recipe.AddRecipe();
        }      
    }
}