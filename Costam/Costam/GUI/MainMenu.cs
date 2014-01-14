using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace Costam.GUI
{
	class MainMenu
	{
		private Viewport viewport;
		private Rectangle rectangle;
		private Button[] buttons;
		private Rectangle screen;

		private void AddButton(int ID, string text)
		{
			int height = 50;
			int width = (int)(rectangle.Width * 0.8f);
			int topSpacing = 20;
			int sideSpacing = (int)(0.1f * rectangle.Width);
			int y = ID * height + ID * topSpacing + rectangle.Y + 30;
			int x = rectangle.X + sideSpacing;

			Rectangle rec = new Rectangle(x,y,width,height);

			buttons[ID] = new Button(ID, rec, text);
		}



		public MainMenu(Viewport viewport)
		{
			this.viewport = viewport;
			buttons = new Button[5];
		
			int width = 400;
			int height = 500;
			int x = viewport.Width / 2 - width / 2;
			int y = viewport.Height / 2 - height / 2;
			rectangle = new Rectangle(x, y, width, height);
			screen = new Rectangle(0, 0, viewport.Width, viewport.Height);

			AddButton(0, "asda");
			AddButton(1, "fdsdfb");
			AddButton(2, "c");
		}

		public void Update(ref GuiState gowno)
		{
			foreach (var item in buttons)
			{
				if (item == null)
				{
					break;
				}
				item.Update();
			}

			if (buttons[0].isClicked)
			{
				gowno = GuiState.MessageBox;
				// emmmmmm
			}

		}



		public void Draw(SpriteBatch spriteBatch)
		{
			spriteBatch.Draw(SpriteBank.blankPixel, screen, Color.FromNonPremultiplied(0, 0, 0, 126));

			spriteBatch.Draw(SpriteBank.blankPixel, rectangle, Color.Gainsboro);

			foreach (var item in buttons)
			{
				if (item != null)
				{
					item.Draw(spriteBatch);
				}
			}
		}
	}
}
