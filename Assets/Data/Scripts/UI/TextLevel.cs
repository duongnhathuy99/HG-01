using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TextLevel : MonoBehaviour
{
    TextMeshProUGUI text;
    private static TextLevel _instance;
    public static TextLevel Instance { get => _instance; }
    private void Awake()
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
    public void LevelChange(int level)
    {
        text.SetText("Level " + level / 10 + level % 10);
    }
}
