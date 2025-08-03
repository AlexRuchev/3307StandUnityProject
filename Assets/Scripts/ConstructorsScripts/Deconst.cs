using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Microsoft.MixedReality.Toolkit.Input;
using Microsoft.MixedReality.Toolkit.UI;
using UnityEngine.UI;
using TMPro;

public class Deconst : MonoBehaviour
{
    [SerializeField] private GameObject Lenta1;
    [SerializeField] private GameObject Lenta2;
    [SerializeField] private GameObject Buncker;
    [SerializeField] private GameObject ControlCabinet;
    [SerializeField] private GameObject HMI;
    [SerializeField] private GameObject Cabinet2;
    [SerializeField] private GameObject Platform;
    [SerializeField] private GameObject Info;
    [SerializeField] private GameObject CheckBox;

    [SerializeField] private GameObject ConvLenta1;
    [SerializeField] private GameObject ConvLenta2;
    private List<GameObject> Components;
    private int componentsOnPlace = 0;

    public void Deconstruct()
    {
        Destroy(ConvLenta1.GetComponent<Rigidbody>());
        Destroy(ConvLenta2.GetComponent<Rigidbody>());
        Vector3 platfomPos = Platform.transform.localPosition;
        Components = new List<GameObject>() { Lenta1, Lenta2, Buncker, ControlCabinet, HMI, Cabinet2 };
        for (int i = 0; i < 6;i++)
        {
            Components[i].GetComponent<BoxCollider>().enabled = true;
            if (i != 4) 
            {
                Components[i].transform.localScale = new Vector3(0.25f, 0.25f, 0.25f);
            }
            else
            {
                Components[i].AddComponent<Rigidbody>();
                Components[i].GetComponent<Rigidbody>().isKinematic = true;
            }
            if (i == 5)
            {
                Components[i].transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
            }
            ManupulatorSwitch(Components[i], true);

        }
        Buncker.transform.localPosition = new Vector3(-1.301f, platfomPos.y + 0.1f, 2.55f);
        Lenta1.transform.localPosition = new Vector3(-1.37699997f, platfomPos.y + 0.05f, 0.930000007f);
        Lenta2.transform.localPosition = new Vector3(-1.13f, platfomPos.y + 0.05f, 0.935000002f);
        ControlCabinet.transform.localPosition = new Vector3(-1.24199998f, platfomPos.y+0.22f, 1.30f);
        HMI.transform.localPosition= new Vector3(-1.24199998f, platfomPos.y + 0.22f, 1.8f);
        Cabinet2.transform.localPosition= new Vector3(-1.24199998f, platfomPos.y + 0.1f, 2.2f);
        CheckBox.SetActive(true);   
        
    }
    private void ManupulatorSwitch(GameObject Component, bool SwitchFlag)
    {
        Component.GetComponent<ObjectManipulator>().enabled = SwitchFlag;
        Component.GetComponent<NearInteractionGrabbable>().enabled = SwitchFlag;
    }
    public void Interaction()
    {

    }
    public void PutInPlace(int flag)
    {
        ManupulatorSwitch(Components[flag], false);
        Components[flag].GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezePosition;
        Components[flag].GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
        if (flag != 4)
        {
            Components[flag].transform.localRotation = new Quaternion(0, 0, 0, 1);
        }
        else
        {
            Destroy(Components[flag].GetComponent<Rigidbody>());
            Components[flag].transform.localRotation = new Quaternion(-0.5f, 0.5f, -0.5f, -0.5f);
        }
        Components[flag].GetComponent<Animator>().enabled = true;
        Components[flag].GetComponent<Animator>().SetBool("Puter", true);

        Components[flag].GetComponent<BoxCollider>().enabled = false;
        componentsOnPlace += 1;
        Info.GetComponent<TextMeshProUGUI>().text = "Количество уставноленных компонентов: \n" + componentsOnPlace.ToString() + "/6";
        if (componentsOnPlace == 6)
        {
            componentsOnPlace = 0;
            Info.GetComponent<TextMeshProUGUI>().text = "Задание выполнено";

            CheckBox.SetActive(false);
        }
        if (flag == 1) 
        {
            ConvLenta1.AddComponent<Rigidbody>();
            ConvLenta1.GetComponent<Rigidbody>().isKinematic = true;
        }
        if (flag == 2)
        {
            ConvLenta2.AddComponent<Rigidbody>();
            ConvLenta2.GetComponent<Rigidbody>().isKinematic = true;
        }
    }
public void BackToMenu()
    {
        for (int i=0;i< 6; i += 1)
        {
            PutInPlace(i);
        }
    }
}
