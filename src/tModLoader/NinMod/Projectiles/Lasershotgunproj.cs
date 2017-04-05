using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace NinMod.Projectiles
{
    public class Lasershotgunproj : ModProjectile
    {
        public override void SetDefaults()
        {
            projectile.name = "lasy";
            projectile.width = 32;
            projectile.height = 32;
//            projectile.aiStyle = 1;
            projectile.friendly = true;
            projectile.alpha = 100;
            projectile.extraUpdates = 2;
            projectile.scale = 1f;
            projectile.timeLeft = 600;
            projectile.magic = true;
            projectile.ignoreWater = true;
            projectile.penetrate = 2;
            projectile.Hitbox = new Rectangle(0, 0, 32, 32);
        }
        public override void AI()
        {
            projectile.rotation -= 0.4f;
        }
        public override bool PreKill(int timeLeft)
        {
            projectile.type = 440;
            projectile.penetrate = 2;
            return true;
        }

    }
}