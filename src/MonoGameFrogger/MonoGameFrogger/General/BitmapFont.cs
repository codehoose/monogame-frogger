using Microsoft.Xna.Framework;

namespace MonoGameFrogger.General
{
    class BitmapFont
    {
        private readonly SpriteSheet _sprite;

        public BitmapFont(SpriteSheet sprite)
        {
            _sprite = sprite;
        }

        public void Draw(string msg, Vector2 position, Color color)
        {
            var pos = position;

            foreach(char ch in msg)
            {
                var frame = ch - '!';
                if (frame >= 0)
                {
                    _sprite.Draw(pos, frame, color);
                }

                pos += new Vector2(_sprite.CellWidth, 0);
            }
        }
    }
}
