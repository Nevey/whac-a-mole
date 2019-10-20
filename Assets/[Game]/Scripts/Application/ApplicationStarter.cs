using Game.DI;
using UnityEngine;

namespace Game.Application
{
    /// <summary>
    /// The start of the flow of the application. Creates the ApplicationStateMachine and starts it.
    /// </summary>
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