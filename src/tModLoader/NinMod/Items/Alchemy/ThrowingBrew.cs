using System;
using System.IO;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
 
namespace NinMod.Items.Alchemy
{
    public class ThrowingBrew : ModItem
    {
        public override void SetDefaults()
        {
            item.name = "Throwing Brew";
            item.UseSound = SoundID.Item3;
            item.useStyle = 2;
            item.useTurn = true;
            item.useAnimation = 17;
            item.useTime = 17;
            item.maxStack = 30;
            item.consumable = true;
            item.width = 20;
            item.height = 28;
            item.toolTip = "A mixture that reduces throwing ammo cost and icreases your throwing skills";
            item.value = 100;
            item.rare = 4;
            item.buffType = mod.BuffType("ThrowingBuff");
            item.buffTime = 7200;
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