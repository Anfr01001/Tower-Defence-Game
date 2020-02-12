using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TowerDefenceGame {
    class StartButton : Button {
        public StartButton(String text, Vector2 pos, int size) : base(text, pos, size) {
            texture = Assets.PlayButton;
            color = Color.Green;
        }

        public override void OnClick() {
            Player.dead = false;
        }
    }
}
