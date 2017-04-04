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
            if(context == "bossBag" && arg == 3324) {
              if (Main.rand.Next(9) == 0) {
                player.QuickSpawnItem(mod.ItemType("HolyEmblem"));
              }
            }
            // Moon Lord
            if (context == "bossBag" && arg == 3332) {
              if (Main.rand.Next(9) == 0)
              {
                // Frostmourne
                player.QuickSpawnItem(mod.ItemType("Frostmourne"));
              }
            }
        }
    }
}
