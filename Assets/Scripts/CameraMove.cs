using System;
using DG.Tweening;
using UnityEngine;

public class CameraMove : MonoBehaviour
{
    [SerializeField] private float _durationMove = 4;
    
    [SerializeField] private Transform _lookZone;

    [SerializeField] private Transform _targetWatch;

    private bool _isLookZone;
    
    public void GoToLookZone()
    {
        transform.DOMove(_lookZone.position, _durationMove);

        _isLookZone = true;
    }

    private void Update()
    {
        if (!_isLookZone)
            return;
        
        transform.LookAt(_targetWatch);
    }
}