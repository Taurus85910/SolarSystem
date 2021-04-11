using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SphereCollider))]
public class Zoom : MonoBehaviour
{
    [SerializeField] private GameObject _camera;
    [SerializeField] private GameObject _button;
    [SerializeField] private CameraChanger _cameraChanger;
    private void OnMouseDown()
    {
        if (!_cameraChanger.IsTopCamera && !ZoomChecker.IsZoomed)
        {
            foreach (var i in FindObjectsOfType<TrailRenderer>())
                i.enabled = false;
            UIOpener uiOpener = FindObjectOfType<UIOpener>();
            uiOpener.IsOpen = true;
            uiOpener.ChangeVisibility();
            FindObjectOfType<Camera>().gameObject.SetActive(false);
            _camera.SetActive(true);
            ZoomChecker.IsZoomed = true;
            _button.SetActive(true);
        }
    }
    
    
}
