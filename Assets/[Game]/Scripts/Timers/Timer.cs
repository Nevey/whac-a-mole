using System;
using UnityEngine;

namespace Game.Timers
{
    /// <summary>
    /// A simple Timer object running on Unity's deltaTime.
    /// </summary>
    public class Timer : MonoBehaviour
    {
        private bool isStarted;
        private float targetDuration;
        private float currentDuration;
        private Action callback;

        public float TargetDuration => targetDuration;
        public float CurrentDuration => currentDuration;

        private void Update()
        {
            if (!isStarted)
            {
                return;
            }

            currentDuration += Time.deltaTime;

            if (currentDuration >= targetDuration)
            {
                isStarted = false;
                callback?.Invoke();
            }
        }

        public void StartTimer(float duration, Action callback)
        {
            currentDuration = 0f;
            targetDuration = duration;
            isStarted = true;
            this.callback = callback;
        }

        public void Stop(bool handleCallback = false)
        {
            isStarted = false;

            if (handleCallback)
            {
                callback?.Invoke();
            }
        }
    }
}