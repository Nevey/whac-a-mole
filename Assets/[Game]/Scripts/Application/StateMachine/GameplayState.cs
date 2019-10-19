using Game.DI;
using Game.Moles;
using Game.StateMachines;
using Game.UI;

namespace Game.Application
{
    public class GameplayState : State
    {
        [Inject] private UIController uiController;
        [Inject] private MoleSpawnController moleSpawnController;

        protected override void OnEnter()
        {
            uiController.Show(UIScreens.Gameplay);
            moleSpawnController.StartSpawning();
        }

        protected override void OnExit()
        {
            moleSpawnController.StopSpawning();
        }
    }
}