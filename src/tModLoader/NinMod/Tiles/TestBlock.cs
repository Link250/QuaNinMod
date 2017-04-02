/*
 * Created by SharpDevelop.
 * User: QuantumHero
 * Date: 07.05.2016
 * Time: 14:16
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ObjectData;

namespace NinMod.Tiles
{
    public class TestBlock : ModTile
    {
        public override void SetDefaults()
        {
            Main.tileFrameImportant[Type] = true;
            Main.tileSolid[Type] = true;
            Main.tileNoAttach[Type] = true;
            TileObjectData.newTile.CopyFrom(TileObjectData.Style1x1);
            TileObjectData.newTile.CoordinateHeights = new int[] { 8, 8 };
            TileObjectData.addTile(Type);
            AddMapEntry(new Color(200, 200, 200), "TestBlock");
            dustType = mod.DustType("Sparkle");
            disableSmartCursor = true;
            adjTiles = new int[] { };
        }

        /*        public override void MouseOver(int i, int j)
                {

                    Projectile.NewProjectile(Main.player[Main.myPlayer].position.X, Main.player[Main.myPlayer].position.Y, 0, -1, 286, 0, 10f, Main.myPlayer);
                }*/

        public override void RandomUpdate(int i, int j)
        {
            Projectile.NewProjectile(Main.player[Main.myPlayer].position.X, Main.player[Main.myPlayer].position.Y, 0, -1, 286, 0, 10f, Main.myPlayer);
        }

        public override void HitWire(int i, int j)
        {
            Main.Map.Update(i, j, 0);
            for (int n = 0; n < 100; n++)
            {
                double r = Main.rand.NextFloat() * Math.PI * 2;
                Projectile.NewProjectile(new Vector2(i * 16 + (float)Math.Cos(r) * 100, j * 16 + (float)Math.Sin(r) * 100),new Vector2((float)Math.Cos(r) * 5, (float)Math.Sin(r) * 5), 645, 1000, 10f, Main.myPlayer);
            }
            /*            for (double r = 0; r < Math.PI * 2; r += Math.PI / 10)
                        {
                            Projectile.NewProjectile(i * 16 + (int)Math.Round(Math.Cos(r) * 50), j * 16 + (int)Math.Round(Math.Sin(r) * 50), (int)Math.Round(Math.Cos(r) * 5), (int)Math.Round(Math.Sin(r) * 5), 645, 1000, 10f, Main.myPlayer);
                        }
                        for (double r = 0; r < Math.PI * 2; r += Math.PI / 40)
                        {
                            Projectile.NewProjectile(i * 16 + (int)Math.Round(Math.Cos(r) * 100), j * 16 + (int)Math.Round(Math.Sin(r) * 100), (int)Math.Round(Math.Cos(r) * 5), (int)Math.Round(Math.Sin(r) * 5), 645, 1000, 10f, Main.myPlayer);
                        }
                        for (double r = 0; r < Math.PI * 2; r += Math.PI / 160)
                        {
                            Projectile.NewProjectile(i * 16 + (int)Math.Round(Math.Cos(r) * 200), j * 16 + (int)Math.Round(Math.Sin(r) * 200), (int)Math.Round(Math.Cos(r) * 5), (int)Math.Round(Math.Sin(r) * 5), 645, 1000, 10f, Main.myPlayer);
                        }*/
        }

        /*        public override void AnimateTile(ref int frame, ref int frameCounter)
                {
                               if (++Main.tileFrameCounter[TileID.Loom] >= 16)
                               {
                                   Main.tileFrameCounter[TileID.Loom] = 0;
                                   if (++Main.tileFrame[TileID.Loom] >= 4)
                                   {
                                       Main.tileFrame[TileID.Loom] = 0;
                                   }
                               }
                    if (Main.time % 10 == 0)
                    {
                        Projectile.NewProjectile(Main.player[Main.myPlayer].position.X, Main.player[Main.myPlayer].position.Y, 0, -1, 286, 0, 10f, Main.myPlayer);
                    }
                }*/

        public override void NumDust(int i, int j, bool fail, ref int num)
        {
            num = fail ? 1 : 3;
        }

        public override void KillTile(int i, int j, ref bool fail, ref bool effectOnly, ref bool noItem)
        {
            Item.NewItem(i * 16, j * 16, 8, 8, mod.ItemType("TestBlock"));
        }
    }
}