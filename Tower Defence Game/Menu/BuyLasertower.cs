using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TowerDefenceGame {
    class BuyLasertower : Button{
        public BuyLasertower(String text, string price, Vector2 pos, int size) : base(text, pos, size, price) {
            texture = Assets.UFOTower;
        }

        public override void OnClick() {
            TowerController.BoughtTower(2);
        }
    }
}
