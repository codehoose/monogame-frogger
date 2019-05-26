using Microsoft.Xna.Framework;
using MonoGameFrogger.Models;

namespace MonoGameFrogger.Controllers
{
    /// <summary>
    /// Controls the collision detection of the goals.
    /// </summary>
    class GoalController : IController
    {
        private readonly PlayerModel _player;
        private readonly GoalContainerModel _goals;
        private readonly IReset _playerReset;

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="model">The player model</param>
        /// <param name="goals">The goal container</param>
        /// <param name="playerReset">The function to call when the player needs reset</param>
        public GoalController(PlayerModel model, GoalContainerModel goals, IReset playerReset)
        {
            _player = model;
            _goals = goals;
            _playerReset = playerReset;
        }

        /// <summary>
        /// Determines if the player has entered one of the goal areas.
        /// </summary>
        /// <param name="deltaTime">Delta time</param>
        public void Update(float deltaTime)
        {
            var playerArea = new Rectangle((int)_player.Position.X, (int)_player.Position.Y, 16, 16);

            foreach (var goal in _goals.Goals)
            {
                if (goal.Area.Intersects(playerArea))
                {
                    if (goal.Occupied)
                    {
                        _playerReset.Reset(ResetMode.Death);
                    }
                    else
                    {
                        goal.Occupied = true;
                        _playerReset.Reset(ResetMode.Goal);
                    }
                    return;
                }
            }
        }
    }
}
