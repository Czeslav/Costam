using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework;

namespace Costam.GUI
{
	public enum GuiState { None, MainMenu, MessageBox }

	class Gui
	{
		private GuiState currentGuiState = GuiState.None;
		private MainMenu mainMenu;
		private MessageBox messageBox;
		private Viewport viewport;


		public Gui(Viewport viewport)
		{
			this.viewport = viewport;

			mainMenu = new MainMenu(viewport);
			messageBox = new MessageBox(viewport, "Trolololo ja sobie derpie tu ze strinami i dzielenie mstringow, a wy sie nudzicie a ja mam co robic, w sumie nie mam co robic, skoro takie cos robie, ale jest dobrze");
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

			if (currentGuiState == GuiState.None)
			{
				//pass
			}
			else if (currentGuiState == GuiState.MainMenu)
			{
				mainMenu.Update(ref currentGuiState);				
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
