using System;
using Game.Spawning;
using Game.Timers;
using UnityEngine;

namespace Game.Moles
{
    public class Mole : MonoBehaviour, ISpawnable
    {
        [SerializeField] private float showDuration = 1f;
        [SerializeField] private MoleView moleViewPrefab;
        [SerializeField] private Timer timerPrefab;

        private MoleView moleViewInstance;
        private Timer timerInstance;

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

            Destroy(moleViewInstance.gameObject);
            moleViewInstance = null;
        }

        private void StartTimer()
        {
            timerInstance.StartTimer(showDuration, Despawn);
        }

        public void Spawn(Vector3 position)
        {
            timerInstance = Instantiate(timerPrefab, transform);
            transform.position = position;
            OnSpawnEvent?.Invoke(this);
            Show();
        }

        public void Despawn()
        {
            Destroy(timerInstance.gameObject);
            Hide();
        }
    }
}