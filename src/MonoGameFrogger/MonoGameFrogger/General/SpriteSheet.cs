using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;

namespace MonoGameFrogger.General
{
    class SpriteSheet
    {
        private readonly Texture2D _texture;
        private readonly SpriteBatch _spriteBatch;
        private readonly int _columns;
        private readonly int _rows;

        public int CellWidth { get; }

        public int CellHeight { get; }

        public SpriteSheet(Texture2D texture, SpriteBatch spriteBatch, int cellWidth, int cellHeight)
        {
            _texture = texture;
            _spriteBatch = spriteBatch;
            CellWidth = cellWidth;
            CellHeight = cellHeight;

            _columns = _texture.Width / CellWidth;
            _rows = _texture.Height / CellHeight;
        }

        public void Draw(Vector2 position, int frame, Color color)
        {
            if (frame < 0 || frame >= _columns * _rows)
                throw new ArgumentOutOfRangeException($"{frame} is out of range!");

            var column = frame % _columns;
            var row = frame / _columns;
            var x = column * CellWidth;
            var y = row * CellHeight;

            _spriteBatch.Draw(_texture,
                             position,
                             new Rectangle(x, y, CellWidth, CellHeight),
                             color);
        }
    }
}
