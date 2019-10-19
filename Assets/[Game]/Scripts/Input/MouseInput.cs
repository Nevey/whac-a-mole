using System;
using Game.DI;
using UnityEngine;

namespace Game.Input
{
    [Injectable(Singleton = true)]
    public class MouseInput : MonoBehaviour
    {
        public event Action<Vector2> TapEvent;

        private void Update()
        {
            if (UnityEngine.Input.GetMouseButtonDown(0))
            {
                TapEvent?.Invoke(UnityEngine.Input.mousePosition);
            }
        }
    }
}