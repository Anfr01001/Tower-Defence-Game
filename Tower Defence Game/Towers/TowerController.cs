using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace TowerDefenceGame {
    static class TowerController {
        static List<TowerBase> TowerLista = new List<TowerBase>();
        static List<Bullet> BulletLista = new List<Bullet>();

        public static void Update(GameTime gameTime) {
            foreach (TowerBase Tower in TowerLista) {
                Tower.Update(gameTime);
            }

            for (int i = 0; i < BulletLista.Count; i++) {
                if (!BulletLista[i].dead) {
                    BulletLista[i].Update(gameTime);
                } else {
                    BulletLista.RemoveAt(i);
                    i--;
                }


            }
        }

        public static void BoughtTower(int type) {
            TowerLista.Add(new BasicTower());
        }

        public static void AddBullet(Vector2 Startpos, EnemyBase target, int size, int damage) {
            BulletLista.Add(new Bullet(Startpos, size, target, damage));
        }

        public static void Draw(SpriteBatch spriteBatch) {
            foreach (TowerBase Tower in TowerLista) {
                Tower.Draw(spriteBatch);
            }

            foreach (Bullet bullet in BulletLista) {
                bullet.Draw(spriteBatch);
            }
        }


    }
}
