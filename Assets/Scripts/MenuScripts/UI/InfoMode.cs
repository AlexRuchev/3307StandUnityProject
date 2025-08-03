using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InfoMode : MonoBehaviour
{
    private GameObject _canvas;
    private GameObject _lastMenu;
    public void UpdateCanvas(GameObject canvas,GameObject menu)
    {
        _canvas = canvas;
        _lastMenu = menu;
    }

    public void Back()
    {
        _canvas.SetActive(false);
        _lastMenu.SetActive(true);
        gameObject.SetActive(false);
    }
}