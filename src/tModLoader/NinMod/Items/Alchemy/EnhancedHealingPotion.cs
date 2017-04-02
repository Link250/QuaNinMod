using System;
using System.IO;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
 
namespace NinMod.Items.Alchemy
{
    public class EnhancedHealingPotion : ModItem
    {
        public override void SetDefaults()
        {
            item.name = "Enhanced Healing Potion";
            item.UseSound = SoundID.Item3;               
            item.useStyle = 2;         
            item.useTurn = true;
            item.useAnimation = 17;
            item.useTime = 17;
            item.maxStack = 30; 
            item.consumable = true; 
            item.width = 20;
            item.height = 28;
            item.toolTip = "A mixture that heals but decreases light vision";
            item.value = 100;                
            item.rare = 1;
			item.buffType = 21; 
			item.buffTime = 3600;  
			item.healLife = 80;
            return;
        }
		public override bool CanUseItem(Player player){
        return player.FindBuffIndex(21) == -1;}
		public override bool UseItem(Player player){
		player.AddBuff(22, 1200, true);
		return true;
		}
		
        public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ModLoader.GetMod("NinMod").GetItem("Basepotion"));
			recipe.AddTile(13);
			recipe.AddTile(355);
			recipe.SetResult(this);
			recipe.AddIngredient(183, 1);
			recipe.AddRecipe();
		}
		
	}
}