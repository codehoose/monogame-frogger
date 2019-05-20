using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using MonoGameFrogger.General;
using MonoGameFrogger.Models;

namespace MonoGameFrogger.Views
{
    class FrogPositionView : BaseView
    {
        private BitmapFont _font;
        private readonly PlayerModel _model;

        public FrogPositionView(ContentManager contentManager, SpriteBatch spriteBatch, PlayerModel playerModel) 
            : base(contentManager, spriteBatch)
        {
            var fontTexture = contentManager.Load<Texture2D>("font");
            var fontSprite = new SpriteSheet(fontTexture, spriteBatch, 8, 8);
            _font = new BitmapFont(fontSprite);
            _model = playerModel;
        }

        public override void Draw()
        {
            var msg = _model.Position.ToString().Replace("{", "(").Replace("}", ")");
            _font.Draw(msg, new Vector2(4, 16), Color.Orange);
        }
    }
}
