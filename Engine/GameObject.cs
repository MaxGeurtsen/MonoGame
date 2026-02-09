using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace MonoGame.Engine;

public abstract class GameObject
{
    protected Texture2D Sprite;
    protected Vector2 Position;
    public void Update(GameTime gameTime){}
    public void Draw(GameTime gameTime){}
}