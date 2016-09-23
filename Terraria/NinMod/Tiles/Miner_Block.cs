using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.Enums;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ObjectData;

namespace NinMod.Tiles{
    public class Miner_Block : ModTile{
        HitTile hitTile = new HitTile();
        public override void SetDefaults(){
            Main.tileSpelunker[Type] = true;
            Main.tileContainer[Type] = true;
            Main.tileShine2[Type] = true;
            Main.tileShine[Type] = 1200;
            Main.tileFrameImportant[Type] = true;
            Main.tileNoAttach[Type] = true;
            Main.tileValue[Type] = 500;
            TileObjectData.newTile.CopyFrom(TileObjectData.Style2x2);
            TileObjectData.newTile.Origin = new Point16(0, 1);
            TileObjectData.newTile.CoordinateHeights = new int[] { 16, 18 };
            TileObjectData.newTile.HookCheck = new PlacementHook(new Func<int, int, int, int, int, int>(Chest.FindEmptyChest), -1, 0, true);
            TileObjectData.newTile.HookPostPlaceMyPlayer = new PlacementHook(new Func<int, int, int, int, int, int>(Chest.AfterPlacement_Hook), -1, 0, false);
            TileObjectData.newTile.AnchorInvalidTiles = new int[] { 127 };
            TileObjectData.newTile.StyleHorizontal = true;
            TileObjectData.newTile.LavaDeath = false;
            TileObjectData.newTile.AnchorBottom = new AnchorData(AnchorType.SolidTile | AnchorType.SolidWithTop | AnchorType.SolidSide, TileObjectData.newTile.Width, 0);
            TileObjectData.addTile(Type);
            AddMapEntry(new Color(200, 200, 200), "Basic Miner", MapChestName);
            //	dustType = mod.DustType("DustName");
            disableSmartCursor = true;
            adjTiles = new int[] { TileID.Containers };
            chest = "Basic Miner";
        }

        public string MapChestName(string name, int i, int j){
            int left = i;
            int top = j;
            Tile tile = Main.tile[i, j];
            if (tile.frameX % 36 != 0){
                left--;
            }
            if (tile.frameY != 0){
                top--;
            }
            int chest = Chest.FindChest(left, top);
            if (Main.chest[chest].name == ""){
                return name;
            } else{
                return name + ": " + Main.chest[chest].name;
            }
        }

        public override void NumDust(int i, int j, bool fail, ref int num){
            num = 1;
        }

        public override bool CanKillTile(int i, int j, ref bool blockDamaged){
            Tile tile = Main.tile[i, j];
            int left = i;
            int top = j;
            if (tile.frameX % 36 != 0){
                left--;
            }
            if (tile.frameY != 0){
                top--;
            }
            return Chest.CanDestroyChest(left, top);
        }

        public override void KillMultiTile(int i, int j, int frameX, int frameY){
            Item.NewItem(i * 16, j * 16, 32, 32, mod.ItemType("Miner_Item"));
            Chest.DestroyChest(i, j);
        }

        public override void RightClick(int i, int j){
            Player player = Main.player[Main.myPlayer];
            Tile tile = Main.tile[i, j];
            Main.mouseRightRelease = false;
            int left = i;
            int top = j;
            if (tile.frameX % 36 != 0){
                left--;
            }
            if (tile.frameY != 0){
                top--;
            }
            if (player.sign >= 0){
                Main.PlaySound(11, -1, -1, 1);
                player.sign = -1;
                Main.editSign = false;
                Main.npcChatText = "";
            }
            if (Main.editChest){
                Main.PlaySound(12, -1, -1, 1);
                Main.editChest = false;
                Main.npcChatText = "";
            }
            if (player.editedChestName){
                NetMessage.SendData(33, -1, -1, Main.chest[player.chest].name, player.chest, 1f, 0f, 0f, 0, 0, 0);
                player.editedChestName = false;
            }
            if (Main.netMode == 1){
                if (left == player.chestX && top == player.chestY && player.chest >= 0){
                    player.chest = -1;
                    Recipe.FindRecipes();
                    Main.PlaySound(11, -1, -1, 1);
                }else{
                    NetMessage.SendData(31, -1, -1, "", left, (float)top, 0f, 0f, 0, 0, 0);
                    Main.stackSplit = 600;
                }
            }
            else{
                int chest = Chest.FindChest(left, top);
                if(chest >= 0){
                    Main.stackSplit = 600;
                    if(chest == player.chest){
                        player.chest = -1;
                        Main.PlaySound(11, -1, -1, 1);
                    }else{
                        player.chest = chest;
                        Main.playerInventory = true;
                        Main.recBigList = false;
                        player.chestX = left;
                        player.chestY = top;
                        Main.PlaySound(player.chest < 0 ? 10 : 12, -1, -1, 1);
                    }
                    Recipe.FindRecipes();
                }
            }
        }

        public override void MouseOver(int i, int j){
            Player player = Main.player[Main.myPlayer];
            Tile tile = Main.tile[i, j];
            int left = i;
            int top = j;
            if (tile.frameX % 36 != 0){
                left--;
            }
            if (tile.frameY != 0){
                top--;
            }
            int chest = Chest.FindChest(left, top);
            player.showItemIcon2 = -1;
            if (chest < 0){
                player.showItemIconText = Lang.chestType[0];
            }
            else{
                player.showItemIconText = Main.chest[chest].name.Length > 0 ? Main.chest[chest].name : "Red Chest";
                if (player.showItemIconText == "Red Chest"){
                    player.showItemIcon2 = mod.ItemType("Miner_Item");
                    player.showItemIconText = "";
                }
            }
            player.noThrow = 2;
            player.showItemIcon = true;
        }

        public override void MouseOverFar(int i, int j){
            MouseOver(i, j);
            Player player = Main.player[Main.myPlayer];
            if (player.showItemIconText == ""){
                player.showItemIcon = false;
                player.showItemIcon2 = 0;
            }
        }

        public override void HitWire(int i, int j){
            int x = i, y = j;
            int chestIndex = Chest.FindChest(x, y);
            if(chestIndex >= 0){
                Chest chest = Main.chest[chestIndex];
/*                for (int slot = 0; slot < 50; slot++){
                    if(chest.item[slot].type == ItemID.None){
                        chest.item[slot].SetDefaults(ItemID.DirtBlock);
                        chest.item[slot].stack = 1;
                        break;
                    }else{
                        if(chest.item[slot].type == ItemID.DirtBlock){
                            chest.item[slot].stack ++;
                            break;
                        }
                    }
                }*/
                int yOff = 3;
                while (WorldGen.TileEmpty(x, y +yOff)) yOff++;
                MineBlock(x, y + yOff, chest.item[0].pick);
                foreach (Item item in Main.item) {
                    Vector2 dist = new Vector2(x,y + yOff);
                    dist.X -= item.position.X / 16;
                    dist.Y -= item.position.Y / 16;
                    if (dist.Length() <= 2) {
                        Item.NewItem(x*16,y*16, 0, 0, item.type);
                        item.SetDefaults();
                    }
                }
            }
        }

        public void MineBlock(int x, int y, int pickPower) {
            this.hitTile.UpdatePosition(Main.tile[x, y].type, x, y);
            int num = 0;
            int tileId = this.hitTile.HitObject(x, y, 1);
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
            if (this.hitTile.AddDamage(tileId, num, false) >= 100 && (tile.type == 2 || tile.type == 23 || tile.type == 60 || tile.type == 70 || tile.type == 109 || tile.type == 199 || Main.tileMoss[(int)tile.type])) {
                num = 0;
            }
            if (tile.type == 128 || tile.type == 269) {
                if (tile.frameX == 18 || tile.frameX == 54) {
                    x--;
                    tile = Main.tile[x, y];
                    this.hitTile.UpdatePosition(tileId, x, y);
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
                    this.hitTile.UpdatePosition(tileId, x, y);
                }
                if (tile.frameY == 36) {
                    y--;
                    tile = Main.tile[x, y];
                    this.hitTile.UpdatePosition(tileId, x, y);
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
            if (this.hitTile.AddDamage(tileId, num, true) >= 100) {
                this.hitTile.Clear(tileId);
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
                this.hitTile.Prune();
            }
        }
    }
}
