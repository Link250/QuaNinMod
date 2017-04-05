using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using NinMod.Items;

namespace NinMod.Items.Weapons.Holy {
  public class Bandage : CustomItem {
    public override void SetDefaults() {
			item.name = "Bandage";
            this.holy = true;
			item.damage = 3;
			item.crit = 2;
			item.mana = 3;
			item.width = 32;
			item.height = 32;
			item.toolTip = "Heal amount equal to players holy power";
			item.useTime = 39;
			item.useAnimation = 39;
			item.useStyle = 1;
			item.noMelee = true;
			item.value = 000010;
			item.rare = 5;
			item.UseSound = SoundID.Item20;
			item.autoReuse = true;
			item.shoot = 14;
			item.shootSpeed = 40.0f;
		}

        public override void GetWeaponDamage(Player player, ref int damage) {
          base.GetWeaponDamage(player, ref damage);
        }

    public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack) {
        CustomPlayer modPlayer = player.GetModPlayer<CustomPlayer>(mod);
        if (damage > 0) {
            player.statLife += damage;
            if (Main.myPlayer == player.whoAmI) {
                player.HealEffect(damage, true);
            }
            if (player.statLife > player.statLifeMax2) {
                player.statLife = player.statLifeMax2;
            }
        }
        return false;
    }
  }
}
