using System;
using System.Collections.Generic;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Microsoft.Xna.Framework;

namespace NinMod.Items.Armor.Train {
    public class TrainHelmet : ModItem
    {
        public override bool Autoload(ref string name, ref string texture, IList<EquipType> equips)
        {
            equips.Add(EquipType.Head);
            return true;
        }

        public override void SetDefaults()
        {
            item.name = "Locomotive Cab";
            item.maxStack = 1;
            item.defense = 14;
            item.toolTip = "Tchoo Tchoo!";
            item.width = 18;
            item.height = 18;
            item.value = 10000;
            item.rare = 2;
        }

        public override void UpdateEquip(Player player)
        {
            player.setBonus = "WROOOOOOOOOOOOOOOOM";

          //  player.statDefense += 1 + (int)(8 * player.velocity.Length());
            item.defense = 1 + (int)(8 * player.velocity.Length());
        }

        /*  public override bool IsArmorSet(Item head, Item body, Item legs)
          {
              return body.type == mod.ItemType("ExampleBreastplate") && legs.type == mod.ItemType("ExampleLeggings");
          }*/

        /*    public override void UpdateArmorSet(Player player)
            {
                player.setBonus = "trollface.jpg";
                player.meleeDamage *= 0.8f;
                player.thrownDamage *= 0.8f;
                player.rangedDamage *= 0.8f;
                player.magicDamage *= 0.8f;
                player.minionDamage *= 0.8f;
            }*/

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(3458, 10);
            recipe.AddTile(18);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}