using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace NinMod.GlobalItems {
    public class GlobalItem : Terraria.ModLoader.GlobalItem {

        public override void OpenVanillaBag(string context, Player player, int arg) {
          // Wall of Flesh
          if(context == "bossBag" && arg == 3324) {
            // Holy Emblem
            if (Main.rand.Next(6) == 0) {
              player.QuickSpawnItem(mod.ItemType("HolyEmblem"));
            }
          }
          // Moon Lord
          if (context == "bossBag" && arg == 3332) {
            // Frostmourne
            if (Main.rand.Next(9) == 0)
            {
              player.QuickSpawnItem(mod.ItemType("Frostmourne"));
            }
          }
        }
    }
}
