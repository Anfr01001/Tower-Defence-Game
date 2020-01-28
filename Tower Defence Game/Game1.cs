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
            map = new Map();
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

            base.Update(gameTime);
        }

        
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            spriteBatch.Begin();

            //Rita ut kartan
            map.DrawMap(spriteBatch);

            spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}
