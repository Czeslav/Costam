using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Costam.Map
{
    class TileGravel:Tile
    {
        public TileGravel(Vector2 Position)
            : base(Position)
        {
            type = TileType.Gravel;
        }

		public override void Draw(SpriteBatch spriteBatch)
		{
			spriteBatch.Draw(SpriteBank.tileGravel, rectangle, Color.White);
		}
    }
}
