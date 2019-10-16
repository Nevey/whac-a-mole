using System;
using UnityEngine;

namespace Game.Spawning
{
    public class SpawnPoint : MonoBehaviour 
    {
        public event Action<SpawnPoint> SpawnPointFreedEvent;

        public void Spawn<T>(T prefab) where T : ISpawnable, new()
        {
            ISpawnable spawnable;

            Type type = typeof(T);
            if (type.IsSubclassOf(typeof(MonoBehaviour)))
            {
                MonoBehaviour monoBehaviour = Instantiate((MonoBehaviour)((object)prefab), transform);
                spawnable = monoBehaviour.GetComponent<T>();
            }
            else
            {
                spawnable = new T();
            }

            spawnable.Spawn(transform.position);
            spawnable.OnDespawnEvent += OnSpawnableDespawned;
        }

        private void OnSpawnableDespawned(ISpawnable spawnable)
        {
            spawnable.OnDespawnEvent -= OnSpawnableDespawned;
            SpawnPointFreedEvent?.Invoke(this);
        }
    }
}