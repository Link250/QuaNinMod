using System;
using System.Collections.Generic;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Microsoft.Xna.Framework;

namespace NinMod.Items.Armor.HealStuff.Anodyne
{
    public class AnodynePants : ModItem
    {
        public override bool Autoload(ref string name, ref string texture, IList<EquipType> equips)
        {
          equips.Add(EquipType.Legs);
          return true;
        }

        public override void SetDefaults()
        {
          item.name = "Anodyne Pants";
          item.maxStack = 1;
          item.defense = 8;
          item.width = 11;
          item.height = 9;
          item.toolTip = "+30% holy power";
          item.value = 0;
          item.rare = 10;
        }

        public override void UpdateEquip(Player player)
        {
          CustomPlayer modPlayer = player.GetModPlayer<CustomPlayer>(mod);
          modPlayer.holyPower *= 1.3f;
        }
    }
}
