using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class BtnSkill : MonoBehaviour
{
    Button fireballBtn;
    Transform menuUpgrade;
    [SerializeField] Image imageSkill;
    [SerializeField] TextMeshProUGUI textSkill;
    SkillsUpgrade skillsUpgrade;
    Skill skill;

    private void Awake()
    {
        fireballBtn = transform.GetComponent<Button>();
        menuUpgrade = transform.parent.GetComponent<Transform>();
        skillsUpgrade = menuUpgrade.GetComponent<SkillsUpgrade>();
    }
    private void OnEnable()
    {
        skill = skillsUpgrade.GetSkillRandom();
        imageSkill.sprite = skill.Sprite;
        textSkill.text = skill.Name + "\n" + "Level " + skill.Level;
    }
    private void Start()
    {
        fireballBtn.onClick.AddListener(OnClick);
    }
    void OnClick()
    {
        skill.UpgradeSkill();
        Time.timeScale = 1;
        menuUpgrade.gameObject.SetActive(false);
    }
}
