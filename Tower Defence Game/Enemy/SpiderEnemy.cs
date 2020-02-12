using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

namespace TowerDefenceGame {
    class SpiderEnemy : EnemyBase {

        public SpiderEnemy() {
            size = 30;
            hp = 20;
            Reward = 5;
            speed = 4.5f; // block per sekund
            color = Color.White;
            texture = Assets.spider;

            hpbar = new Healthbar(hp, size);
        }

    }
}
