using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TowerDefenceGame {
    class BigEnemy : EnemyBase {

        public BigEnemy(Map map) : base(map) {
        size = 50;
        hp = 50;
        speed = 1f; // 1 block per sekund
        color = Color.White;
        texture = Assets.BigRockEnemy;
    }
}
}
