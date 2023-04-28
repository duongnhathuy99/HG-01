using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ExpBar : MonoBehaviour
{
    Slider slider;
    PlayerCtrl playerCtrl;
    int currentExp;
    int expNextLevel;
    int level;
    private void Awake()
    {
        slider = GetComponent<Slider>();
        playerCtrl = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerCtrl>();
    }
    private void Start()
    {
        slider.value = 0;
    }
    /* private void FixedUpdate()
     {
         CalculationExp();
     }
     private void CalculationExp()
     {
         currentExp = playerCtrl.Player.Exp;
         level = playerCtrl.Player.Level;
         expNextLevel = playerCtrl.PlayerSO.listLever[level];

         float percentExp = (float)currentExp / expNextLevel;
         slider.value = percentExp;
     }*/
    public void ExpChange(int currentExp ,int expNextLevel)
    {
        float percentExp = (float)currentExp / expNextLevel;
        slider.value = percentExp;
    }
}
