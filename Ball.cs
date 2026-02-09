using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace MonoGame.Content;

public class Ball
{
    private Texture2D _sprite;
    private Vector2 _location;
    private Vector2 _velocity;
    private int _increasedSpeed;

    public Ball(Texture2D sprite, Vector2 location)
    {
        _sprite = sprite;
        _location = location;
        _velocity = new Vector2(1, 1);
        _increasedSpeed = 1;
    }

    public void Update(GameTime gameTime)
    {
        _location += _velocity * _increasedSpeed;
    }

    public void Draw(GameTime gameTime, SpriteBatch spriteBatch)
    {
        spriteBatch.Draw(_sprite, _location, Color.White);
    }
}