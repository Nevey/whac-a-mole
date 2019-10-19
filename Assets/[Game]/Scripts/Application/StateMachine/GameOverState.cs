using Game.DI;
using Game.StateMachines;
using Game.UI;

namespace Game.Application
{
    public class GameOverState : State
    {
        [Inject] private UIController uiController;

        protected override void OnEnter()
        {
            uiController.Show(UIScreens.GameOver);
        }

        protected override void OnExit()
        {
            
        }
    }
}