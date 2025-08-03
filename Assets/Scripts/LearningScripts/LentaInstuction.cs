using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class LentaInstuction : MonoBehaviour
{
    [SerializeField] private GameObject[] btnFrontPlate;
    [SerializeField] private GameObject testingPanelText;
    [SerializeField] private GameObject HMIPosIndicator;
    [SerializeField] private GameObject OrderChooseMenu;
    [SerializeField] private GameObject btnOrderInstr;
    [SerializeField] private GameObject btnLentaControl;
    private TMPro.TextMeshProUGUI Text;
    void Start()
    {
        Text = testingPanelText.GetComponent<TMPro.TextMeshProUGUI>();
    }
    public void StartInstruction()
    {
        btnOrderInstr.SetActive(true);
        btnLentaControl.SetActive(false);
        Text.text = "Лера че нить напиши пж. найдите чми и запустите конвейр";
        btnFrontPlate[0].GetComponent<BackLightBtn>().backlightOn(true);
        HMIPosIndicator.SetActive(true);
    }
    public void ReverseSpeed()
    {
        Text.text = "Пустите в обртную сторону";
        btnFrontPlate[0].GetComponent<BackLightBtn>().backlightOn(false);
        HMIPosIndicator.SetActive(false);
        btnFrontPlate[1].GetComponent<BackLightBtn>().backlightOn(true);
    }
    public void SpeedChangeInstruction()
    {
        Text.text = "Измените скорость";
        btnFrontPlate[1].GetComponent<BackLightBtn>().backlightOn(false);
        btnFrontPlate[3].GetComponent<BackLightBtn>().backlightOn(true);
    }
    public void End()
    {
        Text.text = "Все";
        btnFrontPlate[3].GetComponent<BackLightBtn>().backlightOn(false);
        btnOrderInstr.SetActive(false);
        btnLentaControl.SetActive(true);
    }
    public void BackToMenu()
    {
        OrderChooseMenu.SetActive(true);
        gameObject.SetActive(false);
        btnOrderInstr.SetActive(false);
        btnLentaControl.SetActive(true);
        HMIPosIndicator.SetActive(false);
    }
}
