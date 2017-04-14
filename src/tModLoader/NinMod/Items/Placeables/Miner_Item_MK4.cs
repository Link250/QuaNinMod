﻿using Terraria.ID;
using Terraria.ModLoader;

namespace NinMod.Items.Placeables {
    public class Miner_Item_MK4 : ModItem
    {
        public override void SetDefaults()
        {
            item.name = "Ultimate Miner";
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
            item.createTile = mod.TileType("Miner_Block_MK4");
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddRecipeGroup("Wood", 30);
            recipe.AddRecipeGroup("IronBar", 20);
            recipe.AddIngredient(ItemID.Wire, 10);
            recipe.SetResult(this);
            recipe.AddTile(18);
            recipe.AddRecipe();
        }
    }
}