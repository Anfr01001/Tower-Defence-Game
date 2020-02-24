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
			for (int i = 0; i < TowerLista.Count; i++)
			{
				if (!TowerLista[i].dead)
				{
					TowerLista[i].Update(gameTime);
				}
				else
				{
					TowerLista.RemoveAt(i);
					i--;
				}
			}

            TowerShooting.Update(gameTime);
        }

        public static void BoughtTower(int type) {
            switch (type) {
                case 1: //Normal
                    if(Player.Money >= 100) {
                        Player.Money -= 100;
                        TowerLista.Add(new BasicTower());
                    }
                    break;

                case 2: // Laser
                    if (Player.Money >= 150) {
                        Player.Money -= 150;
                        TowerLista.Add(new LaserTower());
                    } 
                    break;

                case 3: //Missile
                    if (Player.Money >= 300) {
                        Player.Money -= 300;
                        TowerLista.Add(new MissileTower());
                    }
                    break;

				case 4: //Bomb
					if (Player.Money >= 50)
					{
						Player.Money -= 50;
						TowerLista.Add(new Bomb());
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
