using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class UIOpener : MonoBehaviour
{
    [SerializeField] private List<GameObject> _planetsNames;
    [HideInInspector] public bool IsOpen = false;

    public void ChangeVisibility()
    {
        if (!ZoomChecker.IsZoomed)
        {
            if (!IsOpen)
            {
                foreach (var i in _planetsNames)
                {
                    i.SetActive(true);
                }
                IsOpen = true;
            }
            else
            {
                foreach (var i in _planetsNames)
                {
                    i.SetActive(false);
                }
                IsOpen = false;
            }
        }
    }
}


