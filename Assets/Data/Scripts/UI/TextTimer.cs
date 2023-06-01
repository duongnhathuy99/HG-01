using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TextTimer : MonoBehaviour
{
    TextMeshProUGUI text;
    public float TimeGame { get; private set; } = 0f;
    int sencond;
    int minute;

    private static TextTimer _instance;
    public static TextTimer Instance { get => _instance; }

    protected void Awake()
    {
        if (_instance != null)
        {
            Destroy(this.gameObject);
        }
        else
        {
            _instance = this;
        }
        text = GetComponent<TextMeshProUGUI>();
    }
    
    private void FixedUpdate()
    {
        CalculationTime();
        text.SetText((minute/10).ToString()+ (minute % 10).ToString() + " : "+ (sencond / 10).ToString() + (sencond % 10).ToString());
    }
    private void CalculationTime()
    {
        TimeGame += Time.fixedDeltaTime;
        sencond = (int)TimeGame % 60;
        minute = (int)TimeGame / 60;
    }
}
