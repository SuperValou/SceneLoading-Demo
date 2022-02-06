using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace Assets.Scripts.UI
{
    public class SmoothProgressBar : MonoBehaviour
    {
        // -- Inspector

        [Header("Values")]
        [Tooltip("Max proportion of the progress bar that can be filled each second. " +
                 "A value of 0.5 (50%) means that the progress bar will take at least 2 seconds to be fully filled.")]
        public float maxDeltaPerSecond = 1f;

        [Header("References")]
        public Slider slider;

        [Header("Events")]
        [Tooltip("Raised when the progress bar reach 100%.")]
        public UnityEvent onComplete;

        // -- Class
        
        private float _target;

        void Start()
        {
            slider.minValue = 0;
            slider.maxValue = 1;
            slider.value = 0;
        }

        void Update()
        {
            float currentValue = slider.value;
            if (currentValue == _target)
            {
                return;
            }

            float maxFillSpeed = Time.deltaTime * maxDeltaPerSecond;
            slider.value = Mathf.MoveTowards(currentValue, _target, maxFillSpeed);

            if (slider.value >= 1)
            {
                onComplete.Invoke();
            }
        }

        public void SetTargetProgress(float progress)
        {
            _target = Mathf.Clamp01(progress);
        }
    }
}