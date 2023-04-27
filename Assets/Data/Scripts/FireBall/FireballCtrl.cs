using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireballCtrl : MonoBehaviour
{
    public BoxCollider BoxCollider { get; private set; }

    [SerializeField] protected FireballSO bulletSO;
    public FireballSO FireballSO => bulletSO;
    private void Awake()
    {
        BoxCollider = GetComponent<BoxCollider>();
    }
}
