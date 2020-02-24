using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TowerDefenceGame {
    static class Player {

        public static int life = 10;
        public static bool dead = true;
        public static int Money = 120;

        public static void subtractLife(int x) {
            life -= x;

            if (life < 1)
                dead = true;
        }

        public static void Draw(SpriteBatch spriteBatch) {
            spriteBatch.DrawString(Assets.textfont, "Money: " + Money, new Vector2(835, 750), Color.Black);
        }


    }
}
