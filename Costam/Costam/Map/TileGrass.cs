using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Costam.Map
{
    class TileGrass:Tile
    {

        public TileGrass(Vector2 Position)
            : base(Position)
        {
            type = TileType.Grass;
        }

		public override void Draw(SpriteBatch spriteBatch)
		{
			spriteBatch.Draw(SpriteBank.tileGrass, rectangle, Color.White);
		}
    }
}
