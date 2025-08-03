using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private GameObject Placing;
    [SerializeField] private GameObject Info;
    [SerializeField] private GameObject Canvas;
    [SerializeField] private GameObject Stand;
    [SerializeField] private GameObject Quad;
    public void PlaceStand()
    {
        Placing.SetActive(true);
        Stand.SetActive(true);
        gameObject.SetActive(false);
        Quad.GetComponent<BoxCollider>().enabled = false;
    }
    public void TakeInfo()
    {
        Info.SetActive(true);
        Canvas.SetActive(true);
        Info.GetComponent<InfoMode>().UpdateCanvas(Canvas, gameObject);
        gameObject.SetActive(false);

    }
}
