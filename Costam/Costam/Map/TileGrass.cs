using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace Costam.Map
{
    class TileGrass:Tile
    {

        public TileGrass(Vector2 Position)
            : base(Position)
        {
            texture = SpriteBank.tileGrass;
            type = TileType.Grass;
        }

        
    }
}
