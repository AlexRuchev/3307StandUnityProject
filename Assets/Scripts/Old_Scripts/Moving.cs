using UnityEngine;
using Microsoft.MixedReality.Toolkit.UI;

public class Moving : MonoBehaviour
{
    private Rigidbody _conveyer;
    [SerializeField] private Rigidbody _botPartOfConv;
    [SerializeField] private Material _botMaterial;
    public float _speed = 0;
    private float _matirealSpeed = 0;
    private Material _material;
    private bool _moveStatus = false;
    [SerializeField] private GameObject _speedBar;
    [SerializeField] private GameObject _leftBaraban;
    [SerializeField] private GameObject _rightBaraban;
    private float _startSpeedBarStatus = 0.5f;
    private bool _alarmStatus=false;
    private bool _globalAlarm;
    [SerializeField] private GameObject _alarmLamp;
    [SerializeField] private bool _aboba;
    private Vector3 startpos;
    [SerializeField] GameObject MainStand;
    [SerializeField] GameObject InputSpeedMenu;
    [SerializeField] private int objnum;
    private bool reverse = false;
    public float HMISpeed;

    private void Start()
    {
        _conveyer = GetComponent<Rigidbody>();
        _material = GetComponent<MeshRenderer>().material;
        
    }
    void FixedUpdate()
    {

        if (_moveStatus)
        {
            _material.mainTextureOffset = new Vector2(0f, Time.time * _matirealSpeed * Time.deltaTime);
            Vector3 pos = _conveyer.position;
            //if (_aboba) {
            //    var random = new System.Random();
            //    float dispose = (float)(random.Next(-200, 200));
            //    if (dispose < 195 && dispose > -195)
            //    {
            //        dispose = dispose / 1000000000;
            //    }
            //    else
            //    {
            //        dispose = dispose / 10000000;
            //    }
            //    pos.z -= dispose;
            //}

            
            _conveyer.position += Vector3.left * _speed * Time.fixedDeltaTime;
            
            _conveyer.MovePosition(pos);
            _botMaterial.mainTextureOffset = new Vector2(0, Time.time * _matirealSpeed * -1 * Time.deltaTime);
            Vector3 pos1 = _botPartOfConv.position;
            _botPartOfConv.position += Vector3.right * _speed * Time.fixedDeltaTime;
            _botPartOfConv.MovePosition(pos1);
            
        }
        

    }
    public void PowerSwitch() {
        if (!_moveStatus)
        {
            _moveStatus = true;
            _speed = 0.1f;
            _matirealSpeed = -10;
            _speedBar.GetComponent<PinchSlider>().SliderValue = _speed / 2 + 0.5f;
            SetSpeedBaraban();

            if (_alarmStatus)
            {
                _alarmStatus = false;
            }
            startpos = _conveyer.position;
            if (_speed > 0)
            {
                _speedBar.GetComponent<PinchSlider>().SliderValue = 1;
            }
            else
            {
                _speedBar.GetComponent<PinchSlider>().SliderValue = 1;
            }
            SendMessegeMQTT("{\"WS\":\"1\"}");
        }
        else
        {
            _moveStatus = false;
            _speed = 0;
            _matirealSpeed = 0;
            _speedBar.GetComponent<PinchSlider>().SliderValue = 0.5f;
            //_speedBar.GetComponent<SliderSounds>().playTickSounds = false;
            SetSpeedBaraban();
            SendMessegeMQTT("{\"WS\":\"0\"}");
            _speedBar.GetComponent<PinchSlider>().SliderValue=0.5f;
        }
    }

    public void Stop()
    {
        if (_moveStatus)
        {
            PowerSwitch();
        }
    }

    public void Pusk()
    {
        if (!_moveStatus)
        {
            PowerSwitch();
        }
    }
    public void SpeedBar()
    {
        float posofBar = _speedBar.GetComponent<PinchSlider>().SliderValue;
        if (posofBar == 1)
        {
            _speedBar.GetComponent<PinchSlider>().SliderValue = 0;
        }
        else if (posofBar == 0){
            _speedBar.GetComponent<PinchSlider>().SliderValue = 1;
        }
    }
    private void SetSpeedBaraban()
    {
        _leftBaraban.GetComponent<Baraban>().SetSpeed(_speed * 480);
        _rightBaraban.GetComponent<Baraban>().SetSpeed(_speed * 480);
        Debug.Log(_leftBaraban.GetComponent<Baraban>().GetSpeed());
    }

    //public void EmergancyShotDown()
    //{
    //    PowerSwitch();
    //    //_alarmLamp.GetComponent<AlarmLamp>().alarm();
        
    //}
    //private void OnTriggerEnter(Collider other)
    //{
    //    EmergancyShotDown();
    //    _conveyer.position = startpos;
    //}
    private void SendMessegeMQTT(string message)
    {
        gameObject.GetComponent<mqttReceiver>().messagePublish = message;
        gameObject.GetComponent<mqttReceiver>().Publish();
    }
    
    
    public void SpeedUp()
    {
        _speed += 0.1f;
        _matirealSpeed += 40f;
        _speedBar.GetComponent<PinchSlider>().SliderValue = _speed / 2 + 0.5f;
        //_speedBar.GetComponent<SliderSounds>().playTickSounds = true;
        SetSpeedBaraban();
    }
    public void SpeedDown()
    {
        _speed -= 0.1f;
        _matirealSpeed -= 40f;
        _speedBar.GetComponent<PinchSlider>().SliderValue = _speed / 2 + 0.5f;
        //_speedBar.GetComponent<SliderSounds>().playTickSounds = true;
        SetSpeedBaraban();
    }
    public void ReverseSpeed()
    {
        
        _speed = _speed * -1;
        _matirealSpeed = _matirealSpeed * -1;
        SpeedBar();
        SetSpeedBaraban();
        if (reverse)
        {
            SendMessegeMQTT("{\"Reverse\":\"1\"}");
        }
        else
        {
            SendMessegeMQTT("{\"Reverse\":\"0\"}");
        }
        reverse = !reverse;
    }
    public void ReverseOn()
    {
        if (!reverse)
        {
            ReverseSpeed();
        }
    }
    public void ReverseOff()
    {
        if (reverse)
        {
            ReverseSpeed();
        }
    }
    public void SetSpeed()
    {
        float speed;
        Debug.Log(objnum);
        speed = InputSpeedMenu.GetComponent<SpeedPanel>().ApplySpeed(objnum);
        HMISpeed = speed;
        string messagaSpeed=speed.ToString();
        messagaSpeed = string.Format("\"Speed\":\"{0}\"", messagaSpeed);
        messagaSpeed = "{" + messagaSpeed + "}";
        _speed = speed / 5000;
        SendMessegeMQTT(messagaSpeed);
        SetSpeedBaraban();
    }
    public void SetSpeed(float speed)
    {
        HMISpeed = speed;
        string messagaSpeed = speed.ToString();
        messagaSpeed = string.Format("\"Speed\":\"{0}\"", messagaSpeed);
        messagaSpeed = "{" + messagaSpeed + "}";
        _speed = speed / 5000;
        SendMessegeMQTT(messagaSpeed);
        SetSpeedBaraban();
    }
    public void GetMessage(string topic, int value)
    {
        switch (topic)
        {
            case "WS":
                if ((value == 1 && !_moveStatus)|| (value == 0 && _moveStatus)) 
                {
                    PowerSwitch();
                }
                break;
            case "Reverse":
                if ((value == 1 && _speed < 0) || (value == 0 && _speed > 0))
                {
                    ReverseSpeed();
                }
                break;

            case "speed":
                _speed = value;
                break;
        }
    }
}
