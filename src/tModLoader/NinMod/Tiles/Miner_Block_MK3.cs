using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.DataStructures;
using Terraria.Enums;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ObjectData;

namespace NinMod.Tiles{
    public class Miner_Block_MK3 : Miner_Block{
        public override void SetDefaults(){
            base.drillTimeout = 60 * 1;
            base.width = 11;
            base.spelunkerWidth = 21;
            base.spelunkerEfficiency = 2;
            base.chestOffset = new Point(-2, 2);
            base.drillOffset = new Point(2, 5);

            base.drillSound = SoundID.Item15;

            Main.tileFrameImportant[Type] = true;
            Main.tileNoAttach[Type] = true;
            Main.tileLavaDeath[Type] = false;
            TileObjectData.newTile.Width = 5;
            TileObjectData.newTile.Height = 4;
            TileObjectData.newTile.Origin = new Point16(2, 3);
            TileObjectData.newTile.AnchorBottom = new AnchorData(AnchorType.SolidTile | AnchorType.SolidWithTop | AnchorType.Table | AnchorType.SolidSide, TileObjectData.newTile.Width, 0);
            TileObjectData.newTile.UsesCustomCanPlace = true;
            TileObjectData.newTile.CoordinateHeights = new int[] { 16, 16, 16, 18 };
            TileObjectData.newTile.CoordinateWidth = 16;
            TileObjectData.newTile.CoordinatePadding = 2;
            TileObjectData.newTile.StyleHorizontal = true;
            TileObjectData.newTile.LavaDeath = false;
            TileObjectData.addTile(Type);
            AddMapEntry(new Color(200, 200, 200), "Advanced Miner");
            dustType = mod.DustType("Pixel");
            this.animationFrameHeight = 74;
        }

        public override void KillMultiTile(int i, int j, int frameX, int frameY) {
            Item.NewItem(i * 16, j * 16, 32, 32, mod.ItemType("Miner_Item_MK3"));
            if (getChestIndex(i, j) >= 0) {
                base.lastDrills[getChestIndex(i, j)] = 0;
                base.spelunkerLeft[getChestIndex(i, j)] = 0;
            }
        }

        public override void AnimateTile(ref int frame, ref int frameCounter) {
            if (++frameCounter >= 4) {
                frameCounter = 0;
                if (++frame >= 6) {
                    frame = 0;
                }
            }
        }

        public override void DrawEffects(int i, int j, SpriteBatch spriteBatch, ref Color drawColor, ref int nextSpecialDrawIndex) {
            Tile tile = Main.tile[i, j];
            //create dust particles, but only once (for the first upper left tile)
            if (tile.frameX == 0 && (tile.frameY % this.animationFrameHeight) == 0) {
                Dust.NewDust(new Vector2(i * 16 + 5 * 16 / 2-4, j * 16 + 4 * 16), 1, 1, 131);
                Dust.NewDust(new Vector2(i * 16 + 5 * 16 / 2-4, j * 16 + 4 * 16), 1, 1, 220);
            }
        }
    }
}
