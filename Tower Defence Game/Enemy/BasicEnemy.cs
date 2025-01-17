﻿using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace TowerDefenceGame {
    class BasicEnemy : EnemyBase {

        public BasicEnemy(){
            size = 40;
            hp = 30;
            Reward = 10;
            speed = 3f; // 1 block per sekund
            color = Color.White;

            texture = Assets.RockEnemy;

            hpbar = new Healthbar(hp,size);
        }

    }
}
