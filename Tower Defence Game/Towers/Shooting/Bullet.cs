using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TowerDefenceGame {
    class Bullet : ShootingBase{
        private float speed = 10;
        private EnemyBase target;
        private Vector2 direction;
        private int damage;

        public Bullet(Vector2 Startpos, int size, EnemyBase target, int damage) {
            pos = new Vector2(Startpos.X + 25, Startpos.Y + 25);
            this.size = size;
            this.target = target;
            this.damage = damage;
            rectangle = new Rectangle((int)pos.X, (int)pos.Y, size, size);
        }

        public override void Update(GameTime gameTime) {
            //Från ditt shooterspel
            direction = target.pos - pos;
            direction.Normalize();
            pos += direction * (speed * 50) * gameTime.ElapsedGameTime.Milliseconds / 1000;

            rectangle = new Rectangle((int)pos.X, (int)pos.Y, size, size);

            if (rectangle.Intersects(target.rectangle)) {
                dead = true;
                target.TakeDamage(damage);
            }
        }

        public override void Draw(SpriteBatch spriteBatch) {
            spriteBatch.Draw(Assets.ThrowingRock, rectangle, color);
        }
    }
}
