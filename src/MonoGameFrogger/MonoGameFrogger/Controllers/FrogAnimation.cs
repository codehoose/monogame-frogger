using Microsoft.Xna.Framework;

namespace MonoGameFrogger.Controllers
{
    class FrogAnimation
    {
        private readonly int[] _frames;
        private float _slice;
        private float _current = 0f;
        private float _duration;
        private int _currentFrame = 0;
        private float _positionTime = 0f;
        private Vector2 _start;
        private Vector2 _end;

        public int CurrentFrame { get { return _frames[_currentFrame]; } }

        public bool Done { get; private set; }

        public Vector2 Position { get; private set; }

        public FrogAnimation(int[] frames, Vector2 start, Vector2 delta, float duration)
        {
            _frames = frames;
            _duration = duration;
            _slice = 1f / _frames.Length;
            _start = start;
            _end = _start + delta;
        }

        public void Update(float deltaTime)
        {
            if (Done) { return; }

            _current += deltaTime / _duration;
            if (_current >= _slice)
            {
                _current = _current - _slice;
                _currentFrame++;
                if (_currentFrame == _frames.Length)
                {
                    _currentFrame = _frames.Length - 1;
                    Position = _end;
                    Done = true;
                    return;
                }
            }

            _positionTime += deltaTime / _duration;
            Position = Vector2.Lerp(_start, _end, _positionTime);
        }
    }
}
