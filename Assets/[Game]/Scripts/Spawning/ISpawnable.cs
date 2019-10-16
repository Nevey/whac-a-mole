using System;
using UnityEngine;

namespace Game.Spawning
{
    public interface ISpawnable
    {
        void Spawn(Vector3 position);
        void Despawn();
        event Action<ISpawnable> OnSpawnEvent;
        event Action<ISpawnable> OnDespawnEvent;
    }
}