using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace TowerDefenceGame
{
	class TowerBase
	{
        //Fixa så att knappen bara pangar en gång


		protected Vector2 pos;
		protected Texture2D texture = Assets.Pixel;
		protected Rectangle rectangle;
		protected Color color = Color.White;
        private Vector2 Mousepos;

        //Används som sorterad lista över mapblock. (sortering utifrån avstång till musen)
        List<Vector2> TempLista = new List<Vector2>();

		protected bool beingPlaced = true;

		Map map;

        float testtemp = 123f;

		public TowerBase(Map map)
		{
			this.map = map;

            
        }

		public void Update(GameTime gameTime)
		{
			if (beingPlaced)
                FindPlace();
			else
			{
				//Skjut
				//osv
			}
		}

		private void FindPlace()
		{

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
            
            if(map.MapArray[pos.X,pos.Y] == 1) {
                //Kan inte placera det är en väg här
            } 

            //kolla nu om det finns torn här

        }

        private static int RoundTofifty(float i) {
            return ((int)Math.Round(i / 50.0)) * 50;
        }

        public void Draw(SpriteBatch spriteBatch)
		{
			spriteBatch.Draw(texture, rectangle, color);
            spriteBatch.DrawString(Assets.textfont, testtemp.ToString(), Vector2.Zero, Color.White);
		}
	}
}
