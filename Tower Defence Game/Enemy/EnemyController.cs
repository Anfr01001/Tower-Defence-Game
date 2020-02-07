using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace TowerDefenceGame {
    static class EnemyController {
        private static double TimeBetweenEnemys = 1;
        private static double timeToSpawn = 0;



        static Random r = new Random();

        // Huvud listam med Fiender
        public static List<EnemyBase> EnemyList = new List<EnemyBase>();

        static public void Update(GameTime gameTime) {

            if (gameTime.TotalGameTime.TotalSeconds >= timeToSpawn) {
                //tiden har gått lägg till fiende
                if (r.Next(0, 3) < 2)
                    EnemyList.Add(new BasicEnemy());
                else
                    EnemyList.Add(new BigEnemy());

                timeToSpawn = gameTime.TotalGameTime.TotalSeconds + TimeBetweenEnemys;
            }

            for (int i = 0; i < EnemyList.Count; i++) {
                if (!EnemyList[i].dead) {
                    EnemyList[i].Update(gameTime, i);
                } else {
                    EnemyList.RemoveAt(i);
                    i--;
                }


            }

        }

        static public void Draw(SpriteBatch spriteBatch) {
            foreach (EnemyBase Enemy in EnemyList) {
                Enemy.Draw(spriteBatch);
            }
        }

    }
}
