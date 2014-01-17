using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Costam.Map
{
    class TileRock:Tile
    {
        public TileRock(Vector2 Position)
            : base(Position)
        {
            type = TileType.Rock;
        }

		public override void Draw(SpriteBatch spriteBatch)
		{
			spriteBatch.Draw(SpriteBank.tileRock, rectangle, Color.White);
		}
    }
}
