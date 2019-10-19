using Game.DI;
using UnityEngine;

namespace Game.Application
{
    public class ApplicationStarter : CardboardCoreBehaviour
    {
        [Inject] private ApplicationStateMachine applicationStateMachine;

        protected override void Start()
        {
            base.Start();
            applicationStateMachine.Start();
        }
    }
}