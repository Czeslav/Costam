using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Costam.GUI
{
	class ContextMenu
	{
		private Rectangle rectangle;
		private Rectangle[] fields;
		private string[] fieldsTexts;
		private int hoveredButtonID;
		private int clickedButtonID;

		private int fieldHeight = 30;

		public ContextMenu(Vector2 position, string[] fieldsTexts)
		{
			this.fieldsTexts = fieldsTexts;
			fields = new Rectangle[fieldsTexts.Length];

			rectangle = new Rectangle((int)position.X, (int)position.Y, 130, fieldsTexts.Length * (fieldHeight + 1) + 1);

			for (int i = 0; i < fields.Length; i++)
			{
				Vector2 fieldPos = new Vector2(rectangle.X + 1, rectangle.Y + 1 + i * (fieldHeight + 1));

				fields[i] = new Rectangle((int)fieldPos.X, (int)fieldPos.Y, rectangle.Width - 2, fieldHeight);
			}
		}

		public void Update()
		{
			if (Globals.mouseRectangle.Intersects(rectangle))
			{
				int currentFieldID = 0;
				foreach (var item in fields)
				{
					if (item.Intersects(Globals.mouseRectangle))
					{
						hoveredButtonID = currentFieldID;
					}
					currentFieldID++;
				}


				if (Globals.mouse.LeftButton == ButtonState.Pressed
					&& Globals.prevMouse.LeftButton == ButtonState.Pressed)
				{
					clickedButtonID = hoveredButtonID;
				}
				else
				{
					clickedButtonID = -1;
				}

			}
			else
			{
				hoveredButtonID = -1;
			}


		}

		public void Draw(SpriteBatch spriteBatch)
		{
			spriteBatch.Draw(SpriteBank.blankPixel, rectangle, Color.SandyBrown);
			int currentCheckedField = 0;
			foreach (var item in fields)
			{
				if (currentCheckedField == hoveredButtonID)
				{
					spriteBatch.Draw(SpriteBank.blankPixel, item, Color.SaddleBrown);
				}
				else
				{
					spriteBatch.Draw(SpriteBank.blankPixel, item, Color.RosyBrown);
				}

				Vector2 textpos = new Vector2(item.X + 2, item.Y + 5);
				spriteBatch.DrawString(SpriteBank.font, fieldsTexts[currentCheckedField], textpos, Color.Black);

				currentCheckedField++;
			}
		}
	}
}
