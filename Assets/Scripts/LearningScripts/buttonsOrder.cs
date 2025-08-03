using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class buttonsOrder : MonoBehaviour
{
    [SerializeField] private GameObject[] btns;
    private bool goEnd = false;

    public void pwrOn()
    {
         btns[0].SetActive(true);
   
    }
    public void pwrOf()
    {
        btns[3].SetActive(false);
        btns[0].SetActive(true);
        goEnd = true;
    }
    public void reverse()
    {
        if (!goEnd)
        {
            btns[0].SetActive(false);
            btns[1].SetActive(true);
        }
    }
    public void setSpeed()
    {
        btns[1].SetActive(false);
        btns[3].SetActive(true);
    }
    public void endInstruction()
    {
        if (goEnd) {
            btns[0].SetActive(false);
            goEnd = false;
        }
    }
}
