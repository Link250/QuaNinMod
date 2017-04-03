using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace NinMod.Items.Weapons
{
    public class LeadSpear : ModItem
    {
        public override void SetDefaults()
        {
            item.name = "Lead Spear";
            item.damage = 10;// 7 9 10 12 13 15 17
            item.crit = 2;
            item.melee = true;
            item.width = 5;
            item.height = 5;
            item.scale = 1.1f;
            item.maxStack = 1;
            item.useTime = 30;
            item.useAnimation = 30;
            item.knockBack = 1.6f;
            item.UseSound = SoundID.Item1;
            item.noMelee = true;
            item.noUseGraphic = true;
            item.useTurn = true;
            item.useStyle = 5;
            item.value = 000010;
            item.rare = 8;
            item.shoot = mod.ProjectileType("leadspearproj");  
            item.shootSpeed = 2.2f;
        }
        public override void AddRecipes()  
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(704, 9);   
            recipe.AddTile(TileID.WorkBenches);  
            recipe.SetResult(this);
            recipe.AddRecipe();
        }      
    }
}