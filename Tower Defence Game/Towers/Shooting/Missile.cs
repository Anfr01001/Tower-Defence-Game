using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TowerDefenceGame {
    class Missile : ShootingBase {
        private float speed = 5;
        private EnemyBase target;
        private Vector2 direction;
        private int damage;
        Rectangle sourceRectangle;
        private float angle;
        private Vector2 origin = new Vector2(0, 0);


        public Missile(Vector2 Startpos, int size, EnemyBase target, int damage) {
            pos = new Vector2(Startpos.X + 25, Startpos.Y + 25);
            this.size = size;
            this.target = target;
            this.damage = damage;
            rectangle = new Rectangle((int)pos.X, (int)pos.Y, size, size);

            sourceRectangle = new Rectangle(0, 0, size, size);
        }

        public override void Update(GameTime gameTime) {
            //Från ditt shooterspel
            direction = target.pos - pos;
            direction.Normalize();
            pos += direction * (speed * 50) * gameTime.ElapsedGameTime.Milliseconds / 1000;

            rectangle = new Rectangle((int)pos.X, (int)pos.Y, size, size);

            angle = (float)(Math.Atan2(pos.Y - target.pos.Y, pos.X - target.pos.X)- Math.PI /2); // Radianer?!?!?!?!??!?!?!

            if (Vector2.Distance(pos,target.pos) < 10) {
                dead = true;

                TowerShooting.NewExplotion(target.pos);

                foreach (EnemyBase enemy in EnemyController.EnemyList) {
                    if (Vector2.Distance(pos,enemy.pos)  < 100) {
                        enemy.TakeDamage((float)(damage - (0.35* Vector2.Distance(pos, enemy.pos))));
                    }
                }
                target.TakeDamage(damage);
            }
        }

        public override void Draw(SpriteBatch spriteBatch) {
            spriteBatch.Draw(Assets.Missile, pos, sourceRectangle, color, angle, origin, 1.0f, SpriteEffects.None, 1);
        }

    }
}
