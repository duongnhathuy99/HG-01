using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCtrl : MonoBehaviour
{
    [SerializeField] protected EnemySO enemySO;
    public EnemySO EnemySO => enemySO;
    public EnemyDropItem EnemyDropItem { get; private set; }
    public Rigidbody Rigidbody { get; private set; }
    public Animator Animator { get; private set; }
    public Enemy Enemy { get; private set; }

    private void Awake()
    {
        Rigidbody = GetComponent<Rigidbody>();
        EnemyDropItem = GetComponentInChildren<EnemyDropItem>();
        Animator = GetComponent<Animator>();
        Enemy = GetComponent<Enemy>();
    }
}
