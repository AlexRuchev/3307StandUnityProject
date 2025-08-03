using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MqttValueGetter : MonoBehaviour
{
    [SerializeField] private int receiverNum;
    [SerializeField] private GameObject DataPanel;
    public void GetMqqtMessage(string msg)
    {
        int value;
        string topic;
        if (receiverNum == 3)
        {
            gameObject.GetComponent<UsersAutorizator>().GetMqqtMSG(msg);
        } 
        else
        {
            DataPanel.GetComponent<MqttConnect>().UpdateParValue(receiverNum, msg, out topic, out value);
            if (receiverNum != 2)
            {
                gameObject.GetComponent<Moving>().GetMessage(topic, value);
            }
        }
    }
}
