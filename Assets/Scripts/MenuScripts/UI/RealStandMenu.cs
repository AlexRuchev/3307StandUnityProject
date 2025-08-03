using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RealStandMenu : MonoBehaviour
{
    [SerializeField] GameObject HidenStand;
    [SerializeField] GameObject PrevMenu;
    public void ActiveHudenStand()
    {
        HidenStand.SetActive(true);
    }
    public void Back()
    {
        HidenStand.SetActive(false);
        PrevMenu.SetActive(true);
        gameObject.SetActive(false);
    }
}
