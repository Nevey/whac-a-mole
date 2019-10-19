using Game.DI;

namespace Game.Application
{
    [Injectable(Singleton = true)]
    public class ApplicationStateMachine : StateMachines.StateMachine
    {
        public ApplicationStateMachine()
        {
            SetInitialState<MenuState>();
            AddTransition<MenuState, GameplayState>();
            AddTransition<GameplayState, GameOverState>();
            AddTransition<GameOverState, MenuState>();
        }
    }
}