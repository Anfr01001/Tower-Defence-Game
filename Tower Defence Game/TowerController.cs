using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace TowerDefenceGame
{
	class TowerController
	{
		Map map;
		List<TowerBase> TowerLista = new List<TowerBase>();

		public TowerController(Map map)
		{
			this.map = map;
		}

		public void Update(GameTime gameTime)
		{
			foreach (TowerBase Tower in TowerLista)
			{
				Tower.Update(gameTime);
			}
		}

		public void BoughtTower(int type)
		{
            TowerLista.Add(new BasicTower(map));
		}

		public void Draw(SpriteBatch spriteBatch)
		{
			foreach (TowerBase Tower in TowerLista)
			{
				Tower.Draw(spriteBatch);
			}
		}


	}
}
