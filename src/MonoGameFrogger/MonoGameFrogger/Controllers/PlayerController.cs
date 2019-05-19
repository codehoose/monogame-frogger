using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using MonoGameFrogger.Models;
using System.Linq;

namespace MonoGameFrogger.Controllers
{
    class PlayerController : IController
    {
        private static float MoveCooldownPeriod = 0.2f;
        private static float Distance = 8f;

        private readonly PlayerModel _model;
        private FrogAnimation _animation = null;

        public PlayerController(PlayerModel playerModel)
        {
            _model = playerModel;
        }

        public void Update(float deltaTime)
        {
            if (_animation != null && !_animation.Done)
            {
                _animation.Update(deltaTime);
                _model.Position = _animation.Position;
                _model.Frame = _animation.CurrentFrame;
                return;
            }

            _animation = null;

            var state = Keyboard.GetState();
            var pressedKeys = state.GetPressedKeys();
            if (pressedKeys.Contains(Keys.Up))
            {
                _model.Flip = SpriteEffects.None;
                _animation = new FrogAnimation(new int[] { 34, 33, 32, 34 },
                                               _model.Position, 
                                               new Vector2(0, -Distance), 
                                               MoveCooldownPeriod);
            }
            else if (pressedKeys.Contains(Keys.Down))
            {
                _model.Flip = SpriteEffects.FlipVertically;
                _animation = new FrogAnimation(new int[] { 34, 33, 32, 34 },
                                               _model.Position,
                                               new Vector2(0, Distance),
                                               MoveCooldownPeriod);
            }
            else if (pressedKeys.Contains(Keys.Left))
            {   
                _model.Flip = SpriteEffects.None;
                _animation = new FrogAnimation(new int[] { 37, 36, 35, 37 },
                                               _model.Position,
                                               new Vector2(-Distance, 0),
                                               MoveCooldownPeriod);
                
            }
            else if (pressedKeys.Contains(Keys.Right))
            {
                _model.Flip = SpriteEffects.FlipHorizontally;
                _animation = new FrogAnimation(new int[] { 37, 36, 35, 37 },
                                               _model.Position,
                                               new Vector2(Distance, 0),
                                               MoveCooldownPeriod);
            }
        }
    }
}
