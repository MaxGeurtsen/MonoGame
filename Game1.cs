using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using MonoGame.Content;

namespace MonoGame;

public class Game1 : Game
{
    private GraphicsDeviceManager _graphics;

    private SpriteBatch _spriteBatch;

    // ball
    private Ball _ball;

    // paddles
    private Paddle _paddleBottom;
    private Paddle _paddleTop;
    private Paddle _paddleLeft;
    private Paddle _paddleRight;

    // walls
    private Wall _wallLeft;
    private Wall _wallRight;
    private Wall _wallTop;
    private Wall _wallBottom;

    public Game1()
    {
        _graphics = new GraphicsDeviceManager(this);
        Content.RootDirectory = "Content";
        IsMouseVisible = true;
    }

    protected override void Initialize()
    {
        _graphics.PreferredBackBufferHeight = 720;
        _graphics.PreferredBackBufferWidth = 1280;
        _graphics.ApplyChanges();
        base.Initialize();
    }

    protected override void LoadContent()
    {
        _spriteBatch = new SpriteBatch(GraphicsDevice);

        // Ball
        Texture2D ballSprite = Content.Load<Texture2D>("ball");
        Vector2 ballPosition = new Vector2(_graphics.GraphicsDevice.Viewport.Width / 2,
            _graphics.GraphicsDevice.Viewport.Height / 2);
        _ball = new Ball(ballSprite, ballPosition);


        //paddles
        Texture2D paddleSprite = Content.Load<Texture2D>("paddle");
        _paddleBottom = new Paddle(paddleSprite, new Vector2(_graphics.GraphicsDevice.Viewport.Width / 2, 590),
            Keys.Left, Keys.Right, true);
        _paddleTop = new Paddle(paddleSprite, new Vector2(_graphics.GraphicsDevice.Viewport.Width / 2, 20),Keys.A,Keys.D,true);
        _paddleLeft = new Paddle(paddleSprite, new Vector2(20,_graphics.GraphicsDevice.Viewport.Height / 2),Keys.W,Keys.S,false);
        _paddleRight =  new Paddle(paddleSprite, new Vector2(590,_graphics.GraphicsDevice.Viewport.Height / 2),Keys.Up,Keys.Down,false);


        // walls
        Texture2D wallSprite = Content.Load<Texture2D>("wall");
        _wallBottom = new Wall(wallSprite, new Vector2(10, 610), true);
        _wallTop = new Wall(wallSprite, new Vector2(10, 10), true);
        _wallLeft = new Wall(wallSprite, new Vector2(10, 10), false);
        _wallRight = new Wall(wallSprite, new Vector2(610, 10), false);
    }

    protected override void Update(GameTime gameTime)
    {
        if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed ||
            Keyboard.GetState().IsKeyDown(Keys.Escape))
            Exit();

        _ball.Update(gameTime);
        
        _paddleBottom.Update(gameTime);
        _paddleTop.Update(gameTime);
        _paddleLeft.Update(gameTime);
        _paddleRight.Update(gameTime);

        base.Update(gameTime);
    }

    protected override void Draw(GameTime gameTime)
    {
        GraphicsDevice.Clear(Color.CornflowerBlue);

        _spriteBatch.Begin();

        // ball
        _ball.Draw(gameTime, _spriteBatch);

        //paddles
        _paddleBottom.Draw(gameTime, _spriteBatch);
        _paddleTop.Draw(gameTime, _spriteBatch);
        _paddleRight.Draw(gameTime, _spriteBatch);
        _paddleLeft.Draw(gameTime, _spriteBatch);

        // walls
        _wallBottom.Draw(gameTime, _spriteBatch);
        _wallTop.Draw(gameTime, _spriteBatch);
        _wallLeft.Draw(gameTime, _spriteBatch);
        _wallRight.Draw(gameTime, _spriteBatch);

        _spriteBatch.End();

        base.Draw(gameTime);
    }
}