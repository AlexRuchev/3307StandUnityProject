using System.Collections;
using System.Collections.Generic;
using Microsoft.MixedReality.Toolkit.UI.BoundsControl;
using UnityEngine;
using Microsoft.MixedReality.Toolkit.Input;
using Microsoft.MixedReality.Toolkit.UI;

public class HidenStandComponetns : MonoBehaviour
{
    [SerializeField] private GameObject[] StandComponents;
    private bool meshFlag = true;
    private bool boundsFlag = false;
    [SerializeField] private GameObject[] Buttons;
    private Quaternion[] startRotation;
    private bool buttonsMove=true;
    [SerializeField] private GameObject HMI;
    [SerializeField] private GameObject Quad;

    private void Start()
    {
        startRotation = new Quaternion[7];
        for(int i=0;i<6;i++)
        {
            startRotation[i] = StandComponents[i].transform.rotation;
        }
        startRotation[6] = HMI.transform.rotation;
    }
    public void ActiveteMeshes()
    {
        if (meshFlag)
        {
            for (int i = 0; i < 6; i++)
            {
                StandComponents[i].transform.rotation = startRotation[i];
            }
            HMI.transform.rotation = startRotation[6];
        }
        meshFlag = !meshFlag;
        foreach (GameObject obj in StandComponents)
        {
            obj.GetComponent<MeshRenderer>().enabled = meshFlag;
            obj.GetComponent<NearInteractionGrabbable>().enabled = meshFlag;
            obj.GetComponent<ObjectManipulator>().enabled = meshFlag;
        }
        Quad.GetComponent<MeshRenderer>().enabled = meshFlag;
        HMI.GetComponent<NearInteractionGrabbable>().enabled = meshFlag;
        HMI.GetComponent<ObjectManipulator>().enabled = meshFlag;

    }
    public void ActiveBounds()
    {
        boundsFlag = !boundsFlag;
        foreach(GameObject obj in StandComponents)
        {
            obj.GetComponent<BoundsControl>().enabled = boundsFlag;
        }
    }
    public void btnActive()
    {
        buttonsMove = !buttonsMove;
        foreach(GameObject obj in Buttons)
        {
            obj.SetActive(buttonsMove);
            obj.GetComponent<NearInteractionGrabbable>().enabled = buttonsMove;
            obj.GetComponent<ObjectManipulator>().enabled = buttonsMove;
        }
    }
 }
