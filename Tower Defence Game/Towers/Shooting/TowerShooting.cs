using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TowerDefenceGame {
    static class TowerShooting {
        static List<Bullet> BulletLista = new List<Bullet>();
        static List<Laser> LaserLista = new List<Laser>();
        static List<Missile> MissileList = new List<Missile>();

        public static void Update(GameTime gameTime) {

            for (int i = 0; i < BulletLista.Count; i++) {
                if (!BulletLista[i].dead) {
                    BulletLista[i].Update(gameTime);
                } else {
                    BulletLista.RemoveAt(i);
                    i--;
                }
            }

            for (int i = 0; i < LaserLista.Count; i++) {
                if (!LaserLista[i].dead) {
                    LaserLista[i].Update(gameTime);
                } else {
                    LaserLista.RemoveAt(i);
                    i--;
                }
            }

            for (int i = 0; i < MissileList.Count; i++) {
                if (!MissileList[i].dead) {
                    MissileList[i].Update(gameTime);
                } else {
                    MissileList.RemoveAt(i);
                    i--;
                }
            }

        }

        public static void NewBullet(Vector2 Startpos, EnemyBase target, int size, int damage) {
            BulletLista.Add(new Bullet(Startpos, size, target, damage));
        }

        public static void NewLaser(Vector2 Startpos, EnemyBase target, int range) {
            LaserLista.Add(new Laser(Startpos, target, range));
        }

        public static void NewMissile(Vector2 Startpos, EnemyBase target, int size, int damage) {
            MissileList.Add(new Missile(Startpos, size, target, damage));
        }

        public static void Draw(SpriteBatch spriteBatch) {
            foreach (Bullet bullet in BulletLista) {
                bullet.Draw(spriteBatch);
            }

            foreach (Laser laser in LaserLista) {
                laser.Draw(spriteBatch);
            }

            foreach (Missile missile in MissileList) {
                missile.Draw(spriteBatch);
            }
        }
    }
}
