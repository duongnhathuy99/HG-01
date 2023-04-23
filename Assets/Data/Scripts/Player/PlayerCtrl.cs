using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCtrl : MonoBehaviour
{
    [SerializeField] protected PlayerSO playerSO;
    public PlayerSO PlayerSO => playerSO;

    public PlayerAttack PlayerAttack { get; private set; }
    public PlayerMovement PlayerMovement { get; private set; }
    public SpawnPoins enemySpawnPoins { get; private set; }
    public Animator Animator { get; private set; }
    public Rigidbody Rigidbody { get; private set; }
    public BoxCollider BoxCollider { get; private set; }
    private void Awake()
    {
        PlayerAttack = GetComponentInChildren<PlayerAttack>();
        PlayerMovement = GetComponentInChildren<PlayerMovement>();
        enemySpawnPoins = GetComponentInChildren<SpawnPoins>();
        Animator = GetComponent<Animator>();
        Rigidbody = GetComponent<Rigidbody>();
        BoxCollider = GetComponent<BoxCollider>();
    }
}
