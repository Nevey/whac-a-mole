using Game.DI;

namespace Game.UI
{
    public class GameplayScreen : UIScreen
    {
        [Inject] private UIController uiController;

        public override UIScreens Screen => UIScreens.Gameplay;

        protected override void OnShow()
        {
            uiController.Show(UIWidgets.Score);
        }

        protected override void OnHide()
        {
            uiController.Hide(UIWidgets.Score);
        }
    }
}