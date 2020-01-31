using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace TowerDefenceGame
{
	class TowerBase
	{

		protected Vector2 pos;
		protected Texture2D texture;
		protected Rectangle rectangle;
		protected Color color;

		protected bool beingPlaced;

		Map map;

		public TowerBase(Map map)
		{
			this.map = map;
		}

		public void Update(GameTime gameTime)
		{
			if (beingPlaced)
				Placeing();
			else
			{
				//Skjut
				//osv
			}
		}

		private void Placeing()
		{
			pos = Mouse.GetState().Position.ToVector2();
		}

		public void Draw(SpriteBatch spriteBatch)
		{
			spriteBatch.Draw(texture, rectangle, color);
		}
	}
}
