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

        public static void Update(GameTime gameTime) {
            foreach (TowerBase Tower in TowerLista) {
                Tower.Update(gameTime);
            }

            TowerShooting.Update(gameTime);
        }

        public static void BoughtTower(int type) {
            switch (type) {
                case 1:
                    if(Player.Money >= 100) {
                        Player.Money -= 100;
                        TowerLista.Add(new BasicTower());
                    }
                    break;

                case 2:
                    if (Player.Money >= 150) {
                        Player.Money -= 150;
                        TowerLista.Add(new LaserTower());
                    } 
                    break;

                default:
                    //något gick fel
                    break;
            }

        }

        

        public static void Draw(SpriteBatch spriteBatch) {

            TowerShooting.Draw(spriteBatch);

            foreach (TowerBase Tower in TowerLista) {
                Tower.Draw(spriteBatch);
            }

        }


    }
}
