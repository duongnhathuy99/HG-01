using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TextLevel : MonoBehaviour
{
    TextMeshProUGUI text;
    PlayerCtrl playerCtrl;
    private void Awake()
    {
        text = GetComponent<TextMeshProUGUI>();
        playerCtrl = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerCtrl>();
    }
    private void FixedUpdate()
    {
        int level = playerCtrl.Player.Level + 1;
        text.SetText("Level " + level / 10 + level % 10);
    }
}
