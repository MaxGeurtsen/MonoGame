using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MonoGame.Engine;

namespace MonoGame.Content;

public class Ball: GameObject
{
    private Vector2 _velocity;
    private int _increasedSpeed;

    public Ball(Texture2D sprite, Vector2 position)
    {
        Sprite = sprite;
        Position = position;
        _velocity = new Vector2(1, 1);
        _increasedSpeed = 1;
    }

    public void Update(GameTime gameTime)
    {
        Position += _velocity * _increasedSpeed;
    }

    public void Draw(GameTime gameTime, SpriteBatch spriteBatch)
    {
        spriteBatch.Draw(Sprite, Position, Color.White);
    }
}