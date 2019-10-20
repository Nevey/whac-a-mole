using Game.DI;

namespace Game.UI
{
    /// <summary>
    /// Core object for UIController to use.
    /// Extend from this class to add new ways of handling UI, much like UIScreen and UIWidget.
    /// </summary>
    public abstract class UIView : CardboardCoreBehaviour
    {
        protected abstract void OnShow();
        protected abstract void OnHide();

        public void Show()
        {
            gameObject.SetActive(true);
            OnShow();
        }

        public void Hide()
        {
            gameObject.SetActive(false);
            OnHide();
        }
    }
}