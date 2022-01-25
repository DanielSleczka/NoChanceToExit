using UnityEngine;
using UnityEngine.Events;

namespace GameCore
{
    public class TimeSystem : MonoBehaviour
    {
        private float startTime;
        [SerializeField]
        private float duration = 5f;
        private float currentTime;
        private float currentTimeInSeconds;

        private UnityAction onCountEnded;
        private bool isCounting = false;

        public bool IsCountEnded()
        {
            return !isCounting;
        }

        public float GetCurrentTimeInSeconds()
        {
            return currentTimeInSeconds;
        }

        public float GetCurrentTimeInSecondsReversed()
        {
            return duration - currentTimeInSeconds;
        }

        public void OnCountEnded_AddListener(UnityAction callback)
        {
            onCountEnded += callback;
        }

        public void RemoveAllListeners()
        {
            onCountEnded = null;
        }

        public void Initialize()
        {
            startTime = Time.time;
            currentTime = 0f;
            isCounting = true;
        }

        public void UpdateCounting()
        {
            if (!isCounting)
                return;

            currentTime = (Time.time - startTime) / duration;
            currentTimeInSeconds = Time.time - startTime;
            if (currentTime > 1f)
            {
                onCountEnded?.Invoke();
                isCounting = false;
            }
        }


    }
}
