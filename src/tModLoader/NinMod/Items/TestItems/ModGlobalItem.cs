using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace NinMod.Items.TestItems {
    public class ModGlobalItem : GlobalItem {

        public override void OpenVanillaBag(string context, Player player, int arg) {
            if(context == "bossBag" && arg == 3324) {
                //TODO add new boss drop in Wall Of Flesh Tresure Bag
//                Item.NewItem((int)player.position.X, (int)player.position.Y, player.width, player.height, ItemID.DirtBlock);
            }
        }
    }
}
