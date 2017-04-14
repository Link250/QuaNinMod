using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace NinMod.Items.Placeables {
    public class TestBlock : ModItem
    {
        public override void SetDefaults()
        {
            item.name = "TestBlock";
            item.width = 14;
            item.height = 14;
            item.maxStack = 99;
            AddTooltip("This is a modded Block.");
            item.useTurn = true;
            item.autoReuse = true;
            item.useAnimation = 15;
            item.useTime = 10;
            item.useStyle = 1;
            item.consumable = true;
            item.value = 150;
            item.createTile = mod.TileType("TestBlock");
        }
    }
}