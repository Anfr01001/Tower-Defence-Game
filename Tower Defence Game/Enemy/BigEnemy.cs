using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TowerDefenceGame {
    class BigEnemy : EnemyBase {

        public BigEnemy() {
            size = 50;
            hp = 60;
            Reward = 20;
            speed = 2f; // 1 block per sekund
            color = Color.White;
            texture = Assets.BigRockEnemy;

            hpbar = new Healthbar(hp,size);
        }
    }
}
