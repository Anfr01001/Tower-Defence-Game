using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace TowerDefenceGame {
    class EnemyController {
        private double TimeBetweenEnemys = 1;
        private double timeToSpawn = 0;

        // Huvud listam med Fiender
        List<EnemyBase> EnemyList = new List<EnemyBase>();
        Map map;
        

        public EnemyController(Map map) {
            this.map = map;
        }

        public void Update(GameTime gameTime) {

            if (gameTime.TotalGameTime.TotalSeconds >= timeToSpawn) {
                //tiden har gått lägg till fiende
                EnemyList.Add(new BasicEnemy(map));


                timeToSpawn = gameTime.TotalGameTime.TotalSeconds + TimeBetweenEnemys;
            }


            for (int i = 0; i < EnemyList.Count; i++) {
                if (!EnemyList[i].dead) {
                    EnemyList[i].Update(gameTime);
                } else {
                    EnemyList.RemoveAt(i);
                    i--;
                }
                    
                
            }

            

        }

        public void Draw(SpriteBatch spriteBatch) {
            foreach (EnemyBase Enemy in EnemyList) {
                Enemy.Draw(spriteBatch);
            }
        }

    }
}
