using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrderMode : MonoBehaviour
{
    [SerializeField] GameObject Lenta1InstructionMenu;
    [SerializeField] GameObject ModeSelectionMenu;
    public void toLenta1Instr()
    {
        Lenta1InstructionMenu.SetActive(true);
        gameObject.SetActive(false);
    }
    public void BackToMenu()
    {
        ModeSelectionMenu.SetActive(true);
        gameObject.SetActive(false);
    }
}
