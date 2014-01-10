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
        private int mapSize = 128; //determines map size (width and height)

        private Vector2[] ponds;
        private int currentPondIndex = 0;
        private int maxponds = 64;
        private int pondSICN = 500;
        //SICN - Shit I Cant Name - sets probability of creating pond

		private Vector2[] rocks;
		private int currentRockIndex = 0;
		private int maxrocks = 64;
		private int rockSICN = 500;




        #region map generator

        private void CreateTile(TileType type, Vector2 position)
        {
			//sets tile with given position to given type

			if (position.X > mapSize
				|| position.Y > mapSize)
			{
				return;
			}

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


		private void GenerateArea(Vector2 centralPosition, TileType type)
		{
			if (centralPosition.X == 0 ||
				centralPosition.Y == 0)
			{
				return;
			}
			int size = rand.Next(2, 3);
			/*1- very small (2 tiles wide)
			 *2- small (3 tiles wide)
			 *3- medium (4 tiles wide)
			 *4- large (5 tiles wide
			 */

			double direction = rand.NextDouble();
			Vector2 pos = centralPosition;

			#region very small
			if (size == 1)
			{
				if (direction>=0.5)
				{
					pos.X += 1;
				}
				else
				{
					pos.X -= 1;
				}
				CreateTile(type, pos);

				direction = rand.NextDouble();
				if (direction >= 0.5)
				{
					pos.Y += 1;
				}
				else
				{
					pos.Y -= 1;
				}
				CreateTile(type, pos);
			}
			#endregion
			//works

			#region small
			if (size == 2)
			{
				double dir2 = rand.NextDouble();

				if (direction >= 0.5)
				{
					// add 2 tiles horizontaly
					pos.X += 1;
					CreateTile(type, pos);
					pos.X -= 2;
					CreateTile(type, pos);

					if (dir2 < 0.5)
					{
						pos.Y += 1;
					}
					else
					{
						pos.Y -= 1;
					}

					dir2 = rand.NextDouble();
					pos.X = centralPosition.X;

					if (dir2 < 0.33)
					{
						pos.X -= 1;
					}
					else if (dir2 > 0.66)
					{
						pos.X += 1;
					}
					else
					{

					}

					CreateTile(type, pos);

				}
				else
				{
					//or verticaly
					pos.Y += 1;
					CreateTile(type, pos);
					pos.Y -= 2;
					CreateTile(type, pos);

					if (dir2 < 0.5)
					{
						pos.X += 1;
					}
					else
					{
						pos.X -= 1;
					}

					dir2 = rand.NextDouble();
					pos.Y = centralPosition.Y;

					if (dir2 < 0.33)
					{
						pos.Y -= 1;
					}
					else if (dir2 > 0.66)
					{
						pos.Y += 1;
					}
				}
			}
			#endregion
			//works

		}


		//STILL IN DEVELOPMENT
        private void SetObjects()
        {
			//set objects on whole map 
			//objects are ponds, rocks, etc
            foreach (var item in TilesArray)
            {
				//checks every tile
                if (item.GetTileType() == TileType.Grass)
                {
					//checks if this tile is grass, if it's so, lets start lottery


					//create ponds
					#region ponds
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
					#endregion


					//create rocks
					#region rocks
					if (currentRockIndex < maxrocks)
					{
						// if we already have less tan $maxrocks rocks
						int result = rand.Next(1, rockSICN);
						if (result == 1
							&& !IsObjectClose(item.GetPositionInTab(), rocks, 5))
						{
							//if random number between 1 and $rockSCIN == 1, create pond
							rocks[currentRockIndex] = item.GetPositionInTab(); //adds choosen tile to tab of choosen tiles
							currentRockIndex++; //increment rock index

							Debug.WriteLine("Rock ID: " + currentRockIndex + " location: " + item.GetPositionInTab());

							CreateTile(TileType.Rock, item.GetPositionInTab());
							//make choosen tile rock tile
						}
					}
					#endregion
				}

                else //if current tle type is NOT grass
                {
                    continue;
                }
            }

			foreach (var item in ponds)
			{
				GenerateArea(item, TileType.Water);
			}
			foreach (var item in rocks)
			{
				GenerateArea(item, TileType.Rock);
			}
        }
		//STILL IN DEVELOPMENT





        private void GenerateMap(int size)
        {
            //fills whole map with grass
            for (int i = 0; i < size + 1; i++)
            {
                //rows
                for (int j = 0; j < size + 1; j++)
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
            TilesArray = new Tile[mapSize + 1, mapSize + 1];
            ponds = new Vector2[maxponds + 1];
			rocks = new Vector2[maxrocks + 1];

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
