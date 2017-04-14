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
    public class Miner_Block : ModTile{
        protected double[] lastDrills = new double[1000]; // used for drill timeouts
        protected int[] spelunkerLeft = new int[1000]; // used for drill timeouts

        protected int drillTimeout = 60 * 5; // timeout between drills in frames (60 per s)
        protected int width = 1; //width of the drill area (has to be uneven)
        protected int spelunkerWidth = 5; //width of the drill area while using a spelunker potion (has to be uneven)

        protected float spelunkerEfficiency = 1;
        protected int potionStrength = 100;
        protected int stickStrength = 20;

        protected Point chestOffset = new Point(-2,1);
        protected Point drillOffset = new Point(1,4);

        public override void SetDefaults(){
            Main.tileFrameImportant[Type] = true;
            Main.tileNoAttach[Type] = true;
            Main.tileLavaDeath[Type] = false;
            TileObjectData.newTile.CopyFrom(TileObjectData.Style3x3);
            TileObjectData.newTile.CoordinateHeights = new int[] { 16, 16, 18};
            //            TileObjectData.newTile.Origin = new Point16(1, 1);
            TileObjectData.newTile.StyleHorizontal = true;
            TileObjectData.newTile.LavaDeath = false;
            TileObjectData.addTile(Type);
            AddMapEntry(new Color(200, 200, 200), "Basic Miner");
            dustType = mod.DustType("Pixel");
            this.animationFrameHeight = 56;
        }

        public override void NumDust(int i, int j, bool fail, ref int num){
            num = fail ? 1 : 3;
        }

        public override void PlaceInWorld(int i, int j, Item item) {
            if (getChestIndex(i, j) >= 0) {
                lastDrills[getChestIndex(i, j)] = 0;
                spelunkerLeft[getChestIndex(i, j)] = 0;
            }
            base.PlaceInWorld(i, j, item);
        }

        public override void KillMultiTile(int i, int j, int frameX, int frameY){
            Item.NewItem(i * 16, j * 16, 32, 32, mod.ItemType("Miner_Item"));
            if(getChestIndex(i, j) >= 0) {
                lastDrills[getChestIndex(i, j)] = 0;
                spelunkerLeft[getChestIndex(i, j)] = 0;
            }
        }

        public override void HitWire(int i, int j) {
            if (getChestIndex(i, j) >= 0 && Math.Abs(lastDrills[getChestIndex(i, j)] - Main.time) >= drillTimeout) {
                startDrill(i, j);
            }
        }

        public void startDrill(int x, int y){
            Point drillPos = getDrillPosition(x, y);
            int drillX = drillPos.X, drillY = drillPos.Y;
            int chestIndex = getChestIndex(x, y);
            if(chestIndex >= 0) {
                lastDrills[chestIndex] = Main.time;
                Chest chest = Main.chest[chestIndex];
                if(spelunkerLeft[chestIndex] < 1) { refillSpelunkerTime(chest, chestIndex); }
                bool foundTile = false;
                while (drillY < Main.Map.MaxHeight && WorldGen.TileEmpty(drillX, drillY) && !foundTile) {
                    if (spelunkerLeft[chestIndex] >= 1) {
                        int maxXoffset = spelunkerWidth / 2;
                        bool foundOre = false;
                        int oreDir = 0;
                        for (int Xoffset = 1; Xoffset <= maxXoffset; Xoffset++) {
                            if (!WorldGen.TileEmpty(drillX - Xoffset, drillY) && Main.tileSpelunker[Main.tile[drillX - Xoffset,drillY].type]) {
                                oreDir = -1;
                            }else if (!WorldGen.TileEmpty(drillX + Xoffset, drillY) && Main.tileSpelunker[Main.tile[drillX + Xoffset, drillY].type]) {
                                oreDir = 1;
                            }
                            if (oreDir != 0) {
                                foundOre = true;
                                break;
                            }
                        }
                        if (foundOre) for (int Xoffset = 1; Xoffset <= maxXoffset; Xoffset++) {
                            if (!WorldGen.TileEmpty(drillX + oreDir*Xoffset, drillY)) {
                                drillX += oreDir*Xoffset;
                                foundTile = true;
                                if (Main.tileSpelunker[Main.tile[drillX, drillY].type]) spelunkerLeft[chestIndex]--;
                                break;
                            }
                        }
                    } else {
                        int maxXoffset = width / 2;
                        for(int Xoffset = 1; Xoffset <= maxXoffset; Xoffset++) {
                            if (!WorldGen.TileEmpty(drillX - Xoffset, drillY)) {
                                drillX -= Xoffset;
                                foundTile = true;
                                break;
                            }
                            if (!WorldGen.TileEmpty(drillX + Xoffset, drillY)) {
                                drillX += Xoffset;
                                foundTile = true;
                                break;
                            }
                        }
                    }
                    if(!foundTile)drillY++;
                }
                if (drillY >= Main.Map.MaxHeight) return;
                int type = Main.tile[drillX, drillY].type;

                bool foundSpace = false;
                for (int slot = 0; slot < chest.item.Length; slot++){
                    Item item = chest.item[slot];
                    if (item.type == ItemID.None){
                        foundSpace = true;
                        break;
                    }
                }
                if (foundSpace) {
                    MineBlock(drillX, drillY, chest.item[0].pick, chest);
                    collectDrop(drillX, drillY, chest, chestIndex);
                }
            }
        }

        private void refillSpelunkerTime(Chest chest, int chestIndex) {
            for (int slot = 0; slot < chest.item.Length; slot++) {
                Item item = chest.item[slot];
                if (item.type == ItemID.SpelunkerPotion || item.type == ItemID.SpelunkerGlowstick) {
                    spelunkerLeft[chestIndex] += (int)((item.type == ItemID.SpelunkerPotion ? potionStrength : stickStrength) * spelunkerEfficiency);
                    item.stack--;
                    if(item.stack <= 0) {
                        item.SetDefaults();
                    }
                    if (Main.netMode == 2) {
                        NetMessage.SendData(32, -1, -1, "", chestIndex, (float)slot, 0f, 0f, 0, 0, 0);
                    }
                    return;
                }
            }
        }

        public void MineBlock(int x, int y, int pickPower, Chest chest) {
            HitTile hitTile = new HitTile();
            hitTile.UpdatePosition(Main.tile[x, y].type, x, y);
            int num = 0;
            int tileId = hitTile.HitObject(x, y, 1);
            Tile tile = Main.tile[x, y];
            if (Main.tileNoFail[(int)tile.type]) {
                num = 100;
            }
            if (Main.tileDungeon[(int)tile.type] || tile.type == 25 || tile.type == 58 || tile.type == 117 || tile.type == 203) {
                num += pickPower / 2;
            } else if (tile.type == 48 || tile.type == 232) {
                num += pickPower / 4;
            } else if (tile.type == 226) {
                num += pickPower / 4;
            } else if (tile.type == 107 || tile.type == 221) {
                num += pickPower / 2;
            } else if (tile.type == 108 || tile.type == 222) {
                num += pickPower / 3;
            } else if (tile.type == 111 || tile.type == 223) {
                num += pickPower / 4;
            } else if (tile.type == 211) {
                num += pickPower / 5;
            } else {
                TileLoader.MineDamage(pickPower, ref num);
            }
            if (tile.type == 211 && pickPower < 200) {
                num = 0;
            }
            if ((tile.type == 25 || tile.type == 203) && pickPower < 65) {
                num = 0;
            } else if (tile.type == 117 && pickPower < 65) {
                num = 0;
            } else if (tile.type == 37 && pickPower < 50) {
                num = 0;
            } else if (tile.type == 404 && pickPower < 65) {
                num = 0;
            } else if ((tile.type == 22 || tile.type == 204) && (double)y > Main.worldSurface && pickPower < 55) {
                num = 0;
            } else if (tile.type == 56 && pickPower < 65) {
                num = 0;
            } else if (tile.type == 58 && pickPower < 65) {
                num = 0;
            } else if ((tile.type == 226 || tile.type == 237) && pickPower < 210) {
                num = 0;
            } else if (Main.tileDungeon[(int)tile.type] && pickPower < 65) {
                if ((double)x < (double)Main.maxTilesX * 0.35 || (double)x > (double)Main.maxTilesX * 0.65) {
                    num = 0;
                }
            } else if (tile.type == 107 && pickPower < 100) {
                num = 0;
            } else if (tile.type == 108 && pickPower < 110) {
                num = 0;
            } else if (tile.type == 111 && pickPower < 150) {
                num = 0;
            } else if (tile.type == 221 && pickPower < 100) {
                num = 0;
            } else if (tile.type == 222 && pickPower < 110) {
                num = 0;
            } else if (tile.type == 223 && pickPower < 150) {
                num = 0;
            } else {
                TileLoader.PickPowerCheck(tile, pickPower, ref num);
            }
            if (tile.type == 147 || tile.type == 0 || tile.type == 40 || tile.type == 53 || tile.type == 57 || tile.type == 59 || tile.type == 123 || tile.type == 224 || tile.type == 397) {
                num += pickPower;
            }
            if (tile.type == 165 || Main.tileRope[(int)tile.type] || tile.type == 199 || Main.tileMoss[(int)tile.type]) {
                num = 100;
            }
            if (hitTile.AddDamage(tileId, num, false) >= 100 && (tile.type == 2 || tile.type == 23 || tile.type == 60 || tile.type == 70 || tile.type == 109 || tile.type == 199 || Main.tileMoss[(int)tile.type])) {
                num = 0;
            }
            if (tile.type == 128 || tile.type == 269) {
                if (tile.frameX == 18 || tile.frameX == 54) {
                    x--;
                    tile = Main.tile[x, y];
                    hitTile.UpdatePosition(tileId, x, y);
                }
                if (tile.frameX >= 100) {
                    num = 0;
                    Main.blockMouse = true;
                }
            }
            if (tile.type == 334) {
                if (tile.frameY == 0) {
                    y++;
                    tile = Main.tile[x, y];
                    hitTile.UpdatePosition(tileId, x, y);
                }
                if (tile.frameY == 36) {
                    y--;
                    tile = Main.tile[x, y];
                    hitTile.UpdatePosition(tileId, x, y);
                }
                int i = (int)tile.frameX;
                bool flag = i >= 5000;
                bool flag2 = false;
                if (!flag) {
                    int num2 = i / 18;
                    num2 %= 3;
                    x -= num2;
                    tile = Main.tile[x, y];
                    if (tile.frameX >= 5000) {
                        flag = true;
                    }
                }
                if (flag) {
                    i = (int)tile.frameX;
                    int num3 = 0;
                    while (i >= 5000) {
                        i -= 5000;
                        num3++;
                    }
                    if (num3 != 0) {
                        flag2 = true;
                    }
                }
                if (flag2) {
                    num = 0;
                    Main.blockMouse = true;
                }
            }
            if (!WorldGen.CanKillTile(x, y)) {
                num = 0;
            }
            if (hitTile.AddDamage(tileId, num, true) >= 100) {
                hitTile.Clear(tileId);
                if (Main.netMode == 2 && Main.tileContainer[(int)Main.tile[x, y].type]) {
                    WorldGen.KillTile(x, y, true, false, false);
                    NetMessage.SendData(17, -1, -1, "", 0, (float)x, (float)y, 1f, 0, 0, 0);
                    if (TileLoader.IsChest((int)Main.tile[x, y].type)) {
                        NetMessage.SendData(34, -1, -1, "", 1, (float)x, (float)y, 0f, 0, 0, 0);
                    }
                    if (TileLoader.IsDresser((int)Main.tile[x, y].type)) {
                        NetMessage.SendData(34, -1, -1, "", 3, (float)x, (float)y, 0f, 0, 0, 0);
                    }
                } else {
                    int num4 = y;
                    bool flag3 = Main.tile[x, num4].active();
                    WorldGen.KillTile(x, num4, false, false, false);
                    if (Main.netMode == 2) {
                        NetMessage.SendData(17, -1, -1, "", 0, (float)x, (float)num4, 0f, 0, 0, 0);
                    }
                }
            } else {
                WorldGen.KillTile(x, y, true, false, false);
                if (Main.netMode == 2) {
                    NetMessage.SendData(17, -1, -1, "", 0, (float)x, (float)y, 1f, 0, 0, 0);
                }
            }
            if (num != 0) {
                hitTile.Prune();
            }
        }

        private void collectDrop(int x, int y, Chest chest, int chestIndex) {
            int nearestItem = -1;
            float shortestDist = 10;
            for (int i = 0; i < Main.item.Length; i++) {
                Vector2 dist = new Vector2(x, y);
                dist.X -= Main.item[i].position.X / 16;
                dist.Y -= Main.item[i].position.Y / 16;
                if (dist.Length() <= 2 && dist.Length() < shortestDist && Main.item[i].active) {
                    shortestDist = dist.Length();
                    nearestItem = i;
                }
            }
            if (nearestItem < 0) return;
            for (int slot = 0; slot < chest.item.Length; slot++) {
                if (chest.item[slot].type == ItemID.None) {
                    chest.item[slot].SetDefaults(Main.item[nearestItem].type);
                    chest.item[slot].stack = 1;
                    Main.item[nearestItem].SetDefaults();
                    if(Main.netMode == 2) {
                        NetMessage.SendData(32, -1, -1, "", chestIndex, (float)slot, 0f, 0f, 0, 0, 0);
                    }
                    break;
                } else {
                    if (chest.item[slot].type == Main.item[nearestItem].type) {
                        chest.item[slot].stack++;
                        Main.item[nearestItem].SetDefaults();
                        if (Main.netMode == 2) {
                            NetMessage.SendData(32, -1, -1, "", chestIndex, (float)slot, 0f, 0f, 0, 0, 0);
                        }
                        break;
                    }
                }
            }
        }

        public override void AnimateTile(ref int frame, ref int frameCounter) {
            if (++frameCounter >= 6) {
                frameCounter = 0;
                if (++frame >= 4) {
                    frame = 0;
                }
            }
        }

        public override void DrawEffects(int i, int j, SpriteBatch spriteBatch, ref Color drawColor, ref int nextSpecialDrawIndex) {
            Tile tile = Main.tile[i, j];
            //create dust particles, but only once (for the first upper left tile)
            if (tile.frameX == 0 && (tile.frameY % this.animationFrameHeight) == 0) {
                Dust.NewDust(new Vector2(i * 16 + 23, j * 16 + 50), 1, 1, 0);
            }
        }

        public int getChestIndex(int x, int y) {
            Tile tile = Main.tile[x, y];
            int chestX = x - (int)(tile.frameX / 18);
            int chestY = y - (int)((tile.frameY % this.animationFrameHeight) / 18);
            return Chest.FindChest(chestX+chestOffset.X, chestY+chestOffset.Y);
        }

        public Point getDrillPosition(int x, int y) {
            Tile tile = Main.tile[x, y];
            int drillX = x - (int)(tile.frameX / 18);
            int drillY = y - (int)((tile.frameY % this.animationFrameHeight) / 18);
            return new Point(drillX + drillOffset.X, drillY + drillOffset.Y);
        }
    }
}
