using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedPanel : MonoBehaviour
{
    [SerializeField] private TMPro.TextMeshProUGUI Text;
    [SerializeField] private TMPro.TextMeshProUGUI RangeValue;
    private string _speed { set; get; } = "";
    [SerializeField] private TMPro.TextMeshPro SpeedValue1;
    [SerializeField] private TMPro.TextMeshPro SpeedValue2;
    [SerializeField] private TMPro.TextMeshPro BunkerSpeed;
    private void UpdateText()
    {
        Text.text = _speed;
    }
    public void UpdateSpeed(string addSymbol)
    {
        _speed += addSymbol;
        UpdateText();
    }
    public void ResetSpeed()
    {
        _speed = "";
        UpdateText();
    }
    public float ApplySpeed(int objectNum)
    {
        float speed = float.Parse(_speed);
        UpdateSpeedValueTxt(_speed,objectNum);
        gameObject.SetActive(false);
        ResetSpeed();
        return speed;
    }
    public void InputValue(string ButtonValue)
    {
        UpdateSpeed(ButtonValue);
        
    }
    private void UpdateSpeedValueTxt(string text,int flag)
    {
        switch (flag)
        {
            case 1:
                SpeedValue1.text = text;
                Debug.Log("1");
                break;
            case 2:
                SpeedValue2.text = text;
                Debug.Log("2");
                break;
            case 3:
                BunkerSpeed.text = text;
                Debug.Log("3");
                break;
        }
        
    }
    public void SetRange(string text)
    {
        RangeValue.text = text;
    }
}
