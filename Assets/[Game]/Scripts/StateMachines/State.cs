using Game.DI;
using Utilities;

namespace Game.StateMachines
{
    /// <summary>
    /// Core State used by the StateMachine. Extend from this class to create your own State.
    /// </summary>
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