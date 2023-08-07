using System;
using System.Linq;
using UnityEngine;

namespace DefaultNamespace
{
    public class RagdollInfo : MonoBehaviour
    {
        [SerializeField] private Rigidbody[] _parts;

        private const float MinMagnitudeIsStop = 0.1f;
        
        public bool IsMoving => _parts.Select(x => x.velocity.magnitude).Average() > MinMagnitudeIsStop;
    }
}