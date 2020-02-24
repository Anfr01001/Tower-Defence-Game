using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TowerDefenceGame
{
	class Bomb : TowerBase
	{
		public Bomb() : base()
		{
			rectangle = new Rectangle(pos.ToPoint(), new Point(50, 50));
			range = 30;
			damage = 100;
			texture = Assets.Dynamit;

		}

		protected override void shoot(GameTime gameTime, EnemyBase target)
		{
			TowerShooting.NewBombExplode(pos, damage);
			dead = true;
		}

	}
}
