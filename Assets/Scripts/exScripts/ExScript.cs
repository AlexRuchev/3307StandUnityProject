using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ExScript : MonoBehaviour
{
    [SerializeField] protected Moving Lenta1;
    [SerializeField] protected Moving Lenta2;
    protected int currentStep=1;
    protected bool expectedAction;
    public bool waitSpeed = false;
    public bool isLastStep = false;
    public abstract bool CheckAction(int btn);
    public abstract void StartConditions();
    public void resetScript()
    {
        currentStep = 1;
        isLastStep = false;
        expectedAction = true;
        StartConditions();
    }
    public void GettedSpeed(int getSpeedNum)
    {
        if (waitSpeed)
        {
            currentStep += 1;
            
            CheckAction(-1);
        }
    }
}
