using Game.DI;
using Utilities;

namespace Game.StateMachines
{
    public abstract class State
    {
        protected abstract void OnEnter();
        protected abstract void OnExit();

        public void Enter()
        {
            Injector.Inject(this);
            OnEnter();
            Log.Write($"{GetType().Name}");
        }

        public void Exit()
        {
            Injector.Dump(this);
            OnExit();
            Log.Write($"{GetType().Name}");
        }
    }
}