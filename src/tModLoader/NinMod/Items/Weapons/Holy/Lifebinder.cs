using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using NinMod.Items;

namespace NinMod.Items.Weapons.Holy {
  public class Lifebinder : CustomItem {
    public override void SetDefaults() {
			item.name = "The Lifebinder";
      this.holy = true;
			item.damage = 12;
      item.mana = 3;
			item.width = 23;
			item.height = 23;
      item.toolTip = "Heals for " + item.damage + " HP";
			item.toolTip2 = "A gift from the keeper Freya, creator of the Emerald Dream and protector of all living things.";
			item.useTime = 39;
			item.useAnimation = 39;
			item.useStyle = 1;
			Item.staff[item.type] = true;
			item.noMelee = true;
			item.value = 000010;
			item.rare = 5;
			item.UseSound = SoundID.Item20;
			item.autoReuse = true;
		}

    public override void GetWeaponDamage(Player player, ref int damage) {
      base.GetWeaponDamage(player, ref damage);
      item.toolTip = "Heals for " + damage + " HP";
    }
  }
}
