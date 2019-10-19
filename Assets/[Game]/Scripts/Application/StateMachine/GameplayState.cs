using Game.DI;
using Game.Moles;
using Game.StateMachines;
using Game.Timers;
using Game.UI;

namespace Game.Application
{
    public class GameplayState : State
    {
        [Inject] private UIController uiController;
        [Inject] private MoleSpawnController moleSpawnController;
        [Inject] private TimerController timerController;
        [Inject] private ApplicationStateMachine applicationStateMachine;

        protected override void OnEnter()
        {
            uiController.Show(UIScreens.Gameplay);
            moleSpawnController.StartSpawning();

            timerController.StartTimer(this, 20f, GameTimerFinished);
        }

        protected override void OnExit()
        {
            moleSpawnController.StopSpawning();
        }

        private void GameTimerFinished()
        {
            applicationStateMachine.ToState<GameOverState>();
        }
    }
}