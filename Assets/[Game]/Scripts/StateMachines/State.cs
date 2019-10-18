namespace Game.StateMachines
{
    public abstract class State
    {
        protected abstract void OnEnter();
        protected abstract void OnExit();

        public void Enter()
        {
            OnEnter();
        }

        public void Exit()
        {
            OnExit();
        }
    }
}