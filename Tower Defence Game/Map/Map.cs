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
        
        private int[,] MapArray;
        private int tempY, tempX;

        private int todo;

        public void BuildMap() {
            //Ränsa och skapa ny så att man kan skapa ny karta om man är missnöjd
            Mapblocklist.Clear();
            MapArray = new int[17, 17];

            //starta random ett steg in från värje sida (förts väg biten)
            tempX = r.Next(1, 14);
            tempY = -1;

            //1 menas kommer leda till att den plattan blir en "path"
            //gå ner 3 stag i början 
            for (int i = 0; i < 3; i++) {
                MapArray[tempX, ++tempY] = 1; //++ före för att få med alla rutor (öven den första som annars kulle vatit -1)
                Mapblocklist.Add(new MapBlock(new Vector2(tempX * 50, tempY * 50), true, Assets.RoadDown));
                
            }
            
            //Generera random en väg från toppen till botten 
            // 2steg i taget för att få en lite snyggare map
            while (tempY < 15) {
                todo = r.Next(0, 6); // 5st lägen pga höger och vänster är 2(så att det blir större chans) (så mappen breder ut sig mer)
                
                //Gör det 2 gånger för att få snyggare teräng inte lika hoppig
                for (int i = 0; i <= 1; i++) {

                    switch (todo) {

                        case 1: // down
                                //Kolla om föregågende vag ska svänga (nu när vi vet vart den nya vägen är)
                            if (MapArray[tempX, tempY - 1] == 0) {
                                if (MapArray[tempX + 1 , tempY] == 1) // om föregågende har en väg till höger
                                    Mapblocklist.Last().texture = Assets.TurnRight2;
                                else
                                    Mapblocklist.Last().texture = Assets.TurnLeft2;
                            }

                            MapArray[tempX, tempY++] = 1;
                            Mapblocklist.Add(new MapBlock(new Vector2(tempX * 50, tempY * 50), true, Assets.RoadDown));
                            break;

                        case 2: // right
                        case 3: // 2st för höger och vänster för att göra mapen längre
                            if (tempX < 13 && MapArray[tempX + 1, tempY] == 0) {
                                //Kolla om föregågende vag ska svänga (nu när vi vet vart den nya vägen är)
                                if (MapArray[tempX, tempY - 1] == 1)
                                    Mapblocklist.Last().texture = Assets.TurnRight;

                                MapArray[tempX++, tempY] = 1;

                                Mapblocklist.Add(new MapBlock(new Vector2(tempX * 50, tempY * 50), true, Assets.RoadSide));

                            }
                            break;

                        case 4: // Left
                        case 5: // 2st för höger och vänster för att göra mapen längre
                            if (tempX > 2 && MapArray[tempX - 1, tempY] == 0) {
                                //Kolla om föregågende vag ska svänga (nu när vi vet vart den nya vägen är)
                                if (MapArray[tempX, tempY - 1] == 1)
                                    Mapblocklist.Last().texture = Assets.TurnLeft;

                                MapArray[tempX--, tempY] = 1;

                                Mapblocklist.Add(new MapBlock(new Vector2(tempX * 50, tempY * 50), true, Assets.RoadSide));

                            }
                            break;
                    }
                }
            }



            //Gör allt som inte är path til gärs
            for (int y = 0; y <= 15; y++) {
                for (int x = 0; x <= 15; x++) {

                    if (MapArray[x, y] != 1)
                        Mapblocklist.Add(new MapBlock(new Vector2(x * 50, y * 50), false, Assets.Grass));
                    }

                }
            }

        public void DrawMap(SpriteBatch spriteBatch) {

            foreach (MapBlock item in Mapblocklist) {
                    spriteBatch.Draw(item.texture, item.rectangle, item.color);
            }
        }

    }
}
