using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TowerDefenceGame {
    class ShootingBase {

        protected int size;
        protected Vector2 pos;
        protected Rectangle rectangle;
        protected Color color = Color.White;
        public bool dead = false;

        public virtual void Update(GameTime gameTime) {

        }

        public virtual void Draw(SpriteBatch spritebatch) {

        }

    }
}
