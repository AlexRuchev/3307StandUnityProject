using UnityEngine;

public class StartAndSpeedScript : ExScript
{
    public override void StartConditions ()
    {
        float speed = 500;
        Lenta1.SetSpeed(speed);
        Lenta1.Stop();
    }
    public override bool CheckAction(int btn)
    {
        expectedAction = true;
        switch (currentStep)
        {
            case 1:
                if (btn != 0)
                {
                    expectedAction = false;
                }
                else
                {
                    currentStep += 1;
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
                if (Lenta1.HMISpeed!=700)
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
