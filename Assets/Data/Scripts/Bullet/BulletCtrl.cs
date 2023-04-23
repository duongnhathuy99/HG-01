using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletCtrl : MonoBehaviour
{
    public BoxCollider BoxCollider { get; private set; }
    private void Awake()
    {
        BoxCollider = GetComponent<BoxCollider>();
    }
}
