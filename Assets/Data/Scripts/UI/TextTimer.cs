using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TextTimer : MonoBehaviour
{
    TextMeshProUGUI text;
    static public float timeGame = 0f;
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
        timeGame += Time.fixedDeltaTime;
        sencond = (int)timeGame % 60;
        minute = (int)timeGame / 60;
    }
}
