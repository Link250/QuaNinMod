﻿using Terraria.ID;
using Terraria.ModLoader;

namespace NinMod.Items.Placeables {
    public class Miner_Item_MK2 : ModItem
    {
        public override void SetDefaults()
        {
            item.name = "Improved Miner";
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
            item.value = 5 * (6 * 100 * 100);
            item.createTile = mod.TileType("Miner_Block_MK2");
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(mod, "Miner_Item", 1);
            recipe.AddIngredient(ItemID.HellstoneBar, 10);
            recipe.AddIngredient(ItemID.CobaltDrill, 1);
            recipe.SetResult(this);
            recipe.AddTile(18);
            recipe.AddRecipe();
        }
    }
}