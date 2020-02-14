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

        //Ladda in alla textures så det är enkelt och nå dem och behöver inte skicka runt till alla klasser

        public static Texture2D Pixel;

        public static Texture2D RockEnemy;
        public static Texture2D BigRockEnemy;
        public static Texture2D spider;
        public static Texture2D Greengrej;

        public static SpriteFont textfont;

        public static Texture2D UFOTower;
        public static Texture2D RockTower;
        public static Texture2D MissileTower;
        public static Texture2D Missile;

        public static Texture2D RangeCircle;

        public static Texture2D ThrowingRock;

        public static Texture2D Grass;
        public static Texture2D RoadDown;
        public static Texture2D RoadSide;
        public static Texture2D TurnLeft;
        public static Texture2D TurnRight;
        public static Texture2D TurnLeft2;
        public static Texture2D TurnRight2;

        public static Texture2D MapIcon;
        public static Texture2D PlayButton;
        public static Texture2D[] Explotioner = new Texture2D[62];


        public static void CreatePixel(GraphicsDevice device) {
            //Standrad texture för test
            Pixel = new Texture2D(device, 1, 1);
            Pixel.SetData(new Color[] { Color.White });
        }

        public static void LoadContent(ContentManager content) {
            textfont = content.Load<SpriteFont>("Text");

            RockEnemy = content.Load<Texture2D>("RockMonster");
            BigRockEnemy = content.Load<Texture2D>("BigRockMonster");
            spider = content.Load<Texture2D>("spider");
            Greengrej = content.Load<Texture2D>("Greengrej");

            UFOTower = content.Load<Texture2D>("skullufo");
            RockTower = content.Load<Texture2D>("RockTower");
            MissileTower = content.Load<Texture2D>("MissileTower");
            Missile = content.Load<Texture2D>("Missile");

            RangeCircle = content.Load<Texture2D>("RangeCircle");

            ThrowingRock = content.Load<Texture2D>("ThrowingRock");

            Grass = content.Load<Texture2D>("Grass");
            RoadDown = content.Load<Texture2D>("RoadUp");
            RoadSide = content.Load<Texture2D>("RoadSide");
            TurnLeft = content.Load<Texture2D>("UpsideTurnleft");
            TurnRight = content.Load<Texture2D>("UpsideTurnright");
            TurnLeft2 = content.Load<Texture2D>("TurnLeft2");
            TurnRight2 = content.Load<Texture2D>("TurnRight2");

            MapIcon = content.Load<Texture2D>("MapIcon");

            PlayButton = content.Load<Texture2D>("PlayButton"); 

            for (int i = 1; i < 62; i++) {
                    Explotioner[i-1] = content.Load<Texture2D>("Explotion (" + i + ")");
            }

        }

    }
}
