using System;
using UnityEngine;

namespace Game.Input
{
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