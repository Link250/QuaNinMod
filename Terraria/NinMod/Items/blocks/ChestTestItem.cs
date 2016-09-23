using Terraria.ID;
using Terraria.ModLoader;

namespace NinMod.Items.blocks
{
    public class ChestTestItem : ModItem
    {
        public override void SetDefaults()
        {
            item.name = "Red Chest";        //Chest name
            item.width = 26;
            item.height = 22;
            item.maxStack = 99;
            AddTooltip("This is a modded chest.");   //chest descritpion
            item.useTurn = true;
            item.autoReuse = true;
            item.useAnimation = 15;
            item.useTime = 10;
            item.useStyle = 1;
            item.consumable = true;
            item.value = 50;    //chest value/price
            item.createTile = mod.TileType("ChestTestTile");  //here add your Chest name tile
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.DirtBlock);          //example of how to add a vanilla Terraria item
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}