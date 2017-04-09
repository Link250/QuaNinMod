using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Terraria.GameContent;
using Terraria.GameContent.Achievements;
using Terraria.Graphics.Shaders;

namespace NinMod.Items.Accessories
{
    public class ReinhardtboosterWings : ModItem
    {
        public override bool Autoload(ref string name, ref string texture, IList<EquipType> equips)
        {
            equips.Add(EquipType.Wings);
            return true;
        }

        public override void SetDefaults()
        {
            // 203 5 -12
            item.name = "Reinhardts charge";
            item.width = 22;
            item.height = 20;
            item.toolTip = "Precision German engineering!";
            item.value = 30000;
            item.rare = 9;
            item.accessory = true;
        }
        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.wingTimeMax = 5;
            
            
        }

        public override void VerticalWingSpeeds(ref float ascentWhenFalling, ref float ascentWhenRising,
            ref float maxCanAscendMultiplier, ref float maxAscentMultiplier, ref float constantAscend)
        {
            ascentWhenFalling = 0.85f;
            ascentWhenRising = 0.15f;
            maxCanAscendMultiplier = 1f;
            maxAscentMultiplier = 3f;
            constantAscend = 0.135f;
            
        }

        public override void HorizontalWingSpeeds(ref float speed, ref float acceleration)
        {
            speed = 15f;
            acceleration *= 14.5f;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddTile(18);
            recipe.SetResult(this);
            recipe.AddIngredient(3458, 13);
            recipe.AddRecipe();
        }
    }
}
