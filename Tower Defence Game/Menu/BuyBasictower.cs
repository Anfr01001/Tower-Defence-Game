﻿using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TowerDefenceGame {
    class BuyBasictower : Button {
        public BuyBasictower(String text, Vector2 pos, int size) : base(text, pos, size) {
            texture = Assets.RockTower;
        }

        public override void OnClick() {
            TowerController.BoughtTower(1);
        }
    }
}
