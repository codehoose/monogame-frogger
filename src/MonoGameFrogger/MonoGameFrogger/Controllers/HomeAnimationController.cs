using MonoGameFrogger.Models;

namespace MonoGameFrogger.Controllers
{
    class HomeAnimationController : IController
    {
        enum EyeState
        {
            Open,
            Closed
        }

        private readonly GoalContainerModel _goals;
        private readonly float _cooldownPeriod = 2f;
        private readonly float _flashPeriod = 0.5f;
        private float _timer = 0f;
        private float _currentCooldown;
        private EyeState _state = EyeState.Open;

        public HomeAnimationController(GoalContainerModel goals)
        {
            _goals = goals;
            _currentCooldown = _cooldownPeriod;
        }

        public void Update(float deltaTime)
        {
            _timer += deltaTime;
            var frame = 0;
            var newCooldown = _cooldownPeriod;
            if (_timer > _currentCooldown)
            {
                _timer = _timer - _currentCooldown;
                _state = _state == EyeState.Open ? EyeState.Closed : EyeState.Open;
            }

            if (_state == EyeState.Open)
            {
                frame = 1;
                newCooldown = _flashPeriod;
            }

            _currentCooldown = newCooldown;

            foreach (var goal in _goals.Goals)
            {
                goal.Frame = frame;
            }
        }
    }
}
