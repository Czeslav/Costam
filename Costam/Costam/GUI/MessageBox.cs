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
		private Viewport viewport;
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

					if (SpriteBank.font.MeasureString(lineTest).X > 300)
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

					if (i == words.Length - 1)
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

			/*
			int textHeight=0;
			int textWidth=0;
			foreach (var item in lines)
			{
				if (item==null)
				{
					break;
				}

				textHeight += (int)SpriteBank.font.MeasureString(item).Y;
				textHeight += 10;
				textWidth = (int)SpriteBank.font.MeasureString(item).X;

				if (textWidth > rectangle.Width)
				{
					rectangle.Width = textWidth + 20;
				}
			}
			textHeight += 50;
			rectangle.Height = textHeight;*/
		}

		private void Construct()
		{
			screen = new Rectangle(0, 0, viewport.Width, viewport.Height);

			//calculate message box position and size
			int height = 0;
			int width = 400;
			foreach (var item in lines)
			{
				if (item == null)
				{
					break;
				}

				height += (int)SpriteBank.font.MeasureString(item).Y;
				height += 10;

			}
			height += 100;
			rectangle.Height = height;


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
			this.viewport = viewport;
			rawText = text;
			CutString();
		}
		public MessageBox(Viewport viewport)
		{
			this.viewport = viewport;
		}
		#endregion

		public void SetText(string text)
		{
			rawText = text;
			CutString();
			Construct();
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