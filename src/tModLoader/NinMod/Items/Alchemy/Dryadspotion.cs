using System;
using System.IO;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
 
namespace NinMod.Items.Alchemy
{
    public class Dryadspotion : ModItem
    {
        public override void SetDefaults()
        {
            item.name = "Dryad's Potion";
            item.UseSound = SoundID.Item3;               
            item.useStyle = 2;         
            item.useTurn = true;
            item.useAnimation = 17;
            item.useTime = 17;
            item.maxStack = 30; 
            item.consumable = true; 
            item.width = 20;
            item.height = 28;
            item.toolTip = "A mixture that gives you the blessings of the dryad";
            item.value = 100;
            item.buffTime = 10800;
            item.rare = 1;
            return;
        }
		
	    public override bool UseItem(Player player){
		player.AddBuff(165, 10800, true);

            return true;
		}
		
        public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ModLoader.GetMod("NinMod").GetItem("Basepotion"));
			recipe.AddTile(13);
			recipe.AddTile(355);
			recipe.SetResult(this);
			recipe.AddIngredient(1725);
			recipe.AddIngredient(314);
			recipe.AddIngredient(2358);
			recipe.AddIngredient(66);
			recipe.AddIngredient(3191);
			recipe.AddIngredient(13);
			recipe.AddRecipe();
		}
		
	}
}