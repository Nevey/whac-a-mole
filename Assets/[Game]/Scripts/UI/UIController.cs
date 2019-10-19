using System.Linq;
using Game.DI;
using UnityEngine;

namespace Game.UI
{
    // TODO: Generate code based on UIScreen extending classes
    public enum UIScreens
    {
        MainMenu,
        Gameplay,
        GameOver
    }

    // TODO: Generate code based on UIWidget extending classes
    public enum UIWidgets
    {
        Highscore,
        Score
    }

    [Injectable(Singleton = true)]
    public class UIController : MonoBehaviour
    {
        private UIScreen[] screens;
        private UIWidget[] widgets;
        private UIScreen currentUIScreen;

        private void Awake()
        {
            screens = GetComponentsInChildren<UIScreen>(true);
            for (int i = 0; i < screens.Length; i++)
            {
                screens[i].gameObject.SetActive(false);
            }

            widgets = GetComponentsInChildren<UIWidget>(true);
            for (int i = 0; i < widgets.Length; i++)
            {
                widgets[i].gameObject.SetActive(false);
            }
        }

        public void Show(UIScreens screen)
        {
            UIScreen newUIScreen = screens.FirstOrDefault(x => x.Screen == screen);

            if (newUIScreen == null)
            {
                return;
            }

            if (currentUIScreen != null)
            {
                currentUIScreen.Hide();
            }

            newUIScreen.Show();
            currentUIScreen = newUIScreen;
        }

        public void Show(UIWidgets widget)
        {
            UIWidget uiWidget = widgets.FirstOrDefault(x => x.Widget == widget);

            if (uiWidget == null)
            {
                return;
            }

            uiWidget.Show();
        }

        public void Hide(UIWidgets widget)
        {
            UIWidget uiWidget = widgets.FirstOrDefault(x => x.Widget == widget);

            if (uiWidget == null)
            {
                return;
            }

            uiWidget.Hide();
        }
    }
}