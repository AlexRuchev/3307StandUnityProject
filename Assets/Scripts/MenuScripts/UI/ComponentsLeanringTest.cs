using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComponentsLeanringTest : MonoBehaviour
{
    [SerializeField] private GameObject StudyMenu;

    public void ToStudyMenu()
    {
        StudyMenu.SetActive(true);
        gameObject.SetActive(false);
    }
}   
