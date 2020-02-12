using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TowerDefenceGame {
    class MissileTower : TowerBase{
        private double NextShot = 0;
        private double timeToShoot = 1;

        public MissileTower() : base() {
            rectangle = new Rectangle(pos.ToPoint(), new Point(50, 50));
            range = 300;
            damage = 30;
            texture = Assets.MissileTower;

        }

        protected override void shoot(GameTime gameTime, EnemyBase target) {
            //Har det gått lång tid nog föt att skjuta ?
            if (gameTime.TotalGameTime.TotalSeconds > NextShot) {
                TowerShooting.NewMissile(pos, target, 50, damage);
                NextShot = gameTime.TotalGameTime.TotalSeconds + timeToShoot;
            }
        }

    }
}
