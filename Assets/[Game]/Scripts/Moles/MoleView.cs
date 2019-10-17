using System;
using UnityEngine;

namespace Game.Moles
{
    // TODO: Create abstract view class or view interface
    public class MoleView : MonoBehaviour
    {
        public void Show(Action callback)
        {
            // TODO: Do custom visual stuff here
            callback?.Invoke();
        }

        public void Hide(Action callback)
        {
            // TODO: Do custom visual stuff here
            callback?.Invoke();
        }
    }
}