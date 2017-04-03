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
			npc.damage = 70;
			npc.defense = 9;
			npc.lifeMax = 420;
			/*npc.soundHit = 8;
			npc.soundKilled = 5;*/
			npc.value = 750f;
			npc.npcSlots = 1f;
			npc.buffImmune[31] = true;
			npc.noGravity = true;
			npc.knockBackResist = 0.0f;
			npc.takenDamageMultiplier = 1f;
			npc.aiStyle = 85;
			Main.npcFrameCount[npc.type] = Main.npcFrameCount[421];
			aiType = 421;
			animationType = 421;
		}
		
		public override float CanSpawn(NPCSpawnInfo spawnInfo)
		{
			return Main.rand.Next(15)==0 && ModHelper.playerNearSolar(spawnInfo.) ? 1f : 0f;
		}
		
		public override void HitEffect(int hitDirection, double damage)
		{

		}
	}
}
