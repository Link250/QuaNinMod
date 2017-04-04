using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace NinMod.NPCs.Monster
{
	public class BabyMetroid : ModNPC
	{
		public override void SetDefaults()
		{
			npc.name = "Baby Metroid";
			npc.displayName = "Baby Metroid";
			npc.width = 28;
			npc.height = 30;
			npc.damage = 60;
			npc.defense = 10;
			npc.lifeMax = 320;
			/*npc.soundHit = 8;
			npc.soundKilled = 5;*/
			npc.value = 750f;
			npc.npcSlots = 1f;
			npc.buffImmune[31] = true;
			npc.noGravity = true;
			npc.knockBackResist = 0.1f;
			npc.takenDamageMultiplier = 1f;
			npc.aiStyle = 85;
			Main.npcFrameCount[npc.type] = Main.npcFrameCount[421];
			aiType = 421;
			animationType = 421;
		}

		 public override float CanSpawn(NPCSpawnInfo spawnInfo)
		 {
            int x = spawnInfo.spawnTileX;
            int y = spawnInfo.spawnTileY;
            int tile = (int)Main.tile[x, y].type;
            bool oUnderworld = (y >= (Main.maxTilesY * 0.8f));
            return oUnderworld ? 0.02f : 0f;
        }
        public override void NPCLoot()
        {
            {
                Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, 3532, 1);
            }
        }

        public override void HitEffect(int hitDirection, double damage)
		{

		}
	}
}
