using System;
using Game.DI;
using Game.Scoring;
using Game.Spawning;
using Game.Timers;
using Game.Whacking;
using UnityEngine;

namespace Game.Moles
{
    public class Mole : CardboardCoreBehaviour, ISpawnable, IWhackable
    {
        [Inject] private TimerController timerController;

        [SerializeField, Range(0.1f, 3f)] private float minShowDuration = 0.5f;
        [SerializeField, Range (0.1f, 3f)] private float maxShowDuration = 2f;
        [SerializeField] private MoleView moleViewPrefab;

        private MoleView moleViewInstance;
        private Timer timerInstance;

        public Vector3 Position => transform.position;

        public event Action<ISpawnable> OnSpawnEvent;
        public event Action<ISpawnable> OnDespawnEvent;

        private void Show()
        {
            moleViewInstance = Instantiate(moleViewPrefab, transform);
            moleViewInstance.Show(StartTimer);
        }

        private void Hide()
        {
            moleViewInstance.Hide(OnHideComplete);
        }

        private void OnHideComplete()
        {
            OnDespawnEvent?.Invoke(this);

            moleViewInstance = null;
            Destroy(gameObject);
        }

        private void StartTimer()
        {
            float duration = UnityEngine.Random.Range(minShowDuration, maxShowDuration);
            timerInstance = timerController.StartTimer(this, duration, Despawn, false);
        }

        public void Spawn(Vector3 position)
        {
            transform.position = position;
            OnSpawnEvent?.Invoke(this);
            Show();
        }

        public void Despawn()
        {
            timerController.KillTimer(this);
            Hide();
        }

        public Score Hit()
        {
            int scoreValue = 10;

            if (timerInstance != null)
            {
                scoreValue =
                    Mathf.RoundToInt((10 / timerInstance.TargetDuration)
                    * (timerInstance.TargetDuration - timerInstance.CurrentDuration));
            }

            Despawn();

            return new Score(scoreValue);
        }
    }
}