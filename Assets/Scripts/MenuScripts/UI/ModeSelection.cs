using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ModeSelection : MonoBehaviour
{
    [SerializeField] private GameObject FreeMode;
    [SerializeField] private GameObject LearningMode;
    [SerializeField] private UsersAutorizator user;

    
    public void ToFreeMode()
    {
        if (user.user.accesLvl == 1)
        {
            FreeMode.SetActive(true);
            gameObject.SetActive(false);
        }
    }
    public void ToLeaningMode()
    {
        LearningMode.SetActive(true);
        gameObject.SetActive(false);
    }
    public void ApplicationQuit()
    {
        Application.Quit();
    }
}
