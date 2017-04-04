using System;
using System.Collections.Generic;
using System.IO;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.GameContent;
using Terraria.GameContent.UI;
using Terraria.GameInput;
using Terraria.ModLoader.IO;

namespace NinMod {
  public class CustomPlayer : ModPlayer {
    public float holyPower;

    public override void ResetEffects(){
      holyPower = 0.0f;
    }

    public override void UpdateDead(){
      holyPower = 0.0f;
    }
  }
}
