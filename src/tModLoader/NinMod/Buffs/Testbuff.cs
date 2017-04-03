using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
 
namespace NinMod.Buffs
{
    public class Testbuff : ModBuff
    {
        public override void SetDefaults()
        {
            Main.buffNoTimeDisplay[Type] = false;
            Main.buffName[this.Type] = "Test";
            Main.buffTip[this.Type] = "toast";
        }
        public override void Update(Player player, ref int buffIndex)
        {                                     
			player.AddBuff(21, 1);
            player.AddBuff(BuffID.Inferno, 2);
			
        }
		
    }
}
    