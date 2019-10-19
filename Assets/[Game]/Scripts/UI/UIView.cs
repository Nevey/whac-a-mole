using Game.DI;

namespace Game.UI
{
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