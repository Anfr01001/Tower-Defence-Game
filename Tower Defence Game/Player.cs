using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TowerDefenceGame {
    static class Player {

        private static int life = 10;
        public static bool dead = false;

        public static void subtractLife(int x) {
            life -= x;

            if (life < 1)
                dead = true;
        }

        public static void Draw(SpriteBatch spriteBatch) {
            spriteBatch.DrawString(Assets.textfont, life.ToString(), Vector2.Zero, Color.Black);
        }


    }
}
