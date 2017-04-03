using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
 
namespace NinMod.Buffs
{
    public class CrimBuff : ModBuff
    {
        public override void SetDefaults()
        {
            Main.buffNoTimeDisplay[Type] = false;
            Main.buffName[this.Type] = "Crippling Depression";
            Main.buffTip[this.Type] = "Everything is depressing...";
        }
        public override void Update(Player player, ref int buffIndex)
        {
            player.ZoneCrimson = true;
			
        }
		
    }
}
    