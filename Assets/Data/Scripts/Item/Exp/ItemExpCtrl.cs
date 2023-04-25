using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemExpCtrl : Item
{
    [SerializeField] protected ItemExpSO itemExpSO;
    public ItemExpSO ItemExpSO => itemExpSO;
}
