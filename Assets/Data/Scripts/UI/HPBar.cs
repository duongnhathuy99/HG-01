using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HPBar : MonoBehaviour
{
    Slider slider;
    PlayerCtrl playerCtrl;
    int currentHP;
    int HPMax;
    private void Awake()
    {
        slider = GetComponent<Slider>();
        playerCtrl = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerCtrl>();
    }
    private void FixedUpdate()
    {
        CalculationHP();
    }
    private void CalculationHP()
    {
        currentHP = playerCtrl.Player.Health;
        HPMax = playerCtrl.PlayerSO.heathMax;

        float percentHP = (float)currentHP / HPMax;
        slider.value = percentHP;
    }
}
