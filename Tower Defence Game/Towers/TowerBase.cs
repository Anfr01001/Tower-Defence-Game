using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace TowerDefenceGame {
    class TowerBase {
        //Fixa så att knappen bara pangar en gång

        protected int damage = 0; 
        protected Vector2 pos;
        protected Texture2D texture = Assets.Pixel;
        protected Rectangle rectangle;
        protected Color color = Color.White;
        private Vector2 Mousepos;
        protected int range = 0;

        //Används som sorterad lista över mapblock. (sortering utifrån avstång till musen)
        List<EnemyBase> TempLista = new List<EnemyBase>();

        protected bool beingPlaced = true;


        List<EnemyBase> Fiendelista = new List<EnemyBase>();
        EnemyBase Target;

        public TowerBase() {

        }

        public void Update(GameTime gameTime) {
            if (beingPlaced)
                FindPlace();
            else {
                //kommer retunera null därför try catch
                try {
                    findTarget().TakeDamage(damage * (float)gameTime.ElapsedGameTime.TotalSeconds);
                } catch { }
                
                //osv
            }
        }

        protected EnemyBase findTarget() {
            TempLista.Clear();
            foreach (EnemyBase Enemy in EnemyController.EnemyList) {
                if (Vector2.Distance(Enemy.pos, pos) < range) {
                    TempLista.Add(Enemy);
                }
            }
            // Om det fanns några in range eller inte
            if (TempLista.Count > 0) {
                Target = TempLista[0];
                foreach (EnemyBase thing in TempLista) {
                    if (thing.pathblock > Target.pathblock) {
                        Target = thing;
                    }
                }

                return Target;
            } else {
                return null;
            } 
        }
        

        protected void shoot() {

        }

        private void FindPlace() {

            //tornet ska nu följa muspekaren för att hitta ett ställe vi kan ställa det på
            Mousepos = Mouse.GetState().Position.ToVector2();
            //eftersom rutorna är 50 stora hittav vi närmaste "50 tal" och placerar tornet där 
            pos = new Vector2(RoundTofifty(Mousepos.X), RoundTofifty(Mousepos.Y));

            rectangle.Location = pos.ToPoint();

            if (Mouse.GetState().LeftButton == ButtonState.Pressed) {
                Place(pos.ToPoint());
            }
        }

        private void Place(Point pos) {
            //Gör om så vi kan kolla om det är väg där vi ska lägga tornet
            pos = new Point(pos.X / 50, pos.Y / 50);

            if (pos.X <= 16) {
                if (Map.MapArray[pos.X, pos.Y] != 0) {
                    //Kan inte placera det är en väg här
                } else {
                    //Kan placera!
                    Map.MapArray[pos.X, pos.Y] = 2;
                    beingPlaced = false;
                }
            }


        }

        private static int RoundTofifty(float i) {
            return ((int)Math.Round(i / 50.0)) * 50;
        }

        public void Draw(SpriteBatch spriteBatch) {
            spriteBatch.Draw(texture, rectangle, color);
            spriteBatch.DrawString(Assets.textfont, TempLista.ToString(), Vector2.Zero, Color.White);
        }
    }
}
