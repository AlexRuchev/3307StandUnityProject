using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackLightBtn : MonoBehaviour
{
    [SerializeField] private Material whiteColorMat;
    [SerializeField] private Material redColorMat;
    private Material currentMaterial;
    public void backlightOn(bool red)
    {
        if (red==true)
        {
            gameObject.GetComponent<Renderer>().material = redColorMat;
        }
        else
        {
            gameObject.GetComponent<Renderer>().material = whiteColorMat;
        }
    }
}
