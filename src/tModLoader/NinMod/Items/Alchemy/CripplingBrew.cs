using System;
using System.IO;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
 
namespace NinMod.Items.Alchemy
{
    public class CripplingBrew : ModItem
    {
        public override void SetDefaults()
        {
            item.name = "Crippling Brew";
            item.UseSound = SoundID.Item3;               
            item.useStyle = 2;         
            item.useTurn = true;
            item.useAnimation = 17;
            item.useTime = 17;
            item.maxStack = 30; 
            item.consumable = true; 
            item.width = 20;
            item.height = 28;
            item.toolTip = "A brew that will give you Osteoporosis";
            item.value = 100;
            item.buffType = mod.BuffType("CrimBuff");
            item.buffTime = 20000;
            item.rare = 1;
            return;
        }
		
		
        public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ModLoader.GetMod("NinMod").GetItem("Basepotion"));
			recipe.AddTile(13);
			recipe.AddTile(355);
			recipe.SetResult(this);
			recipe.AddIngredient(316);
			recipe.AddRecipe();
		}
		
	}
}