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

        public override void UpdateEquip(Player player)
        {
            player.setBonus = "Increases movement skill, decreases overall damage except for melee and ranged!";
            player.meleeDamage *= 1f;
            player.thrownDamage *= 1f;
            player.rangedDamage *= 0.2f;
            player.magicDamage *= 0.2f;
            player.minionDamage *= 0.2f;
            player.blackBelt = true;
            player.dashTime = 5;
            player.dash = 5;
            player.dashDelay= 1;
            player.meleeCrit = 10;
            player.runAcceleration = 1f;
            

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