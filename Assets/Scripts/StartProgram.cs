using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartProgram : MonoBehaviour
{
    [SerializeField] private GameObject _canvas;

    private void Start()
    {
        Time.timeScale = 0;
    }

    public void Clicked()
    {
        _canvas.SetActive(true);
        Time.timeScale = 1;
        gameObject.SetActive(false);
    }
}
