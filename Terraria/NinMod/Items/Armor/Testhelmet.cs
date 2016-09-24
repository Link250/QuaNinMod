using System;
using System.Collections.Generic;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Microsoft.Xna.Framework;

namespace NinMod.Items.Armor
{
    public class Testhelmet : ModItem
    {
        public override bool Autoload(ref string name, ref string texture, IList<EquipType> equips)
        {
            equips.Add(EquipType.Head);
            return true;
        }

        public override void SetDefaults()
        {
            item.name = "Testhelmet";
            item.toolTip = "tetete";
        }

        public override void UpdateEquip(Player player)
        {
            player.setBonus = "WROOOOOOOOOOOOOOOOM";
            player.meleeDamage *= player.velocity.Length() / 12;
            player.meleeCrit = 10;
            //player.runAcceleration = 1f;
            player.thorns = player.velocity.Length() / 5;
            player.thrownVelocity = 20;
            player.thrownCost50 = true;
            player.thrownVelocity = 27f;
            player.statDefense += (int)(8 * player.velocity.Length());


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
            recipe.AddIngredient(ItemID.DirtBlock, 1);
            recipe.AddTile(18);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}