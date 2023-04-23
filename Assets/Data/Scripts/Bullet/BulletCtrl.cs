using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletCtrl : MonoBehaviour
{
    public BoxCollider BoxCollider { get; private set; }

    [SerializeField] protected BulletSO bulletSO;
    public BulletSO BulletSO => bulletSO;
    private void Awake()
    {
        BoxCollider = GetComponent<BoxCollider>();
    }
}
