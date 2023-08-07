using System;
using UnityEngine;

namespace DefaultNamespace
{
    [RequireComponent(typeof(Animator))]
    public class CharacterController : MonoBehaviour
    {
        [SerializeField] private Transform _targetPartOnStandUp;
        
        private Animator _animator;
        
        private static readonly int GetUp = Animator.StringToHash("GetUp");

        public void StandUp()
        {
            transform.position = _targetPartOnStandUp.position;

            _animator.SetTrigger(GetUp);
        }

        private void Awake()
        {
            _animator = GetComponent<Animator>();
        }
    }
}