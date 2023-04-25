using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemHealth : MonoBehaviour, IItem
{
    ItemHealthSO itemHealthSO;
    private void Awake()
    {
        itemHealthSO = transform.GetComponent<ItemHealthCtrl>().ItemHealthSO;
    }
    public void PickItem(Player player)
    {
        player.SetHealth(itemHealthSO.health); 
    }

}
