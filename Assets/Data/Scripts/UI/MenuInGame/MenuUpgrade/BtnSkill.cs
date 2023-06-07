using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class BtnSkill : MonoBehaviour
{
    Button skillBtn;
    Image imageSkill;
    TextMeshProUGUI textName;
    TextMeshProUGUI textDetail;
    MenuSkillUpgrade skillsUpgrade;
    Skill skill;
    Player player;
    private void Awake()
    {
        skillBtn = transform.GetComponent<Button>();
        skillsUpgrade = transform.parent.GetComponent<MenuSkillUpgrade>();
        player =  GameObject.FindWithTag("Player").GetComponent<Player>();

        textName = transform.Find("NameSkill").GetComponent<TextMeshProUGUI>();
        textDetail = transform.Find("DetailSkill").GetComponent<TextMeshProUGUI>();
        imageSkill = transform.Find("ImageSkill").GetComponent<Image>();
    }
    private void OnEnable()
    {
        skill = skillsUpgrade.GetSkillRandom();
        imageSkill.sprite = skill.Sprite;
        textName.text = skill.Name + "\n" + "Level " + skill.Level;
        textDetail.text = skill.Detail;
    }
    private void Start()
    {
        skillBtn.onClick.AddListener(OnClick);
    }
    void OnClick()
    {
        if (skill.Level == 0) 
        {
            player.GetSkill(skill); 
            skill.GetSkill(); 
        }
        else
            skill.UpgradeSkill();
        Time.timeScale = 1;
        skillsUpgrade.gameObject.SetActive(false);
    }
}
