using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TowerDefenceGame {
    static class TowerShooting {
        //Hanterar projektiler och explotioner
        static List<ShootingBase> Projectiles = new List<ShootingBase>();

        public static void Update(GameTime gameTime) {

            for (int i = 0; i < Projectiles.Count; i++) {
                if (!Projectiles[i].dead) {
                    Projectiles[i].Update(gameTime);
                } else {
                    Projectiles.RemoveAt(i);
                    i--;
                }
            }  
        }

        public static void NewBullet(Vector2 Startpos, EnemyBase target, int size, int damage) {
            Projectiles.Add(new Bullet(Startpos, size, target, damage));
        }

        public static void NewLaser(Vector2 Startpos, EnemyBase target, int range) {
            Projectiles.Add(new Laser(Startpos, target, range));
        }

        public static void NewMissile(Vector2 Startpos, EnemyBase target, int size, int damage) {
            Projectiles.Add(new Missile(Startpos, size, target, damage));
        }

        public static void NewExplotion(Vector2 pos) {
            Projectiles.Add(new Explotion(pos));
        }
		public static void NewBombExplode(Vector2 pos, int damage)
		{
			Projectiles.Add(new BombExplode(pos, damage));
		}

		public static void Draw(SpriteBatch spriteBatch) {
            foreach (ShootingBase thing in Projectiles) {
                thing.Draw(spriteBatch);
            }

        }
    }
}
