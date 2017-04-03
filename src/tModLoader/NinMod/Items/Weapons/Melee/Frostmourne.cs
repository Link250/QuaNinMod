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
      item.toolTip = "Runeblade of Ner'zhul, the Lich King, later wielded by Arthas\nWhomsoever takes up this blade shall wield power eternal.\nJust as the blade rends flesh, so must power scar the spirit.";
      item.toolTip2 = "Deals bonus damage equivalent to 50% of the holders HP";
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
      item.damage = damage + player.statLife / 2;
    }
  }
}
