using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
 
namespace NinMod.Buffs
{
    public class FishmasteryBuff : ModBuff
    {
        public override void SetDefaults()
        {
            Main.buffNoTimeDisplay[Type] = false;
            Main.buffName[this.Type] = "Fishing Mastery";
            Main.buffTip[this.Type] = "Fishing skill increased, sonar and crate potion effect";
        }
        public override void Update(Player player, ref int buffIndex)
        {
            player.fishingSkill += 16;
            player.sonarPotion = true;
            player.cratePotion = true;

        }
		
    }
}
    