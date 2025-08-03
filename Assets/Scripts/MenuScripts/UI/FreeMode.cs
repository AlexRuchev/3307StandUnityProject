using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FreeMode : MonoBehaviour
{
    [SerializeField] private GameObject ModeSelection;
    public void BackToModeSelection()
    {
        ModeSelection.SetActive(true);
        gameObject.SetActive(false);    
    }
}
