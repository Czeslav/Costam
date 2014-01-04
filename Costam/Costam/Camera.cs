using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Costam
{
	public class Camera
	{
		protected float _zoom; // Camera Zoom
		public Matrix _transform; // Matrix Transform
		public Vector2 _pos; // Camera Position
		protected float _rotation; // Camera Rotation

		public Camera()
		{
			_zoom = 1.0f;
			_rotation = 0.0f;
			_pos = Vector2.Zero;
		}

		// Sets and gets zoom
		public float Zoom
		{
			get { return _zoom; }
			set { _zoom = value; if (_zoom < 0.1f) _zoom = 0.1f; } // Negative zoom will flip image
		}

		public float Rotation
		{
			get { return _rotation; }
			set { _rotation = value; }
		}

		KeyboardState keyboard;
		public void Update()
		{
			keyboard = Keyboard.GetState();

			if (keyboard.IsKeyDown(Keys.Up))
			{
				_pos.Y -= 3;
			}
			else if (keyboard.IsKeyDown(Keys.Down))
			{
				_pos.Y += 3;
			}

			if (keyboard.IsKeyDown(Keys.Left))
			{
				_pos.X -= 3;
			}
			else if (keyboard.IsKeyDown(Keys.Right))
			{
				_pos.X += 3;
			}
		}



		// Get set position
		public Vector2 Pos
		{
			get { return _pos; }
			set { _pos = value; }
		}

		public Matrix get_transformation(GraphicsDevice graphicsDevice)
		{
			_transform =       // Thanks to o KB o for this solution
			  Matrix.CreateTranslation(new Vector3(-_pos.X, -_pos.Y, 0)) *
										 Matrix.CreateRotationZ(Rotation) *
										 Matrix.CreateScale(new Vector3(Zoom, Zoom, 1)) *
										 Matrix.CreateTranslation(new Vector3(graphicsDevice.Viewport.Width * 0.5f, graphicsDevice.Viewport.Height * 0.5f, 0));
			return _transform;
		}
	}
}

