using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace Costam.GUI
{
	class MainMenu
	{
		private Viewport viewport;
		private Rectangle rectangle;



		public MainMenu(Viewport viewport)
		{
			this.viewport = viewport;
		
			int width = 400;
			int height = 500;
			int x = viewport.Width / 2 - width / 2;
			int y = viewport.Height / 2 - height / 2;
			rectangle = new Rectangle(x, y, width, height);
		}

		public void Update()
		{
		}

		public void Draw(SpriteBatch spriteBatch)
		{
			Rectangle screen = new Rectangle(0, 0, viewport.Width, viewport.Height);
			spriteBatch.Draw(SpriteBank.blankPixel, screen, Color.FromNonPremultiplied(0, 0, 0, 126));

			spriteBatch.Draw(SpriteBank.blankPixel, rectangle, Color.Gainsboro);
		}
	}
}
