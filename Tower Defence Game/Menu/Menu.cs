using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace TowerDefenceGame {
    class Menu {

        private Vector2 pos;
        private int BackGorundwidth;
        private int BackGroundhight;
        private List<Button> buttons = new List<Button>();

        private Rectangle ColitionRectangle;

        public bool isMainMenu = false;

        //Main menyn
        public Menu(Vector2 pos, int width, int hight, bool ismainmenu) {
            this.pos = pos;
            BackGorundwidth = width;
            BackGroundhight = hight;

            this.isMainMenu = ismainmenu;

            buttons.Clear();

            //Lägg till knappar
            buttons.Add(new NextMap("New map", new Vector2(835, 20), 80));
            buttons.Add(new StartButton("Start", new Vector2(835, 140), 80));

        }

        //Köp menyn
        public Menu(Vector2 pos, int width, int hight) {
            this.pos = pos;
            BackGorundwidth = width;
            BackGroundhight = hight;

            buttons.Clear();

            isMainMenu = false;

            //Lägg till knappar
            buttons.Add(new BuyBasictower("BasicTower", "100" ,new Vector2(835, 20), 80));
            buttons.Add(new BuyLasertower("LaserTower", "150" ,new Vector2(835, 140), 80));
            buttons.Add(new BuyMissiletower("MissileTower", "300", new Vector2(835, 260), 80));

        }

        public void MouseKlick(Point pos) {
            ColitionRectangle = new Rectangle(pos.X, pos.Y, 1, 1);

            foreach (Button button in buttons) {
                if (button.rectangle.Intersects(ColitionRectangle)) {
                    button.OnClick();
                }
            }

        }

        public void draw(SpriteBatch spriteBatch) {
            spriteBatch.Draw(Assets.Pixel, new Rectangle((int)pos.X, (int)pos.Y, BackGorundwidth, BackGroundhight), Color.Gray);
            foreach (Button button in buttons) {
                button.draw(spriteBatch);
            }
        }
    }
}
