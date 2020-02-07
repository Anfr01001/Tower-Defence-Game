using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TowerDefenceGame
{
    class Bullet
    {
        private int size;
        private float speed = 10;
        private Vector2 pos;
        private Rectangle rectangle;
        private Color color = Color.Red;
        private EnemyBase target;
        private Vector2 direction;
        public bool dead = false;
        private int damage;

        public Bullet(Vector2 Startpos, int size, EnemyBase target, int damage)
        {
            pos = Startpos;
            this.size = size;
            this.target = target;
            this.damage = damage;
            rectangle = new Rectangle((int)pos.X, (int)pos.Y, size, size);
        }

        public void Update(GameTime gameTime)
        {
            //Från ditt shooterspel
            direction = target.pos - pos;
            direction.Normalize();
            pos += direction * (speed * 50) * gameTime.ElapsedGameTime.Milliseconds / 1000;

            rectangle = new Rectangle((int)pos.X, (int)pos.Y, size, size);

            if (rectangle.Intersects(target.rectangle))
            {
                dead = true;
                target.TakeDamage(damage);
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(Assets.Pixel, rectangle, color);
        }
    }
}
