using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Graphics;

namespace Costam.GUI
{
	class Button
	{
		private Rectangle rectangle;
		private int ID;

		private bool hovered;
		public bool isClicked;

		private string text;

		public Button(int ID, Rectangle rectangle, string text)
		{
			hovered = false;
			isClicked = false;

			this.ID = ID;
			this.rectangle = rectangle;
			this.text = text;
		}

		public void Update()
		{
			if (rectangle.Intersects(Globals.mouseRectangle))
			{
				hovered = true;
				if (Globals.mouse.LeftButton == ButtonState.Pressed
					&& Globals.prevMouse.LeftButton == ButtonState.Released)
				{
					isClicked = true;
				}
				else
				{
					isClicked = false;
				}
			}
			else
			{
				hovered = false;
				isClicked = false;
			}
		
		}

		public void Draw(SpriteBatch spriteBatch)
		{
			if (isClicked)
			{
				spriteBatch.Draw(SpriteBank.blankPixel, rectangle, Color.FromNonPremultiplied(80, 80, 80, 255));
			}
			else if (hovered)
			{
				spriteBatch.Draw(SpriteBank.blankPixel, rectangle, Color.FromNonPremultiplied(180, 180, 180, 255));
			}
			else
			{
				spriteBatch.Draw(SpriteBank.blankPixel, rectangle, Color.FromNonPremultiplied(200, 200, 200, 200));
			}

			Vector2 stringSize= SpriteBank.font.MeasureString(text);
			spriteBatch.DrawString(SpriteBank.font, text, new Vector2(rectangle.X + (rectangle.Width - stringSize.X)/2, rectangle.Y + (rectangle.Height - stringSize.Y)/2 ),Color.Red);
		}
	}
}
