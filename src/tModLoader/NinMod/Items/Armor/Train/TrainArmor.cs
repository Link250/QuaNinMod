using System;
using System.Collections.Generic;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Microsoft.Xna.Framework;

namespace NinMod.Items.Armor.Train
{
    public class TrainArmor : ModItem
    {
        public override bool Autoload(ref string name, ref string texture, IList<EquipType> equips)
        {
            equips.Add(EquipType.Body);
            return true;
        }

        public override void SetDefaults()
        {
            item.name = "Locomotive Burning Box";
            item.maxStack = 1;
            item.defense = 18;
            item.toolTip = "Chacka Chacka Chacka Chacka";
            item.width = 18;
            item.height = 18;
            item.value = 10000;
            item.rare = 6;
        }

        public override void UpdateEquip(Player player)
        {
            player.setBonus = "WROOOOOOOOOOOOOOOOM";
            player.meleeDamage *= player.velocity.Length() / 10;
            player.meleeCrit += 10;
  
           
        }

       

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(3458, 30);
            recipe.AddTile(18);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}