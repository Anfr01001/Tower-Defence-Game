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

        public static Texture2D Grass;
        public static Texture2D RoadDown;
        public static Texture2D RoadSide;
        public static Texture2D TurnLeft;
        public static Texture2D TurnRight;
        public static Texture2D TurnLeft2;
        public static Texture2D TurnRight2;


        public static void CreatePixel(GraphicsDevice device) {

            Pixel = new Texture2D(device, 1, 1);
            Pixel.SetData(new Color[] { Color.White });
        }

        public static void LoadContent(ContentManager content) {
            textfont = content.Load<SpriteFont>("Text");
            RockEnemy = content.Load<Texture2D>("RockMonster");

            Grass = content.Load<Texture2D>("Grass");
            RoadDown = content.Load<Texture2D>("RoadUp");
            RoadSide = content.Load<Texture2D>("RoadSide");
            TurnLeft = content.Load<Texture2D>("UpsideTurnleft");
            TurnRight = content.Load<Texture2D>("UpsideTurnright");
            TurnLeft2 = content.Load<Texture2D>("TurnLeft2");
            TurnRight2 = content.Load<Texture2D>("TurnRight2");


        }

    }
}
