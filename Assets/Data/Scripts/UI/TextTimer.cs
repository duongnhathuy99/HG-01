using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TextTimer : MonoBehaviour
{
    TextMeshProUGUI text;
    float timeStart = 0f;
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
        timeStart += Time.fixedDeltaTime;
        sencond = (int)timeStart % 60;
        minute = (int)timeStart / 60;
    }
}
