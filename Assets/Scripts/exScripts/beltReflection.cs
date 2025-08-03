using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class beltReflection : ExScript
{
    [SerializeField] private BuckerPlatformMoving Bunker;
    private bool[] parControls = new[] { false, false, false };
    public override void StartConditions()
    {
        Lenta1.Pusk();
        Lenta1.ReverseOff();
        Lenta1.SetSpeed(550);
        Lenta2.Pusk();
        Lenta2.ReverseOff();
        Lenta2.SetSpeed(550);
        Bunker.Pusk();
        Bunker.SetSpeed(225);
    }
    public override bool CheckAction(int btn)
    {
        switch (btn)
        {
            case 1:
                if (!parControls[0]) parControls[0] = true;
                else expectedAction = false;
                break;
            case 5:
                if (!parControls[1]) parControls[1] = true;
                else expectedAction = false;
                break;
            case 9:
                if (!parControls[2]) parControls[2] = true;
                else expectedAction = false; 
                break;
            case 3:
                if (parControls[0] && parControls[1] && parControls[2]) isLastStep = true;
                else expectedAction = false;
                break;

        }
        return expectedAction;
    }
}
