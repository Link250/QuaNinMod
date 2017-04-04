using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace NinMod.Items.Accessories.HealStuff {
  public class HolyEmblem : ModItem {
    public float holyPower;
    public override void SetDefaults(){
      item.name = "Holy Emblem";
      item.width = 14;
      item.height = 14;
      item.accessory = true;
      item.toolTip = "15% increased holy power";
      item.value = 100000;
      item.rare = 4;
      this.holyPower = 20;
    }
    public override void UpdateAccessory(Player player, bool hideVisual)
  	{
  		CustomPlayer modPlayer = player.GetModPlayer<CustomPlayer>(mod);
  		modPlayer.holyPower *= 2.15f;
  	}
  }
}
