using System.Collections.Generic;
using Game.DI;
using Game.Timers;
using UnityEngine;

namespace Game.Spawning
{
    [Injectable(Singleton = true)]
    public abstract class SpawnController<T> : CardboardCoreBehaviour
        where T : ISpawnable, new()
    {
        [Inject] private TimerController timerController;

        [Header("Spawn Timing")]
        [SerializeField, Range(0.01f, 5f)] private float minWaitDuration = 0.2f;
        [SerializeField, Range(0.1f, 5f)] private float maxWaitDuration = 2f;

        [Header("Spawn Points")]
        [SerializeField] private List<SpawnPoint> spawnPoints;

        private List<SpawnPoint> takenSpawnPoints = new List<SpawnPoint>();

        protected abstract T Prefab { get; }

        private void StartSpawnTimer()
        {
            float duration = UnityEngine.Random.Range(minWaitDuration, maxWaitDuration);
            timerController.StartTimer(this, duration, Spawn);
        }

        private void Spawn()
        {
            StartSpawnTimer();

            SpawnPoint spawnPoint = GetAvailableSpawnPoint();
            if (spawnPoint == null)
            {
                return;
            }

            spawnPoint.SpawnPointFreedEvent += OnSpawnPointFreed;
            spawnPoint.Spawn(Prefab);
        }

        private void OnSpawnPointFreed(SpawnPoint spawnPoint)
        {
            spawnPoint.SpawnPointFreedEvent -= OnSpawnPointFreed;

            takenSpawnPoints.Remove(spawnPoint);
            spawnPoints.Add(spawnPoint);
        }

        private SpawnPoint GetAvailableSpawnPoint()
        {
            if (spawnPoints.Count == 0)
            {
                return null;
            }

            int randomIndex = UnityEngine.Random.Range(0, spawnPoints.Count);

            SpawnPoint spawnPoint = spawnPoints[randomIndex];
            spawnPoints.RemoveAt(randomIndex);
            takenSpawnPoints.Add(spawnPoint);

            return spawnPoint;
        }

        public void StartSpawning()
        {
            StartSpawnTimer();
        }

        public void StopSpawning()
        {
            timerController.KillTimer(this);
        }
    }
}