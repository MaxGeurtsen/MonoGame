using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using MonoGame.Engine;

namespace MonoGame;

public class Paddle: GameObject
{
    private const int Velocity = 5;
    private readonly Keys _left, _right;
    private readonly bool _horizontal;
    private bool _ai = true;

    public Paddle(Texture2D sprite, Vector2 position, Keys left, Keys right, bool horizontal)
    {
        Sprite = sprite;
        Position = position;
        _left = left;
        _right = right;
        _horizontal = horizontal;
    }

    public void Update(GameTime gameTime)
    {
        Move(gameTime);
    }

    public void Draw(GameTime gameTime, SpriteBatch spriteBatch)
    {
        spriteBatch.Draw(Sprite, Position, Color.White);
    }


    private void AiMove(GameTime gameTime)
    {
        var time = gameTime.TotalGameTime.TotalSeconds % 2;

        if (time <= 1)
        {
            MoveLeft();
        }
        else
        {
            MoveRight();
        }
    }

    private void MoveLeft()
    {
        if (_horizontal)
        {
            Position.X -= Velocity;
        }
        else
        {
            Position.Y -= Velocity;
        }
    }

    private void MoveRight()
    {
        if (_horizontal)
        {
            Position.X += Velocity;
        }
        else
        {
            Position.Y += Velocity;
        }
    }

    private void Move(GameTime gameTime)
    {
        if (Keyboard.GetState().IsKeyDown(_left))
        {
            _ai = false;
            MoveLeft();
        }

        if (Keyboard.GetState().IsKeyDown(_right))
        {
            _ai = false;
            MoveRight();
        }

        if (_ai)
        {
            AiMove(gameTime);
        }
    }
}