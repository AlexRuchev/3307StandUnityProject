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
        Text.text = "���� �� ���� ������ ��. ������� ��� � ��������� �������";
        btnFrontPlate[0].GetComponent<BackLightBtn>().backlightOn(true);
        HMIPosIndicator.SetActive(true);
    }
    public void ReverseSpeed()
    {
        Text.text = "������� � ������� �������";
        btnFrontPlate[0].GetComponent<BackLightBtn>().backlightOn(false);
        HMIPosIndicator.SetActive(false);
        btnFrontPlate[1].GetComponent<BackLightBtn>().backlightOn(true);
    }
    public void SpeedChangeInstruction()
    {
        Text.text = "�������� ��������";
        btnFrontPlate[1].GetComponent<BackLightBtn>().backlightOn(false);
        btnFrontPlate[3].GetComponent<BackLightBtn>().backlightOn(true);
    }
    public void End()
    {
        Text.text = "���";
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
