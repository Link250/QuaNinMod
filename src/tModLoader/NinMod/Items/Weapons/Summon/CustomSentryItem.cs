using Terraria;
using Terraria.ID;
using Microsoft.Xna.Framework;
using Terraria.ModLoader;
 
 
namespace NinMod.Items.Weapons     ///We need this to basically indicate the folder where it is to be read from, so you the texture will load correctly
{
    public class CustomSentryItem : ModItem
    {
 
        public override void SetDefaults()
        {
            item.name = "Sentry Staff"; 
            item.damage = 5; 
            item.mana = 12;  
            item.width = 56; 
            item.height = 56;   
            item.useTime = 25;  
            item.useAnimation = 25; 
            item.useStyle = 1;  
            AddTooltip("Summons a Sentry gun. Made by DAHL");  
            item.noMelee = true; 
            item.knockBack = 2.5f;  
            item.value = Item.buyPrice(0, 10, 0, 0); 
            item.rare = 4;  
            item.UseSound = SoundID.Item44; 
            item.autoReuse = true;
            item.shoot = mod.ProjectileType("CustomSentryProj");   
            item.summon = true;  
            item.sentry = true; 
        }
 
        public override bool Shoot(Player player, ref Microsoft.Xna.Framework.Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
            Vector2 SPos = Main.screenPosition + new Vector2((float)Main.mouseX, (float)Main.mouseY);  
            position = SPos;
            for (int l = 0; l < Main.projectile.Length; l++)
            {                                                                  
                Projectile proj = Main.projectile[l];
                if (proj.active && proj.type == item.shoot && proj.owner == player.whoAmI)
                {
                    proj.active = false;
                }
            }
            return true;
			
        }
		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(98, 1);
            recipe.AddIngredient(117, 12);
            recipe.AddIngredient(3619, 1);
            recipe.AddIngredient(530, 20);
            recipe.AddIngredient(97, 100);
            recipe.SetResult(this);
			recipe.AddTile(221);
			recipe.AddRecipe();
		}
    }
}