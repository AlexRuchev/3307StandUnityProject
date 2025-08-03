using UnityEngine.UI;
using UnityEngine;
using System;

public class MqttConnect : MonoBehaviour
{
    [SerializeField] private GameObject[] receivers;
    private int[] values = {0,0,0,0,0,0};
    [SerializeField] GameObject[] statusIndicator;
    [SerializeField] Material activeMat;
    [SerializeField] Material nonActiveMat;
    [SerializeField] private GameObject[] parValues;
    public void connectMQTT()
    {
        foreach(GameObject receiver in receivers)
        {
            receiver.GetComponent<mqttReceiver>().enabled = true;
        }
    }
    public void disconnectMQTT()
    {
        foreach (GameObject receiver in receivers)
        {
            receiver.GetComponent<mqttReceiver>().enabled = false;
        }
    }
    public void UpdateParValue(int topic,string message,out string topicName, out int value)
    {
        Debug.Log(topic);
        
        string speed = values[topic].ToString();
        char checkForSpeed = message[2];
        if (checkForSpeed == 'S')
        {
            speed = GetSpeedValue(message);
            Debug.Log(message);
            Debug.Log(checkForSpeed);
            message = "Speed";
        }
        switch (message)
        {
            case "{\"WS\":\"0\"}":
                statusIndicator[topic].GetComponent<Renderer>().material = nonActiveMat;
                topicName = "WS";
                value = 0;
                break;
            case "{\"WS\":\"1\"}":
                statusIndicator[topic].GetComponent<Renderer>().material = activeMat;
                topicName = "WS";
                value = 1;
                break;
            case "{\"Reverse\":\"1\"}":
                values[topic + 3] = 1;
                parValues[topic + 3].GetComponent<TMPro.TextMeshProUGUI>().text = "1";
                topicName = "Reverse";
                value = 1;
                break;
            case "{\"Reverse\":\"0\"}":
                values[topic + 3] = 1;
                parValues[topic + 3].GetComponent<TMPro.TextMeshProUGUI>().text = "0";
                topicName = "Reverse";
                value = 0;
                break;
            case "Speed":
                int.TryParse(speed, out values[topic]);
                Debug.Log(values[topic]);
                Debug.Log(topic);
                parValues[topic].GetComponent<TMPro.TextMeshProUGUI>().text = speed;
                topicName = "Speed";
                int.TryParse(speed,out value);
                break;
            default:
                topicName = "Err";
                value = -1;
                break;
        }
    }
    private string GetSpeedValue(string message)
    {
        string speed="";
        foreach(char sym in message)
        {
            bool checkNum = Char.IsDigit(sym);
            if (checkNum)
            {
                speed += sym;
            }
       }
        return speed;
    }
}
