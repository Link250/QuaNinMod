using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace NinMod.NPCs.Monster
{
	public class Metroid : ModNPC
	{
		public override void SetDefaults()
		{
			npc.name = "Metroid";
			npc.displayName = "Metroid";
			npc.width = 88;
			npc.height = 88;
			npc.damage = 170;
			npc.defense = 70;
			npc.lifeMax = 9200;
			npc.soundHit = 8;
			npc.soundKilled = 5;
			npc.value = 75000f;
			npc.npcSlots = 1f;
			npc.buffImmune[31] = true;
			npc.noGravity = true;
			npc.knockBackResist = 0.0f;
			npc.takenDamageMultiplier = 3f;
			npc.aiStyle = 85;
			Main.npcFrameCount[npc.type] = Main.npcFrameCount[421];
			aiType = 421;
			animationType = 421;
		}
		
		public override float CanSpawn(NPCSpawnInfo spawnInfo)
		{
			return Main.rand.Next(10)==0 && ModHelper.playerNearSolar(spawnInfo.player) ? 1f : 0f;
		}
		
		public override void HitEffect(int hitDirection, double damage)
		{

		}
	}
}
