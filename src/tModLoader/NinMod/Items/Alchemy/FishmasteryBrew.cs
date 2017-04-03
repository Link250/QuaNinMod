using System;
using System.IO;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
 
namespace NinMod.Items.Alchemy
{
    public class FishmasteryBrew : ModItem
    {
        public override void SetDefaults()
        {
            item.name = "Fishing master Brew";
            item.UseSound = SoundID.Item3;
            item.useStyle = 2;
            item.useTurn = true;
            item.useAnimation = 17;
            item.useTime = 17;
            item.maxStack = 30;
            item.consumable = true;
            item.width = 20;
            item.height = 28;
            item.toolTip = "A mixture that will transform you into the ultimate fishing expert!";
            item.value = 1000;
            item.rare = 5;
            item.buffType = mod.BuffType("FishmasteryBuff");
            item.buffTime = 18000;
            return;
        }
		
        public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ModLoader.GetMod("NinMod").GetItem("Basepotionplus"));
            recipe.AddIngredient(287, 3);
            recipe.AddIngredient(3197, 3);
            recipe.AddTile(13);
			recipe.AddTile(355);
			recipe.SetResult(this);
			recipe.AddIngredient(75);
			recipe.AddRecipe();
		}
		
	}
}