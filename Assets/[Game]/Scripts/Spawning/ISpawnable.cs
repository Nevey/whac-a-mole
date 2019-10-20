using System;
using UnityEngine;

namespace Game.Spawning
{
    /// <summary>
    /// Add to any object which needs to be spawned via a SpawnController
    /// </summary>
    public interface ISpawnable
    {
        void Spawn(Vector3 position);
        void Despawn();
        event Action<ISpawnable> OnSpawnEvent;
        event Action<ISpawnable> OnDespawnEvent;
    }
}