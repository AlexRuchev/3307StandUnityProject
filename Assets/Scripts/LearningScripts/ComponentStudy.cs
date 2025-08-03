using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComponentStudy : MonoBehaviour
{
    [SerializeField] private GameObject bnk;
    [SerializeField] private GameObject cnv1;
    [SerializeField] private GameObject cnv2;
    [SerializeField] private GameObject controlCab;
    [SerializeField] private GameObject HMI;
    private int currentQustion;
    private List<int> questions = new List<int>() { 0, 1, 2, 3, 4 };
    [SerializeField] private GameObject resultOfTest;
    [SerializeField] private GameObject testingPanelText;
    [SerializeField] private GameObject counterQuastion;

    public void CheckAnsv(int ans)
    {
        Debug.Log(ans + " " + currentQustion);
        if (ans == currentQustion){
            
            TextUpdate(5);
        }
        else{
            questions= new List<int>() { 0, 1, 2, 3, 4 };
            
            TextUpdate(6);
        }

        InteracteSwith(false);

    }
    public void QuestionChoose()
    {
        if (questions.Count != 0)
        {
            var random = new System.Random();
            int currentQustionNum = random.Next(0, questions.Count);
            currentQustion = questions[currentQustionNum];
            Debug.Log("len=" + questions.Count);
            questions.Remove(currentQustion);
            Debug.Log(currentQustion);
            TextUpdate(currentQustion);
            InteracteSwith(true);
        }
        else {
            testingPanelText.GetComponent<TMPro.TextMeshProUGUI>().text = "Тест пройден";
        }
    }
    private void TextUpdate(int num)
    {
        switch (num)
        {
            case (0):
                testingPanelText.GetComponent<TMPro.TextMeshProUGUI>().text  = "Найдите бункер" ;
                break;
            case (1):
                testingPanelText.GetComponent<TMPro.TextMeshProUGUI>().text = "Найдите первый конвеер";
                break;
            case (2):
                testingPanelText.GetComponent<TMPro.TextMeshProUGUI>().text = "Найдите второй конвеер";
                break;
            case (3):
                testingPanelText.GetComponent<TMPro.TextMeshProUGUI>().text = "Найдите HMI";
                break;
            case (4):
                testingPanelText.GetComponent<TMPro.TextMeshProUGUI>().text = "Найдите Шкаф управления";
                break;
            case (5):
                resultOfTest.GetComponent<TMPro.TextMeshProUGUI>().text = "Правильный ответ";
                counterQuastion.GetComponent<TMPro.TextMeshProUGUI>().text = (6 - questions.Count).ToString();
                break;
            case (6):
                resultOfTest.GetComponent<TMPro.TextMeshProUGUI>().text = "Неправильный ответ";
                counterQuastion.GetComponent<TMPro.TextMeshProUGUI>().text = (6 - questions.Count).ToString();
                break;
        }

    }
    public void InteracteSwith(bool flag)
    {
        bnk.GetComponent<Microsoft.MixedReality.Toolkit.UI.Interactable>().enabled = flag;
        cnv1.GetComponent<Microsoft.MixedReality.Toolkit.UI.Interactable>().enabled = flag;
        cnv2.GetComponent<Microsoft.MixedReality.Toolkit.UI.Interactable>().enabled = flag;
        HMI.GetComponent<Microsoft.MixedReality.Toolkit.UI.Interactable>().enabled = flag;
        controlCab.GetComponent<Microsoft.MixedReality.Toolkit.UI.Interactable>().enabled = flag;
    }
}
