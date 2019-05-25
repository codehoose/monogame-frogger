namespace MonoGameFrogger.Controllers
{
    class Cooldown
    {
        private readonly float _duration;

        private float _current = 1f;
        
        public bool Complete { get; private set; }

        public Cooldown(float duration = 1f)
        {
            _duration = duration;
        }

        public void Update(float deltaTime)
        {
            if (Complete) return;

            _current -= deltaTime / _duration;
            if (_current <= 0f)
            {
                Complete = true;
            }
        }
    }
}
