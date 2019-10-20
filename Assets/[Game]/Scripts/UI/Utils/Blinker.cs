using Game.DI;
using Game.Timers;
using UnityEngine;

namespace Game.UI
{
    public class Blinker : CardboardCoreBehaviour
    {
        [Inject] private TimerController timerController;

        [SerializeField] private bool autoStart = true;
        [SerializeField] private float blinkDuration = 1f;

        protected override void Awake()
        {
            base.Awake();

            if (autoStart)
            {
                StartTimer();
            }
        }

        protected override void OnDestroy()
        {
            StopTimer();
            base.OnDestroy();
        }

        private void StartTimer()
        {
            timerController.StartTimer(this, blinkDuration, ToggleVisibility, false);
        }

        private void StopTimer()
        {
            timerController.KillTimer(this);
        }

        private void ToggleVisibility()
        {
            gameObject.SetActive(!gameObject.activeSelf);
            StartTimer();
        }

        public void StartBlinking()
        {
            StartTimer();
        }

        public void StopBlinking()
        {
            StopTimer();
        }
    }
}