using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;

namespace Costam
{
    static class SpriteBank
    {
        public static Texture2D tileGrass;
        public static Texture2D tileWater;
        public static Texture2D tileGravel;
        public static Texture2D tileRock;

		public static Texture2D blankPixel;

        public static void LoadTextures(ContentManager Content)
        {
            tileGrass = Content.Load<Texture2D>("Tiles/GrassTile");
            tileGravel = Content.Load<Texture2D>("Tiles/GrassTile");
            tileRock = Content.Load<Texture2D>("Tiles/RockTile");
            tileWater = Content.Load<Texture2D>("Tiles/WaterTile");

			blankPixel = Content.Load<Texture2D>("blankPixel");
        }
    }
}
