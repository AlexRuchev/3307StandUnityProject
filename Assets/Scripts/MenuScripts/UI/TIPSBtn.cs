using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TIPSBtn : MonoBehaviour
{
    private bool isActive;
    [SerializeField] GameObject infoPanel;

    public void infoPanelState()
    {
        isActive = !isActive;
        infoPanel.SetActive(isActive);
    }
}
