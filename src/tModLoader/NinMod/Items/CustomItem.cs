using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Terraria;
using Terraria.ModLoader;

namespace NinMod.Items {
    public abstract class CustomItem : ModItem{

        public bool holy = false;

        // Magic Tooltip related stuff
        public override bool CloneNewInstances{
            get { return true; }
        }

        public override void GetWeaponDamage(Player player, ref int damage) {
            if (this.holy) {
                CustomPlayer modPlayer = player.GetModPlayer<CustomPlayer>(mod);
                damage = (int)(modPlayer.holyPower * damage);
            }
        }

        public override void ModifyTooltips(List<TooltipLine> tooltips) {
            base.ModifyTooltips(tooltips);
            if (this.holy) {
                int dmgIndex = tooltips.FindIndex(x => x.Name == "Damage");
                tooltips[dmgIndex].text = tooltips[dmgIndex].text.Split(' ')[0] + " holy power";
                tooltips.RemoveAll(x => x.Name == "Knockback");
            }
        }
    }
}
