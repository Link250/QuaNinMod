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
                //TODO add new boss drop in Wall Of Flesh Tresure Bag
//                player.QuickSpawnItem(ItemID.DirtBlock, 1);
            }
        }
    }
}
