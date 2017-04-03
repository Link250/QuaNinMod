using Terraria.ID;
using Terraria.ModLoader;

namespace NinMod.Items.blocks
{
    public class Miner_Item : ModItem
    {
        public override void SetDefaults()
        {
            item.name = "Basic Miner";
            item.width = 26;
            item.height = 22;
            item.maxStack = 99;
            AddTooltip("A useful Miner for lazy Terrarians.");
            item.useTurn = true;
            item.autoReuse = true;
            item.useAnimation = 15;
            item.useTime = 10;
            item.useStyle = 1;
            item.consumable = true;
            item.value = 50;
            item.createTile = mod.TileType("Miner_Block");
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(1041, 93);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}