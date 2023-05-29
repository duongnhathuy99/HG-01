using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
public class InfoSkill: MonoBehaviour
{

    [SerializeField] protected TextMeshProUGUI nameSkill;
    public TextMeshProUGUI NameSkill => nameSkill;

    [SerializeField] protected TextMeshProUGUI totalDamage;
    public TextMeshProUGUI TotalDamageSkill => totalDamage;
    private void Awake()
    {

        nameSkill = transform.Find("NameSkill").GetComponent<TextMeshProUGUI>();

        totalDamage = transform.Find("TotalDamageSkill").GetComponent<TextMeshProUGUI>();
    }
    public void ShowInfoSkill(Skill skill) 
    {
        nameSkill.text = skill.Name;
        totalDamage.text = "Total damage: "+skill.DamageInflicted.ToString();
    }
}
