using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace TowerDefenceGame {
    class Map {
        Random r = new Random();
        public List<MapBlock> Mapblocklist = new List<MapBlock>();
        public List<MapBlock> MapPath = new List<MapBlock>();
        //Värje del av kartan är 50 stor * 16 blir 800pixlar totalt 
        int[,] MapArray;
        private bool path;
        private int tempY, tempX;
        private Vector2 StartPoint, EndPoint;

        private MapBlock temp;

        public void BuildMap() {
            //Ränsa och skapa ny så att man kan skapa ny karta om man är missnöjd
            Mapblocklist.Clear();
            MapPath.Clear();
            MapArray = new int[17, 17];

            //starta random ett steg in från värje sida
            tempX = r.Next(1, 14);
            tempY = 0;

            //1 menas kommer leda till att den plattan blir en "path"
            MapArray[tempX, tempY] = 1;
            temp = new MapBlock(new Vector2(tempX * 50, tempY * 50), true);
            Mapblocklist.Add(temp);
            MapPath.Add(temp);

            MapArray[tempX, tempY++] = 1;
            MapArray[tempX, tempY++] = 1;
            temp = new MapBlock(new Vector2(tempX * 50, tempY * 50), true);
            Mapblocklist.Add(temp);
            MapPath.Add(temp);


            //Generera random en väg från toppen till botten 
            // 2steg i taget för att få en lite snyggare map
            while (tempY < 15) {

                switch (r.Next(0, 4)) {

                    case 1: // down                       
                        MapArray[tempX, tempY++] = 1;
                        MapArray[tempX, tempY++] = 1;
                        temp = new MapBlock(new Vector2(tempX * 50, tempY * 50), true);
                        Mapblocklist.Add(temp);
                        MapPath.Add(temp);
                        break;

                    case 2: // right
                        if (tempX < 13 && MapArray[tempX + 1, tempY] == 0) {
                            MapArray[tempX++, tempY] = 1;
                            MapArray[tempX++, tempY] = 1;
                            temp = new MapBlock(new Vector2(tempX * 50, tempY * 50), true);
                            Mapblocklist.Add(temp);
                            MapPath.Add(temp);
                        }


                        break;

                    case 3: // Left
                        if (tempX > 2 && MapArray[tempX - 1, tempY] == 0) {
                            MapArray[tempX--, tempY] = 1;
                            MapArray[tempX--, tempY] = 1;
                            temp = new MapBlock(new Vector2(tempX * 50, tempY * 50), true);
                            Mapblocklist.Add(temp);
                            MapPath.Add(temp);
                        }


                        break;
                        /* Kanske implementerar sen 
                        case 4: // Up
                            if (tempY != 1 && MapArray[tempX, tempY - 1] == 0 ) {
                                MapArray[tempX, tempY--] = 1;
                            }
                            break;
                        */
                }
                
            }



            //Gör alla som inte är path til block
            for (int y = 0; y <= 15; y++) {
                for (int x = 0; x <= 15; x++) {

                    //Om de ska vara path skicka med det (true = path)
                    if (MapArray[x, y] != 1)
                        Mapblocklist.Add(new MapBlock(new Vector2(x * 50, y * 50), false));
                    }

                    //gånger 50 pixlar pga storlek av värje "block"
                    
                }
            }

        public void DrawMap(SpriteBatch spriteBatch) {

            foreach (MapBlock item in Mapblocklist) {
                if (!item.ispath) // rita förtillfälligt inte ut pathes (ska ha annan texture sen)
                    spriteBatch.Draw(Assets.Pixel, item.rectangle, item.color);
            }
        }

    }
}
