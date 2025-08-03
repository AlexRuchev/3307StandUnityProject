using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HMISize : MonoBehaviour
{
    private bool isBig = false;
    public void changeSize()
    {
        if (!isBig)
        {

            gameObject.transform.position = transform.position + new Vector3(0, 0, -0.1f);
            transform.localScale = new Vector3(2, 2, 2); 
        }
        else
        {
            gameObject.transform.position = transform.position+ new Vector3(0, 0, 0.1f);
            transform.localScale = new Vector3(1, 1, 1);
        }
        isBig = !isBig;
    }
}
