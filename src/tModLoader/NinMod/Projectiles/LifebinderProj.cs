using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Terraria;
using Terraria.ModLoader;
using Microsoft.Xna.Framework.Graphics;

namespace NinMod.Projectiles {
    class LifebinderProj : ModProjectile {
        public override void SetDefaults() {
            projectile.alpha = 255;
            projectile.tileCollide = false;
            projectile.light = 0;
        }

        public override bool? CanHitNPC(NPC target) {
            return false;
        }

        public override bool PreDraw(SpriteBatch spriteBatch, Color lightColor) {
            float radius = projectile.ai[0];
            switch ((int)projectile.ai[1]) {
                case 0:
                    ModHelper.createParticleCircle(projectile.position, radius, 50, ModLoader.GetMod("NinMod").GetDust("HealDust").Type, 0.08f);
                    break;
                case 1:
                    ModHelper.createParticleCircle(projectile.position, radius, 50, ModLoader.GetMod("NinMod").GetDust("HealDust").Type, 0f, new Color(255, 255, 0));
                    break;
                default:
                    break;
            }
            projectile.active = false;
            return base.PreDraw(spriteBatch, lightColor);
        }

        public override void AI() {
            /*            Vector2 mouse = Main.screenPosition + new Vector2(Main.mouseX, Main.mouseY);
                        List<Player> possibleTargets = ModHelper.getPlayersInArea(mouse, 125);
                        if (possibleTargets.Count > 0) {
                            foreach (Player pl in possibleTargets) {
                                if (pl.statLife < pl.statLifeMax2) {
                                    pl.statLife += projectile.damage;
                                    pl.HealEffect(projectile.damage, true);
            //                        ModHelper.createParticleCircle(projectile.position, 100, 50, ModLoader.GetMod("NinMod").GetDust("HealDust").Type);
                                    projectile.active = false;
                                    break;
                                }
                            }
                        }*/
        }
    }
}
