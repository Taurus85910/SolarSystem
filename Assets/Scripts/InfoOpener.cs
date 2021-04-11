using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InfoOpener : MonoBehaviour
{
    [SerializeField] private GameObject _panel;
    public void InfoOpen()
    {
        _panel.SetActive(true);
    }
}
