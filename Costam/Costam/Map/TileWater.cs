using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Costam.Map
{
    class TileWater:Tile

    {
        public TileWater(Vector2 Position)
            : base(Position)
        {
            type = TileType.Water;
        }

		public override void Draw(SpriteBatch spriteBatch)
		{
			spriteBatch.Draw(SpriteBank.tileWater, rectangle, Color.White);
		}
    }
}
