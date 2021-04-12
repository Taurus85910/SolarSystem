using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZoomOuter : MonoBehaviour
{
    [SerializeField] private GameObject _mainCamera;
    [SerializeField] private Material _material;
    public void Outing()
    {
        foreach (var i in FindObjectsOfType<TrailRenderer>())
            i.material = _material;
        ZoomChecker.IsZoomed = false;
        FindObjectOfType<Camera>().gameObject.SetActive(false);
        _mainCamera.SetActive(true);
        gameObject.SetActive(false);
        
        UIOpener uiOpener = FindObjectOfType<UIOpener>();
        uiOpener.IsOpen = false;
        uiOpener.ChangeVisibility();
    }
}
