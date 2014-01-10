using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework;

namespace Costam.GUI
{
	public enum GuiState { None, MainMenu, Context }

	class Gui
	{
		private GuiState currentGuiState = GuiState.None;
		private MainMenu mainMenu;
		private Viewport viewport;


		public Gui(Viewport viewport)
		{
			this.viewport = viewport;

			mainMenu = new MainMenu(viewport);
		}

		public void Update()
		{
			#region input

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
			#endregion
		}

		public void Draw(SpriteBatch spriteBatch)
		{
			if (currentGuiState == GuiState.MainMenu)
			{
				mainMenu.Draw(spriteBatch);
			}
		}
	}
}
