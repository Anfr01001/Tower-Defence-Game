using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TowerDefenceGame {
    class Laser : ShootingBase {
        private int width = 5;
        private int height;
        private EnemyBase target;
        private int range;

        private float angle;
        private Rectangle sourceRectangle;
        private Vector2 origin = new Vector2(0, 0);

        public Laser(Vector2 Startpos, EnemyBase target, int range) {
            pos = new Vector2(Startpos.X + 25, Startpos.Y + 25);
            this.target = target;
            this.range = range;
            color = Color.Orange;
        }

        public override void Update(GameTime gameTime) {

            height = (int)Vector2.Distance(pos, target.pos);
            angle = (float)(Math.Atan2(pos.Y - target.pos.Y, pos.X - target.pos.X) + Math.PI/2); // Radianer?!?!?!?!??!?!?!

            sourceRectangle = new Rectangle(0, 0, width, height);

            //Om spelaren dör dör också lasern
            if (target.dead) {
                dead = true;
            }

            //height blir också avstånd till spelare 
            if (height > range) {
                dead = true;
            }

        }

        public override void Draw(SpriteBatch spriteBatch) {
            // Rotationer från guiden http://rbwhitaker.wikidot.com/monogame-rotating-sprites
            spriteBatch.Draw(Assets.Pixel, pos, sourceRectangle, color, angle, origin, 1.0f, SpriteEffects.None, 1);
        }
    }
}
