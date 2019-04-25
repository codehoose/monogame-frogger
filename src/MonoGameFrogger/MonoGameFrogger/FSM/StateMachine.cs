using Microsoft.Xna.Framework;
using System.Collections.Generic;

namespace MonoGameFrogger.FSM
{
    class StateMachine
    {
        private readonly Dictionary<string, IState> _states = new Dictionary<string, IState>();
        private IState _currentState;

        public Game Game { get; }

        public StateMachine(Game game)
        {
            Game = game;
        }

        public void Add(string stateName, IState state)
        {
            _states[stateName] = state;
        }

        public void Change(string stateName)
        {
            if (!_states.ContainsKey(stateName))
                throw new KeyNotFoundException($"{stateName} is not a valid state!");

            if (_currentState != null)
            {
                _currentState.Exit();
            }

            _currentState = _states[stateName];
            _currentState.Enter();
        }

        public void Draw()
        {
            if (_currentState != null)
                _currentState.Draw();
        }

        public void Update(float deltaTime)
        {
            if (_currentState != null)
                _currentState.Update(deltaTime);
        }
    }
}
