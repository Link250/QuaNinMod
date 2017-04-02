using System;
using System.IO;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
 
namespace NinMod.Items.Alchemy
{
    public class LuckyPotion : ModItem
    {
        public override void SetDefaults()
        {
            item.name = "Lucky Potion";
            item.UseSound = SoundID.Item3;               
            item.useStyle = 2;         
            item.useTurn = true;
            item.useAnimation = 17;
            item.useTime = 17;
            item.maxStack = 30; 
            item.consumable = true; 
            item.width = 20;
            item.height = 28;
            item.toolTip = "A mixture that Gives you a random buff or debuff... or something else?";
            item.value = 100;                
            item.rare = 1;
			item.buffType = 21; 
			item.buffTime = 600;  
			item.healLife = 7;
            return;
            
        }
		public override bool CanUseItem(Player player){
        return player.FindBuffIndex(21) == -1;}
		public override bool UseItem(Player player){
		int[] randBuff = {22,196,195,148,5,6,7,42,58,63,114,112,113,94,70,100,97};
		player.AddBuff(randBuff[(int)(Main.rand.NextFloat()*17)], 2700, true);
		return true;
		}
		
        public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ModLoader.GetMod("NinMod").GetItem("Basepotion"));
			recipe.AddTile(13);
			recipe.AddTile(355);
			recipe.SetResult(this);
			recipe.AddIngredient(75);
			recipe.AddIngredient(2316);
			recipe.AddRecipe();
		}
		
	}
}