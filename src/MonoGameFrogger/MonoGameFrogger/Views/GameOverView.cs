using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using MonoGameFrogger.General;

namespace MonoGameFrogger.Views
{
    class GameOverView : BaseView
    {
        private BitmapFont _font;

        public GameOverView(ContentManager contentManager, SpriteBatch spriteBatch)
            : base(contentManager, spriteBatch)
        {
            var fontTexture = contentManager.Load<Texture2D>("font");
            
            var fontSprite = new SpriteSheet(fontTexture, spriteBatch, 8, 8);
            _font = new BitmapFont(fontSprite);
        }

        public override void Draw()
        {
            _font.Draw("GAME OVER!", new Vector2(100, 50), Color.Red);
            _font.Draw("PRESS SPACE TO PLAY AGAIN", new Vector2(100, 100), Color.White);
        }
    }
}
