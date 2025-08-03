using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Microsoft.MixedReality.Toolkit.Experimental.UI;
public struct currentUser
{
    public string userName;
    public int accesLvl;
}
public class UsersAutorizator : MonoBehaviour
{
    private string inputLogin;
    private string inputPassword;
    [SerializeField] private MRTKUGUIInputField inputFieldLogNew;
    [SerializeField] private MRTKUGUIInputField inputFieldPasswordNew;
    [SerializeField] private MRTKUGUIInputField inputFieldLog;
    [SerializeField] private MRTKUGUIInputField inputFieldPassword;
    [SerializeField] private mqttReceiver MQTT;
    private string lastCmd;
    public currentUser user;
    [SerializeField] private GameObject ErrMessage;
    [SerializeField] private GameObject ErrMessageNew;
    [SerializeField] private GameObject NextMenu;
    [SerializeField] private GameObject AutorizeMenu;
    [SerializeField] private GameObject AddUserMenu;

    public void InputLogin()
    {
        inputLogin = inputFieldLog.text;
    }

    public void InputPassword()
    {
        inputPassword = inputFieldPassword.text;
    }
    public void NewUserLogin()
    {
        inputLogin = inputFieldLogNew.text;
    }

    public void NewUserPassword()
    {
        inputPassword = inputFieldPasswordNew.text;
    }

    public void AutorizationPublish()
    {
        lastCmd = "Autoriz";
        string message = inputLogin + " " + inputPassword + " "+ lastCmd;
        PublishMsg(message);
    }

    public void AddNewPublish()
    {
        lastCmd = "NewUser";
        string message = inputLogin + " " + inputPassword + " " + lastCmd;
        PublishMsg(message);
    }

    public void UpdateLvlPublish(string lvl)
    {
        lastCmd = "UpdateLvlAcces";
        string message = inputLogin + " " + lvl + " " + lastCmd;
        PublishMsg(message);
    }

    private void PublishMsg(string msg)
    {
        MQTT.messagePublish = msg;
        MQTT.Publish();
    }

    private void SuccessfulAuthorization()
    {
        user.userName = inputLogin;
        inputLogin = null;
        inputPassword = null;
        inputFieldLog.text = "";
        inputFieldPassword.text = "";
        ErrMessage.SetActive(false);
        AutorizeMenu.SetActive(false);
        NextMenu.SetActive(true);
        lastCmd = "";
    }

    private void ErrAuthorization()
    {
        inputFieldLog.text = "";
        inputFieldPassword.text = "";
        ErrMessage.SetActive(true);
        lastCmd = "";
    }

    private void SuccessfulAddUser()
    {
        user.userName = inputLogin;
        inputFieldLogNew.text = "";
        inputFieldPasswordNew.text = "";
        inputLogin = null;
        inputPassword = null;
        user.accesLvl = 0;
        AddUserMenu.SetActive(false);
        NextMenu.SetActive(true);
        ErrMessageNew.SetActive(false);
        lastCmd = "";
    }

    private void ErrAddUser()
    {
        inputFieldLogNew.text = "";
        inputFieldPasswordNew.text = "";
        ErrMessageNew.SetActive(true);
        lastCmd = "";
    }

    public void GetMqqtMSG(string msg)
    {
        switch (lastCmd)
        {
            case "Autoriz":
                if (msg == "A1") SuccessfulAuthorization();
                else if (msg == "A0") ErrAuthorization();
                if (msg == "L0") user.accesLvl = 0;
                else if (msg == "L1") user.accesLvl = 1;
                break;
            case "NewUser":
                if (msg == "N1") SuccessfulAddUser();
                else if (msg == "N0") ErrAddUser();
                break;
            case "UpdateLvlAcces":
                lastCmd = "";
                break;
        }
    }
    public void ChangeUser()
    {

    }
}
