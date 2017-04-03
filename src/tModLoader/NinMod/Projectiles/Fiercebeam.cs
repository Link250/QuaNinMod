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

namespace NinMod.Projectiles
{
	public class Fiercebeam : ModProjectile
	{
		bool foundTarget = false;
		NPC target;
		
		public override void SetDefaults()
		{
			projectile.alpha = 128;
			projectile.tileCollide = true;
			projectile.damage = 0;
			projectile.Hitbox = new Rectangle(0,0,30,30);
			projectile.light=1;
		}
		
		public override bool? CanHitNPC(NPC target)
		{
			return !target.townNPC && !target.immortal && !target.friendly;
		}
		
		public override void AI()
		{
			Dust.NewDust(projectile.position, projectile.width, projectile.height, DustID.Vortex);
			projectile.rotation ++;
			if(!foundTarget){
				NPC nearest = null;
				foreach(NPC n in Main.npc){
					if((nearest == null || (n.Distance(projectile.position) < nearest.Distance(projectile.position))) && n.life>0 && !n.townNPC && !n.immortal && !n.friendly)nearest = n;
				}
				if((nearest != null) && (nearest.Distance(projectile.position)<500)){
					foundTarget = true;
					target = nearest;
				}
			}else{
				float agility = 10/(target.position - projectile.position).Length();
//				agility = 1;
				if(agility > 1) agility = 1;
				float newAngle = (float)Math.Atan2(target.position.Y-projectile.position.Y, target.position.X-projectile.position.X);
				float oldAngle = projectile.velocity.ToRotation();
				projectile.velocity = projectile.velocity.RotatedBy((oldAngle < newAngle ? 1 : -1)*agility);
				if(target.life <= 0)foundTarget = false;
			}
		}
	}
}
