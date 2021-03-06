using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using NinMod;
using NinMod.Items;
using System.Collections.Generic;

namespace NinMod.Items.Weapons.Holy {
  public class Lifebinder : CustomItem {
    public override void SetDefaults() {
			item.name = "The Lifebinder";
            this.holy = true;
            item.damage = 20;
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
            item.shoot = 14;
			item.shootSpeed = 40.0f;
		}

    public override void GetWeaponDamage(Player player, ref int damage) {
      base.GetWeaponDamage(player, ref damage);
    }

    public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack) {
        bool healed = false;
        int healradius = 125;
        Vector2 mouse = Main.screenPosition + new Vector2(Main.mouseX, Main.mouseY);
        if (damage > 0) {
            List<Player> possibleTargets = ModHelper.getPlayersInArea(mouse, healradius);
            if(possibleTargets.Count > 0) {
                foreach (Player pl in possibleTargets) {
                    if(pl.statLife < pl.statLifeMax2) {
                        Projectile.NewProjectile(pl.Center, new Vector2(0,0), 298, 0, 0f, Main.myPlayer, (float)ModHelper.getPlayerIndex(pl), damage);
                        Projectile.NewProjectile(mouse, new Vector2(0,0), mod.ProjectileType("LifebinderProj"), 0, 0, Main.myPlayer, (float) healradius, 0f);
                        healed = true;
                        break;
                    }
                }
            }
        }
        if(!healed){
            Projectile.NewProjectile(mouse, new Vector2(0,0), mod.ProjectileType("LifebinderProj"), 0, 0, Main.myPlayer, (float) healradius, 1f);
        }
        return false;
    }
  }
}
