using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace Costam
{
	static class Globals
	{
		public static Rectangle mouseRectangle;
		public static MouseState mouse;
		public static MouseState prevMouse;

		public static KeyboardState oldKeyboard;
		public static KeyboardState currentKeyboard;

		public static void Update()
		{
			prevMouse = mouse;
			mouse = Mouse.GetState();
			mouseRectangle = new Rectangle(mouse.X, mouse.Y, 1, 1);

			oldKeyboard = currentKeyboard;
			currentKeyboard = Keyboard.GetState();
		}
	}
}
