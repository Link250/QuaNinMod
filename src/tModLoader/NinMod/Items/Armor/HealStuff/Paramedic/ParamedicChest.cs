using System;
using System.Collections.Generic;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Microsoft.Xna.Framework;

namespace NinMod.Items.Armor.HealStuff.Paramedic
{
    public class ParamedicChest : ModItem
    {
        public override bool Autoload(ref string name, ref string texture, IList<EquipType> equips)
        {
          equips.Add(EquipType.Body);
          return true;
        }

        public override void SetDefaults()
        {
          item.name = "Paramedic's Chest";
          item.maxStack = 1;
          item.defense = 6;
          item.width = 15;
          item.height = 12;
          item.toolTip = "+10% holy power";
          item.value = 0;
          item.rare = 10;
        }

        public override void UpdateEquip(Player player)
        {
          CustomPlayer modPlayer = player.GetModPlayer<CustomPlayer>(mod);
          modPlayer.holyPower *= 1.1f;
        }
    }
}
