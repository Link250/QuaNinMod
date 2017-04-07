using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
 
namespace NinMod.Buffs
{
    public class ThrowingBuff : ModBuff
    {
        public override void SetDefaults()
        {
            Main.buffNoTimeDisplay[Type] = false;
            Main.buffName[this.Type] = "Throwing Pro";
            Main.buffTip[this.Type] = "33% chance not to consume throwing Ammo, 5% more Damage and Crit, higher thrown velocity";
        }
        public override void Update(Player player, ref int buffIndex)
        {                                     
            player.thrownCost33 = true;
            player.thrownCrit += 5;
            player.thrownDamage += 5;
            player.thrownVelocity += 3;
            
        }
		
    }
}
    