using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace Costam.Map
{
    class TileGravel:Tile
    {
        public TileGravel(Vector2 Position)
            : base(Position)
        {
            texture = SpriteBank.tileGravel;
            type = TileType.Gravel;
        }
    }
}
