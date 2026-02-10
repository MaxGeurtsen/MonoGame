using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace MonoGame.Engine;

public abstract class GameObject
{
    protected Texture2D Sprite;
    protected Vector2 Position;

    public GameObject(Texture2D texture, Vector2 position)
    {
        Sprite = texture;
        Position = position;
    }

    public void Update(GameTime gameTime)
    {
    }

    public void Draw(GameTime gameTime, SpriteBatch spriteBatch)
    {
        spriteBatch.Draw(Sprite, Position, Color.White);
    }
}