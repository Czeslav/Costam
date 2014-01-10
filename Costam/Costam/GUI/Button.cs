using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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


		public Button(int ID)
		{
			hovered = false;

			this.ID = ID;

			rectangle = new Rectangle();
			//TODO nie chce mi sie nawet po hamerykańsku pisać...
		}

		public void Update()
		{
			if (rectangle.Intersects(Globals.mouseRectangle))
			{
				hovered = true;
			}
			else
			{
				hovered = false;
			}
		
		}

		public void Draw(SpriteBatch spriteBatch)
		{
			if (hovered)
			{
				spriteBatch.Draw(SpriteBank.blankPixel, rectangle, Color.FromNonPremultiplied(200, 200, 200, 255));
			}
			else
			{
				spriteBatch.Draw(SpriteBank.blankPixel, rectangle, Color.FromNonPremultiplied(200, 200, 200, 200));
			}
			
		}
	}
}
