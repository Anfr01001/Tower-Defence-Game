using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace TowerDefenceGame
{
	static class TowerController
	{
        static List<TowerBase> TowerLista = new List<TowerBase>();

		public static void Update(GameTime gameTime)
		{
			foreach (TowerBase Tower in TowerLista)
			{
				Tower.Update(gameTime);
			}
		}

		public static void BoughtTower(int type)
		{
            TowerLista.Add(new BasicTower());
		}

		public static void Draw(SpriteBatch spriteBatch)
		{
			foreach (TowerBase Tower in TowerLista)
			{
				Tower.Draw(spriteBatch);
			}
		}


	}
}
