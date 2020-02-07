﻿using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TowerDefenceGame
{
	class BasicTower : TowerBase
	{
        double NextShot = 0;
        double timeToShoot = 1;
        public BasicTower() : base()
        {
            rectangle = new Rectangle(pos.ToPoint(), new Point(50, 50));
            range = 200;
            damage = 15;
            texture = Assets.TowerBasic;
            
        }
        protected override void shoot(GameTime gameTime, EnemyBase target)
        {
            //Har det gått lång tid nog föt att skjuta ?
          if (gameTime.TotalGameTime.TotalSeconds > NextShot)
          {
                TowerController.AddBullet(pos, target, 10, damage);
                NextShot = gameTime.TotalGameTime.TotalSeconds + timeToShoot;
          }
        }

    }

	
}
