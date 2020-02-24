using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TowerDefenceGame
{
	class BombExplode : ShootingBase
	{

		public BombExplode(Vector2 pos, int damage)
		{

			TowerShooting.NewExplotion(new Vector2(pos.X+25, pos.Y+25));

			foreach (EnemyBase enemy in EnemyController.EnemyList)
			{
				if (Vector2.Distance(pos, enemy.pos) < 100)
				{
					
					enemy.TakeDamage((float)(damage - (0.35 * Vector2.Distance(pos, enemy.pos))));
				}
			}
		}



	}
}
