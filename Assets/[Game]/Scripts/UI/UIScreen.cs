namespace Game.UI
{
    /// <summary>
    /// Extend from this to create your own UI Screen.
    /// Only one UI Screen will be active at all times.
    /// </summary>
    public abstract class UIScreen : UIView
    {
        public abstract UIScreens Screen { get; }
    }
}