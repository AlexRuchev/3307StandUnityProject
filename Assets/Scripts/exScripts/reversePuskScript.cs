using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class reversePuskScript : ExScript
{
    public override void StartConditions()
    {
        Lenta1.Pusk();
        Lenta1.ReverseOff();
        Lenta1.SetSpeed(800);
    }
    public override bool CheckAction(int btn)
    {
        expectedAction = true;
        switch (currentStep)
        {
            case 1:
                if (btn == 2)
                {
                    currentStep += 1;
                }
                else
                {
                    expectedAction = false;
                }
                break;
            case 2:
                if (btn != 4)
                {
                    expectedAction = false;
                }
                else
                {
                    waitSpeed = true;
                }
                break;
            case 3:
                if (Lenta1.HMISpeed != 600)
                {
                    expectedAction = false;
                    Debug.Log(expectedAction);
                }
                else
                {
                    isLastStep = true;
                }
                waitSpeed = false;
                break;
        }
        return expectedAction;
    }
}
