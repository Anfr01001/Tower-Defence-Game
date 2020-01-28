using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TowerDefenceGame {
    static class Assets {
        public static Texture2D Pixel;
        public static Texture2D RockEnemy;
        public static SpriteFont textfont;

        public static void CreatePixel(GraphicsDevice device) {

            Pixel = new Texture2D(device, 1, 1);
            Pixel.SetData(new Color[] { Color.White });
        }

        public static void LoadContent(ContentManager content) {
            textfont = content.Load<SpriteFont>("Text");
            RockEnemy = content.Load<Texture2D>("RockMonster");
            
        }

    }
}
