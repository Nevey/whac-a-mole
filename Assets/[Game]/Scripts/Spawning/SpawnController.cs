using System;
using System.Collections.Generic;
using Game.Timers;
using UnityEngine;

namespace Game.Spawning
{
    public abstract class SpawnController<T> : MonoBehaviour
        where T : ISpawnable, new()
    {
        [Header("Spawn Timing")]
        [SerializeField] private Timer timerPrefab;
        [SerializeField, Range(0.01f, 5f)] private float minWaitDuration = 0.2f;
        [SerializeField, Range(0.1f, 5f)] private float maxWaitDuration = 2f;

        [Header("Spawn Points")]
        [SerializeField] private List<SpawnPoint> spawnPoints;

        private Timer timerInstance;
        private List<SpawnPoint> takenSpawnPoints = new List<SpawnPoint>();

        protected abstract T Prefab { get; }

        private void Awake()
        {
            timerInstance = Instantiate(timerPrefab);
            StartSpawnTimer();
        }

        private void OnDestroy()
        {
            timerInstance.Stop();
        }

        private void StartSpawnTimer()
        {
            float duration = UnityEngine.Random.Range(minWaitDuration, maxWaitDuration);
            timerInstance.StartTimer(duration, Spawn);
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
    }
}