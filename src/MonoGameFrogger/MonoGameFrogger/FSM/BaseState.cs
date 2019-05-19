namespace MonoGameFrogger.FSM
{
    abstract class BaseState : IState
    {
        public abstract void Update(float deltaTime);

        public abstract void Draw();

        public abstract void Enter();

        public abstract void Exit();

        public StateMachine StateMachine { get; }

        public BaseState(StateMachine stateMachine)
        {
            StateMachine = stateMachine;
        }
    }
}
