using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour, IHealth
{
    [SerializeField] protected int health;
    [SerializeField] protected int damage;
    EnemySO enemySO;
    private void Awake()
    {
        enemySO = transform.GetComponent<EnemyCtrl>().EnemySO;
    }
    private void OnEnable()
    {
        health = enemySO.heathMax;
        damage = enemySO.damage;
    }
    private void OnTriggerStay(Collider other)
    {
        Enemy enemy = other.GetComponent<Enemy>();
        if (enemy != null) return;
        IHealth health = other.GetComponent<IHealth>();
        if (health == null) return;

        health.TakeDamage(damage);
    }
    public void TakeDamage(int amount)
    {
        health -= amount;
        if (health > 0) return;
        EnemySpawner.Instance.Despawn(transform);
        Drop(enemySO.dropList, transform.position, transform.rotation);
    }
    public virtual List<ItemDropRate> Drop(List<ItemDropRate> dropList, Vector3 pos, Quaternion rot)
    {
        List<ItemDropRate> dropItems = new List<ItemDropRate>();
        if (dropList.Count < 1) return dropItems;

        dropItems = DropItems(dropList);
        foreach (ItemDropRate itemDropRate in dropItems)
        {
            ItemType itemType = itemDropRate.itemType;
            Transform itemDrop = ItemSpawner.Instance.Spawn(itemType.ToString(), pos, rot);
            if (itemDrop == null) continue;
            itemDrop.gameObject.SetActive(true);
        }
        return dropItems;
    }
    public virtual List<ItemDropRate> DropItems(List<ItemDropRate> items)
    {
        List<ItemDropRate> droppedItems = new List<ItemDropRate>();
        float rate, itemRate;
        int itemDropMore;
        foreach (ItemDropRate item in items)
        {
            rate = Random.Range(0, 1f);
            itemRate = item.dropRate / 100f ;
            itemDropMore = Mathf.FloorToInt(itemRate);
            if (itemDropMore > 0)
            {
                itemRate -= itemDropMore;
                for (int i = 0; i < itemDropMore; i++)
                {
                    droppedItems.Add(item);
                }
            }
            if (rate <= itemRate)
                droppedItems.Add(item);
        }
        return droppedItems;
    }

}
