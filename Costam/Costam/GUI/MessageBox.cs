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
		public bool fromMenu;


		#region constructors
		private void CutString()
		{
			//cuts $rawString into $lines array, depends on their lenght
			if (SpriteBank.font.MeasureString(rawText).X > (rectangle.Width - 40))
			{
				lines = new string[32];
				//create list of officially approved lines
				string[] words = rawText.Split(' ');
				//get all words from $rawString separated
				List<string> line = new List<string>();
				//make room for line, which we're creating
				string lineTest;
				//just for testing if created line is not too width
				int currentline = 0;
				

				for (int i = 0; i < words.Length; i++)
				{
					line.Add(words[i]);
					//add next word to list

					lineTest = string.Join(" ", line);
					//join all words from list into one string

					if (SpriteBank.font.MeasureString(lineTest).X > rectangle.Width - 75)
					{
						//if $lineTest is not too wide, then:
						lines[currentline] = lineTest;
						//add this to officially created lines array
						line.Clear();
						//clear line
						lineTest = null;
						//clear test line
						currentline++;
						//and increment official lines index
					}

					if (i==words.Length -1)
					{
						lines[currentline] = lineTest;
					}
				}

			}
			else
			{
				//if text is short enough, screw this
				lines = new string[1];
				lines[0] = rawText;
			}
		}

		private void Construct(Viewport viewport)
		{
			screen = new Rectangle(0, 0, viewport.Width, viewport.Height);

			//calculate message box position and size
			int width = 300;
			int height = 250;
			int x = screen.Center.X - width / 2;
			int y = screen.Center.Y - height / 2;

			rectangle = new Rectangle(x, y, width, height);
			//calculate center position (dunno why)
			center.X = rectangle.Center.X;
			center.Y = rectangle.Center.Y;

			//create OK button
			width = 100;
			height = 40;
			Rectangle buttonRec = new Rectangle(rectangle.X + rectangle.Width / 2 - width / 2, rectangle.Bottom - height - 20, width, height);
			exitButton = new Button(1, buttonRec, "OK");
		}

		public MessageBox(Viewport viewport, string text)
		{
			rawText = text;
			Construct(viewport);
			CutString();
		}
		public MessageBox(Viewport viewport)
		{
			Construct(viewport);
		}
		#endregion

		public void SetText(string text)
		{
			rawText = text;
			CutString();
		}


		public void Update(ref GuiState guiState)
		{
			exitButton.Update();
			if (exitButton.isClicked)
			{
				if (fromMenu)
				{
					guiState = GuiState.MainMenu;
				}
				else
				{
					guiState = GuiState.None;
				}

				//if exit button is clicked, swich gui to menu
			}
		}


		public void Draw(SpriteBatch spriteBatch)
		{
			spriteBatch.Draw(SpriteBank.blankPixel, screen, Color.FromNonPremultiplied(0, 0, 0, 126));
			//draw background
			spriteBatch.Draw(SpriteBank.blankPixel, rectangle, Color.Gainsboro);
			//draw box
			exitButton.Draw(spriteBatch);
			//draw button


			for (int i = 0; i < lines.Length; i++)
			{
				if (lines[i] == null)
				{
					return;
				}
				spriteBatch.DrawString(SpriteBank.font, lines[i], new Vector2(rectangle.Width / 2 + rectangle.X - SpriteBank.font.MeasureString(lines[i]).X / 2, rectangle.Top + 20 + i * SpriteBank.font.MeasureString(lines[i]).Y + i * 10), Color.Red);
				//calculate and write single lines of text
			}
		}

	}
}
