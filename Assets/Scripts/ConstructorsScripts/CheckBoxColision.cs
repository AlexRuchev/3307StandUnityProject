using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckBoxColision : MonoBehaviour
{
    public string TagName;
    [SerializeField] private GameObject Stand;
    private List<string> objects = new List<string>() {"lenta1","lenta2","Buncker","ControlCabinet","HMI", "Cabinet2" };
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == TagName)
        {
            int index = objects.IndexOf(TagName);
            Stand.GetComponent<Deconst>().PutInPlace(index);
        }
        else
        {
            Debug.Log("WrongPlace");
        }
    }
}
