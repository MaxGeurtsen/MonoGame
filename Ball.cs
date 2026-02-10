using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MonoGame.Engine;

namespace MonoGame.Content;

public class Ball : GameObject
{
    private Vector2 _velocity;
    private int _increasedSpeed;

    public Ball(Texture2D sprite, Vector2 position) : base(sprite, position)
    {
        _velocity = new Vector2(1, 1);
        _increasedSpeed = 1;
    }

    public void Update(GameTime gameTime)
    {
        Position += _velocity * _increasedSpeed;
    }
}