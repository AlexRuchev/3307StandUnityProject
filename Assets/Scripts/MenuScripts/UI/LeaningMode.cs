using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeaningMode : MonoBehaviour
{
    [SerializeField] private GameObject ConstructionMode;
    [SerializeField] private GameObject LearnComponentsMode;
    [SerializeField] private GameObject Info;
    [SerializeField] private GameObject OrderInstructionMenu;
    [SerializeField] private GameObject ModeSelection;
    [SerializeField] private GameObject CanvasInfo1;
    [SerializeField] private GameObject CanvasInfo2;
    [SerializeField] private GameObject CanvasInfo3;
    [SerializeField] private GameObject CanvasInfo4;
    [SerializeField] private GameObject ComponentsStudyMenu;
    [SerializeField] private GameObject RealStandMen;

    public void toInfo(int flag)
    {
        Info.SetActive(true);
        switch (flag)
        {
            case (1):
                CanvasInfo1.SetActive(true);
                Info.GetComponent<InfoMode>().UpdateCanvas(CanvasInfo1,gameObject);
                break;
            case (2):
                CanvasInfo2.SetActive(true);
                Info.GetComponent<InfoMode>().UpdateCanvas(CanvasInfo2,gameObject);
                break;
            case (3):
                CanvasInfo3.SetActive(true);
                Info.GetComponent<InfoMode>().UpdateCanvas(CanvasInfo3, gameObject);
                break;
            case (4):
                CanvasInfo4.SetActive(true);
                Info.GetComponent<InfoMode>().UpdateCanvas(CanvasInfo4, gameObject);
                break;
        }
        gameObject.SetActive(false);
    }
    public void BackToMain()
    {
        LearnComponentsMode.GetComponent<ComponetsStudyMenu>().activeTips();
        ModeSelection.SetActive(true);
        gameObject.SetActive(false);
    }
    public void ToConstruct()
    {
        ConstructionMode.SetActive(true);
        gameObject.SetActive(false);
    }
    public void ToLearnComponents()
    {
        LearnComponentsMode.SetActive(true);
        LearnComponentsMode.GetComponent<ComponetsStudyMenu>().activeTips();
        ComponentsStudyMenu.GetComponent<ComponetsStudyMenu>().activeObj();
        gameObject.SetActive(false);
    }
    public void ToOrderInstruction()
    {
        OrderInstructionMenu.SetActive( true);
        gameObject.SetActive(false);
    }
    public void ToRealStandMenu()
    {
        RealStandMen.SetActive(true);
        RealStandMen.GetComponent<RealStandMenu>().ActiveHudenStand();
        gameObject.SetActive(false);

    }
}
