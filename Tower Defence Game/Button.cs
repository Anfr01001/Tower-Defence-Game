using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TowerDefenceGame {
    class Button {
        protected Vector2 pos;
        protected int size;
        protected string text = "";
        public Rectangle rectangle;

        public Button(String text, Vector2 pos, int size) {
            this.text = text;
            this.pos = pos;
            this.size = size;
            rectangle = new Rectangle((int)pos.X, (int)pos.Y, size, size);

        }

        public virtual void OnClick() {
            text = "klickad";
        }


        public void draw(SpriteBatch spriteBatch) {
            spriteBatch.Draw(Assets.Pixel, rectangle, Color.WhiteSmoke);
            spriteBatch.DrawString(Assets.textfont, text, pos, Color.Black);

        }
    }
}
