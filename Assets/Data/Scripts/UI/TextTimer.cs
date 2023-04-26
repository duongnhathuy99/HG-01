using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TextTimer : MonoBehaviour
{
    TextMeshProUGUI text;
    int sencond;
    int minute;
    private void Awake()
    {
        text = GetComponent<TextMeshProUGUI>();
    }
    private void FixedUpdate()
    {
        CalculationTime();
        text.SetText((minute/10).ToString()+ (minute % 10).ToString() + " : "+ (sencond / 10).ToString() + (sencond % 10).ToString());
    }
    private void CalculationTime()
    {
        sencond = (int)Time.time % 60;
        minute = (int)Time.time / 60;
    }
}
