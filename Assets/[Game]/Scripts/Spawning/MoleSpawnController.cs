using Game.Moles;
using UnityEngine;

namespace Game.Spawning
{
    public class MoleSpawnController : SpawnController<Mole>
    {
        [SerializeField] private Mole molePrefab;

        protected override Mole Prefab => molePrefab;
    }
}