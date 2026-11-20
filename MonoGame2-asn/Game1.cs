using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace MonoGame2_asn
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;

        Rectangle window;

        Texture2D circleTexture, rectangleTexture;

        SpriteFont textFont;

        Rectangle faceRect;
        Rectangle mouthRect;
        Rectangle mohawkRect;
        Rectangle leftEyeRect;
        Rectangle rightEyeRect;
        Rectangle toothRect;

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here

            this.Window.Title = "SQN";

            window = new Rectangle(0, 0, 800, 600);
            _graphics.PreferredBackBufferWidth = window.Width;
            _graphics.PreferredBackBufferHeight = window.Height;
            _graphics.ApplyChanges();

            faceRect = new Rectangle((window.Width / 2) - 150, (window.Height /2) - 150, 300, 300);
            mohawkRect = new Rectangle((faceRect.X * 2) - 150, (faceRect.Y / 2) / 2, 100, 200);

            mouthRect = new Rectangle((mohawkRect.X + 250) / 2, mohawkRect.Y + 280, 200, 100);
            toothRect = new Rectangle(mouthRect.Center.X, mouthRect.Center.Y + 10, 20, 40);

            leftEyeRect = new Rectangle(faceRect.X + 50, faceRect.Y + 100, 50, 50);
            rightEyeRect = new Rectangle(leftEyeRect.X + 140, leftEyeRect.Y, 50, 50);

            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            circleTexture = Content.Load<Texture2D>("circle");
            rectangleTexture = Content.Load<Texture2D>("rectangle");
            textFont = Content.Load<SpriteFont>("textFont");

            // TODO: use this.Content to load your game content here
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.DarkRed);

            // TODO: Add your drawing code here

            _spriteBatch.Begin();

            _spriteBatch.Draw(circleTexture, faceRect, Color.PeachPuff);
            _spriteBatch.Draw(circleTexture, leftEyeRect, Color.Black);
            _spriteBatch.Draw(circleTexture, rightEyeRect, Color.Black);
            _spriteBatch.Draw(circleTexture, mohawkRect, Color.Green);
            _spriteBatch.Draw(circleTexture, mouthRect, Color.Black);
            _spriteBatch.Draw(rectangleTexture, toothRect, Color.White);
            _spriteBatch.DrawString(textFont, "WHAT A CRAZY GUY!", new Vector2(faceRect.Center.X - 100, window.Height - 70), Color.Black);

            _spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
