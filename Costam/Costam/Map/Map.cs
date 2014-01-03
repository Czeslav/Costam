using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

public enum TileType { Grass, Rock, Gravel, Water };


namespace Costam.Map
{
    class Map
    {
        private Random rand = new Random();
        private Tile[,] TilesArray; //array of tiles, whole map
        private int mapSize = 126; //determines map size (width and height)

        private Vector2[] ponds;
        private int currentPondIndex = 0;
        private int maxponds = 32;
        private int pondSICN = 100;
        //SICN - Shit I Cant Name - sets probability of creating pond




        #region map generator

        private void CreateTile(TileType type, Vector2 position)
        {
			//sets tile with given position to given type

			Tile til;
            switch (type)
            {
                case TileType.Grass:
                    til = new TileGrass(position);
					break;
                case TileType.Rock:
                    til = new TileRock(position);
					break;
                case TileType.Gravel:
                    til = new TileGravel(position);
					break;
                case TileType.Water:
                    til = new TileWater(position);
					break;
                default:
                    til = new TileGrass(position);
					break;
			}

			int X = (int)position.X;
			int Y = (int)position.Y;

			TilesArray[X, Y] = til;
        }
        //works

        private void FillRectangle(Vector2 size, Vector2 position, TileType type)
        {
            //fills rectangle with given size and on given position with given type 
            for (int i = (int)position.Y; i < size.Y + position.Y; i++)
            {
                //rows
                for (int j = (int)position.X; j < size.X + position.X; j++)
                {
                    CreateTile(type, new Vector2(i, j));
                }
            }
        }
        // HOLY SHIET IT WORKS AT FIRST TRY!!!

		private bool IsObjectClose(Vector2 objectPosition, Vector2[] hisFamily, int maxDistance)
		{
			//checks if $objectPosition is closer than $maxDistance form any item in $hisFamily array
			foreach (var item in hisFamily)
			{
				double distance = Math.Sqrt(Math.Pow(objectPosition.X - item.X, 2) + Math.Pow(objectPosition.Y - item.Y, 2));
				//counts distance between $objectPosition and every single item in $hisFamily array

				if (distance < maxDistance)
				{
					return true;
				}
			}

			return false;
		}
		// Crazy math up here, dont touch (and pray for it working fine) 


		//STILL IN DEVELOPMENT
        private void SetObjects()
        {
			//set objects on whole map 
			//objects are ponds, rocks, etc
            foreach (var item in TilesArray)
            {
                if (item.GetTileType() == TileType.Grass)
                {
					//checks if this tile is grass, if it's so, lets start lottery


                    //create ponds
                    if (currentPondIndex < maxponds)
                    {
						// if we already have less tan $maxponds ponds
                        int result = rand.Next(1, pondSICN);
                        if (result == 1
							&& !IsObjectClose(item.GetPositionInTab(),ponds,5))
                        {
							//if random number between 1 and $pondSCIN == 1, create pond
                            ponds[currentPondIndex] = item.GetPositionInTab(); //adds choosen tile to tab of choosen tiles
                            currentPondIndex++; //increment pond index

                            Debug.WriteLine("Pond ID: " + currentPondIndex + " location: " + item.GetPositionInTab());

							CreateTile(TileType.Water, item.GetPositionInTab());
							//make choosen tile water tile
						}
                    }
                }

                else //if current tle type is NOT grass
                {
                    continue;
                }
            }
        }
		//STILL IN DEVELOPMENT





        private void GenerateMap(int size)
        {
            //fills whole map with grass
            for (int i = 0; i < size; i++)
            {
                //rows
                for (int j = 0; j < size; j++)
                {
                    //cols
                    TilesArray[i, j] = new TileGrass(new Vector2(i, j));
                }
            }

            SetObjects();
        }

        #endregion

        #region else, unimportant shit
        public Map()
        {
            TilesArray = new Tile[mapSize, mapSize];
            ponds = new Vector2[maxponds+1];

            GenerateMap(mapSize);
        }


        public void Draw(SpriteBatch spriteBatch)
        {
            foreach (var item in TilesArray)
            {
                item.Draw(spriteBatch);
            }
        }
        #endregion
    }
}
