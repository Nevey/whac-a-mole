using System;
using UnityEngine;

namespace Game.Moles
{
    public class MoleView : MonoBehaviour
    {
        public void Show(Action callback)
        {
            callback?.Invoke();
        }

        public void Hide(Action callback)
        {
            callback?.Invoke();
        }
    }
}