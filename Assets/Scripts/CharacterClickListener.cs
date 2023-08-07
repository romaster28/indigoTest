using System;
using System.Linq;
using UnityEngine;

public class CharacterClickListener : MonoBehaviour
{
    [SerializeField] private Collider[] _allowedParts;

    [SerializeField] private Camera _camera;

    private bool _clicked;
    
    private const float MaxDistance = 500;

    public event Action<RaycastHit> Clicked;

    private void Update()
    {
        if (_clicked || !Input.GetMouseButtonDown(0))
            return;

        Ray ray = _camera.ScreenPointToRay(Input.mousePosition);

        if (!Physics.Raycast(ray, out RaycastHit hit, MaxDistance))
            return;

        Collider hitCollider = hit.collider;
        
        if (!_allowedParts.Contains(hitCollider))
            return;
        
        Clicked?.Invoke(hit);

        _clicked = true;
    }
}