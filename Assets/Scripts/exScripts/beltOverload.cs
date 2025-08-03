using UnityEngine;

public class beltOverload : ExScript
{
    [SerializeField] protected BuckerPlatformMoving Bunker;
    float targetSpeedLenta1 = 750;
    float targetSpeedLenta2 = 750;
    float targetSpeedBunker = 125;
    private bool[] speedControls = new[] { false, false, false };
    public override void StartConditions()
    {
        Lenta1.Pusk();
        Lenta1.ReverseOff();
        Lenta1.SetSpeed(550);
        Lenta2.Pusk();
        Lenta2.ReverseOff();
        Lenta2.SetSpeed(550);
 
    }
    public override bool CheckAction(int btn)
    {
        float currentSpeed;
        Debug.Log("knopka"+btn);
        expectedAction = false;
        switch (btn)
        {
            
            case -1:
                currentSpeed = Lenta1.HMISpeed;
                expectedAction = checkSpeed(currentSpeed, targetSpeedLenta1, 0);
                break;
            case -2:
                currentSpeed = Lenta2.HMISpeed;
                expectedAction = checkSpeed(currentSpeed, targetSpeedLenta2, 1);
                break;
            case -3:
                currentSpeed = Bunker.HMIspeed;
                expectedAction = checkSpeed(currentSpeed, targetSpeedBunker, 2);
                break;
            
        }
        isLastStep = (speedControls[0] && speedControls[1] && speedControls[2]);
        return expectedAction;
    }
    private bool checkSpeed(float currentSpeed,float targetSpeed,int speedContNum)
    {
        bool checker = (currentSpeed == targetSpeed);
        speedControls[speedContNum] = checker;
        return checker;
    }
}
