using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Microsoft.MixedReality.Toolkit.UI;
public class ComponetsStudyMenu : MonoBehaviour
{
    [SerializeField] private GameObject Lenta1;
    [SerializeField] private GameObject Lenta2;
    [SerializeField] private GameObject Bucker;
    [SerializeField] private GameObject HMI;
    [SerializeField] private GameObject ControlCabinet;
    [SerializeField] private GameObject TestMenu;
    [SerializeField] private GameObject LearnMenu;
    [SerializeField] private GameObject Tips;
    private List<GameObject> objects;

    public void activeTips()
    {
        Tips.SetActive(true);
    }

    public void ToComponentsLearnMenu()
    {
        LearnMenu.SetActive(true);
        ColidersSwitch(false);
        TipsSwicth(false);
        gameObject.SetActive(false);
        Tips.SetActive(false);
    }
    public void ToTestMenu()
    {
        TipsSwicth(false);
        Debug.Log('a');
        TestMenu.SetActive(true);
        Tips.SetActive(false);
        gameObject.SetActive(false);
    }
    private void ColidersSwitch(bool flag)
    {
        objects = new List<GameObject>() { Lenta1, Lenta2, Bucker, HMI, ControlCabinet };
        for (int i = 0; i < 5; i++)
        {
            objects[i].GetComponent<BoxCollider>().enabled = flag;
        }
    }
    private void TipsSwicth(bool flag) {
        for (int i = 0; i < 5; i++)
        {
            objects[i].GetComponent<ToolTipSpawner>().FocusEnabled = false;
        }
    }
    public void activeObj()
    {
        ColidersSwitch(true);
        TipsSwicth(true);
    }
}
