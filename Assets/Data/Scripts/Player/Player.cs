using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour, IHealth
{
    [SerializeField] protected int health;
    [SerializeField] protected int exp = 0;
    [SerializeField] protected int lever = 0;
    PlayerSO playerSO;

    public void TakeDamage(int amount)
    {
        health -= amount;
        Debug.Log("mat mau ");
        if (health > 0) return;
        Debug.Log("Game over");
    }

    private void Awake()
    {
        playerSO = transform.GetComponent<PlayerCtrl>().PlayerSO;
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
    public void SetHealth(int amount)
    {
        health += amount;
        if (health > playerSO.heathMax) health = playerSO.heathMax;
    }
    public void SetExp(int amount)
    {
        if (lever == playerSO.listLever.Count) return;
        exp += amount;
        if (exp < playerSO.listLever[lever]) return;
        lever++;
        exp = 0;
    }
}
