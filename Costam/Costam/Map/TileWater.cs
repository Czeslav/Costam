using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace Costam.Map
{
    class TileWater:Tile

    {
        public TileWater(Vector2 Position)
            : base(Position)
        {
            texture = SpriteBank.tileWater;
            type = TileType.Water;
        }
    }
}
