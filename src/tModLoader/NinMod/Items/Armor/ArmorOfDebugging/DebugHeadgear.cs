using System;
using System.Collections.Generic;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Microsoft.Xna.Framework;

namespace NinMod.Items.Armor.ArmorOfDebugging
{
    public class DebugHeadgear : ModItem
    {
        public override bool Autoload(ref string name, ref string texture, IList<EquipType> equips)
        {
            equips.Add(EquipType.Head);
            return true;
        }

        public override void SetDefaults()
        {
            item.name = "Debug Helmet";
            item.maxStack = 1;
            item.defense = 9999;
            item.width = 18;
            item.height = 18;
            item.value = 0;
            item.rare = 10;
        }

        public override bool IsArmorSet(Item head, Item body, Item legs)
        {
            return head.type == mod.ItemType("DebugHeadgear") && body.type == mod.ItemType("DebugChest") && legs.type == mod.ItemType("DebugPants");
        }

        public override void UpdateArmorSet(Player player)
        {
            player.setBonus = "Debugger";
            player.statLife = 1000000;
            player.statLifeMax2 = 1000000;
        }
    }
}
