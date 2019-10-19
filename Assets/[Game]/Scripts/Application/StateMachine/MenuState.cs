using Game.DI;
using Game.StateMachines;
using Game.UI;

namespace Game.Application
{
    public class MenuState : State
    {
        [Inject] private UIController uiController;

        protected override void OnEnter()
        {
            uiController.Show(UIScreens.MainMenu);
        }

        protected override void OnExit()
        {
            
        }
    }
}