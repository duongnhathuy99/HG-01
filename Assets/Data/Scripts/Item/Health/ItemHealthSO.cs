using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ItemHealth", menuName = "SO/Item/Health")]
public class ItemHealthSO : ScriptableObject
{
    public ItemType itemType = ItemType.Health;
    public int health = 50;
}

