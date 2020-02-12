using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TowerDefenceGame {
    class Explotion {

        public bool dead = false;

        private double Nextpic = 0;
        private double TimebetweenPic = 0.01;

        private Texture2D[] textureArray = Assets.Explotioner;
        private int texture = 0;
        private Rectangle rectangle;

        public Explotion(Vector2 pos) {
            rectangle = new Rectangle(new Point((int)pos.X - 100, (int)pos.Y - 100), new Point(200));
        }

        public void Update(GameTime gameTime) {

            if (gameTime.TotalGameTime.TotalSeconds > Nextpic) {
                Nextpic = gameTime.TotalGameTime.TotalSeconds + TimebetweenPic;
                texture++;

                if (texture == 60)
                    dead = true;
            }
                
        }

        public void Draw(SpriteBatch spriteBatch) {
            spriteBatch.Draw(textureArray[texture], rectangle, Color.White);
        }
    }
}
