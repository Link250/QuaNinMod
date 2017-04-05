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
            projectile.CloneDefaults(440);
            projectile.name = "lasy";
            aiType = 440;
            projectile.penetrate = 2;
            Main.projFrames[projectile.type] = 1;
            projectile.rotation += 0.7f;
           
        }
        public override void AI()
        {
            projectile.rotation += 0.7f;
            
        }
        public override bool PreKill(int timeLeft)
        {
            projectile.type = 440;
            projectile.penetrate = 2;
            return true;
        }

    }
}