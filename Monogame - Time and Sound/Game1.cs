using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Security.Cryptography.X509Certificates;

namespace Monogame___Time_and_Sound
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;

        Texture2D bombTexture;
        Rectangle bombRect;
        SpriteFont timefont;
        Texture2D bombImageExpTexture;
        Rectangle bombImageExpRect;
        SoundEffect explode;

        MouseState mouseState;

        float seconds;



        Texture2D pliersTexture;


        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {       
            bombRect = new Rectangle(50, 50, 700, 400);
            _graphics.PreferredBackBufferWidth = 800;
            _graphics.PreferredBackBufferHeight = 500;
            _graphics.ApplyChanges();
            seconds = 0f;
            bombImageExpRect = new Rectangle(50, 50, 0, 0);

            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);
            bombImageExpTexture = Content.Load<Texture2D>("bombImage");
            bombTexture = Content.Load<Texture2D>("bomb");
            timefont = Content.Load<SpriteFont>("TimeFont");
            explode = Content.Load<SoundEffect>("explosion");
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            mouseState = Mouse.GetState();
            this.Window.Title = $"x = {mouseState.X}, y = {mouseState.Y}";

            seconds += (float)gameTime.ElapsedGameTime.TotalSeconds;
            if (seconds > 15)
            {
                seconds = 0f;
                explode.Play();
                bombImageExpRect.Width = _graphics.PreferredBackBufferWidth;
                bombImageExpRect.Height = _graphics.PreferredBackBufferHeight;
            }
            if (seconds ==  0)
            {
                bombRect
            }
                       


            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            _spriteBatch.Begin();

            _spriteBatch.Draw(bombImageExpTexture, bombImageExpRect, Color.White);
            _spriteBatch.Draw(bombTexture, bombRect, Color.White);
            _spriteBatch.DrawString(timefont, (15 - seconds).ToString("00.0"), new Vector2 (270, 200), Color.Black);


            _spriteBatch.End();


            base.Draw(gameTime);
        }
    }
}
