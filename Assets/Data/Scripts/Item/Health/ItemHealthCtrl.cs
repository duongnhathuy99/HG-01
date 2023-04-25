using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemHealthCtrl : Item
{
    [SerializeField] protected ItemHealthSO itemHealthSO;
    public ItemHealthSO ItemHealthSO => itemHealthSO;
}
