using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TowerDefenceGame {
    class NextMap : Button{

        public NextMap(String text, Vector2 pos, int size) : base(text, pos, size) {
            texture = Assets.MapIcon;
        }

        public override void OnClick() {
            Map.BuildMap();
        }
    }
}
