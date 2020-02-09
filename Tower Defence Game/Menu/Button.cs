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
        public Texture2D texture = Assets.Pixel;
        private bool hasPrice = false;
        private string price = "";
        protected Color color = Color.White;

        public Button(String text, Vector2 pos, int size) {
            this.text = text;
            this.pos = pos;
            this.size = size;
            rectangle = new Rectangle((int)pos.X, (int)pos.Y, size, size);
        }

        public Button(String text, Vector2 pos, int size, string price) {
            this.text = text;
            this.pos = pos;
            this.size = size;
            this.price = price;
            rectangle = new Rectangle((int)pos.X, (int)pos.Y + 15, size, size);
            hasPrice = true;
        }


        public virtual void OnClick() {
            text = "klickad";
        }


        public void draw(SpriteBatch spriteBatch) {
            if (texture == null)
                texture = Assets.Pixel;

            spriteBatch.Draw(texture, rectangle, color);
            spriteBatch.DrawString(Assets.textfont, text, pos, Color.Black);
            if (hasPrice)
                spriteBatch.DrawString(Assets.textfont, "Cost: "+ price, new Vector2(pos.X,pos.Y + size + 15), Color.Black);

        }
    }
}
