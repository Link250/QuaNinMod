using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace NinMod.Items.Accessories.HealStuff {
  public class HolyEmblem : ModItem {
    public override void SetDefaults(){
      item.name = "Holy Emblem";
      item.width = 24;
      item.height = 24;
      item.accessory = true;
      item.toolTip = "15% increased holy power";
      item.value = 100000;
      item.rare = 4;
    }
    public override void UpdateAccessory(Player player, bool hideVisual)
  	{
  		CustomPlayer modPlayer = player.GetModPlayer<CustomPlayer>(mod);
  		modPlayer.holyPower *= 1.15f;
  	}
  }
}
