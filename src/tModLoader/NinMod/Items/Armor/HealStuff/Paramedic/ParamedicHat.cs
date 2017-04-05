using System;
using System.Collections.Generic;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Microsoft.Xna.Framework;

namespace NinMod.Items.Armor.HealStuff.Paramedic
{
    public class ParamedicHat : ModItem
    {
        public override bool Autoload(ref string name, ref string texture, IList<EquipType> equips)
        {
          equips.Add(EquipType.Head);
          return true;
        }

        public override void SetDefaults()
        {
          item.name = "Paramedic's Hat";
          item.maxStack = 1;
          item.defense = 5;
          item.width = 12;
          item.height = 11;
          item.toolTip = "+10% holy power";
          item.value = 0;
          item.rare = 10;
        }

        public override void UpdateEquip(Player player)
        {
          CustomPlayer modPlayer = player.GetModPlayer<CustomPlayer>(mod);
          modPlayer.holyPower *= 1.1f;
        }

        public override bool IsArmorSet(Item head, Item body, Item legs)
        {
          return head.type == mod.ItemType("ParamedicHat") && body.type == mod.ItemType("ParamedicChest") && legs.type == mod.ItemType("ParamedicPants");
        }

        public override void UpdateArmorSet(Player player)
        {
          player.setBonus = "Paramedic\n+80 mana\nIncreased mana regeneration below 50% HP.";
          player.statManaMax2 += 80;
          if(player.statLife <= (player.statLifeMax2 * 0.5f)) {
            player.manaRegenBonus += 7;
          }
        }
    }
}
