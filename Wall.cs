using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace MonoGame;

public class Wall
{
    Texture2D _sprite;
    private int x;
    private int y;
    public bool _horizontal;

    public Wall(Texture2D sprite, Vector2 location, bool horizontal)
    {
        _sprite = sprite;
        x = int.Parse(location.X.ToString());
        y = int.Parse(location.Y.ToString());
        _horizontal = horizontal;
    }

    public void Update(GameTime gameTime)
    {
    }

    public void Draw(GameTime gameTime, SpriteBatch spriteBatch)
    {
        // Desired final size on screen
        const int horizontalWidth = 800;
        const int horizontalHeight = 100;

        const int verticalWidth = 100;
        const int verticalHeight = 800;

        if (_horizontal)
        {
            // Draw unrotated
            var center = new Vector2(x + (horizontalWidth / 2f), y + (horizontalHeight / 2f));
            var origin = new Vector2(_sprite.Width / 2f, _sprite.Height / 2f);
            var scale = new Vector2(horizontalWidth / (float)_sprite.Width, horizontalHeight / (float)_sprite.Height);

            spriteBatch.Draw(
                _sprite,
                center,
                sourceRectangle: null,
                color: Color.White,
                rotation: 0f,
                origin: origin,
                scale: scale,
                effects: SpriteEffects.None,
                layerDepth: 0f);
        }
        else
        {
            // Rotate 90° so a horizontal sprite becomes a vertical wall
            var center = new Vector2(x + (verticalWidth / 2f), y + (verticalHeight / 2f));
            var origin = new Vector2(_sprite.Width / 2f, _sprite.Height / 2f);

            // Scale to the *pre-rotation* size (800x100). After rotating, it becomes 100x800 on screen.
            var scale = new Vector2(verticalHeight / (float)_sprite.Width, verticalWidth / (float)_sprite.Height);

            spriteBatch.Draw(
                _sprite,
                center,
                sourceRectangle: null,
                color: Color.White,
                rotation: MathHelper.PiOver2,
                origin: origin,
                scale: scale,
                effects: SpriteEffects.None,
                layerDepth: 0f);
        }
    }
}