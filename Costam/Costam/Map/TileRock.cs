using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace Costam.Map
{
    class TileRock:Tile
    {
        public TileRock(Vector2 Position)
            : base(Position)
        {
            texture = SpriteBank.tileRock;
            type = TileType.Rock;
        }
    }
}
