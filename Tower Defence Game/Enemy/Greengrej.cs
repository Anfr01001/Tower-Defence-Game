using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TowerDefenceGame
{
    class Greengrej : EnemyBase
    {

        public Greengrej()
        {
            size = 50;
            hp = 60;
            Reward = 20;
            speed = 2f; // 1 block per sekund
            color = Color.White;
            texture = Assets.Greengrej;

            hpbar = new Healthbar(hp, size);
        }
    }
}
