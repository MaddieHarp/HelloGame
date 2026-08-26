using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace HelloGame;

public class Game1 : Game
{
    private Texture2D _texture; 
    private Vector2 _position;

    private Vector2 _direction;
    private GraphicsDeviceManager _graphics;
    private SpriteBatch _spriteBatch;

    public Game1()
    {
        _graphics = new GraphicsDeviceManager(this);
        Content.RootDirectory = "Content";
        IsMouseVisible = true;
    }

    protected override void Initialize()
    {
        // // TODO: Add your initialization logic here
        // _graphics.PreferredBackBufferWidth = 1280;
        // _graphics.PreferredBackBufferHeight = 720;
    
        // // Apply the changes to update the window size
        // _graphics.ApplyChanges();

        
        base.Initialize();
    }

    protected override void LoadContent()
    {
        _spriteBatch = new SpriteBatch(GraphicsDevice);

        _texture = Content.Load<Texture2D>("smile1");

        // TODO: use this.Content to load your game content here

        MathHelper.Random rand = new ();
        _position = new Vector2(rand.NextFloat() * GraphicsDevice.Viewport.Width, rand.NextFloat() * GraphicsDevice.Viewport.Height);

        _direction = new Vector2(500 * rand.NextFloat() -50, 500 * rand.NextFloat() - 50);
        
        
    }

    protected override void Update(GameTime gameTime)
    {
        if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
            Exit();

        // TODO: Add your update logic here

        _position += _direction * (float)gameTime.ElapsedGameTime.TotalSeconds;

        if(_position.X < 0 || _position.X > GraphicsDevice.Viewport.Width - _texture.Width)
        {
            _direction.X *= -1;
        }

        if(_position.Y < 0 || _position.Y > GraphicsDevice.Viewport.Height - _texture.Height)
        {
            _direction.Y *= -1;
        }

        base.Update(gameTime);
    }

    protected override void Draw(GameTime gameTime)
    {
        GraphicsDevice.Clear(Color.Red);

        // TODO: Add your drawing code here

        _spriteBatch.Begin();

        _spriteBatch.Draw(_texture, _position, Color.White);

        _spriteBatch.End();

        base.Draw(gameTime);
    }
}
