using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace NinMod.Items.Weapons.Holy {
  public class Bandage : ModItem {
    public override void SetDefaults() {
			item.name = "Bandage";
			item.damage = 12;
			item.magic = true;
			item.crit = 2;
			item.mana = 3;
			item.width = 32;
			item.height = 32;
			item.toolTip = "Heals equal to players holy power";
			item.useTime = 39;
			item.useAnimation = 39;
			item.useStyle = 1;
			Item.staff[item.type] = true;
			item.noMelee = true;
			item.knockBack = -10;
			item.value = 000010;
			item.rare = 5;
			item.UseSound = SoundID.Item20;
			item.autoReuse = true;
			item.shoot = 14;
			item.shootSpeed = 40.0f;
		}

    public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack) {
      CustomPlayer modPlayer = player.GetModPlayer<CustomPlayer>(mod);
      int heal = (int) (modPlayer.holyPower * 12);
      if (heal > 0) {
        player.statLife += heal;
        if (Main.myPlayer == player.whoAmI)
        {
          player.HealEffect(heal, true);
        }
        if (player.statLife > player.statLifeMax2)
        {
          player.statLife = player.statLifeMax2;
        }
      }
			return false;
		}
  }
}
