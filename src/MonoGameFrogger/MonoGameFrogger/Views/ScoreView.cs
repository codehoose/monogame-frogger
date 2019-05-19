using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using MonoGameFrogger.General;
using MonoGameFrogger.Models;

namespace MonoGameFrogger.Views
{
    class ScoreView : BaseView
    {
        private BitmapFont _font;
        private PlayerModel _model;

        public ScoreView(ContentManager contentManager, 
                         SpriteBatch spriteBatch, 
                         PlayerModel playerModel) 
            : base(contentManager, spriteBatch)
        {
            var fontTexture = contentManager.Load<Texture2D>("font");
            var fontSprite = new SpriteSheet(fontTexture, spriteBatch, 8, 8);
            _font = new BitmapFont(fontSprite);
            _model = playerModel;
        }

        public override void Draw()
        {
            _font.Draw("1-UP", new Vector2(40, 0), Color.White);
            _font.Draw(_model.Score.ToString(), new Vector2(40, 8), Color.Red);

            _font.Draw("HI-SCORE", new Vector2(88, 0), Color.White);
            _font.Draw(_model.HiScore.ToString(), new Vector2(96, 8), Color.Red);

            for (int i = 0; i < _model.Lives; i++)
            {
                _font.Draw("/", new Vector2(i * 8, 30 * 8), Color.White);
            }

            _font.Draw("TIME", new Vector2(24 * 8, 31 * 8), Color.Yellow);
        }
    }
}
