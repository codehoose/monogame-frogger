using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using MonoGameFrogger.General;
using MonoGameFrogger.Models;
using System;

namespace MonoGameFrogger.Views
{
    class PlayerView : BaseView
    {
        private readonly SpriteSheet _blocks;
        private readonly PlayerModel _model;

        public PlayerView(ContentManager contentManager, 
                          SpriteBatch spriteBatch,
                          PlayerModel playerModel) 
            : base(contentManager, spriteBatch)
        {
            var blocksTexture = contentManager.Load<Texture2D>("blocks");
            _blocks = new SpriteSheet(blocksTexture, spriteBatch, 16, 16);
            _model = playerModel;
        }

        public override void Draw()
        {
            var x = Math.Round(_model.Position.X, 0, MidpointRounding.AwayFromZero);
            var y = Math.Round(_model.Position.Y, 0, MidpointRounding.AwayFromZero);

            _blocks.Draw(new Vector2((int)x, (int)y), _model.Frame, Color.White, _model.Flip);
        }
    }
}
