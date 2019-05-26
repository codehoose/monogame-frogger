using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using MonoGameFrogger.General;
using MonoGameFrogger.Models;

namespace MonoGameFrogger.Views
{
    class GoalView : BaseView
    {
        private readonly SpriteSheet _blocks;
        private readonly GoalContainerModel _goals;

        public GoalView(ContentManager contentManager, SpriteBatch spriteBatch, GoalContainerModel goals)
            : base(contentManager, spriteBatch)
        {
            var blocksTexture = contentManager.Load<Texture2D>("blocks");
            _blocks = new SpriteSheet(blocksTexture, spriteBatch, 16, 16);
            _goals = goals;
        }

        public override void Draw()
        {
            foreach (var goal in _goals.Goals)
            {
                if (goal.Occupied)
                    _blocks.Draw(new Vector2(goal.Area.Left, goal.Area.Top), 10 + goal.Frame, Color.White);
            }
        }
    }
}
