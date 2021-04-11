using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAt : MonoBehaviour
{
    [SerializeField] private Transform _target;
    [SerializeField] private Transform _targetTop;
    [SerializeField] private CameraChanger _cameraChanger;
    private void Update()
    {
        if (!_cameraChanger.IsTopCamera)
        transform.LookAt(_target);
        else
            transform.LookAt(_targetTop);
    }
    
}
