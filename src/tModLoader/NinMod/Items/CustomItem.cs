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
            base.GetWeaponDamage(player, ref damage);
            if (holy) {
                CustomPlayer modPlayer = player.GetModPlayer<CustomPlayer>(mod);
                damage = (int)(modPlayer.holyPower * damage);
            }
        }
    }
}
