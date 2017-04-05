using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Terraria;
using Terraria.ModLoader;

namespace NinMod.Items {
    public abstract class CustomItem : ModItem{

        public bool holy = false;

        public override void GetWeaponDamage(Player player, ref int damage) {
            GetWeaponDamageCustom(player, ref damage, this);
        }

        public void GetWeaponDamageCustom(Player player, ref int damage, CustomItem item) {
            if (item.holy) {
                CustomPlayer modPlayer = player.GetModPlayer<CustomPlayer>(mod);
                damage = (int)(modPlayer.holyPower * damage);
            }
        }
    }
}
