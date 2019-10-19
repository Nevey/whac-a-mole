using Game.Application;
using Game.DI;
using Game.Input;
using UnityEngine;

namespace Game.UI
{
    public class MainMenuScreen : UIScreen
    {
        [Inject] private ApplicationStateMachine applicationStateMachine;
        [Inject] private UIController uiController;
        [Inject] private MouseInput mouseInput;

        public override UIScreens Screen => UIScreens.MainMenu;

        protected override void OnShow()
        {
            uiController.Show(UIWidgets.Highscore);
            mouseInput.TapEvent += OnTap;
        }

        protected override void OnHide()
        {
            uiController.Hide(UIWidgets.Highscore);
            mouseInput.TapEvent -= OnTap;
        }

        private void OnTap(Vector2 obj)
        {
            applicationStateMachine.ToState<GameplayState>();
        }
    }
}