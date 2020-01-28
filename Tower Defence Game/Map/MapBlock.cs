using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace TowerDefenceGame {
    class MapBlock {
        private int size = 50;
        private Vector2 pos;
        public Rectangle rectangle { get; }
        public bool ispath { get; }
        public Color color { get; }

        public Vector2 center { get; }

        public MapBlock(Vector2 pos, bool ispath) {
            this.pos = pos;
            this.ispath = ispath;
            color = Color.White;
            center = new Vector2(pos.X + 25, pos.Y + 25);
            rectangle = new Rectangle((int)pos.X, (int)pos.Y, size, size);
        }

    }
}
