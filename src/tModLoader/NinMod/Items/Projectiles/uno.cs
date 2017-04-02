﻿using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace NinMod.Items.Projectiles
{
    public class uno : ModProjectile
    {
        public override void SetDefaults()
        {
            projectile.CloneDefaults(63);
            projectile.name = "test";
            aiType = 63;
        }

        public override bool PreKill(int timeLeft)
        {
            projectile.type = 63;
            return true;
        }
        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
        {

            target.AddBuff(31, 120);

        }

        public override bool OnTileCollide(Vector2 oldVelocity)
        {
            for (int i = 0; i < 5; i++)
            {
                int a = Projectile.NewProjectile(projectile.Center.X, projectile.Center.Y - 16f, Main.rand.Next(-10, 11) * .25f, Main.rand.Next(-10, -5) * .25f, 296, (int)(projectile.damage * .5f), 0, projectile.owner);
                Main.projectile[a].aiStyle = 1;
                Main.projectile[a].tileCollide = true;
            }
            return true;
        }
    }
}