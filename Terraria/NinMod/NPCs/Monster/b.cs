using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using System;

namespace NinMod.NPCs.Monster
{
	public class b : ModNPC
	{
   /*     public override bool Shoot(Player player, ref Microsoft.Xna.Framework.Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
            float baseSpeed = (float)Math.Sqrt(speedX * speedX + speedY * speedY);
            double baseAngle = Math.Atan2(speedX, speedY);
            position.X += 40 * (float)Math.Sin(baseAngle);
            position.Y += 40 * (float)Math.Cos(baseAngle);


            for (int i = 0; i < 1; ++i)
            {
                double randomAngle = baseAngle + (Main.rand.NextFloat() - 0.5f) * 0.17;
                speedX = baseSpeed * (float)Math.Sin(randomAngle) * ((Main.rand.NextFloat() * 0.2f + 0.9f));
                speedY = baseSpeed * (float)Math.Cos(randomAngle) * ((Main.rand.NextFloat() * 0.2f) + 0.9f);

                Terraria.Projectile.NewProjectile(position.X, position.Y, speedX, speedY, 283, damage, 20f, Main.myPlayer);
            }
            

            return false;
        }*/

        public override void PostAI()
        {

            if(npc.HasValidTarget)
            {
                float baseSpeed = (float)Math.Sqrt(5 * 5 + 5 * 5);
                Vector2 targetPos = Main.player[npc.target].position;
                Vector2 thisPos = npc.position;
                targetPos.X -= (thisPos.X += npc.width / 2);
                targetPos.Y -= (thisPos.Y += npc.height / 2);
                double baseAngle = Math.Atan2(targetPos.X, targetPos.Y);

                for (int i = 0; i < 1; ++i)
                {
                    double randomAngle = baseAngle + (Main.rand.NextFloat() - 0.5f) * 0.17;
                    float speedX = baseSpeed * (float)Math.Sin(randomAngle) * ((Main.rand.NextFloat() * 0.2f + 0.9f));
                    float speedY = baseSpeed * (float)Math.Cos(randomAngle) * ((Main.rand.NextFloat() * 0.2f) + 0.9f);

                    Terraria.Projectile.NewProjectile(thisPos.X, thisPos.Y, speedX, speedY, 283, 10, 20f);
                }
            }
        }

        public override void SetDefaults()
		{
            npc.target = 3;
			npc.name = "b";
			npc.displayName = "b";
			npc.width = 88;
			npc.height = 88;
			npc.damage = 1;
			npc.defense = 70;
			npc.lifeMax = 9200;
			npc.soundHit = 8;
			npc.soundKilled = 5;
			npc.value = 75000f;
			npc.npcSlots = 1f;
			npc.buffImmune[31] = true;
			npc.noGravity = true;
			npc.knockBackResist = 0.2f;
			npc.takenDamageMultiplier = 1f;
			npc.aiStyle = 85;
			Main.npcFrameCount[npc.type] = Main.npcFrameCount[421];
			aiType = 421;
			animationType = 421;
		}
		
		public override float CanSpawn(NPCSpawnInfo spawnInfo)
		{
			return 1f;
		}
		
		public override void HitEffect(int hitDirection, double damage)
		{

		}
	}
}
