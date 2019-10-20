using Game.DI;
using Game.Spawning;
using UnityEngine;

namespace Game.Moles
{
    /// <summary>
    /// Is Injectable.
    /// Spawns Mole objects based on SpawnController's core logic.
    /// </summary>
    [Injectable(Singleton = true)]
    public class MoleSpawnController : SpawnController<Mole>
    {
        [SerializeField] private Mole molePrefab;

        protected override Mole Prefab => molePrefab;
    }
}