using System;
using System.Collections.Generic;
using System.Linq;
using Game.DI;
using UnityEngine;

namespace Game.Timers
{
    [Injectable(Singleton = true)]
    public class TimerController : MonoBehaviour
    {
        [SerializeField] private Timer timerPrefab;

        private Dictionary<Timer, object> timerDict = new Dictionary<Timer, object>();

        public Timer StartTimer(object owner, float duration, Action callback)
        {
            Timer timerInstance = null;
            if (timerDict.ContainsValue(owner))
            {
                timerInstance = timerDict.FirstOrDefault(x => x.Value == owner).Key;
            }

            // If owner didn't own a timer
            if (timerInstance == null)
            {
                timerInstance = Instantiate(timerPrefab, transform);
                timerDict[timerInstance] = owner;
            }

            timerInstance.StartTimer(duration, () => 
            {
                KillTimer(owner);
                callback?.Invoke();
            });

            return timerInstance;
        }

        public void KillTimer(object owner, bool handleCallback = false)
        {
            Timer timerInstance = null;
            if (timerDict.ContainsValue(owner))
            {
                timerInstance = timerDict.FirstOrDefault(x => x.Value == owner).Key;
            }

            // It's ok if the timer instance didn't exist anymore
            if (timerInstance == null)
            {
                return;
            }

            timerDict.Remove(timerInstance);

            timerInstance.Stop(handleCallback);
            Destroy(timerInstance.gameObject);
        }
    }
}