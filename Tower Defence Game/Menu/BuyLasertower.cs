using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TowerDefenceGame {
    class BuyLasertower : Button{
        public BuyLasertower(String text, Vector2 pos, int size) : base(text, pos, size) {
            texture = Assets.UFOTower;
        }

        public override void OnClick() {
            TowerController.BoughtTower(2);
        }
    }
}
