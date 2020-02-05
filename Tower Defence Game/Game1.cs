using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace TowerDefenceGame
{

    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        Menu BuyMeny;

        bool canclick = true;
        
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
            BuyMeny = new Menu(new Vector2(800, 0), 150, 800);

            base.Initialize();
        }

        
        protected override void LoadContent()
        {
            
            spriteBatch = new SpriteBatch(GraphicsDevice);
            Assets.CreatePixel(GraphicsDevice);
            Map.BuildMap();

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
                Map.BuildMap();
                //towerController.BoughtTower(1);
            //För test


            if (Mouse.GetState().LeftButton == ButtonState.Pressed && canclick) {
                BuyMeny.MouseKlick(Mouse.GetState().Position);
                canclick = false;
            }

            //Kan göras bättre
            if (Mouse.GetState().LeftButton == ButtonState.Released)
                canclick = true;

			TowerController.Update(gameTime);

			EnemyController.Update(gameTime);

            base.Update(gameTime);
        }

        
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            spriteBatch.Begin();

            //Rita ut kartan
            Map.DrawMap(spriteBatch);
            //Rita ut fienden
            EnemyController.Draw(spriteBatch);
			TowerController.Draw(spriteBatch);
            BuyMeny.draw(spriteBatch);
            spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}
