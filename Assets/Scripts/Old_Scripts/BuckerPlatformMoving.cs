using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Microsoft.MixedReality.Toolkit.UI;
public class BuckerPlatformMoving : MonoBehaviour
{
    [SerializeField] private GameObject botMarker;
    [SerializeField] private GameObject topMarker;
    [SerializeField] private int objNum;
    [SerializeField] private GameObject InputSpeedMenu;
    [SerializeField] private GameObject Slider;
    private float maxHight;
    private float minHight;
    private bool workStatus = false;
    private bool isUp = true;
    private float distanse;
    private float _speed { set; get; } = 0.001f;
    public float HMIspeed;
    public void PowerSwitch()
    {
        workStatus = !workStatus;
        maxHight = topMarker.transform.position.y;
        minHight = botMarker.transform.position.y;
        distanse = maxHight - minHight;
        if (workStatus==true)
        {
            SendMessegeMQTT("{\"WS\":\"1\"}");
        }
        else
        {
            SendMessegeMQTT("{\"WS\":\"0\"}");
        }
    }
    public void Pusk()
    {
        if (!workStatus)
        {
            PowerSwitch();
        }
    }
    public void Stop()
    {
        if (workStatus)
        {
            PowerSwitch();
        }
    }
    public void ChangeDirection() {
        isUp = !isUp;
        _speed = _speed * -1f;
        transform.position += new Vector3(0, _speed, 0);
        if (isUp)
        {
            SendMessegeMQTT("{\"reverse\":\"1\"}");
        }
        else
        {
            SendMessegeMQTT("{\"reverse\":\"0\"}");
        }
        SendMessegeMQTT("{\"WS\":\"1\"}");
    }
    public void SetSpeed()
    {
        float speed;
        speed = InputSpeedMenu.GetComponent<SpeedPanel>().ApplySpeed(objNum);
        string messagaSpeed = speed.ToString();
        messagaSpeed = string.Format("\"Speed\":\"{0}\"", messagaSpeed);
        messagaSpeed = "{" + messagaSpeed + "}";
        Debug.Log(messagaSpeed);
        _speed = speed / 250000;
        SendMessegeMQTT(messagaSpeed);
        HMIspeed = speed;
    }
    public void SetSpeed(float speed)
    {
        string messagaSpeed = speed.ToString();
        messagaSpeed = string.Format("\"Speed\":\"{0}\"", messagaSpeed);
        messagaSpeed = "{" + messagaSpeed + "}";
        Debug.Log(messagaSpeed);
        _speed = speed / 250000;
        SendMessegeMQTT(messagaSpeed);
        HMIspeed = speed;
    }
    void FixedUpdate()
    {
        
        if (workStatus)
        {
            float currentHight = transform.position.y;
            float sliderPos = currentHight / distanse;
            Slider.GetComponent<PinchSlider>().SliderValue = sliderPos;
            if (currentHight > minHight && currentHight < maxHight)
            {
                transform.position += new Vector3(0, _speed, 0);
            }
        }
    }
    private void SendMessegeMQTT(string messege)
    {
        gameObject.GetComponent<mqttReceiver>().messagePublish = messege;
        gameObject.GetComponent<mqttReceiver>().Publish();
    }
    //public void GetMqqtMessage(string msg)
    //{
    //    if (msg == "Start")
    //    {
            
    //    }
    //    if (msg == "Stop")
    //    {
            
    //    }
    //}
}
