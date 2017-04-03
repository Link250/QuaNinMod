using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace NinMod.Items.Weapons.Melee {
  public class Frostmourne : ModItem {
    public override void SetDefaults(){
      item.name = "Frostmourne";
      item.toolTip = "Runeblade of Ner'zhul, the Lich King, later wielded by Arthas.\nWhomsoever takes up this blade shall wield power eternal.\nJust as the blade rends flesh, so must power scar the spirit.";
      item.toolTip2 = "Missing Health increases Damage greatly.\nHeals for % of Damage dealt, falls off with more HP.";
      item.melee = true;
      item.damage = 44;
      item.knockBack = 8.0f;
      item.useTime = 31;
      item.useAnimation = 31;
      item.useStyle = 1;
      item.UseSound = SoundID.Item1;
      item.width = 37;
      item.height = 37;
      item.autoReuse = true;
      item.value = 1000000;
      item.rare = 9;
    }

    public override void GetWeaponDamage(Player player, ref int damage){
      float hpp = (float) player.statLife / player.statLifeMax2;
      short multiplier = (short) (15 - 10 * hpp);
      // x15 max dmg
      // x10 avg
      // x5 min
      damage = item.damage * multiplier;
    }

    public override void OnHitNPC(Player player, NPC target, int damage, float knockback, bool crit){
      float hpp = (float) player.statLife / player.statLifeMax2;
      int heal = (int) (50 * (1 - hpp));

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
  }
}
