using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace TowerDefenceGame {

    public class Game1 : Game {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        Menu meny;

        Healthbar hpbar;

        bool canclick = true;

        public Game1() {
            graphics = new GraphicsDeviceManager(this);
            graphics.PreferredBackBufferWidth = 950;
            graphics.PreferredBackBufferHeight = 800;
            Content.RootDirectory = "Content";
        }


        protected override void Initialize() {
            Assets.LoadContent(Content);
            this.IsMouseVisible = true;
            meny = new Menu(new Vector2(800, 0), 150, 800, true);

            hpbar = new Healthbar(Player.life, 200, 20);

            base.Initialize();
        }


        protected override void LoadContent() {

            spriteBatch = new SpriteBatch(GraphicsDevice);
            Assets.CreatePixel(GraphicsDevice);
            Map.BuildMap();

        }


        protected override void UnloadContent() {

        }


        protected override void Update(GameTime gameTime) {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // Om man klickar ge positionen till Menyn som kollar om man klickar på något
            if (Mouse.GetState().LeftButton == ButtonState.Pressed && canclick) {
                meny.MouseKlick(Mouse.GetState().Position);
                canclick = false;
            }

            //Kan göras bättre
            if (Mouse.GetState().LeftButton == ButtonState.Released)
                canclick = true;


            if (!Player.dead) {
                // Gör om meny till köp menyn
                if (meny.isMainMenu)
                    meny = new Menu(new Vector2(800, 0), 150, 800);
                
                TowerController.Update(gameTime);

                EnemyController.Update(gameTime);

                hpbar.Update(Player.life, new Vector2(20,20));
            } else {
                if (!meny.isMainMenu)
                    meny = new Menu(new Vector2(800, 0), 150, 800, true);
            }
            base.Update(gameTime);
        }


        protected override void Draw(GameTime gameTime) {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            spriteBatch.Begin();

            Map.DrawMap(spriteBatch);
            EnemyController.Draw(spriteBatch);
            TowerController.Draw(spriteBatch);
            meny.draw(spriteBatch);
            Player.Draw(spriteBatch);

            hpbar.Draw(spriteBatch);

            spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}
