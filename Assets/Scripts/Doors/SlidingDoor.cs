using Packages.UniKit.Runtime.Extensions;
using UnityEngine;

namespace Assets.Scripts.Doors
{
    [RequireComponent(typeof(Animator))]
    public class SlidingDoor : MonoBehaviour
    {
        // -- Editor

        [Header("Animator constants")]
        [SerializeField]
        private string OnOpenTriggerName = "OnOpen";

        [SerializeField]
        private string OnCloseTriggerName = "OnClose";

        // -- Class

        private Animator _animator;

        void Start()
        {
            _animator = this.GetOrThrow<Animator>();
        }

        public void OnOpen()
        {
            _animator.ResetTrigger(OnCloseTriggerName);
            _animator.SetTrigger(OnOpenTriggerName);
        }

        public void OnClose()
        {
            _animator.ResetTrigger(OnOpenTriggerName);
            _animator.SetTrigger(OnCloseTriggerName);
        }
    }
}