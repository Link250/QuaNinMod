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
	public class AlloySmelter : ModTile
	{
		public override void SetDefaults()
		{
			Main.tileSolidTop[Type] = true;
			Main.tileFrameImportant[Type] = true;
			Main.tileNoAttach[Type] = true;
			Main.tileTable[Type] = true;
			Main.tileLavaDeath[Type] = true;
			TileObjectData.newTile.CopyFrom(TileObjectData.Style2x2);
			TileObjectData.newTile.CoordinateHeights = new int[]{ 16 , 16 };
			TileObjectData.addTile(Type);
			AddToArray(ref TileID.Sets.RoomNeeds.CountsAsTable);
			AddMapEntry(new Color(200, 200, 200), "AlloySmelter");
			dustType = mod.DustType("Sparkle");
			disableSmartCursor = true;
			adjTiles = new int[]{ TileID.WorkBenches };
		}

/*		public override void AnimateTile()
		{
			if (++Main.tileFrameCounter[TileID.Loom] >= 16)
			{
				Main.tileFrameCounter[TileID.Loom] = 0;
				if (++Main.tileFrame[TileID.Loom] >= 4)
				{
					Main.tileFrame[TileID.Loom] = 0;
				}
			}
		}*/
		
		public override void NumDust(int i, int j, bool fail, ref int num)
		{
			num = fail ? 1 : 3;
		}

		public override void KillMultiTile(int i, int j, int frameX, int frameY)
		{
			Item.NewItem(i * 16, j * 16, 32, 16, mod.ItemType("AlloySmelter"));
		}
	}
}