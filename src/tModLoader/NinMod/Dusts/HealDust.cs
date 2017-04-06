using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Terraria;
using Terraria.ModLoader;

namespace NinMod.Dusts {
    class HealDust : ModDust{
        public override void OnSpawn(Dust dust) {
            dust.velocity *= 1f;
            dust.noGravity = true;
            dust.noLight = true;
        }

        public override bool Update(Dust dust) {
            dust.position += dust.velocity;
            dust.velocity *= 0.99f;
            dust.scale *= 0.99f;
//            float light = 0.35f * dust.scale;
//            Lighting.AddLight(dust.position, 0.5f, 0.05f, 0.05f);
            if (dust.scale < 0.25f) {
                dust.active = false;
            }
            return false;
        }
    }
}
