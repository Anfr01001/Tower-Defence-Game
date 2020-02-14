using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TowerDefenceGame {
    class LaserTower : TowerBase{

        EnemyBase currentTarget = null;

        public LaserTower() : base() {
            rectangle = new Rectangle(pos.ToPoint(), new Point(50, 50));
            range = 200;
            damage = 14;
            texture = Assets.UFOTower;

        }
        
        protected override void shoot(GameTime gameTime, EnemyBase target) {
            //Skada fiende
            target.TakeDamage(damage * (float)gameTime.ElapsedGameTime.TotalSeconds);
            //Rita ut "lasern"
            if(currentTarget != target) {
                TowerShooting.NewLaser(pos, target, range);
            }

        }
    }
}
