using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ModGlobalNPC.NPCs
{
    public class ModGlobalNPC : GlobalNPC
    {
        public override void NPCLoot(NPC npc) {

          // Frostmourne
          if (npc.type == NPCID.IceQueen){
            if (Main.rand.next(66) == 0) {
              Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("Frostmourne"), 1);
            }
          }

/*        	if(npc.type == NPCID.Zombie && Main.rand.Next(100) == 0)
            {
                Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.PlatinumCoin, 95);
            }*/
        }
    }
}
