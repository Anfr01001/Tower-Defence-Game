using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TowerDefenceGame {
    class Healthbar {

        private float maxHealth;

        private Rectangle rectangle;
        private float width;
        private float MaxWidth;
        private float height = 5;

        public Healthbar(float hp, float MaxWidth) {
            //Eftersom denna skapas när fiende/Spelare skapas är det värder max värder för health;
            maxHealth = hp;
            this.MaxWidth = MaxWidth - 5;
        }

        public Healthbar(float hp, float MaxWidth, float height) {
            //Eftersom denna skapas när fiende/Spelare skapas är det värder max värder för health;
            maxHealth = hp;
            this.MaxWidth = MaxWidth - 5;
            this.height = height;
        }

        public void Update(float currenthp, Vector2 pos) {
            width = MaxWidth * (currenthp / maxHealth);
            rectangle = new Rectangle((int)pos.X, (int)pos.Y, (int)width, (int)height);
        }

        public void Draw(SpriteBatch spriteBatch) {
            spriteBatch.Draw(Assets.Pixel, rectangle, Color.Red);
        }

    }
}
