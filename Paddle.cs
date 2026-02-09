using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace MonoGame;

public class Paddle
{
    private Texture2D _sprite;
    private Vector2 _position;
    private int _velocity = 5;
    private Keys _left, _right;
    private bool _horizontal;

    public Paddle(Texture2D sprite, Vector2 position, Keys left, Keys right, bool horizontal)
    {
        _sprite = sprite;
        _position = position;
        _left = left;
        _right = right;
        _horizontal = horizontal;
    }

    public void Update(GameTime gameTime)
    {
        if (Keyboard.GetState().IsKeyDown(_left))
        {
            if (_horizontal)
            {
                _position.X -= _velocity;
            }
            else
            {
                _position.Y -= _velocity;
            }
        }

        if (Keyboard.GetState().IsKeyDown(_right))
        {
            if (_horizontal)
            {
                _position.X += _velocity;
            }
            else
            {
                _position.Y += _velocity;
            }
        }
    }

    public void Draw(GameTime gameTime, SpriteBatch spriteBatch)
    {
        spriteBatch.Draw(_sprite, _position, Color.White);
    }
}