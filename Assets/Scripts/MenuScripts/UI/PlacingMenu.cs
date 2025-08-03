using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Microsoft.MixedReality.Toolkit.UI;
using Microsoft.MixedReality.Toolkit.Input;

public class PlacingMenu : MonoBehaviour
{
    [SerializeField] private GameObject Stand;
    [SerializeField] private GameObject ModeSelection;
    [SerializeField] private GameObject Quad;
    public void SetLocation()
    {
        Destroy(Stand.GetComponent<Rigidbody>());
        Stand.GetComponent<ObjectManipulator>().enabled = false;
        Stand.GetComponent<NearInteractionGrabbable>().enabled = false;
        Stand.GetComponent<BoxCollider>().enabled = false;
        Quad.GetComponent<BoxCollider>().enabled = true;
        ModeSelection.SetActive(true);
        gameObject.SetActive(false);
    }
    public void SetSize()
    {
        float scale = gameObject.GetComponentInChildren<PinchSlider>().SliderValue;
        Stand.transform.localScale = new Vector3(scale, scale, scale);   
    }
}
