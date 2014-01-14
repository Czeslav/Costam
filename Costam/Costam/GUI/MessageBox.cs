using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace Costam.GUI
{
	class MessageBox
	{
		private Rectangle rectangle;
		private Vector2 center;
		private Rectangle screen;
		private string rawText;
		private string[] lines;
		private Button exitButton;

		public bool close;

		#region constructors
		private void Construct(Viewport viewport)
		{
			screen = new Rectangle(0, 0, viewport.Width, viewport.Height);


			int width = 300;
			int height = 250;
			int x = screen.Center.X - width / 2;
			int y = screen.Center.Y - height / 2;

			rectangle = new Rectangle(x, y, width, height);
			center.X = rectangle.Center.X;
			center.Y = rectangle.Center.Y;

			width = 100;
			height = 40;
			Rectangle buttonRec = new Rectangle(rectangle.X + rectangle.Width / 2 - width / 2, rectangle.Bottom - height - 20, width, height);
			exitButton = new Button(1, buttonRec, "OK");

			CutString();
		}

		private void CutString()
		{
			if (SpriteBank.font.MeasureString(rawText).X > (rectangle.Width - 40))
			{
				lines = new string[32];
				string[] words = rawText.Split(' ');
				//string[] line = new string[32];
				List<string> line = new List<string>();
				string lineTest;
				int lineIndex = 0;
				int currentline = 0;
				

				for (int i = 0; i < words.Length; i++)
				{
					line.Add(words[i]);
					lineIndex++;

					lineTest = string.Join(" ", line);

					if (SpriteBank.font.MeasureString(lineTest).X > rectangle.Width - 75)
					{
						lines[currentline] = lineTest;
						line.Clear();
						lineTest = null;
						currentline++;
						lineIndex = 0;
					}
				}

			}
			else
			{
				lines = new string[1];
				lines[0] = rawText;
			}
		}

		public MessageBox(Viewport viewport)
		{
			Construct(viewport);
		}

		public MessageBox(Viewport viewport, string text)
		{
			rawText = text;
			Construct(viewport);
		}
		#endregion


		public void Update(ref GuiState guiState)
		{
			if (Globals.currentKeyboard.IsKeyDown(Keys.Enter))
			{
				close = true;
			}
			exitButton.Update();
			if (exitButton.isClicked)
			{
				guiState = GuiState.MainMenu;
			}
		}


		public void Draw(SpriteBatch spriteBatch)
		{
			spriteBatch.Draw(SpriteBank.blankPixel, screen, Color.FromNonPremultiplied(0, 0, 0, 126));
			spriteBatch.Draw(SpriteBank.blankPixel, rectangle, Color.Gainsboro);
			exitButton.Draw(spriteBatch);

			for (int i = 0; i < lines.Length; i++)
			{
				if (lines[i] == null)
				{
					return;
				}

				spriteBatch.DrawString(SpriteBank.font, lines[i], new Vector2(rectangle.Width / 2 + rectangle.X - SpriteBank.font.MeasureString(lines[i]).X / 2, rectangle.Top + 20 + i * SpriteBank.font.MeasureString(lines[i]).Y + i * 10), Color.Red);
			}
		}

	}
}
