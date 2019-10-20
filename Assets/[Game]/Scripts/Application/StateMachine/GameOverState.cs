using Game.DI;
using Game.Scoring;
using Game.StateMachines;
using Game.UI;

namespace Game.Application
{
    public class GameOverState : State
    {
        [Inject] private UIController uiController;
        [Inject] private ScoreController scoreController;

        protected override void OnEnter()
        {
            scoreController.CheckForHighscore();
            uiController.Show(UIScreens.GameOver);
        }

        protected override void OnExit()
        {
            
        }
    }
}