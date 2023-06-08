using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour, IHealth
{
    [SerializeField] protected int health;
    public int Health => health;
    [SerializeField] protected int exp = 0;
    public int Exp => exp;
    [SerializeField] protected int level = 0;
    public int Level => level;
    public List<Skill> skills;
    public List<ArtifactSO> artifacts;
    PlayerSO playerSO;
    PlayerCtrl playerCtrl;
    private void Awake()
    {
        playerCtrl = transform.GetComponent<PlayerCtrl>();
        playerSO = transform.GetComponent<PlayerCtrl>().PlayerSO;
        skills[0].UpgradeSkill();
    }
    private void OnEnable()
    {
        health = playerSO.heathMax;
    }
    private void OnTriggerEnter(Collider other)
    {
        //Debug.Log("va cham " + other.gameObject.name);
        IItem item = other.GetComponent<IItem>();
        if (item == null) return;

        item.PickItem(this);
        ItemSpawner.Instance.Despawn(other.transform);
    }
    public bool TakeDamage(float amount)
    {
        health -= (int)amount;
        if (health > 0) return true;
        Debug.Log("Game over");
        return true;
    }
    public void AddHealth(int amount)
    {
        health += amount;
        if (health > playerSO.heathMax) health = playerSO.heathMax;
    }
    public void AddExp(int amount)
    {
        if (level == playerSO.listLever.Count) return;
        exp += amount;
        playerCtrl.ExpBar.ExpChange(exp, playerSO.listLever[level]);
        if (exp < playerSO.listLever[level]) return;
        LevelUp();
    }
    protected void LevelUp()
    {
        level++;
        TextLevel.Instance.LevelChange(level + 1);
        playerCtrl.MenuUpgrade.GetComponent<MenuSkillUpgrade>().ShuffleSkills();
        playerCtrl.MenuUpgrade.gameObject.SetActive(true);
        Time.timeScale = 0;
        exp -= playerSO.listLever[level];
    }
    public void GetSkill(Skill skill)
    {
        skills.Add(skill);
        playerCtrl.PlayerAttack.LoadSkill();
    }
    public void GetArtifact(ArtifactSO artifact)
    {
        artifacts.Add(artifact);
        SkillManager.Instance.LoadAttributeArtifact(artifact);
    }
}
