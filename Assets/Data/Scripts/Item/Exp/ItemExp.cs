using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemExp : MonoBehaviour, IItem
{
    ItemExpSO itemExpSO;
    private void Awake()
    {
        itemExpSO = transform.GetComponent<ItemExpCtrl>().ItemExpSO;
    }
    public void PickItem(Player player)
    {
        player.SetExp(itemExpSO.exp);
    }

}
