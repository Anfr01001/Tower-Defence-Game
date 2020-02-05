using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace TowerDefenceGame {
    class EnemyBase {
        //Vad alla fiender kommer behöva
        protected int size;
        protected int hp;
        protected float speed; // blocks per sekund
        public Vector2 pos;
        protected Rectangle rectangle;
        protected Color color;
        public bool dead = false;
        protected Texture2D texture = Assets.Pixel;

        public int pathblock = 1; // Hur långt den har kommit i targets (för movement)
        public double distanceToTarget;
        private Vector2 target;

        private List<MapBlock> Targets = new List<MapBlock>();

        int test;

        public EnemyBase() {
            // Sortera ut paths så vi kan följa dem
            foreach (MapBlock item in Map.Mapblocklist) {
                if (item.ispath)
                    Targets.Add(item);
            }

            //börja vid första blocket
            pos = Targets[0].center;
            target = Targets[pathblock].center;
        }

        public void Update(GameTime gameTime, int i) {
            Movement(gameTime);
            rectangle = new Rectangle((int)pos.X - size/2 ,(int)pos.Y - size / 2, size,size);

            //Om spelaren är under mapen är han död och tar hp
            if (pos.Y > 800) {
                dead = true;
            }

            test = i;
        }

        public void tempKill() {
            dead = true;
        }

        public void Movement(GameTime gameTime) {
            
            //Gå mot nästa target (center av nästa path block enligt listan)
            if (pos.Y < target.Y) {
                pos.Y += (speed * 50) * gameTime.ElapsedGameTime.Milliseconds / 1000;
            } else if (pos.Y > target.Y) {
                pos.Y -= (speed * 50) * gameTime.ElapsedGameTime.Milliseconds / 1000;
            } else if (pos.X > target.X) {
                pos.X -= (speed * 50) * gameTime.ElapsedGameTime.Milliseconds / 1000;
            } else if (pos.X < target.X) {
                pos.X += (speed * 50) * gameTime.ElapsedGameTime.Milliseconds / 1000;
            }

            //Om den är nära target byt till nästa target samt centrera
            distanceToTarget = Math.Sqrt(Math.Pow(target.X - pos.X, 2) + Math.Pow(target.Y - pos.Y, 2));
            if (distanceToTarget < 3) {
                pos = target; // Korrgera för den lilla biten kvar (movement är inte exakta ints)
                try {
                    target = Targets[pathblock++].center;
                } catch {
                    // slut på targets (sätt target rakt under senaste för att gå ut ut kartn och där med förlora liv)
                    target = new Vector2(target.X, target.Y + 50);
                }
                
            }
        }

        public void Draw(SpriteBatch spriteBatch) {

            /* Skriv ut nummrerne på path rutorna som den ska följa
            for (int i = 0; i < Targets.Count; i++) {
                spriteBatch.DrawString(Assets.textfont, i.ToString() , Targets[i].center, Color.Black);
            }

            Också test

            
            */
            
            spriteBatch.Draw(texture, rectangle, color);
            spriteBatch.DrawString(Assets.textfont, test.ToString(), pos, Color.Black);

        }


    }
}
