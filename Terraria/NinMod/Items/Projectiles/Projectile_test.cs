/*
 * Created by SharpDevelop.
 * User: QuantumHero
 * Date: 06.05.2016
 * Time: 01:42
 */
using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace NinMod.Items.Projectiles
{
	public class Projectile_test : ModProjectile
	{
		Vector2 originalSpeed;
		Vector2 rotationAngle;
		bool init = false;
		int phase = 0;
		int phaseDir = 1;
		bool foundTarget = false;
		NPC target;
		
		public override void SetDefaults()
		{
			projectile.alpha = 128;
			projectile.tileCollide = true;
			projectile.damage = 0;
			projectile.Hitbox = new Rectangle(0,0,10,10);
		}
		
		public override bool? CanHitNPC(NPC target)
		{
			return !target.townNPC && !target.dontTakeDamage;
		}
		
		public override void AI()
		{
			if(!init){
				originalSpeed = new Vector2(projectile.velocity.X,projectile.velocity.Y);
				float temp = (float)(Main.rand.NextFloat()*Math.PI*2);
				rotationAngle = new Vector2((float)Math.Cos(temp), (float)Math.Sin(temp));
				init = true;
				phase=5;
			}
			
			if(!foundTarget){
				projectile.velocity = originalSpeed+(rotationAngle*phase);
				phase+=phaseDir;
				if(phase >5 || phase<-5)phaseDir*=-1;
				Dust.NewDust(projectile.position, projectile.width, projectile.height, DustID.Fire);
				
				NPC nearest = Main.npc[0];
				foreach(NPC n in Main.npc){
					if(n.Distance(projectile.position) < nearest.Distance(projectile.position) && n.life>0 && !n.townNPC && !n.immortal && !n.friendly)nearest = n;
				}
				if(nearest.Distance(projectile.position)<300){
					foundTarget = true;
					target = nearest;
				}
			}else{
				Dust.NewDust(projectile.position, projectile.width, projectile.height, DustID.Fire);
				float newAngle = (float)Math.Atan2(target.position.X-projectile.position.X, target.position.Y-projectile.position.Y);
				projectile.velocity = new Vector2((float)(originalSpeed.Length() * Math.Sin(newAngle)), (float)(originalSpeed.Length() * Math.Cos(newAngle)));
				if(target.life <= 0)projectile.Kill();
				Terraria.Projectile.NewProjectile(projectile.position.X, projectile.position.Y, projectile.velocity.X, projectile.velocity.Y, 638, (int)(Math.Sqrt(Main.rand.NextFloat()*10000)), 15f, Main.myPlayer);
			}
		}
	}
}
