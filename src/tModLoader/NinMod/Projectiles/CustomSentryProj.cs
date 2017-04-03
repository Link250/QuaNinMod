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
            projectile.width = 42; 
            projectile.height = 42; 
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
 
            for (int i = 0; i < 200; i++)
            {
                NPC target = Main.npc[i];
 
       
                float shootToX = target.position.X + (float)target.width * 0.5f - projectile.Center.X;
                float shootToY = target.position.Y + (float)target.height * 0.5f - projectile.Center.Y;
                float distance = (float)System.Math.Sqrt((double)(shootToX * shootToX + shootToY * shootToY));
 
               
                if (distance < 720f && !target.friendly && target.active) 
                {
                    if (projectile.ai[0] > 12f)
                    {
                        
                        distance = 3.2f / distance;
 
                        
                        shootToX *= distance * 3;
                        shootToY *= distance * 3;
                        int damage = 5;  
						
                        Projectile.NewProjectile(projectile.Center.X, projectile.Center.Y, shootToX, shootToY, 14, damage, 0, Main.myPlayer, 0f, 0f); 
                        Main.PlaySound(28, (int)projectile.position.X, (int)projectile.position.Y, 24); 
                        projectile.ai[0] = 0f;
                    }
                }
				
            }
			
            projectile.ai[0] += 1f;
 
        }
    }
}