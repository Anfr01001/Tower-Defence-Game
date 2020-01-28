using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace TowerDefenceGame {
    class BasicEnemy : EnemyBase {

        public BasicEnemy(Map map) : base(map) {
            size = 40;
            hp = 20;
            speed = 2f; // 1 block per sekund
            color = Color.White;
            texture = Assets.RockEnemy;
        }

    }
}
