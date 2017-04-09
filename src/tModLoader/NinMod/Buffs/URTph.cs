using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
 
namespace NinMod.Buffs
{
    public class URTph : ModBuff
    {
        public override void SetDefaults()
        {
            Main.buffNoTimeDisplay[Type] = false;
            Main.buffName[this.Type] = "Ult Recharge Time";
            Main.buffTip[this.Type] = "";
        }
        public override void Update(Player player, ref int buffIndex)
        {
           
			
        }
		
    }
}
    