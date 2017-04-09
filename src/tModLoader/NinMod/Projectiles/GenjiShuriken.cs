using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace NinMod.Projectiles
{
    public class GenjiShuriken : ModProjectile
    {
        public override void SetDefaults()
        {
            projectile.name = "Genji-Shuriken";
            projectile.width = 31;
            projectile.height = 31;
            projectile.ranged = true;
            projectile.friendly = true;
            projectile.alpha = 100;
            projectile.extraUpdates = 2;
            projectile.scale = 1f;
            projectile.timeLeft = 600;
            projectile.ranged = true;
            projectile.ignoreWater = true;
            projectile.penetrate = 2;
            projectile.Hitbox = new Rectangle(0, 0, 32, 32);
            
        }
        public override void AI()
        {
            projectile.rotation -= 0.3f;
        }
        public override bool PreKill(int timeLeft)
        {
            projectile.type = 158;
            return true;
        }

    }
}