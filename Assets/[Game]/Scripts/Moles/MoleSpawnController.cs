using Game.Spawning;
using UnityEngine;

namespace Game.Moles
{
    public class MoleSpawnController : SpawnController<Mole>
    {
        [SerializeField] private Mole molePrefab;

        protected override Mole Prefab => molePrefab;
    }
}