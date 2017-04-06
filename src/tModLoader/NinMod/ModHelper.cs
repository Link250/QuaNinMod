using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using System.Collections.Generic;

namespace NinMod
{
	public static class ModHelper
	{
		public static Microsoft.Xna.Framework.Vector2[] evenArc(float speedX,  float speedY, int angle, int num)
        {
            var posArray = new Microsoft.Xna.Framework.Vector2[num];
            float spread = (float)(angle * 0.00642925);
            float baseSpeed = (float)System.Math.Sqrt(speedX * speedX + speedY * speedY);
            double startAngle = System.Math.Atan2(speedX, speedY) - spread / 2;
            double deltaAngle = spread / (float)num;
            double offsetAngle;
            for (int i = 0; i < num; ++i)
            {
                offsetAngle = startAngle + deltaAngle * i;
                posArray[i] = new Microsoft.Xna.Framework.Vector2(baseSpeed * (float)System.Math.Sin(offsetAngle), baseSpeed * (float)System.Math.Cos(offsetAngle));
            }
            return (Microsoft.Xna.Framework.Vector2[])posArray;
        }

		public static Vector2 rotateByDegree(Vector2 startVector, float rotationDegree = 0f){
			Vector2 rotationVector = new Vector2((float)Math.Cos(rotationDegree*Math.PI/180),(float)Math.Sin(rotationDegree*Math.PI/180));
			return new Vector2(startVector.X*rotationVector.X-startVector.Y*rotationVector.Y, startVector.X*rotationVector.Y+startVector.Y*rotationVector.X);
		}

		public static bool findNPCWithinDistance(int npcType, Vector2 position, int distance){
			foreach(NPC n in Main.npc){
				if(n.type == npcType && (new Vector2(n.position.X-position.X, n.position.Y-position.Y)).Length() <= distance) return true;
			}
			return false;
		}

		public static bool playerNearSolar(Player player){
			foreach(NPC n in Main.npc){
				if((n.type == NPCID.LunarTowerSolar ||
				   n.type == NPCID.SolarCorite ||
				   n.type == NPCID.SolarCrawltipedeBody ||
				   n.type == NPCID.SolarCrawltipedeHead ||
				   n.type == NPCID.SolarCrawltipedeTail ||
				   n.type == NPCID.SolarDrakomire ||
				   n.type == NPCID.SolarDrakomireRider ||
				   n.type == NPCID.SolarFlare ||
				   n.type == NPCID.SolarGoop ||
				   n.type == NPCID.SolarSolenian ||
				   n.type == NPCID.SolarSpearman ||
				   n.type == NPCID.SolarSroller) && player.Distance(n.position) <= 1000){
					return true;
				}
			}return false;
		}

		public static bool playerNearNebula(Player player){
			foreach(NPC n in Main.npc){
				if((n.type == NPCID.LunarTowerNebula ||
				   n.type == NPCID.NebulaBeast ||
				   n.type == NPCID.NebulaBrain ||
				   n.type == NPCID.NebulaHeadcrab ||
				   n.type == NPCID.NebulaSoldier) && player.Distance(n.position) <= 1000){
					return true;
				}
			}return false;
		}

		public static bool playerNearStardust(Player player){
			foreach(NPC n in Main.npc){
				if((n.type == NPCID.LunarTowerStardust ||
				   n.type == NPCID.StardustCellBig ||
				   n.type == NPCID.StardustCellSmall ||
				   n.type == NPCID.StardustJellyfishBig ||
				   n.type == NPCID.StardustJellyfishSmall ||
				   n.type == NPCID.StardustSoldier ||
				   n.type == NPCID.StardustSpiderBig ||
				   n.type == NPCID.StardustSpiderSmall ||
				   n.type == NPCID.StardustWormBody ||
				   n.type == NPCID.StardustWormHead ||
				   n.type == NPCID.StardustWormTail) && player.Distance(n.position) <= 1000){
					return true;
				}
			}return false;
		}

		public static bool playerNearVortex(Player player){
			foreach(NPC n in Main.npc){
				if((n.type == NPCID.LunarTowerVortex ||
				   n.type == NPCID.VortexHornet ||
				   n.type == NPCID.VortexHornetQueen ||
				   n.type == NPCID.VortexLarva ||
				   n.type == NPCID.VortexRifleman ||
				   n.type == NPCID.VortexSoldier) && player.Distance(n.position) <= 1000){
					return true;
				}
			}return false;
		}

        public static List<Player> getPlayersInArea(Vector2 position, int radius) {
            List<Player> playersFound = new List<Player>();
            foreach(Player player in Main.player) {
                float currentRad;
                if (player.team == Main.player[Main.myPlayer].team && (currentRad = (player.position - position).Length()) <= radius) {
                    int index = 0;
                    foreach(Player pl in playersFound) {
                        if (currentRad < (pl.position - position).Length() )
                            break;
                        else index++;
                    }
                    playersFound.Insert(index, player);
                }
            }
            return playersFound;
        }

        public static void createParticleCircle(Vector2 position, float radius, int density, int dustID, float speedMod) {
			this.createParticleCircleColored(position, radius, density, dustID, speedMod, null);
        }

		public static void createParticleCircleColored(Vector2 position, float radius, int density, int dustID, float speedMod, Color color) {
			Vector2 offset = new Vector2(radius, 0);
			if(color == null){
	            for(int i = 0; i < density; i++) {
	                offset = offset.RotatedBy(Math.PI * 2 / density);
	                //                Dust.NewDustDirect(position + offset, 10, 10, dustID, -offset.X/60, -offset.Y/60);
	                Dust.NewDustPerfect(position + offset, dustID, -offset * speedMod);
	            }
			} else {
				for(int i = 0; i < density; i++) {
	                offset = offset.RotatedBy(Math.PI * 2 / density);
	                //                Dust.NewDustDirect(position + offset, 10, 10, dustID, -offset.X/60, -offset.Y/60);
	                Dust.NewDustPerfect(position + offset, dustID, -offset * speedMod, color);
			}
        }

        public static int getPlayerIndex(Player player) {
            for(int i = 0; i < Main.player.Length; i++) {
                if (Main.player[i].Equals(player)) return i;
            }
            return -1;
        }
	}
}
