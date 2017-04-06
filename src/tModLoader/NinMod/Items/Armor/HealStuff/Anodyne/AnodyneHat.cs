using System;
using System.Collections.Generic;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Microsoft.Xna.Framework;

namespace NinMod.Items.Armor.HealStuff.Anodyne
{
    public class AnodyneHat : ModItem
    {
        public override bool Autoload(ref string name, ref string texture, IList<EquipType> equips)
        {
            equips.Add(EquipType.Head);
            return true;
        }

        public override void SetDefaults()
        {
          // Auf Stufe von Forbidden
          item.name = "Anodyne Hat";
          item.maxStack = 1;
          item.defense = 6;
          item.width = 16;
          item.height = 13;
          item.toolTip = "+30% holy power";
          item.value = 0;
          item.rare = 10;
        }

        public override void UpdateEquip(Player player)
        {
          CustomPlayer modPlayer = player.GetModPlayer<CustomPlayer>(mod);
          modPlayer.holyPower *= 1.3f;
        }

        public override bool IsArmorSet(Item head, Item body, Item legs)
        {
            return head.type == mod.ItemType("AnodyneHat") && body.type == mod.ItemType("AnodyneChest") && legs.type == mod.ItemType("AnodynePants");
        }

        public override void UpdateArmorSet(Player player)
        {
            player.setBonus = "Anodyne\n+500 mana\n95% reduced magic damage";
            player.statManaMax2 += 500;
            player.magicDamage -= 0.9f;
        }
    }
}
