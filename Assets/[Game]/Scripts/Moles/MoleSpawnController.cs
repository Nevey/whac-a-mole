using Game.DI;
using Game.Spawning;
using UnityEngine;

namespace Game.Moles
{
    [Injectable(Singleton = true)]
    public class MoleSpawnController : SpawnController<Mole>
    {
        [SerializeField] private Mole molePrefab;

        protected override Mole Prefab => molePrefab;
    }
}