using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class InfoSkillSpawner : Spawner
{
    private static InfoSkillSpawner _instance;
    public static InfoSkillSpawner Instance { get => _instance; }

    public static string nomalItem = "InfoSkill";
    Player player;

    protected override void Awake()
    {
        base.Awake();
        if (_instance != null)
        {
            Destroy(this.gameObject);
        }
        else
        {
            _instance = this;
        }
    }
    private void OnEnable()
    {
        ShowInfoSkill();
    }
    protected override void LoadHolder()
    {
        holder = transform.Find("Scroll View").Find("Viewport").Find("Content");
        player = GameObject.FindWithTag("Player").GetComponent<Player>();
    }
    private void ClearItems()
    {
        foreach (Transform item in holder)
        {
            Despawn(item);
        }
    }
    private void SpawnItem(Skill skill)
    {
        Transform infoSkill = Spawn(nomalItem, Vector3.zero, Quaternion.identity);
        infoSkill.transform.localScale = new Vector3(1, 1, 1);

        InfoSkill info = infoSkill.GetComponent<InfoSkill>();
        info.ShowInfoSkill(skill);

        infoSkill.gameObject.SetActive(true);
    }
    private void ShowInfoSkill()
    {
        ClearItems();
        List<Skill> skills = player.skills;
        foreach (Skill skill in skills)
        {
            InfoSkillSpawner.Instance.SpawnItem(skill);
        }
    }
}
