using System;
using System.Linq;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class RagdollActivator : MonoBehaviour
{
    [SerializeField] private Rigidbody[] _parts;

    [SerializeField] private Collider[] _colliderParts;

    private Animator _animator;

    public bool IsActive => _animator.isActiveAndEnabled;
    
    public void Activate()
    {
        foreach (Rigidbody part in _parts) 
            part.isKinematic = false;

        foreach (Collider part in _colliderParts)
            part.isTrigger = false;

        _animator.enabled = false;
    }

    public void DeActivate()
    {
        foreach (Rigidbody part in _parts) 
            part.isKinematic = true;

        foreach (Collider part in _colliderParts)
            part.isTrigger = true;

        _animator.enabled = true;
    }

    private void Awake()
    {
        _animator = GetComponent<Animator>();
        
        DeActivate();
    }
}