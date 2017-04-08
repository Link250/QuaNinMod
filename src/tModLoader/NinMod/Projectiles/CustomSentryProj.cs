using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
 
namespace NinMod.Projectiles  
 
{
    public class CustomSentryProj : ModProjectile
    {
 
        public override void SetDefaults()
        {
 
            projectile.name = "Gaylord"; 
            projectile.width = 39; 
            projectile.height = 39; 
            projectile.hostile = false;   
            projectile.friendly = false;   
            projectile.ignoreWater = true;  
            Main.projFrames[projectile.type] = 1; 
            projectile.timeLeft = 3000;  
            projectile.penetrate = -1; 
            projectile.tileCollide = true; 
            projectile.sentry = true; 
        }
 
        public override void Kill(int timeLeft)
        {
            Main.PlaySound(28, projectile.Center, 62);  
        }
 
        public override void AI()
        {
            projectile.rotation += 0.1f;

            if(projectile.ai[0] > 5f) {
                float closestDistance = 720f;
                NPC closestNPC = null;
                foreach (NPC npc in Main.npc) {
                    float distance = (projectile.Center - npc.Center).Length();
                    if (distance <= closestDistance && !npc.friendly && npc.active && npc.life > 0) {
                        closestDistance = distance;
                        closestNPC = npc;
                    }
                }
                if (closestNPC != null) {
                    float bulletSpeed = 10;
                    // aiming
                    float bulletFlyTime = closestDistance / bulletSpeed / 2;
                    Vector2 FutureEnemyPos = closestNPC.Center + closestNPC.velocity * bulletFlyTime;
                    Vector2 angle = FutureEnemyPos - projectile.Center;
                    angle = angle * bulletSpeed / angle.Length();
                    //randomization
                    angle = angle.RotatedByRandom(3.141/100);
                    //shooting
                    Projectile.NewProjectile(projectile.Center, angle, 14, 5, 0, Main.myPlayer, 0f, 0f);
                    Main.PlaySound(28, (int)projectile.position.X, (int)projectile.position.Y, 24);
                    projectile.ai[0] = 0f;
                }
            } else {
                projectile.ai[0] += 1f;
            }
        }
    }
}