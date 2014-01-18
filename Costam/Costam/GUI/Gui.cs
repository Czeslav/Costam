using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework;

namespace Costam.GUI
{
	public enum GuiState { None, MainMenu, MessageBox, Context }

	class Gui
	{
		private GuiState currentGuiState = GuiState.None;
		private MainMenu mainMenu;
		private MessageBox messageBox;
		private ContextMenu contextMenu;
		private Viewport viewport;


		public Gui(Viewport viewport)
		{
			this.viewport = viewport;

			mainMenu = new MainMenu(viewport); //for developing only, later it will be moved somewhere and rewritten
			messageBox = new MessageBox(viewport);
		}

		public void CreateMessageBox(string text, bool fromMenu)
		{
			messageBox.SetText(text);
			messageBox.fromMenu = fromMenu;
			currentGuiState = GuiState.MessageBox;
		}

		public void Update()
		{
			#region input
			//check is esc is pressed, if so, toogle main menu
			if (Globals.currentKeyboard.IsKeyDown(Keys.Escape)
				&& Globals.oldKeyboard.IsKeyUp(Keys.Escape))
			{
				if (currentGuiState == GuiState.None)
				{
					currentGuiState = GuiState.MainMenu;
				}
				else if (currentGuiState == GuiState.MainMenu)
				{
					currentGuiState = GuiState.None;
				}
				else
				{
					currentGuiState = GuiState.None;
				}
			}

			if (Globals.mouse.RightButton == ButtonState.Pressed
				&& Globals.prevMouse.RightButton == ButtonState.Released)
			{
				currentGuiState = GuiState.Context;

				string[] abcd = new string[2];
				abcd[0] = "dupa";
				abcd[1] = "nic";
				contextMenu = new ContextMenu(new Vector2(Globals.mouse.X, Globals.mouse.Y), abcd);
			}
			#endregion

			if (currentGuiState == GuiState.None)
			{
				//pass
			}
			else if (currentGuiState == GuiState.Context)
			{
				contextMenu.Update();
			}
			else if (currentGuiState == GuiState.MainMenu)
			{
				mainMenu.Update(ref currentGuiState, this);				
			}
			else if (currentGuiState == GuiState.MessageBox)
			{
				messageBox.Update(ref currentGuiState);
			}

		}

		public void Draw(SpriteBatch spriteBatch)
		{
			if (currentGuiState == GuiState.None)
			{
				//pass
			}
			else if (currentGuiState == GuiState.Context)
			{
				contextMenu.Draw(spriteBatch);
			}
			else if (currentGuiState == GuiState.MainMenu)
			{
				mainMenu.Draw(spriteBatch);
			}
			else if (currentGuiState == GuiState.MessageBox)
			{
				messageBox.Draw(spriteBatch);
			}
		}
	}
}
