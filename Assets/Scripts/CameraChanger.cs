using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CameraChanger : MonoBehaviour
{
    [SerializeField] private GameObject _camera;
    [SerializeField] private GameObject _topCamera;
    [SerializeField] private Transform _sun;

    private bool _isTopCamera = false;

    public static event UnityAction<bool> CameraChanged;

    public bool IsTopCamera => _isTopCamera;
    
    public void ChangeCamera()
    {
        if (!ZoomChecker.IsZoomed)
        {
            if (_isTopCamera)
            {
                _topCamera.SetActive(false);
                _camera.SetActive(true);
                _isTopCamera = false;
                _sun.position = new Vector3(0, 0, 0);
            }
            else
            {
                _camera.SetActive(false);
                _topCamera.SetActive(true);
                _isTopCamera = true;
                _sun.position = new Vector3(0, -15, 0);
            }
        }

        CameraChanged?.Invoke(_isTopCamera);
        
    }
}
