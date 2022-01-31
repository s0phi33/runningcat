using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace game
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        private Texture2D playerTexture;

        enum GameState
        {
            MainMenu,
           
            EndOfGame,
            GamePlay,
        }
        Texture2D PlayerTexture;
        Vector2 Position;


        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }

        GameState state = GameState.GamePlay;
        private bool pushedStartGameButton;
        private bool playerDied;
        private bool pushedMainMenuButton;
        private bool pushedRestartLevelButton;

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            

            base.Initialize();

            
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            

            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);
            Console.WriteLine("something");

            // TODO: use this.Content to load your game content here
            playerTexture = Content.Load<Texture2D>("cat");
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// game-specific content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here


                base.Update(gameTime);
                switch (state)
                {
                    case GameState.MainMenu:
                        UpdateMainMenu(gameTime);
                        break;
                    case GameState.GamePlay:
                        UpdateGameplay(gameTime);
                        break;
                    case GameState.EndOfGame:
                        UpdateEndOfGame(gameTime);
                        break;
                }

        }
        void UpdateMainMenu(GameTime gameTime)
        {
            // Respond to user input for menu selections, etc
            if (pushedStartGameButton)
                state = GameState.GamePlay;
        }

        void UpdateGameplay(GameTime gameTime)
        {
            // Respond to user actions in the game.
            // Update enemies
            // Handle collisions
            if (playerDied)
                state = GameState.EndOfGame;
        }

        void UpdateEndOfGame(GameTime gameTime)
        {
            // Update scores
            // Do any animations, effects, etc for getting a high score
            // Respond to user input to restart level, or go back to main menu
            if (pushedMainMenuButton)
                state = GameState.MainMenu;
            else if (pushedRestartLevelButton)
            {
                ResetLevel();
                state = GameState.GamePlay;
            }
        }

        private void ResetLevel()
        {
            throw new NotImplementedException();
        }


        private void DrawMainMenu(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // Make a 1x1 texture named pixel.  
            Texture2D pixel = new Texture2D(graphics.GraphicsDevice,1,1);

            // Create a 1D array of color data to fill the pixel texture with.  
            Color[] colorData = {
                        Color.White,
                    };

            // Set the texture data with our color information.  
            pixel.SetData<Color>(colorData);

            // Draw a fancy purple rectangle.  
            spriteBatch.Begin();
            spriteBatch.Draw(pixel, new Rectangle(0, 0, 300, 300), Color.Purple);
            spriteBatch.End();

            spriteBatch.Begin();
            Rectangle titleSafeRectangle = GraphicsDevice.Viewport.TitleSafeArea;
            DrawBorder(titleSafeRectangle, 5, Color.Red); // can draw any rectangle here 
            spriteBatch.End();

        }
        private void DrawBorder(Rectangle rectangleToDraw, int thicknessOfBorder, Color borderColor)
        {
            // Make a 1x1 texture named pixel.  
            Texture2D pixel = new Texture2D(graphics.GraphicsDevice, 1, 1);

            // Create a 1D array of color data to fill the pixel texture with.  
            Color[] colorData = {
                        Color.White,
                    };

            // Set the texture data with our color information.  
            pixel.SetData<Color>(colorData);
            // Draw top line 
            spriteBatch.Draw(pixel, new Rectangle(rectangleToDraw.X, rectangleToDraw.Y, rectangleToDraw.Width, thicknessOfBorder), borderColor);

            // Draw left line 
            spriteBatch.Draw(pixel, new Rectangle(rectangleToDraw.X, rectangleToDraw.Y, thicknessOfBorder, rectangleToDraw.Height), borderColor);

            // Draw right line 
            spriteBatch.Draw(pixel, new Rectangle((rectangleToDraw.X + rectangleToDraw.Width - thicknessOfBorder),
            rectangleToDraw.Y,
            thicknessOfBorder,
            rectangleToDraw.Height), borderColor);

            // Draw bottom line 
            spriteBatch.Draw(pixel, new Rectangle(rectangleToDraw.X,
            rectangleToDraw.Y + rectangleToDraw.Height - thicknessOfBorder,
            rectangleToDraw.Width,
            thicknessOfBorder), borderColor);
        }

        private void DrawGameplay(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);
            spriteBatch.Begin();
            spriteBatch.Draw(playerTexture,Position, null, Color.White, 0f, Vector2.Zero, 1f,
       SpriteEffects.None, 0f);
            spriteBatch.End();
        }

        private void DrawEndOfGame(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);
        }


        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {

            switch (state)
            {
                case GameState.MainMenu:
                    DrawMainMenu(gameTime);
                    break;
                case GameState.GamePlay:
                    DrawGameplay(gameTime);
                    break;
                case GameState.EndOfGame:
                    DrawEndOfGame(gameTime);
                    break;
            }

            base.Draw(gameTime);
        }
    }
}
