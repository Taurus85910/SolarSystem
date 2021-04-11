using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotation : MonoBehaviour
{
    [SerializeField] private float _X;
    [SerializeField] private float _YStep;

    private float _currentY;

    private void Update()
    {
        if (Time.timeScale != 0)
        {
            transform.rotation = Quaternion.Euler(_X, _currentY, 0);
            _currentY += _YStep;

            if (_currentY > 360) _currentY = 0;
        }
    }
}