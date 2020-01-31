using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace TowerDefenceGame
{

    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        Map map;
        EnemyController enemyController;
        Menu BuyMeny;
		TowerController towerController;
        
        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            graphics.PreferredBackBufferWidth = 950;  
            graphics.PreferredBackBufferHeight = 800;  
            Content.RootDirectory = "Content";
        }

        
        protected override void Initialize()
        {
            Assets.LoadContent(Content);
            this.IsMouseVisible = true;

            map = new Map();
            enemyController = new EnemyController(map);
            BuyMeny = new Menu(new Vector2(800, 0), 150,800);
			towerController = new TowerController(map); 

			base.Initialize();
        }

        
        protected override void LoadContent()
        {
            
            spriteBatch = new SpriteBatch(GraphicsDevice);
            Assets.CreatePixel(GraphicsDevice);
            map.BuildMap();

        }

        
        protected override void UnloadContent()
        {
            
        }

        
        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            //För test
            if (Keyboard.GetState().IsKeyDown(Keys.Space))
                map.BuildMap();
            //För test

            if (Mouse.GetState().LeftButton == ButtonState.Pressed) {
                BuyMeny.MouseKlick(Mouse.GetState().Position);
            }

			towerController.Update(gameTime);

			enemyController.Update(gameTime);

            base.Update(gameTime);
        }

        
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            spriteBatch.Begin();

            //Rita ut kartan
            map.DrawMap(spriteBatch);
            //Rita ut fienden
            enemyController.Draw(spriteBatch);
			towerController.Draw(spriteBatch);
            BuyMeny.draw(spriteBatch);
            spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}
