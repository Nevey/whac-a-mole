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

        private Timer GetTimer(object owner)
        {
            if (timerDict.ContainsValue(owner))
            {
                return timerDict.FirstOrDefault(x => x.Value == owner).Key;
            }
            
            return null;
        }

        private Timer CreateTimer(object owner)
        {
            Timer timerInstance = Instantiate(timerPrefab, transform);
            timerDict[timerInstance] = owner;

            return timerInstance;
        }

        private Timer GetOrCreateTimer(object owner)
        {
            Timer timerInstance = GetTimer(owner);

            if (timerInstance == null)
            {
                timerInstance = CreateTimer(owner);
            }

            return timerInstance;
        }

        public Timer StartTimer(object owner, float duration, Action callback, bool autoKill = true)
        {
            Timer timerInstance = GetOrCreateTimer(owner);

            timerInstance.StartTimer(duration, () => 
            {
                if (autoKill)
                {
                    KillTimer(owner);
                }

                callback?.Invoke();
            });

            return timerInstance;
        }

        public void KillTimer(object owner, bool handleCallback = false)
        {
            Timer timerInstance = GetTimer(owner);

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