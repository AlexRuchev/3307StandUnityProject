using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExamScripts : MonoBehaviour
{
    private List<int> examScriptsCount = new List<int> {1,2,3,4};
    private int currentScript;
    public int btnNum;
    [SerializeField] private GameObject ExObj;
    private ExScript controllintScript;
    [SerializeField] private GameObject[] texts;
    [SerializeField] private GameObject successMsg;
    [SerializeField] private GameObject errMsg;
    [SerializeField] private UsersAutorizator user;
    public void ChooseScriptNumber()
    {
        for (int i = 0; i < 1; i += 1)
        {
            texts[i].SetActive(false);
        }
        if (examScriptsCount.Count != 0)
        {
            var random = new System.Random();
            int currentExamNum = 3;
            currentScript = examScriptsCount[currentExamNum-1];
            examScriptsCount.Remove(currentScript);
            texts[currentScript].SetActive(true);
            texts[0].SetActive(false);
            errMsg.SetActive(false);
            successMsg.SetActive(false);
            ActiveScript();
        }
        else
        {
            user.UpdateLvlPublish("1");
        }
    }
    private void ActiveScript()
    {
        switch (currentScript)
        {
            case 1:
                controllintScript = gameObject.GetComponent<StartAndSpeedScript>() ;
                Debug.Log("s1");
                break;
            case 2:
                controllintScript = gameObject.GetComponent<reversePuskScript>();
                Debug.Log("s2");
                break;
            case 3:
                controllintScript = gameObject.GetComponent<beltOverload>();
                Debug.Log("s3");
                break;
            case 4:
                controllintScript = gameObject.GetComponent<beltReflection>();
                Debug.Log("s4");
                break;
            case 5:
                break;
            case 6:
                break;
            
        }
        controllintScript.StartConditions();
    }
    public void StepController(int btn)
    {
        bool checkAction = controllintScript.CheckAction(btn);
        if (!checkAction)
        {
            controllintScript.resetScript();
            texts[currentScript].SetActive(false);
        }
        else
        {
            if (controllintScript.isLastStep)
            {

                texts[currentScript].SetActive(false);
                if (examScriptsCount.Count == 0)
                {
                    texts[0].SetActive(true);
                    texts[5].SetActive(true);
                }
                else successMsg.SetActive(true);
                
            }
        }
    }
    public void GettedSpeed(int speedSetterNum)
    {
        switch (speedSetterNum)
        {
            case 0:
                controllintScript.GettedSpeed(-1);
                Debug.Log("OKK");
                break;
            case 1:
                controllintScript.GettedSpeed(-2);
                Debug.Log("OKK1");
                break;
            case 2:
                controllintScript.GettedSpeed(-3);
                Debug.Log("OKK2");
                break;
        }
        
    }

}
