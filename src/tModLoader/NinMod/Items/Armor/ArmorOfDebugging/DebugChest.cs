using System;
using System.Collections.Generic;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Microsoft.Xna.Framework;

namespace NinMod.Items.Armor.ArmorOfDebugging
{
    public class DebugChest : ModItem
    {
        public override bool Autoload(ref string name, ref string texture, IList<EquipType> equips)
        {
            equips.Add(EquipType.Body);
            return true;
        }

        public override void SetDefaults()
        {
            item.name = "Debug Chest";
            item.maxStack = 1;
            item.defense = 9999;
            item.width = 18;
            item.height = 18;
            item.value = 0;
            item.rare = 10;
        }
    }
}
