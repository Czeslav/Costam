using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Costam.Map
{
    
    class Tile
        /*
         * One tile is one square on map. Map is 2d array of tiles
         */

    {
        #region variables
        protected const int size = 50;
        protected Vector2 position; //position means X and Y position on two dimentions array of tiles
        protected Vector2 positionPX; //position in pixels (position(2,2) means x=2*size y=2*size)
        protected Rectangle rectangle;
        protected TileType type;

        #endregion

        #region constructors
        public Tile(Vector2 PositionInTab)
        {
            position = PositionInTab;
            positionPX.X = position.X * size;
            positionPX.Y = position.Y * size;

            rectangle = new Rectangle((int)positionPX.X, (int)positionPX.Y, size, size);
        }
        #endregion


        #region get functions
        public Vector2 GetPositionInTab()
        {
            return position;
        }
        public Vector2 GetPositionInPixels()
        {
            return positionPX;
        }
        public Rectangle GetRectangle()
        {
            return rectangle;
        }
        public TileType GetTileType()
        {
            return type;
        }

        
        #endregion

        
        public void Update()
        {
            
        }


        virtual public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(SpriteBank.blankPixel, rectangle, Color.White);
        }
    }
}
