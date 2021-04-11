using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextScaler : MonoBehaviour
{
     private RectTransform _transform;
    [SerializeField] private Vector3 _normalScale;
    [SerializeField] private Vector3 _topScale;
    private void OnEnable()
    {
        CameraChanger.CameraChanged += ChangeTextScale;
    }

    private void Start()
    {
        _transform = gameObject.GetComponent<RectTransform>();
    }

    public void ChangeTextScale(bool isTopCamera)
    {
        if (isTopCamera)
        {
            _transform.localScale = _topScale;
            
        }
        else
        {
            _transform.localScale = _normalScale;
        }
    }

    private void OnDisable()
    {
        CameraChanger.CameraChanged -= ChangeTextScale;
    }
    
}
