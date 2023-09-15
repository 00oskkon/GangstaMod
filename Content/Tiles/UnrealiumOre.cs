using Microsoft.Xna.Framework;
using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.IO;
using Terraria.ModLoader;
using Terraria.WorldBuilding;

namespace GangstaMod.Content.Tiles
{
	public class UnrealiumOre : ModTile
	{
		public override void SetStaticDefaults()
		{
			TileID.Sets.Ore[Type] = true;
			Main.tileSpelunker[Type] = true; // The tile will be affected by spelunker highlighting
			Main.tileOreFinderPriority[Type] = 410; // Metal Detector value, see https://terraria.gamepedia.com/Metal_Detector
			Main.tileShine2[Type] = true; // Modifies the draw color slightly.
			Main.tileShine[Type] = 975; // How often tiny dust appear off this tile. Larger is less frequently
			Main.tileMergeDirt[Type] = false;
			Main.tileSolid[Type] = true;
			Main.tileBlockLight[Type] = true;

			ModTranslation name = CreateMapEntryName();
			name.SetDefault("Unrealium");
			AddMapEntry(new Color(182, 28, 232), name);

			DustType = DustID.Tungsten;
			ItemDrop = ModContent.ItemType<Items.Placeable.UnrealiumOre>();
			HitSound = SoundID.Tink;
			MineResist = 4f;
			MinPick = 65;
		}
	}

	public class UnrealiumOreSystem : ModSystem
	{
		public override void ModifyWorldGenTasks(List<GenPass> tasks, ref float totalWeight)
		{
			// Find out which step "Underworld" is.
			int UnderworldIndex = tasks.FindIndex(genpass => genpass.Name.Equals("Underworld"));

			if (UnderworldIndex != -1) {
				// Next, we insert our pass directly after the original "Underworld" pass.
				// UnrealiumOrePass is a class seen below
				tasks.Insert(UnderworldIndex + 1, new UnrealiumOrePass("Unreal Mod Ores", 237.4298f));
			}
		}
	}

	public class UnrealiumOrePass : GenPass
	{
		public UnrealiumOrePass(string name, float loadWeight) : base(name, loadWeight)
		{
		}

		protected override void ApplyPass(GenerationProgress progress, GameConfiguration configuration) {
			// progress.Message is the message shown to the user while the following code is running.
			progress.Message = "Unreal Mod Ores";

			// Use WorldGen.TileRunner to place splotches of the specified Tile in the world.
			for (int k = 0; k < (int)((Main.maxTilesX * Main.maxTilesY) * 6E-05); k++)
			{
				// One single splotch of our Ore.
				// Choosing a random x and y value.
				int x = WorldGen.genRand.Next(0, Main.maxTilesX);

				// WorldGen.worldSurfaceLow is the highest surface tile.
				// Might want to use WorldGen.rockLayer or other WorldGen values.
				int y = WorldGen.genRand.Next(Main.maxTilesY - 200, Main.maxTilesY);

 				Tile tile = Framing.GetTileSafely(x, y);
 				if (tile.HasTile && tile.TileType == 57)
 				{
					// Call WorldGen.TileRunner with random "strength" and random "steps", as well as the Tile to place
					WorldGen.TileRunner(x, y, WorldGen.genRand.Next(3, 6), WorldGen.genRand.Next(20, 60), ModContent.TileType<UnrealiumOre>());
				}
			}
		}
	}
}
